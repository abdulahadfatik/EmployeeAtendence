using AuthGQL.Data.Entities;
using AuthGQL.InputTypes;
using System.Linq;

namespace AuthGQL.Logics
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();

    }
}
