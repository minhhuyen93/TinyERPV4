using System;

namespace TinyERP.Common.Attributes
{
    public class DbContext : System.Attribute
    {
        public Type Use { get; set; }
    }
}
