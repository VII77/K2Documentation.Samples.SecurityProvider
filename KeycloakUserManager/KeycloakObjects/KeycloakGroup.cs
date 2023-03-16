using KeycloakUserManager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.KeycloakObjects
{
    public class KeycloakGroup
    {
        public string id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public List<KeycloakGroup> subGroups { get; set; }

        public GroupDTO MapToGroupDTO()
        {
            var dic = new Dictionary<string, object>();
            var groupDto = new GroupDTO()
            {
                GroupID = id,
                GroupName = name,
                Properties = dic
            };

            return groupDto;
        }
    }
}
