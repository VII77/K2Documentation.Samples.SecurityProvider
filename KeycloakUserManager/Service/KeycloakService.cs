using KeycloakUserManager.API;
using KeycloakUserManager.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.Service
{

    public class KeycloakService
    {
        private KeycloakAPI _keycloakAPI;

        public KeycloakService(KeycloakAPI keycloakAPI)
        {
            _keycloakAPI = keycloakAPI;
        }

        public async Task<GroupCollectionDTO> FindGroups(string groupname)
        {
            groupname = groupname?.Trim(new char[1] { '*' });
            var groups = await _keycloakAPI.GetGroupsByGroupName(groupname);
            var result = new GroupCollectionDTO();
            groups.ForEach(group => result.Add(new GroupDTO(group)));
            return result;
        }

        public async Task<UserCollectionDTO> FindUsers(string username)
        {
            var search = username.StartsWith("*") || username.EndsWith("*");
            username = username?.Trim(new char[1] { '*' });
            var users = await _keycloakAPI.GetUsersByUsername(username, search);
            var result = new UserCollectionDTO();
            users.ForEach(group => result.Add(new UserDTO(group)));
            return result;

        }
    }
}
