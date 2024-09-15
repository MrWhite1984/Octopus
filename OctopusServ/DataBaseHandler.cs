using Microsoft.VisualBasic.FileIO;
using OctoLib;
using System.IO.Compression;
using System.Text;
using System.Xml.Linq;

namespace OctoServ
{
    class DataBaseHandler
    {
        public static string usingDb = "";

        public static string AssembleName(string[] chunks, int startPosition)
        {
            string name = "";
            for (int i = startPosition; i < chunks.Length; i++)
            {
                name += chunks[i];
                if (i < chunks.Length - 1)
                    name += " ";
            }
            return name;
        }

        public static Reply CreateDB(string name)
        {
            if (File.Exists(Path.Combine(Program.configuration.octopusFilesPath, name + ".octp")))
                return new Reply("er", "База данных с таким именем уже существует");
            else
            {
                string path = Path.Combine(Program.configuration.octopusFilesPath, name);
                Directory.CreateDirectory(path);
                ZipFile.CreateFromDirectory(path, path + ".octp");
                Directory.Delete(path);
                usingDb = path + ".octp";
                return new Reply("sc", $"База данных {name} создана");
            }
        }

        public static Reply RenameDB(string newName)
        {
            if (!File.Exists(Path.Combine(usingDb)))
                return new Reply("er", "База данных с таким именем не существует");
            if (File.Exists(Path.Combine(Program.configuration.octopusFilesPath, newName + ".octp")))
                return new Reply("er", "База данных с таким именем уже существует");
            string path = Path.Combine(Program.configuration.octopusFilesPath);
            FileSystem.RenameFile(usingDb, newName + ".octp");
            usingDb = path + newName + ".octp";
            return new Reply("sc", $"Имя успушно изменено на {newName}");
        }

        public static Reply CreateDictionary(string name)
        {
            if (!File.Exists(Path.Combine(usingDb)))
                return new Reply("er", "База данных с таким именем не существует");
            ZipArchive zipArchive = ZipFile.Open(usingDb, ZipArchiveMode.Update);
            if (zipArchive.GetEntry(name + ".octpd") != null)
            {
                zipArchive.Dispose();
                return new Reply("er", "Словарь с таким именем уже существует в базе");
            }
            zipArchive.CreateEntry(name + ".octpd");
            zipArchive.Dispose();
            return new Reply("sc", $"Словарь {name} создан");
        }

        public static Reply GetAllDB()
        {
            var names = Directory.GetFiles(Program.configuration.octopusFilesPath);
            if (names.Length == 0)
                return new Reply("er", "Базы данных не найдены");
            string namesList = "";
            foreach (string name in names)
            {
                if (name.Substring(name.Length-5) == ".octp")
                    namesList = namesList + name.Split('\\', StringSplitOptions.RemoveEmptyEntries).ToList().Last() + "\n";
            }
            return new Reply("sc", namesList);
        }

        public static Reply GetAllDictionaryFromDB()
        {
            if (!File.Exists(Path.Combine(usingDb)))
                return new Reply("er", "База данных с таким именем не существует");
            ZipArchive zipArchive = ZipFile.Open(usingDb, ZipArchiveMode.Read);
            var dictionaries = zipArchive.Entries;
            if (dictionaries.Count == 0)
                return new Reply("er", "База данных не содержит словарей");
            string namesList = "";
            foreach (var entry in dictionaries)
            {
                if (entry.Name.Substring(entry.Name.Length - 6) == ".octpd")
                    namesList = namesList + entry.Name.Split('\\', StringSplitOptions.RemoveEmptyEntries).ToList().Last() + "\n";
            }
            zipArchive.Dispose();
            return new Reply("sc", namesList);
        }

        public static Reply AddDataToDictionary(string key, string value, string dictionaryName)
        {
            Dictionary<string, string> dict;
            if (!File.Exists(Path.Combine(usingDb)))
                return new Reply("er", "База данных с таким именем не существует");
            ZipArchive zipArchive = ZipFile.Open(usingDb, ZipArchiveMode.Update);
            var archiveFile = zipArchive.GetEntry(dictionaryName + ".octpd");
            if (archiveFile == null)
            {
                zipArchive.Dispose();
                return new Reply("er", "Словарь с таким именем не существует");
            }
            var streamReader = new StreamReader(archiveFile.Open());
            dict = OctpdFormatter.ToDictionary(streamReader.ReadToEnd());
            streamReader.Close();
            try
            {
                dict.Add(key, value);
            }
            catch (Exception ex)
            {
                if (ex.Message.Split('.', StringSplitOptions.RemoveEmptyEntries)[0] == "An item with the same key has already been added")
                {
                    zipArchive.Dispose();
                    return new Reply("er", $"Ключ {key} уже существует в словаре");
                }
            }
            var streamWriter = new StreamWriter(archiveFile.Open());
            streamWriter.Write(OctpdFormatter.ToOctpd(dict));
            streamWriter.Close();
            zipArchive.Dispose();
            return new Reply("sc", "Запись добавлена");
        }
        public static Reply GetAllDataFromDictionary(string dictionaryName)
        {
            Dictionary<string, string> dict;
            if (!File.Exists(Path.Combine(usingDb)))
                return new Reply("er", "База данных с таким именем не существует");
            ZipArchive zipArchive = ZipFile.Open(usingDb, ZipArchiveMode.Update);
            var archiveFile = zipArchive.GetEntry(dictionaryName + ".octpd");
            if (archiveFile == null)
            {
                zipArchive.Dispose();
                return new Reply("er", "Словарь с таким именем не существует");
            }
            var streamReader = new StreamReader(archiveFile.Open());
            dict = OctpdFormatter.ToDictionary(streamReader.ReadToEnd());
            streamReader.Close();
            zipArchive.Dispose();
            return new Reply("dt", dict);
        }

        public static Reply GetDataFromDictionaryByKey(string key, string dictionaryName)
        {
            Dictionary<string, string> dict;
            if (!File.Exists(Path.Combine(usingDb)))
                return new Reply("er", "База данных с таким именем не существует");
            ZipArchive zipArchive = ZipFile.Open(usingDb, ZipArchiveMode.Update);
            var archiveFile = zipArchive.GetEntry(dictionaryName + ".octpd");
            if (archiveFile == null)
            {
                zipArchive.Dispose();
                return new Reply("er", "Словарь с таким именем не существует");
            }
            var streamReader = new StreamReader(archiveFile.Open());
            dict = OctpdFormatter.ToDictionary(streamReader.ReadToEnd()).Where(o => o.Key == key).ToDictionary();
            streamReader.Close();
            zipArchive.Dispose();
            return new Reply("dt", dict);
        }

        public static Reply GetDataFromDictionaryByPartOfKey(string partOfKey, string dictionaryName)
        {
            Dictionary<string, string> dict;
            if (!File.Exists(Path.Combine(usingDb)))
                return new Reply("er", "База данных с таким именем не существует");
            ZipArchive zipArchive = ZipFile.Open(usingDb, ZipArchiveMode.Update);
            var archiveFile = zipArchive.GetEntry(dictionaryName + ".octpd");
            if (archiveFile == null)
            {
                zipArchive.Dispose();
                return new Reply("er", "Словарь с таким именем не существует");
            }
            var streamReader = new StreamReader(archiveFile.Open());
            dict = OctpdFormatter.ToDictionary(streamReader.ReadToEnd()).Where(o => o.Key.Contains(partOfKey)).ToDictionary();
            streamReader.Close();
            zipArchive.Dispose();
            return new Reply("dt", dict);
        }

        public static Reply GetDataFromDictionaryByValue(string value, string dictionaryName)
        {
            Dictionary<string, string> dict;
            if (!File.Exists(Path.Combine(usingDb)))
                return new Reply("er", "База данных с таким именем не существует");
            ZipArchive zipArchive = ZipFile.Open(usingDb, ZipArchiveMode.Update);
            var archiveFile = zipArchive.GetEntry(dictionaryName + ".octpd");
            if (archiveFile == null)
            {
                zipArchive.Dispose();
                return new Reply("er", "Словарь с таким именем не существует");
            }
            var streamReader = new StreamReader(archiveFile.Open());
            dict = OctpdFormatter.ToDictionary(streamReader.ReadToEnd()).Where(o => o.Value == value).ToDictionary();
            streamReader.Close();
            zipArchive.Dispose();
            return new Reply("dt", dict);
        }

        public static Reply GetDataFromDictionaryByPartOfValue(string partOfValue, string dictionaryName)
        {
            Dictionary<string, string> dict;
            if (!File.Exists(Path.Combine(usingDb)))
                return new Reply("er", "База данных с таким именем не существует");
            ZipArchive zipArchive = ZipFile.Open(usingDb, ZipArchiveMode.Update);
            var archiveFile = zipArchive.GetEntry(dictionaryName + ".octpd");
            if (archiveFile == null)
            {
                zipArchive.Dispose();
                return new Reply("er", "Словарь с таким именем не существует");
            }
            var streamReader = new StreamReader(archiveFile.Open());
            dict = OctpdFormatter.ToDictionary(streamReader.ReadToEnd()).Where(o => o.Value.Contains(partOfValue)).ToDictionary();
            streamReader.Close();
            zipArchive.Dispose();
            return new Reply("dt", dict);
        }

    }
}
