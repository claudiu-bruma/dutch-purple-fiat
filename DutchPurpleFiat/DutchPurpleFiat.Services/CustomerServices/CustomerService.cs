using DutchPurpleFiat.Data.Constants;
using DutchPurpleFiat.Data.Repositories.CustomerRepository;
using DutchPurpleFiat.Data.Repositories.TransactionRepository;
using DutchPurpleFiat.Services.TransactionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DutchPurpleFiat.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ITransactionService transactionServices;
        public CustomerService(ICustomerRepository customerRepository, ITransactionService transactionServices)
        {
            this.customerRepository =customerRepository;
            this.transactionServices = transactionServices;
        }
        public bool CusomerExists(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException(DataValidationConstants.invalidCustomerIdMessage);
            }
            return customerRepository.CustomerExists(customerId);
        }
        public CustomerDto GetCustomer(string customerId)
        {
            if ( string.IsNullOrWhiteSpace(customerId) )
            {
                throw new ArgumentException(DataValidationConstants.invalidCustomerIdMessage);
            }
            if (!CusomerExists(customerId))
            {
                throw new ArgumentNullException(DataValidationConstants.invalidCustomerIdMessage);
            }
            var customerEntity = customerRepository.GetCustomerByUId(customerId);
            var customerTransactions = transactionServices.GetTransactionsForCustomerId(customerId);
            return new CustomerDto()
            {
                FirstName = customerEntity.FirstName,
                LastName = customerEntity.LastName,
                Balance = customerTransactions.Sum(x => x.Amount),
                Transactions =  customerTransactions
                
            };
        }

        
    }
}
