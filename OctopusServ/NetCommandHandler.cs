using OctoLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoServ
{
    class NetCommandHandler
    {
        public static Reply HandleCommand(string command)
        {
            var chunks = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] chunks2;
            Reply? replyToClient = null;
            Reply reply = null;
            switch (chunks[0])
            {
                case ("0"):
                    replyToClient = new Reply("sc", "Остановка сервера");
                    ConsoleWorker.octoServWork = false;
                    break;
                case ("1"):
                    replyToClient = new Reply("inf", Program.configuration.ToString());
                    break;
                case ("21"):
                    if (chunks.Count() < 2)
                        replyToClient = new Reply("er", "Не указано название базы данных");
                    else
                        replyToClient = DataBaseHandler.CreateDB(chunks[1]);
                    break;
                case ("22"):
                    if (chunks.Count() < 2)
                        replyToClient = new Reply("er", "Не указано название словаря");
                    else if(DataBaseHandler.usingDb == "")
                        replyToClient = new Reply("er", "Рабочая база данных не задана");
                    else
                        replyToClient = DataBaseHandler.CreateDictionary(chunks[1]);
                    break;
                case "3":
                    if (chunks.Count() < 2)
                        replyToClient = new Reply("er", "Не указано название базы данных");
                    else
                    {
                        string name = chunks[1];
                        if (!File.Exists(Path.Combine(Program.configuration.octopusFilesPath, name + ".octp")))
                            replyToClient = new Reply("er", "Базы данных с таким именем не существует");
                        else
                        {
                            DataBaseHandler.usingDb = Path.Combine(Program.configuration.octopusFilesPath, name + ".octp");
                            replyToClient = new Reply("sc", $"Используется база данных {name}");
                        }
                    }
                    break;
                case "11":
                    if(chunks.Count() < 2)
                        replyToClient = new Reply("er", "Не указан новый порт");
                    else
                    {
                        try
                        {
                            int newPort = Convert.ToInt32(chunks[2]);
                            if (newPort < 1111 || newPort > 9999)
                            {
                                replyToClient = new Reply("er", "Неверный порт");
                                break;
                            }
                            Program.configuration.port = newPort;
                            File.WriteAllText("OctoServConfig.json", Configuration.SetConfiguration(Program.configuration));
                            replyToClient = new Reply("sc", "Порт изменен\nДля работы новых настроек перезапутите сервер");
                        }
                        catch
                        {
                            replyToClient = new Reply("er", "Ошибка изменения порта");
                            break;
                        }
                    }
                    break;
                case "12":
                    if (chunks.Count() < 2)
                        replyToClient = new Reply("er", "Не указан новый порт");
                    else
                    {
                        if (!Directory.Exists(chunks[2]))
                        {
                            TextFormatter.WriteLineRed("Указанный путь не найден");
                            break;
                        }
                        Program.configuration.octopusFilesPath = chunks[2];
                        File.WriteAllText("OctoServConfig.json", Configuration.SetConfiguration(Program.configuration));
                        replyToClient = new Reply("sc", "Путь изменен\nДля работы новых настроек перезапутите сервер");
                        break;
                    }
                    break;
                case "41":
                    if (chunks.Count() == 2)
                    {
                        replyToClient = new Reply("ex", "Ошибочный запрос");
                        break;
                    }
                    else
                    {
                        if (DataBaseHandler.usingDb == "")
                        {
                            replyToClient = new Reply("er", "Рабочая база данных не задана");
                            break;
                        }
                        replyToClient = DataBaseHandler.RenameDB(chunks[1]);
                        break;
                    }
                case "51":
                    replyToClient = DataBaseHandler.GetAllDB();
                    break;
                case "52":
                    if(DataBaseHandler.usingDb == "")
                        replyToClient = new Reply("er", "Рабочая база данных не задана");
                    else 
                        replyToClient = DataBaseHandler.GetAllDictionaryFromDB();
                    break;
                case "6":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() != 3)
                    {
                        replyToClient = new Reply("er", "Ошибка запроса");
                        break;
                    }
                    var kvPair = chunks2[1].Split("--", StringSplitOptions.RemoveEmptyEntries);
                    if (kvPair.Count() != 2)
                    {
                        replyToClient = new Reply("er", "Ошибка запроса");
                        break;
                    }
                    replyToClient = DataBaseHandler.AddDataToDictionary(kvPair[0], kvPair[1], chunks2[2]);
                    break;
                case "7":
                    if (chunks.Count() < 2)
                        replyToClient = new Reply("ex", "Ошибочный запрос");
                    else
                        replyToClient = DataBaseHandler.GetAllDataFromDictionary(chunks[1]);
                    break;
                case "711":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() < 3)
                        replyToClient = new Reply("ex", "Ошибочный запрос");
                    else
                        replyToClient = DataBaseHandler.GetDataFromDictionaryByKey(chunks[1], chunks2[2]);
                    break;
                case "712":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() < 3)
                        replyToClient = new Reply("ex", "Ошибочный запрос");
                    else
                        replyToClient = DataBaseHandler.GetDataFromDictionaryByPartOfKey(chunks[1], chunks2[2]);
                    break;
                case "721":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() < 3)
                        replyToClient = new Reply("ex", "Ошибочный запрос");
                    else
                        replyToClient = DataBaseHandler.GetDataFromDictionaryByValue(chunks[1], chunks2[2]);
                    break;
                case "722":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() < 3)
                        replyToClient = new Reply("ex", "Ошибочный запрос");
                    else
                        replyToClient = DataBaseHandler.GetDataFromDictionaryByPartOfValue(chunks[1], chunks2[2]);
                    break;


                default:
                    replyToClient = new Reply("er", "Неизвестная команда");
                    break;

            }

            return replyToClient!;
        }
    }
}
