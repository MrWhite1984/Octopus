using OctoLib;
using OctoLib.DataTypes;
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
            switch (chunks[0])
            {
                case ("0"):
                    replyToClient = new Reply(ReplyType.Success, "Остановка сервера");
                    ConsoleWorker.octoServWork = false;
                    break;
                case ("1"):
                    replyToClient = new Reply(ReplyType.Information, Program.configuration.ToString());
                    break;
                case ("21"):
                    if (chunks.Count() < 2)
                        replyToClient = new Reply(ReplyType.Error, "Не указано название базы данных");
                    else
                        replyToClient = DataBaseHandler.CreateDB(chunks[1]);
                    break;
                case ("22"):
                    if (chunks.Count() < 2)
                        replyToClient = new Reply(ReplyType.Error, "Не указано название словаря");
                    else if(DataBaseHandler.usingDb == "")
                        replyToClient = new Reply(ReplyType.Error, "Рабочая база данных не задана");
                    else
                        replyToClient = DataBaseHandler.CreateDictionary(chunks[1]);
                    break;
                case "3":
                    if (chunks.Count() < 2)
                        replyToClient = new Reply(ReplyType.Error, "Не указано название базы данных");
                    else
                    {
                        string name = chunks[1];
                        if (!File.Exists(Path.Combine(Program.configuration.octopusFilesPath, name + ".octp")))
                            replyToClient = new Reply(ReplyType.Error, "Базы данных с таким именем не существует");
                        else
                        {
                            DataBaseHandler.usingDb = Path.Combine(Program.configuration.octopusFilesPath, name + ".octp");
                            replyToClient = new Reply(ReplyType.Success, $"Используется база данных {name}");
                        }
                    }
                    break;
                case "11":
                    if(chunks.Count() < 2)
                        replyToClient = new Reply(ReplyType.Error, "Не указан новый порт");
                    else
                    {
                        try
                        {
                            int newPort = Convert.ToInt32(chunks[2]);
                            if (newPort < 1111 || newPort > 9999)
                            {
                                replyToClient = new Reply(ReplyType.Error, "Неверный порт");
                                break;
                            }
                            Configuration configuration = Configuration.GetConfiguration();
                            configuration.port = newPort;
                            File.WriteAllText(Properties.Resources.OctoServConfigFileName, Configuration.SetConfiguration(configuration));
                            replyToClient = new Reply(ReplyType.Success, "Порт изменен\nДля работы новых настроек перезапутите сервер");
                        }
                        catch
                        {
                            replyToClient = new Reply(ReplyType.Error, "Ошибка изменения порта");
                            break;
                        }
                    }
                    break;
                case "12":
                    if (chunks.Count() < 2)
                        replyToClient = new Reply(ReplyType.Error, "Не указан новый путь");
                    else
                    {
                        if (!Directory.Exists(chunks[2]))
                        {
                            replyToClient = new Reply(ReplyType.Error, "Указанный путь не найден");
                            break;
                        }
                        Configuration configuration = Program.configuration;
                        configuration.octopusFilesPath = chunks[2];
                        File.WriteAllText(Properties.Resources.OctoServConfigFileName, Configuration.SetConfiguration(configuration));
                        replyToClient = new Reply(ReplyType.Success, "Путь изменен\nДля работы новых настроек перезапутите сервер");
                        break;
                    }
                    break;
                case "41":
                    if (chunks.Count() == 2)
                    {
                        replyToClient = new Reply(ReplyType.Error, Properties.Resources.InvalidRequestText);
                        break;
                    }
                    else
                    {
                        if (DataBaseHandler.usingDb == "")
                        {
                            replyToClient = new Reply(ReplyType.Error, "Рабочая база данных не задана");
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
                        replyToClient = new Reply(ReplyType.Error, "Рабочая база данных не задана");
                    else 
                        replyToClient = DataBaseHandler.GetAllDictionaryFromDB();
                    break;
                case "6":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() != 3)
                    {
                        replyToClient = new Reply(ReplyType.Error, "Ошибка запроса");
                        break;
                    }
                    var kvPair = chunks2[1].Split("--", StringSplitOptions.RemoveEmptyEntries);
                    if (kvPair.Count() != 2)
                    {
                        replyToClient = new Reply(ReplyType.Error, "Ошибка запроса");
                        break;
                    }
                    replyToClient = DataBaseHandler.AddDataToDictionary(kvPair[0], kvPair[1], chunks2[2]);
                    break;
                case "7":
                    if (chunks.Count() < 2)
                        replyToClient = new Reply(ReplyType.Error, Properties.Resources.InvalidRequestText);
                    else
                        replyToClient = DataBaseHandler.GetAllDataFromDictionary(chunks[1]);
                    break;
                case "711":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() < 3)
                        replyToClient = new Reply(ReplyType.Error, Properties.Resources.InvalidRequestText);
                    else
                        replyToClient = DataBaseHandler.GetDataFromDictionaryByKey(chunks[1], chunks2[2]);
                    break;
                case "712":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() < 3)
                        replyToClient = new Reply(ReplyType.Error, Properties.Resources.InvalidRequestText);
                    else
                        replyToClient = DataBaseHandler.GetDataFromDictionaryByPartOfKey(chunks[1], chunks2[2]);
                    break;
                case "721":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() < 3)
                        replyToClient = new Reply(ReplyType.Error, Properties.Resources.InvalidRequestText);
                    else
                        replyToClient = DataBaseHandler.GetDataFromDictionaryByValue(chunks[1], chunks2[2]);
                    break;
                case "722":
                    chunks2 = command.Split('\'', StringSplitOptions.RemoveEmptyEntries);
                    if (chunks2.Count() < 3)
                        replyToClient = new Reply(ReplyType.Error, Properties.Resources.InvalidRequestText);
                    else
                        replyToClient = DataBaseHandler.GetDataFromDictionaryByPartOfValue(chunks[1], chunks2[2]);
                    break;


                default:
                    replyToClient = new Reply(ReplyType.Error, Properties.Resources.UnknownCommandText);
                    break;

            }

            return replyToClient!;
        }
    }
}
