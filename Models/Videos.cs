using System.ComponentModel.DataAnnotations;

namespace videostore_be.Models
{
    public class Videos
    {
        public int VideosId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public int NumberOfCopies { get; set; }

        public decimal? RentalPrice { get; set; }

    }
}
