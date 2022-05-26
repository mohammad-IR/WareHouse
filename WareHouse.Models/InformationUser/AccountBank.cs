using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Models.InformationUser
{
    public class AccountBank
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام بانک")]
        public string NameBank { get; set; }

        [Display(Name = "شماره حساب")]
        public string AccountNumber { get; set; }

        [Display(Name = "شماره شبا")]
        public string ShabaNumber { get; set; }

        [Display(Name = "شماره کارت")]
        public string CardNumber { get; set; }

        [Display(Name ="صاحب حساب")]
        [ForeignKey("OwnerAccountId")]
        public ApplicationUser OwnerAccount { get; set; }
        public String OwnerAccountId { get; set; }


    }
}
