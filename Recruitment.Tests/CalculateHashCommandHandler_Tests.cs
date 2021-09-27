using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Recruitment.DomainLogic;
using Recruitment.Contracts;
using System;
using System.Threading.Tasks;
using System.Threading;
using Recruitment.CommandHandlers;

namespace Recruitment.Tests
{
    [TestClass]
    public class CalculateHashCommandHandler_Tests
    {
        private Mock<IEncryptor> _mockEncryptor;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockEncryptor = new Mock<IEncryptor>();
        }

        [DataTestMethod]
        [DataRow("message", "digest", "messagedigest")]
        public async Task CalculateHashCommandHandler_Returns_Valid_Hash(string login, string password, string expected)
        {
            var source = $"{login}{password}";
            _mockEncryptor.Setup(x => x.Encrypt(source)).Returns(expected);
            var cmd = new CalculateHashCommand { Login = login, Password = password };
            var handler = new CalculateHashCommandHandler(_mockEncryptor.Object);

            var result = await handler.HandleAsync(cmd, It.IsAny<CancellationToken>());

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public async Task CalculateHashCommandHandler_Throws_ArgumentNullException()
        {
            var handler = new CalculateHashCommandHandler(_mockEncryptor.Object);

            await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                async () => await handler.HandleAsync(It.IsAny<CalculateHashCommand>(), It.IsAny<CancellationToken>()));
        }

        [TestMethod]
        public async Task CalculateHashCommandHandler_Encrypt_Called_Once()
        {
            var handler = new CalculateHashCommandHandler(_mockEncryptor.Object);

            await handler.HandleAsync(new CalculateHashCommand(), It.IsAny<CancellationToken>());

            _mockEncryptor.Verify(x => x.Encrypt(string.Empty), Times.Once);
        }
    }
}