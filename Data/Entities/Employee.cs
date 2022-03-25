using System;
using System.ComponentModel.DataAnnotations;

namespace AuthGQL.Data.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
