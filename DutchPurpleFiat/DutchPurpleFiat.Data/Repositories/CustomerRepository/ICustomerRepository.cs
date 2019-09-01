using DutchPurpleFiat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Data.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        CustomerEntity GetCustomerByUId(string customerID);
        bool CustomerExists(string customerId);
    }
}
