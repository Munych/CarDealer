﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models;

public class Buyer
{
    public int BuyerId { get; set; }
    
    [Required(ErrorMessage = "Укажите фамилию")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символом")]
    [Display(Name = "Фамилия")]
    public string Surname { get; set; }
    
    [Required(ErrorMessage = "Укажите имя")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символом")]
    [Display(Name = "Имя")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Укажите адрес")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символом")]
    [Display(Name = "Адрес")]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "Укажите телефон")]
    [RegularExpression("(^\\+[0-9]{11})$", ErrorMessage = "Некорректный номер телефона. Валидный формат +71234567890")]
    [Display(Name = "Телефон")]
    public string Telephone { get; set; }

    public string FullName
    {
        get
        {
            return String.Concat(Surname, " ", Name);
        }
    }

    // Navigation Properties
    [ValidateNever]
    public virtual ICollection<Sale> Sales { get; set; }
}