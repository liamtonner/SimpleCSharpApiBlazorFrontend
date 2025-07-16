namespace CarOffer.Frontend.Models;

public class Offer
{
    public int Id { get; set; } 
    public int DealershipId { get; set; }
    public Dealership Dealership { get; set; }
    public decimal Price { get; set; }
    public string? PromotionalGift { get; set; }
    public int CarId { get; set; }
}