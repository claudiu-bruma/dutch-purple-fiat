using DutchPurpleFiat.Data.DataStores;
using DutchPurpleFiat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DutchPurpleFiat.Data.Repositories.TransactionRepository
{
    public class TransactionRepository: ITransactionRepository
    {
        public DataStore DataStore { get; set; }

        public TransactionRepository(DataStore dataStore)
        {
            this.DataStore = dataStore;
        }
        public IEnumerable<TransactionEntity> GetCusomerTransactions(string customerID)
        {

            if (!DataStore.TransactionStore.Any(x => x.CusomerId == customerID))
            {
                return null;
            }

            return DataStore.TransactionStore.Where(x => x.CusomerId == customerID);
        }
        public void AddTransaction(TransactionEntity newEntity)
        {
            DataStore.TransactionStore.Add(newEntity);
        }
    }
}
