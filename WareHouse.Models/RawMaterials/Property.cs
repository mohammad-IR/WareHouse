using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Models.RawMaterials
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "نام ویژگی")]
        public string Name { get; set; }


        public int RawMaterialId { get; set; }
        [ForeignKey("RawMaterialId")]
        public RawMaterial RawMaterial { get; set; }


        public IList<RelatedToProperty> RelatedToProperties { get; set; }

    }
}
