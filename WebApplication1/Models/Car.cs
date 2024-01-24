using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models;

public class Car
{
    public int CarId { get; set; }
    
    // Navigation Properties
    [Required(ErrorMessage = "Выберите производителя")]
    [Display(Name = "Производитель")]
    public int ManufacturerId { get; set; }
    
    [Required(ErrorMessage = "Укажите марку автомобиля")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символом")]
    [Display(Name = "Марка")]
    public string Brand { get; set; }
    
    [Required(ErrorMessage = "Укажите модель автомобиля")]
    [StringLength(30, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 2 до 30 символом")]
    [Display(Name = "Модель")]
    public string Model { get; set; }
    
    [Required(ErrorMessage = "Укажите цвет автомобиля")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символом")]
    [Display(Name = "Цвет")]
    public string Color { get; set; }
    
    [Required(ErrorMessage = "Укажите VIN автомобиля")]
    [RegularExpression("[A-HJ-NPR-Z0-9]{17}", ErrorMessage = "Некорректный формат VIN номера")]
    public string VIN { get; set; }
    
    [Required(ErrorMessage = "Укажите ПТС автомобиля")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Длина строки должна быть 10 символов")]
    [Display(Name = "ПТС")]
    public string VehiclePassport { get; set; }
    
    [Required(ErrorMessage = "Укажите дату производства автомобиля")]
    [Display(Name = "Дата производства")]
    public DateTime ManufactureDate { get; set; }
    
    [Required(ErrorMessage = "Укажите дату поставки автомобиля")]
    [Display(Name = "Дата поставки")]
    public DateTime DeliveryDate { get; set; }

    public string ShortInfo
    {
        get
        {
            return String.Concat(Brand, " ", Model, " | ", Color, " | VIN: ", VIN);
        }
    }
    
    //Navigation Properties
    [ValidateNever]
    [Display(Name = "Производитель")]
    public virtual Manufacturer Manufacturer { get; set; }
    
    [ValidateNever]
    public virtual ICollection<Sale> Sales { get; set; }
}