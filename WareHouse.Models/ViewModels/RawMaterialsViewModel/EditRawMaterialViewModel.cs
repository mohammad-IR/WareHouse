using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Models.RawMaterials;

namespace WareHouse.Models.ViewModels.RawMaterialsViewModel
{
    public class EditRawMaterialViewModel
    {
        public RawMaterials.RawMaterial RawMaterial { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; }

        public IEnumerable<CurrenciesPrice.CurrencyPrice> Currenies { get; set; }

        public IEnumerable<Property> Properties { get; set; }
        public IEnumerable<RelatedToProperty> RelatedToProperties { get; set; }
    }
}
