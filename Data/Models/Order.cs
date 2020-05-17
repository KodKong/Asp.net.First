using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set;}
        [Display(Name= "Имя")]
        [StringLength(20)]
        [Required(ErrorMessage ="Длина имени не менее 2 символов")]
        public string NameBuyer { get; set; }

        [Display(Name = "Фамилию")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина фамилии не менее 2 символов")]
        public string SurnameBuyer { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(20)]
        [Required(ErrorMessage = "Неверный адрес")]
        public string AdressBuyer { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12)]
        [Required(ErrorMessage = "Неверный номер")]
        public string PhoneBuyer { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "Неверный формат вводы")]
        public string EmailBuyer { get; set; }

        [BindNever]
        [ScaffoldColumn(false)] // не отображается даже в коде
        public DateTime OrderTimeBuyer { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}
