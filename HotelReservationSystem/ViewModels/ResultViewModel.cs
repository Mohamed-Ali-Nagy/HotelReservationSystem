using HotelReservationSystem.Exceptions;

namespace HotelReservationSystem.ViewModels
{
    public class ResultViewModel<T>
    {
        public T Data { get; set; }
        public ErrorCode ErrorCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static ResultViewModel<T> Success<T>(T data,string message="")
        {
            return new ResultViewModel<T>()
            {
                Data = data,
                ErrorCode = ErrorCode.NoError,
                Message = message,
                IsSuccess = true
                
            };
        }
        public static ResultViewModel<T> Faliure(string message,ErrorCode errorCode)
        {
            return new ResultViewModel<T>()
            {
                Data=default,
                ErrorCode = errorCode,
                Message = message,
                IsSuccess = false

            };
        }
    }
}
