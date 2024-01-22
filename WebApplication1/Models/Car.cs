using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models;

public class Car
{
    public int CarId { get; set; }
    
    // Navigation Properties
    [Display(Name = "Производитель")]
    public int ManufacturerId { get; set; }
    
    [Display(Name = "Марка")]
    public string Brand { get; set; }
    [Display(Name = "Модель")]
    public string Model { get; set; }
    [Display(Name = "Цвет")]
    public string Color { get; set; }
    public string VIN { get; set; }
    [Display(Name = "ПТС")]
    public string VehiclePassport { get; set; }
    [Display(Name = "Дата производства")]
    public DateTime ManufactureDate { get; set; }
    [Display(Name = "Дата поставки")]
    public DateTime DeliveryDate { get; set; }
    
    //Navigation Properties
    [ValidateNever]
    [Display(Name = "Производитель")]
    public virtual Manufacturer Manufacturer { get; set; }
    [ValidateNever]
    public virtual ICollection<Sale> Sales { get; set; }
}