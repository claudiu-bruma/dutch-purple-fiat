using DutchPurpleFiat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Data.DataStores
{
   public class DataStore
    {
        public ICollection<TransactionEntity> TransactionStore { get; set; }
        public ICollection<CustomerEntity> CustomerStore { get; set; }
        public ICollection<AccountEntity> AccountStore { get; set; }
        public DataStore()
        {
            TransactionStore = new List<TransactionEntity>();
            CustomerStore = new List<CustomerEntity>();
            AccountStore = new List<AccountEntity>();
            AddDemoCustomerData();
        }
        private void AddDemoCustomerData()
        {
            CustomerStore.Add(new CustomerEntity() { CustomerUID = "CUID1-JW", FirstName = "John", LastName = "Wick" });
            CustomerStore.Add(new CustomerEntity() { CustomerUID = "CUID2-MS", FirstName = "Michael", LastName = "Stonebridge" });
            CustomerStore.Add(new CustomerEntity() { CustomerUID = "CUID3-MW", FirstName = "Michael", LastName = "Weston" });
        }
    }
 
}
