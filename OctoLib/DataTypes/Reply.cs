using System.Collections.Generic;

namespace OctoLib
{
    public class Reply
    {
        public string replyType {  get; private set; }
        public string replyMessage { get; private set; } = null;
        public Dictionary<string, string> data { get; private set; } = null;
        public Reply(string replyType, string replyMessage, Dictionary<string, string> data)
        {
            this.replyType = replyType;
            this.replyMessage = replyMessage;
            this.data = data;
        }
        public Reply(string replyType, string replyMessage)
        {
            this.replyType = replyType;
            this.replyMessage = replyMessage;
        }
        public Reply(string replyType, Dictionary<string, string> data)
        {
            this.replyType = replyType;
            this.data = data;
        }
    }
}
