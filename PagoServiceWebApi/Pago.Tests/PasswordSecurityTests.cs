using Services;
using System;
using Xunit;

namespace Pago.Tests
{
    public class PasswordSecurityTests
    {
        private readonly PasswordSecurity passwordSecurity = new();

        [Fact]
        public void CheckPassword_Is_The_Same_Password()
        {
            //Arrange
            string salt = "ipUKnnlbUQ+1zVoN9VA8vw==";

            string password = "6'("; //Nicolas en base64

            string hashedInDatabase = $"ZhlCs9+GIRdj8/F+FQ5lrg==";

            //Act
            bool isTrue = passwordSecurity.CheckPassword(salt, password, hashedInDatabase);

            //Assert
            Assert.True(isTrue);
        }
    }
}
