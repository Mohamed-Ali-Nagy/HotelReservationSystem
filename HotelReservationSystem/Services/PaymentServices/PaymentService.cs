using HotelReservationSystem.DTO.Payment;
using HotelReservationSystem.DTO.Reservation;
using HotelReservationSystem.DTO.Room;
using HotelReservationSystem.Exceptions;
using HotelReservationSystem.Helpers;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories;

namespace HotelReservationSystem.Services.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository<Payment> _paymentRepository;

        public PaymentService(IRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public PaymentCreateDTO Add(PaymentCreateDTO payment)
        {
            var paymentDTO = payment.MapOne<Payment>();
            //roomDTO.IsAvailable = true;
            var newPayment = _paymentRepository.Add(paymentDTO);
            _paymentRepository.SaveChanges();
            return payment;
        }

        public void Update(int id, PaymentEditDTO payment)
        {
            var paymentDTO = payment.MapOne<Payment>();
            paymentDTO.ID = id;
            _paymentRepository.Update(paymentDTO);
            _paymentRepository.SaveChanges();
            // return roomDTO;
        }

        public void Cancel(int id)
        {
            _paymentRepository.Delete(id);
            // _paymentRepository.SaveChanges();
        }

        public List<PaymentGetDTO> GetAll(int pageNumber, int pageSize)
        {
            List<Payment> payments = _paymentRepository.GetAllPagination(pageNumber, pageSize).ToList();
            List<PaymentGetDTO> paymentssDTO = new List<PaymentGetDTO>();
            foreach (var payment in payments)
            {
                paymentssDTO.Add(payment.MapOne<PaymentGetDTO>());
            }
            return paymentssDTO;
        }

        public PaymentGetDTO Get(int id)
        {
            return _paymentRepository.GetByID(id).MapOne<PaymentGetDTO>();
        }

        public bool AssignReservation(int id, List<int> ReservationIds)
        {
            var Payment=_paymentRepository.GetByID(id).MapOne<PaymentGetDTO>();
            var validate = ValidatePayment(Payment);
            List<Reservation> Reservations = new List<Reservation>();   
            foreach (var reservation in ReservationIds)
            {
                var Reservation_Check = reservation.MapOne<Reservation>();
                var test=ValidateReservation(Reservation_Check);               
                Reservations.Add(Reservation_Check);               
            }
            Payment.MapOne<Payment>().Reservation.AddRange(Reservations);
            return true;
        }

        private bool ValidatePayment(PaymentGetDTO Payment)
        {
            if (Payment == null)
            {
                throw new BusinessException(ErrorCode.InvalidPaymentID, "Invalid Payment");
            }
            return true;
        }

        private bool ValidateReservation(Reservation Reservation_Check)
        {
            if (Reservation_Check == null)
            {
                throw new BusinessException(ErrorCode.InvalidReservationID, "Invalid Reservation");

            }
            return true;
        }
        



    }

}
