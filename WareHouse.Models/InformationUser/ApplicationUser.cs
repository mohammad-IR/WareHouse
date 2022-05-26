using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WareHouse.Models.InformationUser
{
    public class ApplicationUser : IdentityUser
    {
        
        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "کارت ملی")]
        public string CodeNational { get; set; }

        [Display(Name = "کد پرسنلی")]
        public string PersonnelCode { get; set; }

        [Display(Name = "نام پدر")]
        public string FutherName { get; set; }

        [Display(Name = "تلفن ثابت")]
        public string Landline { get; set; }
        [Display(Name = "شماره داخلی اگر دارد وارد کنید")]
        public string LandlineInternalNumber { get; set; }

        [Display(Name = "تاریخ شروع به کار")]
        public DateTime StartDateToWork { get; set; }

        [Display(Name = "تاریخ تسویه حساب")]
        public DateTime EndDateToWork { get; set; }

        [Display(Name = "شماره قرارداد")]
        public string ContractNumber { get; set; }

        [ForeignKey("TitleJobId")]
        [ValidateNever]
        public TitleJobs? TitleJob { get; set; }

        [Display(Name = "عنوان کاری")]
        public int? TitleJobId { get; set; }

        [Display(Name = "پروفایل")]
        public string Profile { get; set; }

        [Display(Name = "فایل قرارداد")]
        public string ContractFile { get; set; }

        [Display(Name = "کد پستی")]
        public string PostalCode { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "شماره بیمه")]
        public string InsuranceNumber { get; set; }

        [Display(Name = "تاریخ تولد")]
        public DateTime dateOfBirth { get; set; }

        [Display(Name = "آدرس سایت")]
        public string UrlWebSite { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "استان")]
        public string State { get; set; }

        [Display(Name = "شهرستان")]
        public string City { get; set; }

        [Display(Name = "کد ثبت")]
        public string RegistrantionNumber { get; set; }

        [Display(Name = "فکس")]
        public string Fax { get; set; }


        [Display(Name = "امضاء الکترونیک")]
        public string Signature { get; set; }
    }
}
