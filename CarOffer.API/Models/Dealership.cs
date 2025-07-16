using System.ComponentModel.DataAnnotations;

namespace CarOfferProject.Models;

public class Dealership
{
    public int Id { get; set; }
    [MaxLength(256)]
    
    public required string? Name { get; set; }
    [MaxLength(256)]
    
    public required string Location { get; set; }
    public List<Offer>? Offers { get; set; }
}