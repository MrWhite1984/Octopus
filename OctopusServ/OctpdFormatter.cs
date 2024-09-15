using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoServ
{
    class OctpdFormatter
    {
        public static string ToOctpd(Dictionary<string, string> dict)
        {
            string result = "";
            foreach (var kvp in dict)
            {
                result = result + kvp.Key + Convert.ToChar(166) + kvp.Value;
                if (!kvp.Equals(dict.Last()))
                    result += "|||";
            }
            return result;
        }

        public static Dictionary<string, string> ToDictionary(string input)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var chunks = input.Split("|||", StringSplitOptions.RemoveEmptyEntries);
            foreach (var chunk in chunks)
            {
                var partOfChunk = chunk.Split(Convert.ToChar(166), StringSplitOptions.RemoveEmptyEntries);
                dict.Add(partOfChunk[0], partOfChunk[1].TrimEnd('\n').TrimEnd('\r'));
            }
            return dict;
        }
    }
}
