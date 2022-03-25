using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthGQL.InputTypes
{
    public class EmployeeInput
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
