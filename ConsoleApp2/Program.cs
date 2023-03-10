using SampleSecurityProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var keycloakapi = new KeycloakApi("");
            keycloakapi.GetUserById("asdf");
        }
    }
}
