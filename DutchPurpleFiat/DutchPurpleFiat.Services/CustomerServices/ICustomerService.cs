using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Services.CustomerServices
{
    public interface ICustomerService 
    {
        bool CusomerExists(string customerId);

    }
}
