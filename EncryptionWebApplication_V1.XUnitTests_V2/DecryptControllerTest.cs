using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using EncryptionWebApplication_V1;
using EncryptionWebApplication_V1.Controllers;
using EncryptionWebApplication_V1.Back;
using EncryptionWebApplication_V1.Models;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionWebApplication_V1.XUnitTests_V2
{
    public class DecryptControllerTest
    {
        [Fact]
        public void TextResponseTest()
        {
            // Arrange
            EncryptedText.Text = "ыърчбфэ".ToUpper();
            Key.Text = "КЛЮЧ";
            DecryptController decryptController = new DecryptController();

            // Act
            var result = decryptController.CreateResponse() as ContentResult;


            // Assert
            Assert.Equal("РОТАЦИЯ", result?.Content);
        }

        [Fact]
        public void GettingNonEncryptedTextTest()
        {
            // Arrange
            string encryptedText = "ыърчбфэ".ToUpper();
            string key = "КЛЮЧ";
            DecryptController decryptController = new DecryptController();

            // Act
            decryptController.GetText(encryptedText, key);


            // Assert
            Assert.Equal("РОТАЦИЯ", NonEncryptedText.Text);
        }

        //[Fact]
        //public void DownloadingNonEncryptedTextNotNullTest()
        //{
        //    // Arrange
        //    string fileName = "ыърчбфэ";
        //    DecryptController decryptController = new DecryptController();

        //    // Act
        //    FileResult result = decryptController.DownloadNonEncryptedText(fileName);


        //    // Assert
        //    Assert.NotNull(result);
        //}


    }
}
