using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models;

public class Sale
{
    public int SaleId { get; set; }
    
    // Navigation Properties
    public int CarId { get; set; }
    public int BuyerId { get; set; }
    public int StaffId { get; set; }
    
    public DateTime SaleDate { get; set; }
    public float Cost { get; set; }
    
    // Navigation Properties
    [ValidateNever]
    public virtual Car Car { get; set; }
    [ValidateNever]
    public virtual Buyer Buyer { get; set; }
    [ValidateNever]
    public virtual Staff Staff { get; set; }
}