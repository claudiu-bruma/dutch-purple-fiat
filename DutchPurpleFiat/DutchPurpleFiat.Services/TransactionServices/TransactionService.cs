using DutchPurpleFiat.Data.Repositories.TransactionRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Services.TransactionServices
{
    public class TransactionService : ITransactionService
    {
        public ITransactionRepository TransactionsRepository { get; set; }
        public TransactionService(ITransactionRepository transactionsRepository)
        {
            this.TransactionsRepository = transactionsRepository;
        }

        public  void  RegisterTransaction(TransactionDto transaction)
        {
            TransactionsRepository.AddTransaction(new Data.Entities.TransactionEntity()
            {
                AccountId = transaction.AccountId,
                Ammount = transaction.Amount ,
                CusomerId = transaction.CustomerId,
                TransactionUID = transaction.TransactionReference,
                TransactionsDate = transaction.TransactionDate 
            });
        }
    }


}
