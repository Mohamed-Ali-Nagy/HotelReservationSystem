namespace HotelReservationSystem.Exceptions
{
    public enum ErrorCode
    {
        NoError=0,
        UnKnown=1,
        //1000:2000 room
        InvalidRoomID =1000,

        //Facility 2000:3000
        InvalidFacilityID=2000,
        InvalidPaymentID = 2001,
        InvalidReservationID = 2002,
        InvalidCustomerID = 2003,

        InvalidCustomerFromBraintree = 2004,

        InvalidCreationTransaction = 2005,

        //user 3000:4000
        UnAuthorized=4000,
        InvalidUserName=4001

    }
}
