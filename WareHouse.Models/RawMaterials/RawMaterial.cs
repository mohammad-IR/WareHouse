using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Models.CurrenciesPrice;
using WareHouse.Models.InformationUser;

namespace WareHouse.Models.RawMaterials
{
    public class RawMaterial
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="هدد شناسایی محصول باید وارد بشود"),Display(Name = "عدد شناسایی محصول")]
        [MaxLength(255, ErrorMessage ="طول عدد شناسایی بیشتر از حد مجاز است")]
        public string PartNumber { get; set; }

        [Required(ErrorMessage = "شناسه محصول باید وارد بشود"), Display(Name = "شناسه محصول")]
        [MaxLength(255, ErrorMessage = "طول شناسه محصول بیشتر از حد مجاز است")]
        public string IdMaterial { get; set; }

        [Required(ErrorMessage ="تعداد را وارد کنید"), Display(Name = "تعداد")]
        public int NumberOfMaterial { get; set; }

        [Required(ErrorMessage = "محدود هشدار محصول باید وارد بشود"), Display(Name = "مقداری که از آن کمتر شد باید خبر بدهد ")]
        public int Limit { get; set; }

        [Required(ErrorMessage ="تامین کننده نباید خالی باشد"), Display(Name = "تامین کننده")]
        public string SupplierId { get; set; }

        [ValidateNever]
        public ApplicationUser Supplier { get; set; }

        [Display(Name = "تاریخ خرید شمسی")]
        [Required(ErrorMessage ="تاریخ خرید رو ثبت کنید ")]
        public DateTime DateOfBuy { get; set; }

        [Display(Name = "قیمت ریالی"), Required(ErrorMessage = "یا قیمت ریالی یا ارزی را وارد کنید")]
        public long PriceIR { get; set; }

        [Display(Name = "قیمت ارزی"), Required(ErrorMessage = "یا قیمت ریالی یا ارزی را وارد کنید")]
        public int CurrencyPriceId { get; set; }

        [ForeignKey("CurrencyPriceId")]
        [ValidateNever]
        public CurrencyPrice CurrencyPriceType { get; set; }

        [Display(Name = "قیمت ارزی"), Required(ErrorMessage ="قیمت ارزی را وارد نکردید")]
        public float CurrencyPrice { get; set; }



    }
}
