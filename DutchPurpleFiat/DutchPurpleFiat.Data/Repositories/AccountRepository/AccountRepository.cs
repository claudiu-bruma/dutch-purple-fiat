﻿using DutchPurpleFiat.Data.DataStores;
using DutchPurpleFiat.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DutchPurpleFiat.Data.Repositories.AccountRepository
{
    public class AccountRepository: IAccountRepository
    {
        public DataStore DataStore { get; set; }

        public AccountRepository(DataStore dataStore)
        {
            this.DataStore = dataStore;
        }
 
        public void AddAccount(AccountEntity newEntity)
        {
            DataStore.AccountStore.Add(newEntity);
        }
        public AccountEntity GetAccountById(string accountId)
        {
            return DataStore.AccountStore.FirstOrDefault(x => x.AccountUID == accountId);
        }
    }
}
