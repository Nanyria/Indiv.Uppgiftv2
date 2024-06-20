using Indiv.Uppgiftv2.Services;
using IndUppClassModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Indiv.Uppgiftv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet(Name = "GetAllCustomers")]
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
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            try
            {
                var result = await _customer.GetSingleCustomer(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve customer from database.");
            }
        }
        [HttpGet("search")]
        public async Task<ActionResult<Customer>> SearchCustomer(string name)
        {
            try
            {
                var result = await _customer.SearchForCustomer(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound("No customer found with matching name.");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve customer from database.");

            }
        }
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateNewCustomer(Customer newCustomer)
        {
            try
            {
                if(newCustomer == null)
                {
                    return BadRequest();
                }
                var createdCustomer = await _customer.Add(newCustomer);
                return CreatedAtAction(nameof(GetCustomer),
                    new
                    {
                        id = createdCustomer.CustomerID
                    }, createdCustomer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve customers from database.");
            }
            
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            try
            {
                var customerToDelete = await _customer.GetSingleCustomer(id);
                if (customerToDelete == null)
                {
                    return NotFound($"Customer with id {id} doesn't exist in database.");
                }
                return await _customer.Delete(id);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");

            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id,  Customer customer)
        {
            try
            {
                if (id != customer.CustomerID)
                {
                    return BadRequest($"Customer ID {id} not found.");
                }
                var customerToUpdate = await _customer.GetSingleCustomer(id);
                if (customerToUpdate == null)
                {
                    return NotFound($"Customer with ID {id} not found.");
                }
                return await _customer.Update(customer);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error when trying to retrieve from database.");

            }
        }
    }
}
