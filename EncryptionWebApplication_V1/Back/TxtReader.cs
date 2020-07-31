using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptionWebApplication_V1.Back
{
    public static class TxtReader
    {
        public static string Read(string path)
        {
            string returnText = "";

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    returnText += line;
                    returnText += "\n";
                }
            }

            return returnText;
        }
    }
}
