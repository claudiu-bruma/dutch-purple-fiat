using DutchPurpleFiat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Data.Repositories.AccountRepository
{
    public interface IAccountRepository
    {
        void AddAccount(AccountEntity newEntity);
        AccountEntity GetAccountById(string accountId);
    }
}
