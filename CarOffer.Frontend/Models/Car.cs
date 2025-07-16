

namespace CarOffer.Frontend.Models;

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string UniqueFeature { get; set; }
    public string Mileage { get; set; }
    public string EnginePower { get; set; }
    public string Transmission { get; set; }
    public string FuelType { get; set; }
    public List<string> Images { get; set; }
    public List<Offer>? Offers { get; set; }
}