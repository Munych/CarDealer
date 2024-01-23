using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models;

public class Sale
{
    public int SaleId { get; set; }
    
    // Navigation Properties
    [Required(ErrorMessage = "Выберите автомобиль")]
    [Display(Name = "Автомобиль")]
    public int CarId { get; set; }
    
    [Required(ErrorMessage = "Выберите покупателя")]
    [Display(Name = "Покупатель")]
    public int BuyerId { get; set; }
    
    [Required(ErrorMessage = "Выберите сотрудника отдела продаж")]
    [Display(Name = "Сотрудник")]
    public int StaffId { get; set; }
    
    [Required(ErrorMessage = "Укажите дату продажи автомобиля")]
    [Display(Name = "Дата продажи")]
    public DateTime SaleDate { get; set; }
    
    [Required(ErrorMessage = "Укажите стоимость автомобиля")]
    [Display(Name = "Стоимость")]
    public float Cost { get; set; }
    
    // Navigation Properties
    [ValidateNever]
    [Display(Name = "Автомобиль")]
    public virtual Car Car { get; set; }
    
    [ValidateNever]
    [Display(Name = "Покупатель")]
    public virtual Buyer Buyer { get; set; }
    
    [Display(Name = "Сотрудник")]
    [ValidateNever]
    public virtual Staff Staff { get; set; }
}