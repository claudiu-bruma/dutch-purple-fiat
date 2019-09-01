using DutchPurpleFiat.Data.Repositories.CustomerRepository;
using DutchPurpleFiat.Services.CustomerServices;
using DutchPurpleFiat.Services.TransactionServices;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DutchPurpleFiat.Services.UnitTests.CustomerServices
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ICustomerRepository> mockCustomerRepository;
        private Mock<ITransactionService> mockTransactionService;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Loose);

            this.mockCustomerRepository = this.mockRepository.Create<ICustomerRepository>();
            this.mockTransactionService = this.mockRepository.Create<ITransactionService>();
        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        private CustomerService CreateService()
        {
            return new CustomerService(
                this.mockCustomerRepository.Object,
                this.mockTransactionService.Object);
        }

        [Test]
        public void CusomerExists_calledWithNullParameter_ThrowException()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = null;



            // Act
            Action act = () => service.CusomerExists(
                customerId);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void CusomerExists_CustomerIdDoesNotExists_returnFalse()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = "inexistentCustomer";
            mockCustomerRepository.Setup(x => x.CustomerExists(customerId)).Returns(false);


            // Act
           var result = service.CusomerExists(
                customerId);

            // Assert
            result.Should().BeFalse();
        }
        [Test]
        public void CusomerExists_CustomerIdDoesExists_returnTrue()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = "existentCustomer";
            mockCustomerRepository.Setup(x => x.CustomerExists(customerId)).Returns(true);


            // Act
            var result = service.CusomerExists(
                 customerId);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void GetCustomer_calledWithNullParameter_ThrowException()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = null;



            // Act
            Action act = () => service.GetCustomer(
                customerId);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void GetCustomer_CustomerExistsWithNotTransactions_NoTransactionsAreReturned()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = "existentCustomer";
            mockCustomerRepository.Setup(x => x.GetCustomerByUId(customerId)).Returns(new Data.Entities.CustomerEntity() {FirstName ="bla", LastName = "crocobaur", CustomerUId = customerId });
            mockTransactionService.Setup(x => x.GetTransactionsForCustomerId(customerId)).Returns(new List<TransactionDto>());
            // Act
            var result = service.GetCustomer(
                customerId);

            // Assert
            result.Transactions.Should().BeEmpty();
            result.Balance.Should().Be(0);
             
        }
        [Test]
        public void GetCustomer_CustomerExistsWithNotTransactions_NamesMatch()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = "existentCustomer";
            mockCustomerRepository.Setup(x => x.GetCustomerByUId(customerId)).Returns(new Data.Entities.CustomerEntity() { FirstName = "bla", LastName = "crocobaur", CustomerUId = customerId });
            mockTransactionService.Setup(x => x.GetTransactionsForCustomerId(customerId)).Returns(new List<TransactionDto>());
            // Act
            var result = service.GetCustomer(
                customerId);

            // Assert
 
            result.FirstName.Should().Be("bla");
            result.LastName.Should().Be("crocobaur");
        }
        [Test]
        public void GetCustomer_CustomerExistsWithTransactions_BalanceMatches()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = "existentCustomer";
            mockCustomerRepository.Setup(x => x.GetCustomerByUId(customerId)).Returns(new Data.Entities.CustomerEntity() { FirstName = "bla", LastName = "crocobaur", CustomerUId = customerId });
            mockTransactionService.Setup(x => x.GetTransactionsForCustomerId(customerId)).Returns(new List<TransactionDto>() {
                new TransactionDto()
                {
                    Amount = 100,
                    CustomerId = customerId,

                },
                 new TransactionDto()
                {
                    Amount = 300,
                    CustomerId = customerId,

                },

            });
            // Act
            var result = service.GetCustomer(
                customerId);

            // Assert

            result.Balance.Should().Be(400);
            
        }
        [Test]
        public void GetCustomer_CustomerExistsWithTransactions_NumberOfTransactionsMatches()
        {
            // Arrange
            var service = this.CreateService();
            string customerId = "existentCustomer";
            mockCustomerRepository.Setup(x => x.GetCustomerByUId(customerId)).Returns(new Data.Entities.CustomerEntity() { FirstName = "bla", LastName = "crocobaur", CustomerUId = customerId });
            mockTransactionService.Setup(x => x.GetTransactionsForCustomerId(customerId)).Returns(new List<TransactionDto>() {
                new TransactionDto()
                {
                    Amount = 100,
                    CustomerId = customerId,

                },
                 new TransactionDto()
                {
                    Amount = 300,
                    CustomerId = customerId,

                },

            });
            // Act
            var result = service.GetCustomer(
                customerId);

            // Assert

            result.Transactions.Should().HaveCount(2);

        }

    }
}
