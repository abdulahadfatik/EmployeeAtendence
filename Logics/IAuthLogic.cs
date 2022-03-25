using AuthGQL.Data.Entities;
using AuthGQL.InputTypes;
using AuthGQL.Model;

namespace AuthGQL.Logics
{
    public interface IAuthLogic
    {
        string Register(RegisterInput registerInput);
        TokenResponseModel Login(LoginInput loginInput);
        TokenResponseModel RenewAccessToken(RenewTokenInput renewToken);
        
    }
}
