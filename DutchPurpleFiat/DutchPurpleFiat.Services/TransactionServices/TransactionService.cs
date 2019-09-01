using DutchPurpleFiat.Data.Constants;
using DutchPurpleFiat.Data.DataStores;
using DutchPurpleFiat.Data.Repositories.TransactionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DutchPurpleFiat.Services.TransactionServices
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionsRepository;
        public TransactionService(ITransactionRepository transactionsRepository)
        {
            this.transactionsRepository = transactionsRepository;
        }

        public void RegisterTransaction(TransactionDto transaction)
        {
            transactionsRepository.AddTransaction(new Data.Entities.TransactionEntity()
            {
                AccountId = transaction.AccountId,
                Ammount = transaction.Amount,
                TransactionUid = DataHelper.GenerateUniqueId(),
                CustomerId = transaction.CustomerId,
                TransactionsDate = transaction.TransactionDate
            });
        }
        public IEnumerable<TransactionDto> GetTransactionsForCustomerId(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException(DataValidationConstants.invalidCustomerIdMessage);
            }
            return transactionsRepository.GetCusomerTransactions(customerId).Select(x => new TransactionDto()
            {
                AccountId = x.AccountId,
                Amount = x.Ammount,
                CustomerId = x.CustomerId,
                TransactionDate = x.TransactionsDate
            });
        }
    }


}
