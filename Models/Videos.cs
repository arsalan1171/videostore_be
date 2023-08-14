using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videostore_be.Models;

public class Videos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VideosId { get; set; }

    [Required]
    public string Title { get; set; }

    public string? Description { get; set; }

    public int NumberOfCopies { get; set; }

    public decimal? RentalPrice { get; set; }

}

