using AuthGQL.Data.Entities;
using AuthGQL.InputTypes;
using System.Linq;

namespace AuthGQL.Logics
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetEmployee();
        string AddEmployee(EmployeeInput employeeinput);
    }
}
