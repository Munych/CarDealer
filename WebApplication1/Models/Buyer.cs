using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models;

public class Buyer
{
    public int BuyerId { get; set; }
    
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Telephone { get; set; }
    
    // Navigation Properties
    [ValidateNever]
    public virtual ICollection<Sale> Sales { get; set; }
}