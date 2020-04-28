namespace TinyERP.Common.Data
{
    using System;
    using System.Reflection;
    using TinyERP.Common.Attributes;
    using TinyERP.Common.Helpers;
    public class DbContextFactory
    {
        public static IDbContext Create<TEntity>()
        {
            Type dbType = AssemblyHelper.GetType<IDbContext>();
            return AssemblyHelper.CreateInstance<IDbContext>(dbType);
        }
        public static IDbContext CreateContext<TEntity>()
        {
            DbContextAttribute dbContextAttribute = ObjectHelper.GetAttribute<DbContextAttribute>(typeof(TEntity));
            if (dbContextAttribute == null || dbContextAttribute.Use == null)
            {
                throw new Exception("Can not create dbContext");
            }
            MethodInfo createMethod = typeof(DbContextFactory).GetMethod("Create", BindingFlags.Static | BindingFlags.InvokeMethod | BindingFlags.Public);
            MethodInfo genericMethod = createMethod.MakeGenericMethod(new[] { dbContextAttribute.Use });
            IDbContext dbContext = (IDbContext)genericMethod.Invoke(null, new object[] { });
            return dbContext;
        }
    }
}
