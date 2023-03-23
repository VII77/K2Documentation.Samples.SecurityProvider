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
            username = username?.Trim(new char[1] { '*' });
            var groups = await _keycloakAPI.GetGroupsByUsername(username);
            var result = new GroupCollectionDTO();
            groups.ForEach(group => result.Add(new GroupDTO(group)));
            return result;
        }

        public async Task<GroupDTO> GetGroup(string groupName)
        {
            var group = await _keycloakAPI.GetGroupByGroupName(groupName);
            return new GroupDTO(group);
        }
        public async Task<UserCollectionDTO> FindUsers(string groupName)
        {
            groupName = groupName?.Trim(new char[1] { '*' });
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
