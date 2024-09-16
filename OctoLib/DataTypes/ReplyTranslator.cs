using OctoLib.DataTypes;
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
                return new Reply(ReplyType.Error, "Ошибка ответа");
            if (chunks[1][0] != '{')
                if (chunks.Length > 2 && message.Contains('{'))
                    return new Reply(ToReplyType(chunks[0]), chunks[1], ToDictionary(message));
                else
                    return new Reply(ToReplyType(chunks[0]), chunks[1]);
            else
                return new Reply(ToReplyType(chunks[0]), ToDictionary(message));
        }

        static ReplyType ToReplyType(string repTypeStr)
        {
            switch (repTypeStr)
            {
                case "Success":
                    return ReplyType.Success;
                case "Error":
                    return ReplyType.Error;
                case "Data":
                    return ReplyType.Data;
                case "Information":
                    return ReplyType.Information;
            }
            return ReplyType.Null;
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
            string replyString = ReplyTypeToString(reply.replyType)+'~';
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
        static string ReplyTypeToString(ReplyType replyType)
        {
            switch (replyType)
            {
                case ReplyType.Success:
                    return "Success";
                case ReplyType.Error:
                    return "Error";
                case ReplyType.Data:
                    return "Data";
                case ReplyType.Information:
                    return "Information";
            }
            return "Null";
        }
    }
}
