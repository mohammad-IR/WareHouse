using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Models.InformationUser
{
    public  class TitleJobs
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string title{ get; set; }
    }
}
