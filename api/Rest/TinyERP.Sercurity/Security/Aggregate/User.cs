namespace Security.Aggregate
{
    using Security.Context;
    using TinyERP.Common.Attributes;

    [DbContextAttribute(Use = typeof(ISecurityDbContext))]
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
