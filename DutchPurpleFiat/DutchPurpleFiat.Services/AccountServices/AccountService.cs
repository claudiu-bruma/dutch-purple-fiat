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
        public ICustomerService customerService { get; set; }
        public IAccountRepository accountRepository { get; set; }
        public DataStore dataStore { get; set; }
        public AccountService(ICustomerService customerService, IAccountRepository accountRepository)
        {
            this.customerService = customerService;
            this.accountRepository = accountRepository;
        }
        public async Task<string> OpenAccount(string customerId, float initialCredit)
        {
            //validate cusomer actually exists 
            if (String.IsNullOrWhiteSpace(customerId ) ||
                !this.customerService.CusomerExists(customerId) )
            {
                throw new ArgumentException("CusomerId invalid");
            }

            //create accout in store 
            var accountId= Guid.NewGuid().ToString() ;
            accountRepository.AddAccount(new Data.Entities.AccountEntity() {AccountUID  = accountId });
            // return account id 
            return accountId;
        }
    }
}
