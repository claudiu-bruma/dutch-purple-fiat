using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DutchPurpleFiat.Services.AccountServices
{
    public interface IAccountService
    {
        Task<string> OpenAccount(string cusomerId, float initialCredit);
    }
}
