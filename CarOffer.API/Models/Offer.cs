using System.ComponentModel.DataAnnotations;

namespace CarOfferProject.Models;

public class Offer
{
    public int Id { get; set; } 
    public int DealershipId { get; set; }
    public Dealership? Dealership { get; set; }
    public decimal Price { get; set; }
    [MaxLength(256)]
    
    public string? PromotionalGift { get; set; }
    public int CarId { get; set; }
}