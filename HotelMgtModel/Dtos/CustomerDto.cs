namespace HotelMgtModel.Dtos
{
    public class CustomerDto
    {
        public string AppUserId { get; set; }
        public string CreditCard { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public AppUserDto AppUser { get; set; }
    }
}
