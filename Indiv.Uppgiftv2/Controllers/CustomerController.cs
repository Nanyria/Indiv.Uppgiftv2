using Indiv.Uppgiftv2.Services;
using IndUppClassModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Indiv.Uppgiftv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetAllCustomers()
        {
            try
            {
                var customers = await _customer.GetAllCustomers();
                return Ok(customers);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve customers from database.");
            }
        }
    }
}
