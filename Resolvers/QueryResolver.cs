using AuthGQL.Data;
using AuthGQL.Data.Entities;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthGQL.Resolvers
{
    public class QueryResolver
    {
        //[Authorize(Policy = "claim-policy")]
        [Authorize]
        public string Welcome()
        {
            return "Welcome To Custom Authentication Servies In GraphQL In Pure Code First";
        }

        [Authorize(Roles = new[] { "admin" })]
        [UseDbContext(typeof(AuthContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUser([Service] AuthContext context)
        { 
            return context.Users.AsQueryable();
        }

        [Authorize(Roles = new[] { "admin" })]
        [UseDbContext(typeof(AuthContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Employee> GetEmployee([Service] AuthContext context)
        {
            
            return context.Employees.AsQueryable();
        }
    }
}
