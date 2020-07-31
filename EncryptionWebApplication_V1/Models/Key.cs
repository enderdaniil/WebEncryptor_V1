using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptionWebApplication_V1.Models
{
    public static class Key
    {
        public static string Text { get; set; } = "";

        public static bool CheckIfAlphabet(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsLetter(s[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
