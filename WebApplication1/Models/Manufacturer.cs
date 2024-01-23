using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models;

public class Manufacturer
{
    public int ManufacturerId { get; set; }
    
    [Required(ErrorMessage = "Укажите наименование")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символом")]
    [Display(Name = "Наименование")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Укажите адрес производства")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символом")]
    [Display(Name = "Адрес производства")]
    public string Address { get; set; }
    
    // Navigation Properties
    [ValidateNever]
    public virtual ICollection<Car> Cars { get; set; }
}