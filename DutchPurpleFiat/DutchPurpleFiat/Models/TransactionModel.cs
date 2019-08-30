using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchPurpleFiat.Models
{
    public class TransactionModel
    {
        /// <summary>
        /// Account id for transaction
        /// </summary>
        /// <value>Account id for transaction</value>
        
        public string AccountId { get; set; }

        /// <summary>
        /// Type of transaction?....YAGNI?
        /// </summary>
        /// <value>Type of transaction?....YAGNI?</value>
        
        public string TransactionType { get; set; }

        /// <summary>
        /// Transacted Value
        /// </summary>
        /// <value>Transacted Value</value>
        
        public decimal? Value { get; set; }

        /// <summary>
        /// Transaction Date
        /// </summary>
        /// <value>Transaction Date</value>
        
        public DateTime? Date { get; set; }

        /// <summary>
        /// Unique Transaction Reference
        /// </summary>
        /// <value>Unique Transaction Reference</value>
       
        public string Reference { get; set; }
    }
}
