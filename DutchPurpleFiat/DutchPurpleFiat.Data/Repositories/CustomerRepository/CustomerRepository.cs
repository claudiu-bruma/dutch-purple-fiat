using DutchPurpleFiat.Data.Entities;
using System;
using System.Collections.Generic;
using DutchPurpleFiat.Data.DataStores;
using System.Linq;
using DutchPurpleFiat.Data.Constants;

namespace DutchPurpleFiat.Data.Repositories.CustomerRepository
{
    public class CustomerRepository: ICustomerRepository
    {
        public  DataStore DataStore { get; set; }
       
        public CustomerRepository(DataStore dataStore)
        {
            this.DataStore = dataStore;
        }
        public bool CustomerExists(string customerId)
        {
            return DataStore.CustomerStore.Any(x => x.CustomerUId == customerId);
        }
        public CustomerEntity GetCustomerByUId(string customerId)
        {
            return DataStore.CustomerStore.FirstOrDefault(x => x.CustomerUId == customerId);
        }
    }
}
