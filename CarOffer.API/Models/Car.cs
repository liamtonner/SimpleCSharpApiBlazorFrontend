

using System.ComponentModel.DataAnnotations;

namespace CarOfferProject.Models;

public class Car
{
    public int Id { get; set; }
    [MaxLength(256)]
    public required string Make { get; set; }
    [MaxLength(256)]
    
    public required string Model { get; set; }
    [MaxLength(256)]
    
    public required string UniqueFeature { get; set; }
    [MaxLength(256)]
    
    public required string Mileage { get; set; }
    [MaxLength(256)]
    
    public required string EnginePower { get; set; }
    [MaxLength(256)]
    
    public required string Transmission { get; set; }
    [MaxLength(256)]
    
    public required string FuelType { get; set; }
    
    public required List<string> Images { get; set; }
    public List<Offer>? Offers { get; set; } = new();
}