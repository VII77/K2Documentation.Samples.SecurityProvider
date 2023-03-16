using SourceCode.Hosting.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.DTOs
{
    public class GroupDTO : IGroup
    {
        public IDictionary<string, object> Properties { get; set; }
        public string GroupName { get; set; }
        public string GroupID { get; set; }

    }
}
