using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models;

public class Staff
{
    public int StaffId { get; set; }
    
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Position { get; set; }
    
    // Navigation Properties
    [ValidateNever]
    public virtual ICollection<Sale> Sales { get; set; }
}