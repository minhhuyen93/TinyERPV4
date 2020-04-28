
namespace Inventory.Enums
{
    public enum ProductValidationRules
    {
        MinLength = 5,
        MaxLength = 50,
        Zero = 0
    }
    public class InventoryConfiguration
    {
        public const string DbConnection = "InventoryModule";
    }
}
