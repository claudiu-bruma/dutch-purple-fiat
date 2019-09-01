using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DutchPurpleFiat.Models;
using DutchPurpleFiat.Services.AccountServices;
using DutchPurpleFiat.Services.TransactionServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DutchPurpleFiat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountService accountService { get; set; }
        public ITransactionService transactionService { get; set; }

        public AccountController(
            IAccountService accountService,
            ITransactionService transactionService
            )
        {
            this.accountService = accountService;
            this.transactionService = transactionService;
        }



        /// <summary>
        /// open account
        /// </summary>
        /// <remarks>open account  - The API will expose an endpoint which accepts the user information (customerID, initialCredit)  for already existing customer</remarks>
        /// <param name="newAccount"></param>
        /// <response code="200">account created succesfully</response>
        /// <response code="400">well.... bad request is quite appropriately descriptive here</response>
        /// <response code="404">Customer not found</response>
        /// <response code="500">Something went wrong. Time to get to know your system admin and fellow developer</response>
        [HttpPost]
        public IActionResult Post([FromBody]AccountModel newAccount)
        {
            if(newAccount == null || string.IsNullOrWhiteSpace (newAccount.CustomerId ))
            {
                return new BadRequestResult();
            }
            var accountId = string.Empty;
            try
            {
                accountId = accountService.OpenAccount(newAccount.CustomerId);
            }
            catch (ArgumentException aex)
            {
                Trace.TraceError(aex.ToString());
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


            if (newAccount.InitialCredit > 0)
            {
                transactionService.RegisterTransaction(new TransactionDto() {
                    AccountId = accountId,
                    CustomerId = newAccount.CustomerId,
                    TransactionDate = DateTime.Now,
                    Amount = newAccount.InitialCredit
                });
            }

            return new OkObjectResult(accountId);
        }
    }
}