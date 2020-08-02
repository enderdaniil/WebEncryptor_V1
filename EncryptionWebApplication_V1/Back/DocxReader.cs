using EncryptionWebApplication_V1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EncryptionWebApplication_V1.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace EncryptionWebApplication_V1.Back
{
    public static class DocxReader
    {
        public static string Read(string path)
        {
            return OpenWordprocessingDocumentReadonly(path);
        }

        private static string OpenWordprocessingDocumentReadonly(string filepath)
        {
            // Open a WordprocessingDocument based on a filepath.
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filepath, false))
            {
                // Assign a reference to the existing document body.  
                Body body = wordDocument.MainDocumentPart.Document.Body;
                //text of Docx file 
                return body.InnerText.ToString();
            }

            return "-1";
        }
    }
}
