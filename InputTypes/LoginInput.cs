using System.ComponentModel.DataAnnotations;

namespace AuthGQL.InputTypes
{
    public class LoginInput
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
