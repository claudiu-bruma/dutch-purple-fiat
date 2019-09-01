using DutchPurpleFiat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Data.Repositories.TransactionRepository
{
    public interface ITransactionRepository
    {
         IEnumerable<TransactionEntity> GetCusomerTransactions(string customerID);
         void AddTransaction(TransactionEntity newEntity);
    }
}
