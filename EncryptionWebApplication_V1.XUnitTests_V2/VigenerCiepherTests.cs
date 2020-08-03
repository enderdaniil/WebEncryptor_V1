using System;
using Xunit;
using EncryptionWebApplication_V1;
using EncryptionWebApplication_V1.Back;

namespace EncryptionWebApplication_V1.XUnitTests_V2
{
    public class VigenerCiepherTests
    {
        [Fact]
        public void EncryptEmptinessTest()
        {
            // Arrange
            VigenereCipher cipher = new VigenereCipher();

            // Act - no test

            // Assert
            Assert.NotNull(cipher);
        }

        [Fact]
        public void EncryptRightnessTest()
        {
            // Arrange
            VigenereCipher cipher = new VigenereCipher("ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞß");


            // Act
            var result = cipher.Vigenere("ĞÎÒÀÖÈß", "ÊËŞ×", true);


            // Assert
            Assert.Equal("ûúğ÷áôı".ToUpper(), result);

        }

        [Fact]
        public void DecryptRightnessTest()
        {
            // Arrange
            VigenereCipher cipher = new VigenereCipher("ÀÁÂÃÄÅ¨ÆÇÈÉÊËÌÍÎÏĞÑÒÓÔÕÖ×ØÙÚÛÜİŞß");


            // Act
            var result = cipher.Vigenere("ûúğ÷áôı".ToUpper(), "ÊËŞ×", false);


            // Assert
            Assert.Equal("ĞÎÒÀÖÈß", result);

        }
    }
}
