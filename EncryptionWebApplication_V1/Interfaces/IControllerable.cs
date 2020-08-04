using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EncryptionWebApplication_V1.Interfaces
{
    interface IControllerable
    {
        [HttpPost]
        public IActionResult CreateResponse();

        [HttpPost]
        public IActionResult Index();

        [HttpPost]
        public Task<IActionResult> AddEncryptedFile(IFormFile uploadedFile, string key);

        [HttpPost]
        public Task<IActionResult> AddNonEncryptedFile(IFormFile uploadedFile, string key);

        public void GetText(string text, string password);

        [HttpGet]
        public FileResult DownloadTextDOCX(string fileName);

        [HttpGet]
        public FileResult DownloadText(string fileName);
    }
}
