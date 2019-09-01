using System;
using System.Collections.Generic;
using System.Text;

namespace DutchPurpleFiat.Services.TransactionServices
{
    public interface ITransactionService
    {
        void RegisterTransaction(TransactionDto transaction);

    }
}
