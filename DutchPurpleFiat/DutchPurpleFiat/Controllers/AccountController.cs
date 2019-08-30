using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchPurpleFiat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DutchPurpleFiat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {


        /// <summary>
        /// open account
        /// </summary>
        /// <remarks>open account  - The API will expose an endpoint which accepts the user information (customerID, initialCredit)  for already existing customer</remarks>
        /// <param name="body"></param>
        /// <response code="200">account created succesfully</response>
        /// <response code="400">well.... bad request is quite appropriately descriptive here</response>
        /// <response code="404">Customer not found</response>
        /// <response code="500">Something went wrong. Time to get to know your system admin and fellow developer</response>
        [HttpPost]                
        public async Task<IActionResult> AccountPost([FromBody]AccountModel body)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(string));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500);

            return new OkObjectResult(Guid.NewGuid());
        }
    }
}