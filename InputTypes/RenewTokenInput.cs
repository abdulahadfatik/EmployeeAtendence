using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthGQL.InputTypes
{
    public class RenewTokenInput
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
