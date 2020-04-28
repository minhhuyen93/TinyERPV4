namespace TinyERP.Common.Config
{
    public class SystemConfiguration
    {
        public DataBaseConnections DataBaseConnections { get; set; }
    }

    public class DataBaseConnections
    {
        public InventoryModule InventoryModule { get; set; }
        public SecurityModule SecurityModule { get; set; }
    }
    public class InventoryModule
    {
        public string ConnectionString { get; set; }
    }
    public class SecurityModule
    {
        public string ConnectionString { get; set; }
    }
}
