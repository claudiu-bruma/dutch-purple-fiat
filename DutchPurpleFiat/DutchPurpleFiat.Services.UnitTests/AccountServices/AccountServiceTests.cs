using DutchPurpleFiat.Data.Repositories.AccountRepository;
using DutchPurpleFiat.Services.AccountServices;
using DutchPurpleFiat.Services.CustomerServices;
using Moq;
using NUnit.Framework;
using FluentAssertions;
using System;
using DutchPurpleFiat.Data.Entities;
using System.Collections.Generic;

namespace DutchPurpleFiat.Services.UnitTests.AccountServices
{
    [TestFixture]
    public class AccountServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ICustomerService> mockCustomerService;
        private Mock<IAccountRepository> mockAccountRepository;
        private List<AccountEntity> accountEntityList;
        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockCustomerService = this.mockRepository.Create<ICustomerService>();
            this.mockAccountRepository = this.mockRepository.Create<IAccountRepository>();
            accountEntityList = new List<AccountEntity>();
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        private AccountService CreateService()
        {
            return new AccountService(
                this.mockCustomerService.Object,
                this.mockAccountRepository.Object);
        }

        [Test]
        public void OpenAccount_CustomerExists_AccountCreated()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = "customerTest1";
            mockCustomerService.Setup(x => x.CusomerExists(customerId)).Returns(true);
            mockAccountRepository.Setup(x => x.AddAccount(It.IsAny<AccountEntity>())).Callback<AccountEntity>(x => accountEntityList.Add(x));
            // Act
            var result = service.OpenAccount(
                customerId);

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            accountEntityList.Should().Contain(x => x.CustomerId == customerId);
        }


        [Test]
        public void GetCustomerIdOnAccount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string accountId = null;

            // Act

            Action act = () => service.GetCustomerIdOnAccount(
                accountId);
            // Assert
            act.Should().Throw<ArgumentException>();


        }
    }
}
