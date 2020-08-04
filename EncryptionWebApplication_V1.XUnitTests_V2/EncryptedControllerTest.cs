using EncryptionWebApplication_V1.Controllers;
using EncryptionWebApplication_V1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EncryptionWebApplication_V1.XUnitTests_V2
{
    public class EncryptControllerTest
    {
        [Fact]
        public void TextResponseTest()
        {
            // Arrange
            NonEncryptedText.Text = "РОТАЦИЯ";
            Key.Text = "КЛЮЧ";
            EncryptController decryptController = new EncryptController();

            // Act
            var result = decryptController.CreateResponse() as ContentResult;

            // Assert
            Assert.Equal("ыърчбфэ".ToUpper(), result?.Content);
        }

        [Fact]
        public void GettingNonEncryptedTextTest()
        {
            // Arrange
            string nonEncryptedText = "РОТАЦИЯ";
            string key = "КЛЮЧ";
            EncryptController decryptController = new EncryptController();

            // Act
            decryptController.GetText(nonEncryptedText, key);

            // Assert
            Assert.Equal("ыърчбфэ".ToUpper(), EncryptedText.Text);
        }

        [Fact]
        public void DownloadingNonEncryptedTextNotNullTest()
        {
            // Arrange
            string fileName = "ыърчбфэ";
            EncryptController decryptController = new EncryptController();

            // Act
            FileResult result = decryptController.DownloadText(fileName);


            // Assert
            Assert.NotNull(result);
        }
    }
}
