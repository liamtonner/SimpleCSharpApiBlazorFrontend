using CarOfferProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CarOfferProject.Data;

public class CarContext : DbContext
{
    public CarContext(DbContextOptions<CarContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Dealership> Dealerships { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed dealerships
        modelBuilder.Entity<Dealership>().HasData(
            new Dealership { Id = 1, Name = "AutoWorld", Location = "London" },
            new Dealership { Id = 2, Name = "CarMax", Location = "Manchester" }
        );

        // Seed cars
        modelBuilder.Entity<Car>().HasData(
            new Car
            {
                Id = 1,
                Make = "Toyota",
                Model = "Corolla",
                UniqueFeature = "Hybrid engine",
                Mileage = "12000",
                EnginePower = "130",
                Transmission = "Automatic",
                FuelType = "Hybrid",
                Images = new List<string> { "https://upload.wikimedia.org/wikipedia/commons/f/fe/Toyota_Corolla_Hybrid_%28E210%29_IMG_4338.jpg", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/2018_Toyota_Corolla_%28MZEA12R%29_Ascent_Sport_hatchback_%282018-11-02%29_02.jpg/1599px-2018_Toyota_Corolla_%28MZEA12R%29_Ascent_Sport_hatchback_%282018-11-02%29_02.jpg" }
            },
            new Car
            {
                Id = 2,
                Make = "Ford",
                Model = "Focus",
                UniqueFeature = "Advanced safety",
                Mileage = "15000",
                EnginePower = "140",
                Transmission = "Manual",
                FuelType = "Petrol",
                Images = new List<string> { "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e6/2003_Ford_Focus_Zetec_1.6_Front.jpg/500px-2003_Ford_Focus_Zetec_1.6_Front.jpg", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/2003_Ford_Focus_Zetec_1.6_Rear.jpg/500px-2003_Ford_Focus_Zetec_1.6_Rear.jpg" }
            },
            new Car
            {
                Id = 3,
                Make = "Honda",
                Model = "Civic",
                UniqueFeature = "Wireless charging",
                Mileage = "18000",
                EnginePower = "150",
                Transmission = "Automatic",
                FuelType = "Petrol",
                Images = new List<string> { "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/2022_Honda_Civic_Touring_in_Lunar_Silver_Metallic%2C_Front_Left%2C_05-10-2022.jpg/500px-2022_Honda_Civic_Touring_in_Lunar_Silver_Metallic%2C_Front_Left%2C_05-10-2022.jpg", "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/2022_Honda_Civic_Sedan_EX_in_Platinum_White_Pearl%2C_rear_left_%282%29.jpg/500px-2022_Honda_Civic_Sedan_EX_in_Platinum_White_Pearl%2C_rear_left_%282%29.jpg" }
            }
        );

        // Seed offers
        modelBuilder.Entity<Offer>().HasData(
            new Offer
            {
                Id = 1,
                Price = 14500,
                PromotionalGift = "Free MOT",
                CarId = 1,
                DealershipId = 1
            },
            new Offer
            {
                Id = 2,
                Price = 14800,
                PromotionalGift = "Free Service for 1 Year",
                CarId = 1,
                DealershipId = 2
            },
            new Offer
            {
                Id = 3,
                Price = 13900,
                PromotionalGift = "Bottle of wine",
                CarId = 2,
                DealershipId = 1
            },
            new Offer
            {
                Id = 4,
                Price = 14200,
                PromotionalGift = "Free Tyre Replacement",
                CarId = 2,
                DealershipId = 2
            },
            new Offer
            {
                Id = 5,
                Price = 15000,
                PromotionalGift = "Fuel Voucher",
                CarId = 3,
                DealershipId = 1
            },
            new Offer
            {
                Id = 6,
                Price = 15300,
                PromotionalGift = "Free Detailing",
                CarId = 3,
                DealershipId = 2
            }
        );

        // Configure owned types or conversions if needed
        modelBuilder.Entity<Car>()
            .Property(c => c.Images)
            .HasConversion(
                v => string.Join(';', v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
            );
    }
}