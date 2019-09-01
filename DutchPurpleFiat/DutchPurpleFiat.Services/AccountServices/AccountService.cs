using DutchPurpleFiat.Data.Constants;
using DutchPurpleFiat.Data.DataStores;
using DutchPurpleFiat.Data.Repositories.AccountRepository;
using DutchPurpleFiat.Services.CustomerServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DutchPurpleFiat.Services.AccountServices
{
    public class AccountService : IAccountService
    {

        private readonly ICustomerService customerService;
        private readonly IAccountRepository accountRepository;      
        public AccountService(ICustomerService customerService, IAccountRepository accountRepository)
        {
            this.customerService = customerService;
            this.accountRepository = accountRepository;
        }
        public string OpenAccount(string customerId)
        {
            //validate cusomer actually exists 
            if (String.IsNullOrWhiteSpace(customerId) ||
                !this.customerService.CusomerExists(customerId))
            {
                throw new ArgumentException(DataValidationConstants.invalidCustomerIdMessage);
            }

            //create accout in store 
            return AddAccountToStore(customerId);
        }

        public string GetCustomerIdOnAccount(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new ArgumentException(DataValidationConstants.invalidAccountIdMessage);
            }

            var accountEntity = accountRepository.GetAccountById(accountId);

            if (accountEntity == null)
            {
                throw new ArgumentException(DataValidationConstants.invalidAccountIdMessage);
            }
            return accountEntity.CustomerId;
        }
        private string AddAccountToStore(string customerId)
        {
            var accountId = DataHelper.GenerateUniqueId();
            accountRepository.AddAccount(
                    new Data.Entities.AccountEntity()
                    {
                        AccountUID = accountId,
                        CustomerId = customerId,
                        DateCreated = DateTime.Now
                    });
            return accountId;
        }


    }
}
