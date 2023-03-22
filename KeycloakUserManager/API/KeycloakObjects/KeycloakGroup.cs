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
            //if (this.Attributes == null)
            //{
            //    this.Attributes = new Dictionary<string, object>()
            //{
            //    { "GroupID", this.id },
            //    { "Name", this.name },
            //    { "Email", string.Empty },
            //    { "GroupName", this.name },
            //    { "Description", string.Empty },
            //};
            //}

        }

        //public GroupDTO MapToGroupDTO()
        //{
        //    var dic = new Dictionary<string, object>()
        //    {
        //        {"Name", this.Attributes["Name"] ?? this.name },
        //        {"Email", this.Attributes["Email"] ?? string.Empty },
        //        {"Description", this.Attributes["Description"] ?? string.Empty },
        //        {"GroupName", this.Attributes["GroupName"] ?? string.Empty },
        //        {"GroupID", this.Attributes["GroupID"] ?? string.Empty }
        //    };

            //< k:group name = "Test\G1" email = "G1@test.com" fullName = "Group 1" description = "Group 1 Description" >

            //      < k:member name = "Test\U1" type = "User" />

            //         < k:member name = "Test\U2" type = "User" />

            //            < k:member name = "Test\U3" type = "User" />

            //           </ k:group >


        //    var groupDto = new GroupDTO()
        //    {
        //        GroupID = id,
        //        GroupName = name,
        //        Properties = this.Attributes
        //    };

        //    return groupDto;
        //}
    }
}
