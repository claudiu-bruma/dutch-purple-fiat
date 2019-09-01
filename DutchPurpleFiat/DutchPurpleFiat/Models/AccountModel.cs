using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DutchPurpleFiat.Models
{
    public class AccountModel
    {
        /// <summary>
        /// Customer id identifying already existing user
        /// </summary>
        /// <value>Customer id identifying already existing user</value>
        [Required]        
        public string CustomerId { get; set; }

        /// <summary>
        /// Initial credit on opening new account
        /// </summary>
        /// <value>Initial credit on opening new account</value>
        [Required]
        public float InitialCredit { get; set; }
    }
}
