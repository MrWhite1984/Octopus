using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoLib
{
    public class ReplyTranslator
    {
        public static Reply StringToReply(string message)
        {
            var chunks = message.Split('~');
            if(chunks.Length < 2 )
                return new Reply("er", "Ошибка ответа");
            if (chunks[1][0] != '{')
                if (chunks.Length > 2 && message.Contains('{'))
                    return new Reply(chunks[0], chunks[1], ToDictionary(message));
                else
                    return new Reply(chunks[0], chunks[1]);
            else
                return new Reply(chunks[0], ToDictionary(message));
        }

        static Dictionary<string, string> ToDictionary(string message)
        {
            message = message.Split('{')[1];
            message = message.TrimStart('{');
            message = message.TrimEnd('}');
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var chunks = message.Split('\n');
            foreach(var chunk in chunks)
            {
                var chunks2 = chunk.Split(Convert.ToChar(166));
                dict.Add(chunks2[0], chunks2[1]);
            }
            return dict;
        }

        public static string ReplyToString(Reply reply)
        {
            string replyString = reply.replyType+'~';
            if(reply.replyMessage != null)
                replyString += (reply.replyMessage + "~");
            if(reply.data != null)
            {
                replyString += "{";
                replyString += ToString(reply.data);
                replyString += "}";
            }
            return replyString;
        }
        static string ToString(Dictionary<string, string> dict)
        {
            string dictString = "";
            foreach(var kvp in dict)
            {
                dictString = dictString + kvp.Key + Convert.ToChar(166) + kvp.Value;
                if(dict.Last().Key != kvp.Key)
                {
                    dictString += "\n";
                }
            }
            return dictString;
        }
    }
}
