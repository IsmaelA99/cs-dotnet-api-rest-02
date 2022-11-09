using CSApiRestPractice02.Data;
using CSApiRestPractice02.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CSApiRestPractice02.Controller {

    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase  {

        private CustomerService _customerService;

        public CustomerController(CustomerService customerService) {

            _customerService = customerService;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetCustomers() {

            try {

                List<Customer> customers = await _customerService.GetCustomers();

                return new OkObjectResult(customers);

            } catch (Exception e) {

                return new NotFoundObjectResult(e.Message);

            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetCustomer(int id) {

            try {

                Customer customer = await _customerService.GetCustomer(id);

                return new OkObjectResult(customer);

            } catch (Exception e) {

                return new NotFoundObjectResult(e.Message);

            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SaveCustomer(Customer customer) {

            try {

                Customer customerSaved = await _customerService.SaveCustomer(customer);

                return new OkObjectResult(customerSaved);

            } catch (Exception e) {

                return new BadRequestObjectResult(e.Message);

            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer) {

            try {

                Customer customerUpdated = await _customerService.UpdateCustomer(id, customer);

                return new OkObjectResult(customerUpdated);

            } catch (Exception e) {

                return new BadRequestObjectResult(e.Message);

            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Boolean))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteCustomer(int id) {

            try {

                Boolean isSuccessfullyDeleted = await _customerService.DeleteCustomer(id);

                return new OkObjectResult(isSuccessfullyDeleted);

            } catch (Exception e) {

                return new BadRequestObjectResult(e.Message);

            }

        }

    }

}
