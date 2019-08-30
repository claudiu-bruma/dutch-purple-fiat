using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchPurpleFiat.Models
{
    public class CustomerDetailsModel
    {
        /// <summary>
        /// Cusomer's first name
        /// </summary>
        /// <value>Cusomer's first name</value>         
        public string Firstname { get; set; }

        /// <summary>
        /// Customer's last name
        /// </summary>
        /// <value>Customer's last name</value>

        public string Surname { get; set; }

        /// <summary>
        /// Current Balance on customer's accounts
        /// </summary>
        /// <value>Current Balance on customer's accounts</value>
        
        public decimal? Balance { get; set; }

        /// <summary>
        /// List of all transaction for customer's accounts
        /// </summary>
        /// <value>List of all transaction for customer's accounts</value>
         
        public List<TransactionModel> Transactions { get; set; }
    }
}
