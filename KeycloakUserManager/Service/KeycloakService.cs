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
            var search = username.StartsWith("*") || username.EndsWith("*");
            username = username?.Trim(new char[1] { '*' });
            var groups = await _keycloakAPI.GetGroupsByUsername(username, search);
            var result = new GroupCollectionDTO();
            groups.ForEach(group => result.Add(new GroupDTO(group)));
            return result;
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
    }
}
