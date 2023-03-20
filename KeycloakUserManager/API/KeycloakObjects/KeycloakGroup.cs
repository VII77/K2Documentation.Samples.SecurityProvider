using KeycloakUserManager.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.API.KeycloakObjects
{
    public class KeycloakGroup
    {
        public string id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public List<KeycloakGroup> subGroups { get; set; }
        public Dictionary<string,object> Attributes { get; set; }

        public KeycloakGroup()
        {
            if (this.Attributes == null)
            {
                this.Attributes = new Dictionary<string, object>()
            {
                { "name", null },
                { "email", null },
                { "fullName", null },
                { "description", null },
            };
            }

        }

        public GroupDTO MapToGroupDTO()
        {
            var dic = new Dictionary<string, object>()
            {
                {"name", this.Attributes["name"] ?? this.name },
                {"email", this.Attributes["email"] ?? string.Empty },
                {"fullName", this.Attributes["fullName"] ?? string.Empty },
                {"description", this.Attributes["description"] ?? string.Empty }
            };

            //< k:group name = "Test\G1" email = "G1@test.com" fullName = "Group 1" description = "Group 1 Description" >
      
            //      < k:member name = "Test\U1" type = "User" />
         
            //         < k:member name = "Test\U2" type = "User" />
            
            //            < k:member name = "Test\U3" type = "User" />
               
            //           </ k:group >


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
