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
            string reply = "";
            if (chunks[0].ToUpper() == "СТОП" ||
                chunks[0].ToUpper() == "STOP" ||
                chunks[0] == "0")
                reply = "0";
            else if (chunks[0].ToUpper() == "CONF" ||
                chunks[0].ToUpper() == "CONFIGURATION")
                reply = "1";
            else if (chunks[0].ToUpper() == "ИЗМЕНИТЬ"||
                chunks[0].ToUpper() == "CHANGE")
            {
                
            }
            else if (chunks[0].ToUpper() == "СОЗДАТЬ"||
                chunks[0].ToUpper() == "CREATE")
                if(chunks.Length >2 && (chunks[1].ToUpper() == "БД" ||
                    chunks[1].ToUpper() == "DB" ||
                    chunks[1].ToUpper() == "DATABASE"))
                {
                    reply = "21 ";
                    for(int i = 2; i<chunks.Length; i++)
                    {
                        reply += chunks[i];
                    }
                }
                else if (chunks.Length > 3 && chunks[1].ToUpper() == "БАЗУ" && chunks[2].ToUpper() == "ДАННЫХ")
                {
                    reply = "21 ";
                    for (int i = 2; i < chunks.Length; i++)
                    {
                        reply += chunks[i];
                    }
                }
                else if (chunks.Length > 2 &&
                    (chunks[1].ToUpper() == "СЛОВАРЬ" || chunks[1].ToUpper() == "DICTIONARY"))
                {
                    reply = "22 ";
                    for (int i = 2; i < chunks.Length; i++)
                    {
                        reply += chunks[i];
                    }
                }
                   

            return reply;
        }
    }
}
