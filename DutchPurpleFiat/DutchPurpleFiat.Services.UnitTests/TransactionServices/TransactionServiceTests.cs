using DutchPurpleFiat.Data.Entities;
using DutchPurpleFiat.Data.Repositories.TransactionRepository;
using DutchPurpleFiat.Services.TransactionServices;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DutchPurpleFiat.Services.UnitTests.TransactionServices
{
    [TestFixture]
    public class TransactionServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ITransactionRepository> mockTransactionRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockTransactionRepository = this.mockRepository.Create<ITransactionRepository>();
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        private TransactionService CreateService()
        {
            return new TransactionService(
                this.mockTransactionRepository.Object);
        }

        [Test]
        public void RegisterTransaction_RepositoryMethodCalledonce()
        {
            // Arrange
            var service = this.CreateService();
            TransactionDto transaction = new TransactionDto();

            // Act
            service.RegisterTransaction(
                transaction);

            // Assert
            mockTransactionRepository.Verify(x => x.AddTransaction(It.IsAny<TransactionEntity>()), Times.Once);
        }

        [Test]
        public void GetTransactionsForCustomerId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = "someCustomerId";
            mockTransactionRepository.Setup(x => x.GetCusomerTransactions(customerId)).Returns(new List<TransactionEntity>() {
                new TransactionEntity()
                {
                    TransactionsDate = DateTime.Now.AddMonths(-5),
                    TransactionUid= "transactio1",
                    Ammount = 100,
                    CustomerId = customerId,

                },
                 new TransactionEntity()
                {
                      TransactionsDate = DateTime.Now.AddMonths(-4),
                      TransactionUid= "transactio2",
                    Ammount = 300,
                    CustomerId = customerId,

                },

            });
            // Act
            var result = service.GetTransactionsForCustomerId(
                customerId);

            // Assert
            result.Should().HaveCount(2);
        }
    }
}
