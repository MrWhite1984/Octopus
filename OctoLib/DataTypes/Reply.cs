using OctoLib.DataTypes;
using System.Collections.Generic;

namespace OctoLib
{
    public class Reply
    {
        public ReplyType replyType {  get; private set; }
        public string replyMessage { get; private set; } = null;
        public Dictionary<string, string> data { get; private set; } = null;
        public Reply(ReplyType replyType, string replyMessage, Dictionary<string, string> data)
        {
            this.replyType = replyType;
            this.replyMessage = replyMessage;
            this.data = data;
        }
        public Reply(ReplyType replyType, string replyMessage)
        {
            this.replyType = replyType;
            this.replyMessage = replyMessage;
        }
        public Reply(ReplyType replyType, Dictionary<string, string> data)
        {
            this.replyType = replyType;
            this.data = data;
        }
    }
}
