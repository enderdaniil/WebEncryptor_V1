using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptionWebApplication_V1.Back
{
    public class VigenereCipher
    {
        const string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        readonly string letters;
        Dictionary<int, string> symbolswithindex = new Dictionary<int, string>();
        Dictionary<int, string> letterOfWords = new Dictionary<int, string>();

        public VigenereCipher(string alphabet = null)
        {
            letters = string.IsNullOrEmpty(alphabet) ? defaultAlphabet : alphabet;
        }

        private void Input(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (letters.Contains(text[i]))
                {
                    letterOfWords.Add(i, text[i].ToString());
                }
                else
                {
                    symbolswithindex.Add(i, text[i].ToString());
                }
            }
        }

        //генерация повторяющегося пароля
        private string GetRepeatKey(string s, int n)
        {
            var p = s;
            while (p.Length < n)
            {
                p += p;
            }

            return p;
        }

        private string Vigenere(string text, string password, bool encrypting = true)
        {
            Input(text);
            //var gamma = GetRepeatKey(password, text.Length);
            var retValue = "";
            var q = letters.Length;
            int keyword_index = 0;
            int c = 1;
            for (int i = 0; i < text.Length; i++)
            {
                var letterIndex = letters.IndexOf(text[i]);
                //
                if (letterIndex < 0)
                {
                    //если буква не найдена, добавляем её в исходном виде
                    string value = "";
                    symbolswithindex.TryGetValue(i, out value);
                    //retValue += text[i].ToString();
                    retValue += value;
                }
                else
                {
                    var codeIndex = letters.IndexOf(password[keyword_index]);
                    retValue += letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();

                    if ((keyword_index + 1) == password.Length)
                    {
                        keyword_index = -1;
                    }

                    keyword_index++;
                }
            }

            return retValue;
        }

        //шифрование текста
        public string Encrypt(string plainMessage, string password)
        => Vigenere(plainMessage, password);

        //дешифрование текста
        public string Decrypt(string encryptedMessage, string password)
        => Vigenere(encryptedMessage, password, false);
    }
}
