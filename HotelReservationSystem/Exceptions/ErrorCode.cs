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
        InvalidPaymentID = 3000,
        InvalidReservationID = 4000,
        InvalidCustomerID = 7000,

        InvalidCustomerFromBraintree = 5000,

        InvalidCreationTransaction = 6000,

    }
}
