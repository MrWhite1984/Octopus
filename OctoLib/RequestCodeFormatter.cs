using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoLib
{
    public class RequestCodeFormatter
    {
        public static string FormatRequest(string request)
        {
            var chunks = request.Split(' ');
            List<string> chunksUpperCase = new List<string>();
            foreach (var chunk in chunks)
            {
                chunksUpperCase.Add(chunk.ToUpper());
            }
            string reply = "";
            if (chunksUpperCase[0] == "СТОП" ||
                chunksUpperCase[0] == "STOP" ||
                chunksUpperCase[0] == "0")
                reply = "0";
            else if (chunksUpperCase[0] == "CONF" ||
                chunksUpperCase[0] == "CONFIGURATION")
                reply = "1";
            else if (chunksUpperCase[0] == "ИЗМЕНИТЬ" ||
                chunksUpperCase[0] == "CHANGE")
            {

            }
            else if (chunksUpperCase[0] == "СОЗДАТЬ" ||
                chunksUpperCase[0] == "CREATE")
                if (chunks.Length > 2 && (chunksUpperCase[1] == "БД" ||
                    chunksUpperCase[1] == "DB" ||
                    chunksUpperCase[1] == "DATABASE"))
                {
                    reply = "21 ";
                    for (int i = 2; i < chunks.Length; i++)
                    {
                        reply += chunks[i];
                    }
                }
                else if (chunks.Length > 3 && chunksUpperCase[1] == "БАЗУ" && chunksUpperCase[1] == "ДАННЫХ")
                {
                    reply = "21 ";
                    for (int i = 2; i < chunks.Length; i++)
                    {
                        reply += chunks[i];
                    }
                }
                else if (chunks.Length > 2 &&
                    (chunksUpperCase[1] == "СЛОВАРЬ" || chunksUpperCase[1] == "DICTIONARY"))
                {
                    reply = "22 ";
                    for (int i = 2; i < chunks.Length; i++)
                    {
                        reply += chunks[i];
                    }
                }
                else
                {

                }
            else if (chunksUpperCase[0] == "ПОЛУЧИТЬ" ||
                        chunksUpperCase[0] == "GET" ||
                        chunksUpperCase[0] == "SELECT")
                    if (chunks.Length > 2 && (chunksUpperCase[1] == "СПИСОК" ||
                        chunksUpperCase[1] == "LIST"))
                    {
                        if (chunksUpperCase[2] == "БД" ||
                            (chunks.Length > 3 && chunksUpperCase[2] == "БАЗ" && chunksUpperCase[3] == "ДАННЫХ") ||
                            chunksUpperCase[2] == "DB" ||
                            chunksUpperCase[2] == "DATABASE")
                            reply = "51";
                    }  
                    else if (chunks.Length > 3 && (chunks[1].ToUpper() == "ВСЕ"||
                        chunks[1].ToUpper() == "*"||
                        chunks[1].ToUpper() == "ALL") && 
                        (chunks[2].ToUpper() == "FROM" ||
                        chunks[2].ToUpper() == "ИЗ"))
                    {
                        if (chunksUpperCase.Contains("ГДЕ"))
                        {
                            
                        }
                        else
                        {
                            reply = $"7 {chunks[3]}";
                        }
                    }

                   

            return reply;
        }
    }
}
