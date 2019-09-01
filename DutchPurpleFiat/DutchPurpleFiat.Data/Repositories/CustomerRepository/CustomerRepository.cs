using DutchPurpleFiat.Data.Entities;
using System;
using System.Collections.Generic;
using DutchPurpleFiat.Data.DataStores;
using System.Linq;

namespace DutchPurpleFiat.Data.Repositories.CustomerRepository
{
    public class CustomerRepository: ICustomerRepository
    {
        public  DataStore DataStore { get; set; }
       
        public CustomerRepository(DataStore dataStore)
        {
            this.DataStore = dataStore;
        }
        public CustomerEntity GetCustomerByUId(string customerID)
        {

            if (!DataStore.CustomerStore.Any(x=>x.CustomerUID  == customerID))
            {
                return null;
            }

            return DataStore.CustomerStore.FirstOrDefault(x => x.CustomerUID == customerID);
        }
    }
}
