using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DutchPurpleFiat.Services.AccountServices
{
    public interface IAccountService
    {
        string OpenAccount(string customerId);
        string GetCustomerIdOnAccount(string accountId);
    }
}
