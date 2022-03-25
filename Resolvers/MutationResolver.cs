using AuthGQL.Data.Entities;
using AuthGQL.InputTypes;
using AuthGQL.Logics;
using AuthGQL.Model;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthGQL.Resolvers
{
    public class MutationResolver
    {
        public string Register([Service] IAuthLogic authLogic, RegisterInput registerInput)
        {
            return authLogic.Register(registerInput);
        }

        public TokenResponseModel Login([Service] IAuthLogic authLogic, LoginInput loginInput)
        {
            return authLogic.Login(loginInput);
        }

        public TokenResponseModel RenewAccessToken([Service] IAuthLogic authLogic, RenewTokenInput renewToken)
        {
            return authLogic.RenewAccessToken(renewToken);
        }

        public string AddEmployee([Service] IEmployeeService employeeService, EmployeeInput employeeInput)
        {
            return employeeService.AddEmployee(employeeInput);
        }
    }
}
