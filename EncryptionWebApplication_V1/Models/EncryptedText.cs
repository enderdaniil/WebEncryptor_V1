﻿using EncryptionWebApplication_V1.Back;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptionWebApplication_V1.Models
{
    public static class EncryptedText
    {
        public static string Text { get; set; } = "";

        public static string CurrentFilePath { get; set; } = "";

        public static string CurrentFileDirectory { get; set; } = "";


        //public static void GetEncrytedText(string text, string password)
        //{
        //    VigenereCipher cipher = new VigenereCipher("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");

        //    if (text != null && password != null)
        //    {
        //        var encryptedText = cipher.Encrypt(NonEncryptedText.Text, password.ToUpper());
        //        Text = encryptedText;
        //    }
        //    else if (text == null)
        //    {
        //        throw new NoTextException();
        //    }
        //    else if (password == null)
        //    {
        //        throw new NoPasswordException();
        //    }
        //    else
        //    {
        //        throw new Exception();
        //    }
        //}

        //public static void DownloadEncryptedText(string path)
        //{
        //    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
        //    {
        //        sw.WriteLine(Text);
        //    }
        //}

        //public class NoTextException : Exception
        //{
        //    public override string Message => "Текста нет((";
        //}
        //public class NoPasswordException : Exception
        //{
        //    public override string Message => "Пароля нет((";
        //}
    }
}
