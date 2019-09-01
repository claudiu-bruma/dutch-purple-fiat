using DutchPurpleFiat.Services.TransactionServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Services.CustomerServices
{
    public  class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Balance { get; set; }
        public IEnumerable<TransactionDto> Transactions { get; set; }

    }
}
