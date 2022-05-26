using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Models.RawMaterials
{
    public class RelatedToProperty
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="نوع")]
        public string Name { get; set; }
        public int IdProperty { get; set; }

        [ForeignKey("IdProperty")]
        public Property Property { get; set; }

    }
}
