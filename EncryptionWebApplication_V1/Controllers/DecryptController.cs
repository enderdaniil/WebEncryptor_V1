using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EncryptionWebApplication_V1.Back;
using EncryptionWebApplication_V1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionWebApplication_V1.Controllers
{
    public class DecryptController : Controller
    {
        static DecryptController() { }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNonEncryptedFile(IFormFile uploadedFile, string key)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = Directory.GetCurrentDirectory() + "_" + uploadedFile.FileName;

                NonEncryptedText.CurrentFilePath = path;
                NonEncryptedText.CurrentFileDirectory = Directory.GetCurrentDirectory();

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    uploadedFile.CopyToAsync(fileStream);
                }

                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };

                string FileExtension = Path.GetExtension(file.Name);

                if (FileExtension == ".txt")
                {
                    using (TextReader tr = new StreamReader(path))
                    {
                        NonEncryptedText.Text = TxtReader.Read(path);
                    }
                    //EncryptedText.Text = TxtReader.Read(path);
                }
                else if (FileExtension == ".docx" || FileExtension == ".doc")
                {
                    using (TextReader tr = new StreamReader(path))
                    {
                        NonEncryptedText.Text = DocxReader.Read(path);
                    }
                }
                else
                {
                    Response.WriteAsync("<script>alert('This is wrong file format!!! Go to the previous page!!!');</script>");
                    return View("Decode");
                }
            }
            else
            {
                Response.WriteAsync("<script>alert('There is nothing in file input!!! Go to the previous page!!!');</script>");
                return View("Decode");
            }

            if (key != null || Key.CheckIfAlphabet(key))
            {
                Key.Text = key.ToUpper();
            }
            else
            {
                Response.WriteAsync("<script>alert('There is a wrong key!!! Go to the previous page!!!');</script>");
                return View("Decode");
            }

            return View("DecodeDownload");
        }

        [HttpPost]
        public async Task<IActionResult> AddEncryptedFile(IFormFile uploadedFile, string key)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = Directory.GetCurrentDirectory() + uploadedFile.FileName;

                EncryptedText.CurrentFilePath = path;
                EncryptedText.CurrentFileDirectory = Directory.GetCurrentDirectory();

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    uploadedFile.CopyToAsync(fileStream);
                }

                FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };

                string FileExtension = Path.GetExtension(file.Name);

                if (FileExtension == ".txt")
                {
                    using (TextReader tr = new StreamReader(path))
                    {
                        EncryptedText.Text = TxtReader.Read(path);
                    }
                    //EncryptedText.Text = TxtReader.Read(path);
                }
                else if (FileExtension == ".docx" || FileExtension == ".doc")
                {
                    using (TextReader tr = new StreamReader(path))
                    {
                        EncryptedText.Text = DocxReader.Read(path);
                    }
                }
                else
                {
                    Response.WriteAsync("<script>alert('This is wrong file format!!! Go to the previous page!!!');</script>");
                    return View("Decode");
                }
            }
            else
            {
                Response.WriteAsync("<script>alert('There is nothing in file input!!! Go to the previous page!!!');</script>");
                return View("Decode");
            }

            if (key != null || Key.CheckIfAlphabet(key))
            {
                Key.Text = key.ToUpper();
            }
            else
            {
                Response.WriteAsync("<script>alert('There is a wrong key!!! Go to the previous page!!!');</script>");
                return View("Decode");
            }

            return View("DecodeDownload");
        }

        public void GetNonEncrytedText(string text, string password)
        {
            VigenereCipher cipher = new VigenereCipher("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ");

            if (text != null && password != null)
            {
                var encryptedText = cipher.Decrypt(text.ToUpper(), password.ToUpper());
                NonEncryptedText.Text = encryptedText;
            }
            else if (text == null)
            {
                throw new NoTextException();
            }
            else if (password == null)
            {
                throw new NoPasswordException();
            }
            else
            {
                throw new Exception();
            }
        }

        [HttpGet]
        public FileResult DownloadNonEncryptedText(string fileName)
        {
            if (fileName == null || fileName == "")
            {
                Response.WriteAsync("<script>alert('You have not entered file name!!! Go to the previous page and enter!!!');</script>");
            }

            GetNonEncrytedText(EncryptedText.Text, Key.Text);

            string resultFileDirectory = NonEncryptedText.CurrentFileDirectory;

            string path = Path.Combine(resultFileDirectory, fileName + ".txt");

            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(NonEncryptedText.Text);
            }

            fileName += ".txt";

            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public FileResult DownloadEncryptedTextDOCX(string fileName)
        {
            if (fileName == null || fileName == "")
            {
                Response.WriteAsync("<script>alert('You have not entered file name!!! Go to the previous page and enter!!!');</script>");
            }

            GetNonEncrytedText(EncryptedText.Text, Key.Text);

            string resultFileDirectory = NonEncryptedText.CurrentFileDirectory;

            string path = Path.Combine(resultFileDirectory, fileName + ".docx");

            DocxCreater.CreateWordDocument(path, NonEncryptedText.Text);

            fileName += ".docx";

            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public IActionResult CreateResponse()
        {
            GetNonEncrytedText(EncryptedText.Text, Key.Text);

            return Content(NonEncryptedText.Text);
        }

        public class NoTextException : Exception
        {
            public override string Message => "Текста нет((";
        }
        public class NoPasswordException : Exception
        {
            public override string Message => "Пароля нет((";
        }
    }
}