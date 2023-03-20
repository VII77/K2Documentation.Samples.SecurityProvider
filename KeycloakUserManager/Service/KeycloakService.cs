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

        public async Task<GroupCollectionDTO> FindGroups(string username)
        {
            var groups = await _keycloakAPI.GetGroupsByUsername(username);
            var result = new GroupCollectionDTO();
            groups.ForEach(group => result.Add(group.MapToGroupDTO()));
            return result;
        }

        public async Task<GroupDTO> GetGroup(string groupName)
        {
            var group = await _keycloakAPI.GetGroupByGroupName(groupName);
            return group.MapToGroupDTO();
        }
        public async Task<UserCollectionDTO> FindUsers(string groupName)
        {
            var users = await _keycloakAPI.GetGroupMembers(groupName);
            var result = new UserCollectionDTO();
            users.ForEach(user => {
            if (user != null)
            {
                result.Add(user.MapToUserDTO());
            }});

            return result;
        }

        public async Task<UserDTO> GetUser(string username)
        {
            var user = await _keycloakAPI.GetUserByUsername(username);
            return user?.MapToUserDTO();
        }
    }
}
