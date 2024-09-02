using Azure.Core;
using Braintree;
using HotelReservationSystem.DTO.Payment;
using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Exceptions;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Mediators.CustomerMediators;
using HotelReservationSystem.Mediators.Reservation;
using HotelReservationSystem.Models;
using HotelReservationSystem.Services.PaymentServices;
using HotelReservationSystem.Services.RoomServices;


namespace HotelReservationSystem.Mediators.Payment
{
    public class PaymentMediator : IPaymentMediator
    {
        IPaymentService _paymentService;
        ICustomerMeditator _customerMediator;

        IReservationMediator _reservationMediator;
        private readonly BraintreeGateway _gateway;
        const string _MerchantId = "6dnmd4f7h743nt4h";
        const string _PublicKey = "mr82dt6xb358vdgn";
        const string _PrivateKey = "6259f1aed127ec09c16207fc4374cf74";
        string token = string.Empty;
        public PaymentMediator(IPaymentService paymentService, IReservationMediator reservationMediator, ICustomerMeditator customerMediator)
        {
            _paymentService = paymentService;
            _reservationMediator = reservationMediator;
            _customerMediator = customerMediator;
            _gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = _MerchantId,
                PublicKey = _PublicKey,
                PrivateKey = _PrivateKey
            };
        }
        public string GenerateClientToken(string customerId)
        {
            var clientToken = _gateway.ClientToken.Generate(new ClientTokenRequest
            {
                CustomerId = customerId
            });

            return clientToken;


        }
        public PaymentCreateDTO Add(PaymentCreateDTO payment)
        {

            var customer=_customerMediator.Get( payment.CustomerId);
            if (customer == null)
            {
                throw new BusinessException(ErrorCode.InvalidCustomerID, "customer is not found");

            }
             token = GenerateClientToken(customer.Braintree_ID);

            CreatePurchase(new Braintree.TransactionRequest {CustomerId=customer.Braintree_ID,Amount=payment.Amount,
                                                            PaymentMethodNonce=payment.PaymentMethodNonce,
               
                                                            });
            payment.PaymentMethodNonce= "fake-valid-nonce";

            return _paymentService.Add(payment);
        }

        public void Cancel(int roomid)
        {
            _paymentService.Cancel(roomid);
        }

        public void AssignReservation(int id, List<int> ReservationIds)
        {

                _paymentService.AssignReservation( id, ReservationIds);
            

        }

        public List<PaymentGetDTO> GetAll(int pageNumber, int pageSize)
        {
            return _paymentService.GetAll(pageNumber, pageSize);
        }



        public void CreatePurchase(TransactionRequest request)
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
                //return Ok(new { TransactionId = result.Target.Id, Status = result.Target.Status.ToString() });
            }
            else
            {
               throw new BusinessException( ErrorCode.InvalidCreationTransaction, result.Message);
            }


        }
  
        



    }
}
