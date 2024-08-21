using HotelReservationSystem.Exceptions;
using HotelReservationSystem.ViewModels;

namespace HotelReservationSystem.Middlewares
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _next(context);
            }catch (Exception ex)
            {
                string message = "Error Occured";
                ErrorCode errorCode = ErrorCode.UnKnown;

                if (ex is BusinessException businessException)
                {
                    message = businessException.Message;
                    errorCode = businessException.ErrorCode;
                }
           

                var result = ResultViewModel<bool>.Faliure( message,errorCode);

                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
