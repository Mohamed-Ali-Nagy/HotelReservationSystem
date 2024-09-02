using Braintree;
using HotelReservationSystem.DTO.Payment;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.Payment;
using HotelReservationSystem.Mediators.Room;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels;
using HotelReservationSystem.ViewModels.Payment;
using HotelReservationSystem.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Payment_GatewayController : ControllerBase
    {
        private readonly BraintreeGateway _gateway;

        public Payment_GatewayController()
        {
            _gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "6dnmd4f7h743nt4h",
                PublicKey = "mr82dt6xb358vdgn",
                PrivateKey = "6259f1aed127ec09c16207fc4374cf74"
            };
        }
        [HttpPost("create")]
        public IActionResult CreateCustomer([FromBody] Braintree.CustomerRequest request)
        {
            // Map your custom CustomerRequest to Braintree's CustomerRequest
            var customerRequest = new Braintree.CustomerRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PaymentMethodNonce = request.PaymentMethodNonce
            };

            Result<Braintree.Customer> result = _gateway.Customer.Create(customerRequest);

            if (result.IsSuccess())
            {
                return Ok(new { CustomerId = result.Target.Id });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        // Existing generate client token endpoint
        [HttpGet("generate-client-token")]
        public IActionResult GenerateClientToken(string customerId)
        {
            var clientToken = _gateway.ClientToken.Generate(new ClientTokenRequest
            {
                CustomerId = customerId
            });

            return Ok(new { ClientToken = clientToken });
        }

        // New endpoint to create a purchase (transaction)
        [HttpPost("create-purchase")]
        public IActionResult CreatePurchase([FromBody] TransactionRequest request)
        {
            var transactionRequest = new TransactionRequest
            {
                Amount = request.Amount,
                PaymentMethodNonce = request.PaymentMethodNonce,
                CustomerId = request.CustomerId,  // Associate with the existing customer
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = _gateway.Transaction.Sale(transactionRequest);

            if (result.IsSuccess())
            {
                return Ok(new { TransactionId = result.Target.Id, Status = result.Target.Status.ToString() });
            }
            else
            {
                return BadRequest(new { Message = result.Message, Errors = result.Errors.DeepAll() });
            }
        }

        [HttpGet("get-all-customers")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var searchRequest = new CustomerSearchRequest(); // Create a basic search request to fetch all customers
                var customers = _gateway.Customer.Search(searchRequest);

                var customerList = new List<Braintree.Customer>(); // Store customer details in a simplified object list

                foreach (Braintree.Customer customer in customers)
                {
                    customerList.Add(customer);
                }

                return Ok(customerList); // Return the list of customers
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


    }
}
