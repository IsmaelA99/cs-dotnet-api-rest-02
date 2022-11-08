using CSApiRestPractice02.Data;
using CSApiRestPractice02.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CSApiRestPractice02.Controller {

    [ApiController]
    [Route("api/addresses")]
    public class AddressController : ControllerBase {

        private AddressService _addressService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Address>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetAddresses() {

            try {

                List<Address> addresses = await _addressService.GetAddresses();

                return new OkObjectResult(addresses);

            } catch (Exception e) {

                return new NotFoundObjectResult(e.Message);

            }


        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Address))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetAddress(int id) {

            try {

                Address address = await _addressService.GetAddress(id);

                return new OkObjectResult(address);

            } catch (Exception e) {

                return new NotFoundObjectResult(e.Message);

            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Address))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> SaveAddress(Address address) {

            try {

                Address addressSaved = await _addressService.SaveAddress(address);
                return new OkObjectResult(addressSaved);

            } catch (Exception e) {

                return new BadRequestObjectResult(e.Message);

            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Address))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> UpdateAddress(int id, Address address) {

            try {

                Address addressUpdated = await _addressService.UpdateAddress(id, address);

                return new OkObjectResult(addressUpdated);

            } catch (Exception e) {

                return new BadRequestObjectResult(e.Message);

            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Boolean))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> DeleteAddress(int id) {

            try {

                Boolean isDeletedSuccessfully = await _addressService.DeleteAddress(id);

                return new OkObjectResult(isDeletedSuccessfully);

            } catch (Exception e) {

                return new BadRequestObjectResult(e.Message);

            }

        }

    }

}
