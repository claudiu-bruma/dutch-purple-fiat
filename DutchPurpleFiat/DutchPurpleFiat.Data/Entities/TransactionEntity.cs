using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Data.Entities
{
    public class TransactionEntity
    {
        public string TransactionUid { get; set; }
        public DateTime TransactionsDate { get; set; }
        public float  Ammount { get; set; }
        public string AccountId { get; set; } 
        public string CustomerId{ get; set; }

    }
}
