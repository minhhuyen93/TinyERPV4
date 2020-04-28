namespace TinyERP.Common.Enums
{
    public class ApplicationConts
    {
        public const string RegexConts = "TinyERP.|Inventory|Security";
    }
    public enum ApplicationType
    {
        WebApi = 1,
        All = 4
    }
    public enum IOMode
    {
        ReadOnly = 1,
        Write = 2
    }
    public enum TaskPriority
    {
        Medium= 30,
        Normal= 50,
        High =70
    }
    public class ModuleConfiguration
    {
        public const string InventoryModule = "InventoryModule";
        public const string SecurityModule = "SecurityModule";
    }
    public class ApplicationActionResultType
    {
        public const string EmptyResult = "EmptyResult";
    }
}
