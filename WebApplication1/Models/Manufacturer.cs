using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models;

public class Manufacturer
{
    public int ManufacturerId { get; set; }
    
    public string Name { get; set; }
    public string Address { get; set; }
    
    // Navigation Properties
    [ValidateNever]
    public virtual ICollection<Car> Cars { get; set; }
}