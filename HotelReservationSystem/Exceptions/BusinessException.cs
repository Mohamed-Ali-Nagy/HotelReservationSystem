namespace HotelReservationSystem.Exceptions
{
    public class BusinessException:Exception
    {
       public ErrorCode ErrorCode;
        public BusinessException(ErrorCode errorCode,string message):base(message)
        {

            ErrorCode = errorCode;

        }
    }
}
