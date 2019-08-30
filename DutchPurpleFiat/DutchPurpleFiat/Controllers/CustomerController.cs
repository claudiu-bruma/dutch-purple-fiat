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
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Get customer information
        /// </summary>
        /// <remarks>Get customer information </remarks>
        /// <param name="customerId">unique identifier for customer id</param>
        /// <response code="200">Status 200</response>
        /// <response code="400">Bad request... probably forgot customer id , didn't you ?</response>
        /// <response code="404">Customer Not Found</response>
        /// <response code="500">Something went wrong... time to get to know your system admin and fellow developer</response>
        [HttpGet]
        public async  Task<IActionResult> Get(  string customerId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(InlineResponse200));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(500);

            return new OkObjectResult(new CustomerDetailsModel());
        }
    }
}