using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octopus
{
    class TextHandler
    {
        public static string FormatToTextBox(string text)
        {
            var chunks = text.Split('\n');
            string newText = "";
            for(int i = 0; i < chunks.Count(); i++)
            {
                newText += chunks[i];
                if(i < chunks.Count() - 1)
                {
                    newText += "\r\n";
                }
            }
            return newText;
        }
    }
}
