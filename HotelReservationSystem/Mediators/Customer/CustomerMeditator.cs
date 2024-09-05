using Braintree;
using HotelReservationSystem.DTO.Customer;
using HotelReservationSystem.DTO.Review;
using HotelReservationSystem.Exceptions;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.CustomerService;
using HotelReservationSystem.Services.ReviewService;

namespace HotelReservationSystem.Mediators.CustomerMediators
{
    public class CustomerMeditator : ICustomerMeditator
    {
        private readonly ICustomerService _customerService;
        private readonly BraintreeGateway _gateway;
        const string _MerchantId = "6dnmd4f7h743nt4h";
        const string _PublicKey = "mr82dt6xb358vdgn";
        const string _PrivateKey = "6259f1aed127ec09c16207fc4374cf74";
        public CustomerMeditator(ICustomerService customerService)
        {
            _customerService = customerService;
            _gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _MerchantId,
                PublicKey = _PublicKey,
                PrivateKey = _PrivateKey
            };
        }
        public CustomerDTO Add(CustomerDTO customerDTO)
        {
            var customerid=AddtoBraintree(customerDTO);
            customerDTO.Braintree_ID=customerid.ToString();
                return _customerService.Add(customerDTO);
            

        }
        public string AddtoBraintree(CustomerDTO customerDTO)
        {
            var All_customer = GetAllCustomers();
            bool check = All_customer.Any(a => a.Email.Equals(customerDTO.Email));
            if (!check)
            {
                var customer_id = CreateCustomer(new Braintree.CustomerRequest
                {
                    Email = customerDTO.Email,
                    FirstName = customerDTO.FullName,
                    
                    PaymentMethodNonce = "fake-valid-nonce",
                    //Id= customerDTO.Braintree_ID,

                });
                return customer_id;

            }
            throw new BusinessException(ErrorCode.InvalidCustomerFromBraintree, "This customer is found in braintree");
        }
        public void Delete(int id)
        {
            CustomerDTO customer = _customerService.GetByID(id);
            _customerService.Delete(customer);
        }

        public CustomerDTO Get(int id)
        {
            return _customerService.GetByID(id);
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            return _customerService.GetAll();
        }

        public void Update(CustomerDTO reviewDTO)
        {
            _customerService.Update(reviewDTO);
        }


        public String CreateCustomer(Braintree.CustomerRequest request)
        {
            var customerRequest = new Braintree.CustomerRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PaymentMethodNonce = request.PaymentMethodNonce
            };

            Result<Braintree.Customer> result = _gateway.Customer.Create(customerRequest);

           
                 return result.Target.Id ;
            


        }
        public List<Braintree.Customer> GetAllCustomers()
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

                return customerList; // Return the list of customers
            }
            catch (Exception ex)
            {
                throw new BusinessException(ErrorCode.InvalidCustomerFromBraintree, ex.Message);
            }


        }

       

    }
}
