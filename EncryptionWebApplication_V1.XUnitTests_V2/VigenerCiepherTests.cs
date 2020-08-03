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
            VigenereCipher cipher = new VigenereCipher("�����Ũ��������������������������");


            // Act
            var result = cipher.Vigenere("�������", "����", true);


            // Assert
            Assert.Equal("�������".ToUpper(), result);

        }

        [Fact]
        public void DecryptRightnessTest()
        {
            // Arrange
            VigenereCipher cipher = new VigenereCipher("�����Ũ��������������������������");


            // Act
            var result = cipher.Vigenere("�������".ToUpper(), "����", false);


            // Assert
            Assert.Equal("�������", result);

        }
    }
}
