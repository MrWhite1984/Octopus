using OctoLib;
using OctoLib.DataTypes;

namespace OctoServ
{
    class ConsoleWorker
    {
        public static bool octoServWork = false;
        static readonly string octopusFilesDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Octopus";

        public static void Work()
        {
            while (octoServWork)
            {
                Console.Write(">>");
                string command = Console.ReadLine();
                if(command != "")
                    HandleConsoleCommand(command);
            }
        }

        static void HandleConsoleCommand(string command)
        {
            var chunks = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Reply reply;
            List<string> chunksForUpdate;
            if(chunks.Count() == 1)
            {
                switch (command.ToUpper())
                {
                    case ("СТОП"):
                        octoServWork = false;
                        break;
                    case ("STOP"):
                        octoServWork = false;
                        break;

                    case ("КОНФИГ"):
                        TextFormatter.WriteLineYellow($"" +
                            $"Адрес: {Program.configuration.address}\n" +
                            $"Порт: {Program.configuration.port}\n" +
                            $"Расположение баз данных: {Program.configuration.octopusFilesPath}");
                        break;
                    case ("КОНФИГУРАЦИЯ"):
                        TextFormatter.WriteLineYellow($"" +
                            $"Адрес: {Program.configuration.address}\n" +
                            $"Порт: {Program.configuration.port}\n" +
                            $"Расположение баз данных: {Program.configuration.octopusFilesPath}");
                        break;
                    case ("CONFIG"):
                        TextFormatter.WriteLineYellow($"" +
                            $"Адрес: {Program.configuration.address}\n" +
                            $"Порт: {Program.configuration.port}\n" +
                            $"Расположение баз данных: {Program.configuration.octopusFilesPath}");
                        break;
                    case ("CONFIGURATION"):
                        TextFormatter.WriteLineYellow($"" +
                            $"Адрес: {Program.configuration.address}\n" +
                            $"Порт: {Program.configuration.port}\n" +
                            $"Расположение баз данных: {Program.configuration.octopusFilesPath}");
                        break;

                    case("ПЕРЕЗАПУСК"):
                        Program.Restart();
                        break;
                    case ("RESTART"):
                        Program.Restart();
                        break;

                    case ("DEVCOM"):
                        DataBaseHandler.GetDataFromDictionaryByPartOfValue("ие3", "аист1");
                        break;

                    default:
                        TextFormatter.WriteLineRed(Properties.Resources.UnknownCommandText);
                        break;
                }
            }
            else
            {
                switch (chunks[0].ToUpper())
                {
                    case ("СОЗДАТЬ"):
                        switch (chunks[1].ToUpper())
                        {
                            case ("БД"):
                                if (chunks.Count() <= 2)
                                    TextFormatter.WriteLineRed("Не указано название базы данных");
                                else
                                {
                                    reply = DataBaseHandler.CreateDB(chunks[2]);
                                    if(reply.replyType == ReplyType.Error)
                                        TextFormatter.WriteLineRed(reply.replyMessage!);
                                    else
                                        TextFormatter.WriteLineBlue(reply.replyMessage!);
                                }
                                break;
                            case ("БАЗУ"):
                                if(chunks[2].ToUpper() != "ДАННЫХ")
                                {
                                    TextFormatter.WriteLineRed(Properties.Resources.UnknownCommandText);
                                    break;
                                }
                                if (chunks.Count() <= 4)
                                    TextFormatter.WriteLineRed("Не указано название базы данных");
                                else
                                {
                                    reply = DataBaseHandler.CreateDB(chunks[3]);
                                    if (reply.replyType == ReplyType.Error)
                                        TextFormatter.WriteLineRed(reply.replyMessage!);
                                    else
                                        TextFormatter.WriteLineBlue(reply.replyMessage!);
                                }
                                break;

                            case ("СЛОВАРЬ"):
                                if (chunks.Count() <= 2)
                                {
                                    TextFormatter.WriteLineRed(Properties.Resources.InvalidRequestText);
                                    break;
                                }
                                if (DataBaseHandler.usingDb == "")
                                {
                                    TextFormatter.WriteLineRed("Рабочая база данных не задана");
                                    break;
                                }
                                reply = DataBaseHandler.CreateDictionary(chunks[2]);
                                if (reply.replyType == ReplyType.Error)
                                    TextFormatter.WriteLineRed(reply.replyMessage!);
                                else
                                    TextFormatter.WriteLineBlue(reply.replyMessage!);
                                break;


                            default:
                                TextFormatter.WriteLineRed(Properties.Resources.UnknownCommandText);
                                break;
                        }
                        break;

                    case ("CREATE"):
                        switch (chunks[1].ToUpper())
                        {
                            case ("DB"):
                                if (chunks.Count() <= 2)
                                    TextFormatter.WriteLineRed("Не указано название базы данных");
                                else
                                {
                                    reply = DataBaseHandler.CreateDB(chunks[2]);
                                    if (reply.replyType == ReplyType.Error)
                                        TextFormatter.WriteLineRed(reply.replyMessage!);
                                    else
                                        TextFormatter.WriteLineBlue(reply.replyMessage!);
                                }
                                break;
                            case ("DATABASE"):
                                if (chunks.Count() <= 2)
                                    TextFormatter.WriteLineRed("Не указано название базы данных");
                                else
                                {
                                    reply = DataBaseHandler.CreateDB(chunks[2]);
                                    if (reply.replyType == ReplyType.Error)
                                        TextFormatter.WriteLineRed(reply.replyMessage!);
                                    else
                                        TextFormatter.WriteLineBlue(reply.replyMessage!);
                                }
                                break;
                            default:
                                TextFormatter.WriteLineRed(Properties.Resources.UnknownCommandText);
                                break;
                        }
                        break;


                    case ("ИСПОЛЬЗОВАТЬ"):
                        string name = chunks[1];
                        if (!File.Exists(Path.Combine(octopusFilesDirectoryPath, name + ".octp")))
                        {
                            TextFormatter.WriteLineRed("Базы данных с таким именем не существует");
                            break;
                        }
                        DataBaseHandler.usingDb = Path.Combine(octopusFilesDirectoryPath, name + ".octp");
                        TextFormatter.WriteLineBlue($"Используется база данных {name}");
                        break;

                    case ("USE"):
                        string name2 = chunks[1];
                        if (!File.Exists(Path.Combine(octopusFilesDirectoryPath, name2 + ".octp")))
                        {
                            TextFormatter.WriteLineRed("Базы данных с таким именем не существует");
                            break;
                        }
                        DataBaseHandler.usingDb = Path.Combine(octopusFilesDirectoryPath, name2 + ".octp");
                        TextFormatter.WriteLineBlue($"Используется база данных {name2}");
                        break;


                    case ("ИЗМЕНИТЬ"):
                        switch (chunks[1].ToUpper())
                        {
                            case ("ПОРТ"):
                                if (chunks.Count() == 2)
                                {
                                    TextFormatter.WriteLineRed("Не указан новый порт");
                                    break;
                                }
                                try
                                {
                                    int newPort = Convert.ToInt32(chunks[2]);
                                    if (newPort < 1111 || newPort > 9999)
                                    {
                                        TextFormatter.WriteLineRed("Неверный порт");
                                        break;
                                    }
                                    Program.configuration.port = newPort;
                                    File.WriteAllText(Properties.Resources.OctoServConfigFileName, Configuration.SetConfiguration(Program.configuration));
                                    TextFormatter.WriteLineYellow("Порт изменен\nДля работы новых настроек перезапутите сервер");
                                }
                                catch (Exception ex)
                                {
                                    TextFormatter.WriteLineRed("Ошибка изменения порта\nПоказать подробности? д/н");
                                    var key = Console.ReadKey();
                                    if (key.KeyChar == 'д' || key.KeyChar == 'y')
                                    {
                                        TextFormatter.WriteLineRed('\n' + ex.Message);
                                    }
                                    else Console.WriteLine("");
                                }
                                break;

                            case ("ПУТЬ"):
                                if (chunks.Count() == 2)
                                {
                                    TextFormatter.WriteLineRed("Не указан новый путь к файлам");
                                    break;
                                }
                                if (!Directory.Exists(chunks[2]))
                                {
                                    TextFormatter.WriteLineRed("Указанный путь не найден");
                                    break;
                                }
                                Program.configuration.octopusFilesPath = chunks[2];
                                File.WriteAllText(Properties.Resources.OctoServConfigFileName, Configuration.SetConfiguration(Program.configuration));
                                TextFormatter.WriteLineYellow("Путь изменен\nДля работы новых настроек перезапутите сервер");
                                break;

                            case ("НАЗВАНИЕ"):
                                if (chunks.Count() == 2)
                                {
                                    TextFormatter.WriteLineRed(Properties.Resources.InvalidRequestText);
                                    break;
                                }
                                switch (chunks[2].ToUpper())
                                {
                                    case ("БД"):
                                        if (DataBaseHandler.usingDb == "")
                                        {
                                            TextFormatter.WriteLineRed("Рабочая база данных не задана");
                                            break;
                                        }
                                        reply = DataBaseHandler.RenameDB(chunks[3]);
                                        if (reply.replyType == ReplyType.Error)
                                        {
                                            TextFormatter.WriteLineRed(reply.replyMessage!);
                                            break;
                                        }
                                        TextFormatter.WriteLineBlue(reply.replyMessage!);
                                        break;

                                    case ("БАЗЫ"):
                                        if (chunks.Count() <= 4 || chunks[3].ToUpper() != "ДАННЫХ")
                                        {
                                            TextFormatter.WriteLineRed(Properties.Resources.InvalidRequestText);
                                            break;
                                        }
                                        if (DataBaseHandler.usingDb == "")
                                        {
                                            TextFormatter.WriteLineRed("Рабочая база данных не задана");
                                            break;
                                        }
                                        reply = DataBaseHandler.RenameDB(chunks[4]);
                                        if (reply.replyType == ReplyType.Error)
                                        {
                                            TextFormatter.WriteLineRed(reply.replyMessage!);
                                            break;
                                        }
                                        TextFormatter.WriteLineBlue(reply.replyMessage!);
                                        break;

                                    default:
                                        TextFormatter.WriteLineRed(Properties.Resources.UnknownCommandText);
                                        break;
                                }
                                break;
                        }
                        break;

                    case ("ПОЛУЧИТЬ"):
                        if(chunks.Count() <= 2)
                        {
                            TextFormatter.WriteLineRed(Properties.Resources.InvalidRequestText);
                            break;
                        }
                        switch (chunks[1].ToUpper())
                        {
                            case ("СПИСОК"):
                                switch (chunks[2].ToUpper())
                                {
                                    case ("БД"):
                                        reply = DataBaseHandler.GetAllDB();
                                        if (reply.replyType == ReplyType.Error)
                                            TextFormatter.WriteLineRed(reply.replyMessage!);
                                        else
                                            TextFormatter.WriteLineYellow(reply.replyMessage!);
                                        break;
                                    case ("БАЗ"):
                                        if(chunks.Count() <= 3 || chunks[3].ToUpper() != "ДАННЫХ")
                                        {
                                            TextFormatter.WriteLineRed(Properties.Resources.InvalidRequestText);
                                            break;
                                        }
                                        reply = DataBaseHandler.GetAllDB();
                                        if(reply.replyType == ReplyType.Error)
                                            TextFormatter.WriteLineRed(reply.replyMessage!); 
                                        else
                                            TextFormatter.WriteLineYellow(reply.replyMessage!);
                                        break;
                                    case ("СЛОВАРЕЙ"):
                                        if(DataBaseHandler.usingDb == "")
                                        {
                                            TextFormatter.WriteLineRed("Рабочая база данных не задана");
                                            break;
                                        }
                                        reply = DataBaseHandler.GetAllDictionaryFromDB();
                                        if (reply.replyType == ReplyType.Error)
                                            TextFormatter.WriteLineRed(reply.replyMessage!);
                                        else
                                            TextFormatter.WriteLineYellow(reply.replyMessage!);
                                        break;
                                }
                                break;

                        }
                        break;

                    case ("ЗАПИСАТЬ"):
                        switch (chunks[1].ToUpper())
                        {
                            case ("СВЯЗКУ"):
                                var chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                                if(chunks2.Count() != 3)
                                {
                                    TextFormatter.WriteLineRed("Ошибка запроса");
                                    break;
                                }
                                var kvPair = chunks2[1].Split("--", StringSplitOptions.RemoveEmptyEntries);
                                if(kvPair.Count() != 2)
                                {
                                    TextFormatter.WriteLineRed("Ошибка запроса");
                                    break;
                                }
                                var toTableChunks = chunks2[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                if(toTableChunks.Count() < 3 ||
                                    toTableChunks[0].ToUpper() != "В" ||
                                    toTableChunks[1].ToUpper() != "СЛОВАРЬ")
                                {
                                    TextFormatter.WriteLineRed("Ошибка запроса");
                                    break;
                                }
                                string dictName = toTableChunks[2];
                                reply = DataBaseHandler.AddDataToDictionary(kvPair[0], kvPair[1], dictName);
                                if (reply.replyType == ReplyType.Error)
                                    TextFormatter.WriteLineRed(reply.replyMessage!);
                                else
                                    TextFormatter.WriteLineBlue(reply.replyMessage!);
                                break;
                        }
                        break;
                    

                    default:
                        TextFormatter.WriteLineRed(Properties.Resources.UnknownCommandText);
                        break;
                }
            }
        }
    }
}
