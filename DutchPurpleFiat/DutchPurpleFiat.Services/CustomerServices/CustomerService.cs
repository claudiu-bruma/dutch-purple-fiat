using DutchPurpleFiat.Data.Repositories.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        public ICustomerRepository CustomerRepository { get; set; }
        public CustomerService(ICustomerRepository CustomerRepository)
        {
            this.CustomerRepository = CustomerRepository;
        }
        public bool CusomerExists(string customerId)
        {
            return CustomerRepository.GetCustomerByUId(customerId) != null;
        }
    }
}
