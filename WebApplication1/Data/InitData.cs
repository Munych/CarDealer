using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class InitData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context =
            new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

        
        // Производители
        if (context.Sales.Any())
        {
            return;
        }

        Manufacturer manufacturer1 = new()
        {
            Name = "Завод Lada Ижевск",
            Address = "Российская Федерация, Ижевск"
        };
        
        Manufacturer manufacturer2 = new()
        {
            Name = "Завод BMW Южная Каролина",
            Address = "США, Южная Каролина"
        };

        context.Manufacturers.Add(manufacturer1);
        context.Manufacturers.Add(manufacturer2);
        context.SaveChanges();

        // Автомобили
        if (context.Cars.Any())
        {
            return;
        }

        Car car1 = new()
        {
            ManufacturerId = manufacturer1.ManufacturerId,
            Brand = "Lada",
            Model = "Vesta",
            Color = "Белый",
            VIN = "JH4KA8172PC002873",
            VehiclePassport = "1234567890",
            ManufactureDate = new DateTime(2024, 1, 4),
            DeliveryDate = new DateTime(2024, 1, 10),
        };
        
        Car car2 = new()
        {
            ManufacturerId = manufacturer2.ManufacturerId,
            Brand = "BMW",
            Model = "X5",
            Color = "Черный",
            VIN = "4S3BH665627630221",
            VehiclePassport = "1234567891",
            ManufactureDate = new DateTime(2024, 1, 10),
            DeliveryDate = new DateTime(2024, 1, 17),
        };

        context.Cars.Add(car1);
        context.Cars.Add(car2);
        context.SaveChanges();
        
        // Сотрудники
        
        if (context.Staff.Any())
        {
            return;
        }

        Staff staff1 = new()
        {
            Surname = "Иванов",
            Name = "Иван",
            Telephone = "+79034562180",
            Position = "Менеджер по продажам",
        };
        
        Staff staff2 = new()
        {
            Surname = "Петров",
            Name = "Петр",
            Telephone = "+79034562182",
            Position = "Менеджер по продажам",
        };

        context.Staff.Add(staff1);
        context.Staff.Add(staff2);
        context.SaveChanges();
        
        // Покупатели
        
        if (context.Buyers.Any())
        {
            return;
        }

        Buyer buyer1 = new()
        {
            Surname = "Евгеньев",
            Name = "Евгений",
            Telephone = "+79038562182",
            Address = "Чебоксары"
        };
        
        Buyer buyer2 = new()
        {
            Surname = "Андропов",
            Name = "Семен",
            Telephone = "+79138562182",
            Address = "Москва"
        };

        context.Buyers.Add(buyer1);
        context.Buyers.Add(buyer2);
        context.SaveChanges();
        
        // Продажи
        
        if (context.Sales.Any())
        {
            return;
        }

        Sale sale1 = new()
        {
            CarId = car1.CarId,
            StaffId = staff1.StaffId,
            BuyerId = buyer1.BuyerId,
            SaleDate = new DateTime(2024, 1, 11),
            Cost = 1600000,
        };
        
        Sale sale2 = new()
        {
            CarId = car2.CarId,
            StaffId = staff2.StaffId,
            BuyerId = buyer2.BuyerId,
            SaleDate = new DateTime(2024, 1, 19),
            Cost = 16000000,
        };

        context.Sales.Add(sale1);
        context.Sales.Add(sale2);
        context.SaveChanges();
    }
}