using System;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Security.Cryptography;
using Lab2.Services;

namespace XUnitTestProject1
{
    public class RSAManagerTests
    {
        private readonly ITestOutputHelper output;

        private RSAService RSAService { get; set; }

        public RSAManagerTests(ITestOutputHelper output)
        {
            this.output = output;

            RSAService = new RSAService();
        }

        [Fact]
        public void EncryptAndDecrypt()
        {
            string messageBefore = "hello";

            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(messageBefore);

            byte[] dataToDecrypt = RSAService.Encrypt(dataToEncrypt);

            byte[] data = RSAService.Decrypt(dataToDecrypt);

            string messageAfter = Encoding.UTF8.GetString(data);

            output.WriteLine(messageAfter);

            Assert.Equal(messageBefore, messageAfter);
        }
    }
}
