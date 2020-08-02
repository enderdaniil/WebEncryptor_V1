using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EncryptionWebApplication_V1.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EncryptionWebApplication_V1.Back;


namespace EncryptionWebApplication_V1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        [HttpGet]
        public IActionResult Encode()
        {
            return View("Encode");
        }

        [HttpGet]
        public IActionResult Decode()
        {
            return View("Decode");
        }

        //[HttpGet]
        //private IActionResult EncodeDownload()
        //{
        //    return View("EncodeDownload");
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddEncryptedFile(IFormFile uploadedFile, string key)
        //{
        //    if (uploadedFile != null)
        //    {
        //        // путь к папке Files
        //        string path = Directory.GetCurrentDirectory() + uploadedFile.FileName;

        //        // сохраняем файл в папку Files в каталоге wwwroot
        //        using (var fileStream = new FileStream(path, FileMode.Create))
        //        {
        //            uploadedFile.CopyToAsync(fileStream);
        //        }

        //        FileModel file = new FileModel { Name = uploadedFile.FileName, Path = path };

        //        string FileExtension = Path.GetExtension(file.Name);

        //        if (FileExtension == ".txt")
        //        {
        //            using(TextReader tr = new StreamReader(path))
        //            {
        //                NonEncryptedText.Text = TxtReader.Read(path);
        //            }
        //            //EncryptedText.Text = TxtReader.Read(path);
        //        }
        //        else if (FileExtension == ".docx" || FileExtension == ".doc")
        //        {
        //            using (TextReader tr = new StreamReader(path))
        //            {
        //                NonEncryptedText.Text = DocxReader.Read(path);
        //            }
        //        }
        //        else 
        //        {
        //            Response.WriteAsync("<script>alert('This is wrong file format!!! Go to the previous page!!!');</script>");
        //            return View("Encode");
        //        }
        //    }
        //    else
        //    {
        //        Response.WriteAsync("<script>alert('There is nothing in file input!!! Go to the previous page!!!');</script>");
        //        return View("Encode");
        //    }

        //    if (key != null || Key.CheckIfAlphabet(key))
        //    {
        //        Key.Text = key.ToUpper();
        //    }
        //    else
        //    {
        //        Response.WriteAsync("<script>alert('There is a wrong key!!! Go to the previous page!!!');</script>");
        //        return View("Encode");
        //    }

        //    return View("EncodeDownload");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
