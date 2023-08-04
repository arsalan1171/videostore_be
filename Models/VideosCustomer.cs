namespace videostore_be.Models
{
    public class VideosCustomer

    {
        public int VideosCustomerId { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int copyCount { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int VideosId { get; set; }
        public Videos Videos { get; set; }

    }
}