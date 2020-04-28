using Inventory.Enums;
using TinyERP.Common.Attributes;

namespace Inventory.Command
{
    public class CreateProductRequest
    {
        [Required("inventory.addOrEdit.nameWasRequired")]
        [MinLength("inventory.addOrEdit.nameWasUnderMinLenght", (int)ProductValidationRules.MinLength)]
        [MaxLength("inventory.addOrEdit.nameWasExceedMaxLength", (int)ProductValidationRules.MaxLength)]
        public string Name { get; set; }
        [Required("inventory.addOrEdit.quantityWasRequired")]
        public int Quantity { get; set; }
        [Required("inventory.addOrEdit.priceWasRequired")]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
