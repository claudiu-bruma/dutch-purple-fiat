using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Services.TransactionServices
{
    public class TransactionDto
    {
        public string AccountId { get; set; }
        public string CustomerId { get; set; }      
        public float Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        
    }
}
