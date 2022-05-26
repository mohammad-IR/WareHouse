using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Models.CurrenciesPrice
{
    public  class CurrencyPrice
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "باید نوع ارز را وارد کنید"), Display(Name = "اسم ارز")]
        public string Type { get; set; }

        [Required(ErrorMessage = "باید ارزش ریالی ارز  را وارد کنید"), Display(Name = "ارزش ریالی ارز")]
        public long RialValue { get; set; }
    }
}
