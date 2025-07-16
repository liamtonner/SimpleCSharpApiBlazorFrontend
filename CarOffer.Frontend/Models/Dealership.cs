namespace CarOffer.Frontend.Models;

public class Dealership
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string Location { get; set; }
    public List<Offer> Offers { get; set; }
}