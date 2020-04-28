using Security.Aggregate;
using System.Collections.Generic;

namespace Security.Repositories
{
    public interface ISecurityRepository
    {
        User GetUserByUserNameAndPwd(string userName, string password);
        IList<User> GetAlls();
        User GetByUserName(string userName);
        void Create(User user);
    }
}
