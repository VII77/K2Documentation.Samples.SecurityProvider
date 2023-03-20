namespace KeycloakUserManager
{
    using KeycloakUserManager.API;
    using KeycloakUserManager.API.KeycloakObjects;
    using KeycloakUserManager.Service;
    using KeycloakUserManager.Service.DTOs;
    using SourceCode.Hosting.Server.Interfaces;
    using SourceCode.Logging;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;

    [ExcludeFromCodeCoverage]
    public class KeycloakSecurityProvider : IHostableSecurityProvider
    {
        ///<summary>
        /// Local authInitData variable used to reference the authentication initialization data provided by Init().
        ///</summary>
        private string _authInitData = string.Empty;
        ///<summary>
        /// Local configurationManager variable used to reference the marshaled configuration manager from Init().
        ///</summary>
        private IConfigurationManager _configurationManager = null;
        ///<summary>
        /// Local securityManager variable used to reference the marshaled security manager from Init().
        ///</summary>
        private ISecurityManager _securityManager = null;
        ///<summary>
        /// Local securityLabel variable used to reference the assigned security label from Init().
        ///</summary>
        private string _securityLabel = string.Empty;

        public string SecurityLabel
        {
            get
            {
                return _securityLabel;
            }
        }

        ///<summary>
        /// K2 logging context
        ///</summary>
        private Logger _logger = null;

        ///<summary>
        /// Instantiates a new SecurityProvider.
        ///</summary>
        public KeycloakSecurityProvider()
        {
            // No implementation necessary.
        }

        ///<summary>
        /// Initializes the security provider.
        ///</summary>
        ///<param name="ServiceMarshalling">An IServiceMarshalling representing the service marshaling.</param>
        ///<param name="ServerMarshaling">An IServerMarshaling representing the server marshaling.</param>
        public void Init(IServiceMarshalling ServiceMarshalling, IServerMarshaling ServerMarshaling)
        {
            // Get configuration manager from service marshaling.
            _configurationManager = ServiceMarshalling.GetConfigurationManagerContext();
            // Get security manager from server marshaling.
            _securityManager = ServerMarshaling.GetSecurityManagerContext();
            //set up loggingthis._logger = (Logger)ServiceMarshalling.GetHostedService(typeof(Logger).ToString());
        }

        ///<summary>
        /// Initializes the security provider"s authentication subsystem. Uses the values set up in the K2 database
        ///</summary>
        ///<param name="label">A string representing the assigned security label.</param>
        ///<param name="authInit">A string representing any additional authentication initialization data.</param>
        public void Init(string label, string authInit)
        {
            _securityLabel = label;
            _authInitData = authInit;
        }

        ///<summary>
        /// Determines if authentication is required.
        ///</summary>
        ///<returns>Returns true if the security provider requires authentication, otherwise returns false.</returns>
        public bool RequiresAuthentication()
        {
            //TODO: If this security provider requires that users authenticate, return true, otherwise return false.
            return true;
        }

        ///<summary>
        /// Unloads the security provider and releases any resources held.
        ///</summary>
        public void Unload()
        {
            //TODO: Add clean up code here. Make sure to dispose of any data connections.
            _configurationManager = null;
            _securityManager = null;
        }

        ///<summary>
        /// Authenticates a user.
        ///</summary>
        ///<param name="userName">A string representing the user"s username.</param>
        ///<param name="password">A string representing the user"s password.</param>
        ///<param name="extraData">string of additional, free-text data that you can use in the authentication method</param>
        ///<returns>Returns true if the user is successfully authenticated, otherwise returns false.</returns>
        public bool AuthenticateUser(string userName, string password, string extraData)
        {
            bool authenticated = false;
            //TODO: Add user authentication code here and remove the NotImplementedException.
            //Return true if the user was successfully authenticated, false if the user is not successfully authenticated
            //Return true if the security provider is not used for authentication. do NOT throw a NotImplementException here
            //Note: this method is called when the security provider is used with SSO. the username and password paramters
            //will be the decrypted SSO-stored username and password that the user entered when caching their SSO credentials
            //in K2 workspace
            try
            {
                //sample of logging debug output
                _logger.LogDebugMessage(base.GetType().ToString() + ".AuthenticateUser", "Authenticating: " + userName);

            }
            catch (Exception ex)
            {
                //sample of logging debug output
                _logger.LogErrorMessage(base.GetType().ToString() + ".AuthenticateUser error", "Error: " + ex.Message);
            }
            return authenticated;
        }

        ///<summary>
        /// Logs in a user using the provided connection string. Does not need to be implemented: required for backward compatability only
        ///</summary>
        ///<param name="connectionString">A string representing the connection string to use for the login operation.</param>
        ///<returns>A string representing the authenticated user"s username.</returns>
        ///<remarks>
        /// Method only included for backward compatibility. Method always throws a NotImplementedException.
        ///</remarks>
        ///<exception cref="System.NotImplementedException" />
        public string Login(string connectionString)
        {
            // Does not need to be implemented unless you use the K2.net 2003 ROM dll
            throw new NotImplementedException();
        }

        ///<summary>
        /// Finds and returns the given user"s groups.
        ///</summary>
        ///<param name="userName">A string representing the username of the user whose groups should be returned.</param>
        ///<param name="properties">An IDictionary representing the properties used to filter the groups returned.</param>
        ///<returns>An IGroupCollection representing the groups which were found.</returns>
        public IGroupCollection FindGroups(string userName, IDictionary<string, object> properties)
        {
            //TODO: Add code to retrieve groups for a specific user

            throw new NotImplementedException();

        }

        ///<summary>
        /// Finds and returns the groups for a specific user
        ///</summary>
        ///<param name="userName">A string representing the username of the user whose groups should be returned.</param>
        ///<param name="properties">An IDictionary representing the properties used to filter the groups returned.</param>
        ///<param name="extraData">A string representing any extra data which may which may be needed.</param>
        ///<returns>An IGroupCollection representing the groups which were found.</returns>
        public IGroupCollection FindGroups(string userName, IDictionary<string, object> properties, string extraData)
        {
            //TODO: Add group retrieval code for a specific user, using extradata

            //throw new NotImplementedException();
            //if this method is not implemented in your security provider

            //if necessary, use the extraData parameter to perform additional processing

            return FindGroups(userName, properties);
        }

        ///<summary>
        /// Gets a group.
        ///</summary>
        ///<param name="name">A string representing the name of the group to retrieve.</param>
        ///<returns>Returns an IGroup representing the group if the group is found, otherwise returns null.</returns>
        public IGroup GetGroup(string name)
        {
            //TODO: Add group retrieval code here and remove the NotImplementedException

            throw new NotImplementedException();

        }

        ///<summary>
        /// Gets a single group using the Name parameter along with free-form extra data
        ///</summary>
        ///<param name="name">A string representing the name of the group to retrieve.</param>
        ///<param name="extraData">A string representing any extra data which may which may be needed.</param>
        ///<returns>Returns an IGroup representing the group if the group is found, otherwise returns null.</returns>
        public IGroup GetGroup(string name, string extraData)
        {
            //TODO: Add group retrieval code here and remove the NotImplementedException
            //use the extra data to perform any additional processing that may be required

            //throw new NotImplementedException();
            //if this method is not implemented in your security provider

            return GetGroup(name);
        }

        ///<summary>
        /// Retrieves the common properties and their types for a Group.
        /// This method is only used to list the possible Properties for a Group
        ///</summary>
        ///<returns>A Dictionary containing the general group properties.</returns>
        public Dictionary<string, string> QueryGroupProperties()
        {
            Dictionary<string, string> groupProps = new Dictionary<string, string>();
            groupProps.Add("Name", "System.String");
            groupProps.Add("Description", "System.String");
            groupProps.Add("Another Group Property", "System.String");

            return groupProps;
        }

        ///<summary>
        /// Finds and returns the given group"s users.
        ///</summary>
        ///<param name="groupName">A string representing the group name of the group for which users should be returned. Could include wildcards (Starts with: *xyz, End with: xyz*, Contains: *xyz*)</param>
        ///<param name="properties">An IDictionary representing the properties used to filter the users returned. You can add additional filter properties to this collection</param>
        ///<returns>An IUserCollection representing the users which were found.</returns>
        public IUserCollection FindUsers(string groupName, IDictionary<string, object> properties)
        {
            //TODO: Add the code to retrieve a collection of users based on a group name and remove the NotImplementedException
            return this.FindUsers(groupName, properties, null);
        }

        ///<summary>
        /// Finds and returns the given group"s users. Extends the standard FindUsers method by adding a free-form ExtraData
        /// value that you can use in your own code.
        ///</summary>
        ///<param name="groupName">A string representing the group name of the group for which users should be returned. Could include wildcards</param>
        ///<param name="properties">An IDictionary representing the properties used to filter the users returned. You can add additional filter properties to this collection</param>
        ///<param name="extraData">A string representing any extra data which may which may be needed.</param>
        ///<returns>An IUserCollection representing the users which were found.</returns>
        public IUserCollection FindUsers(string groupName, IDictionary<string, object> properties, string extraData)
        {
            var httpClient = new HttpClient();
            var configData = new ConfigurationData();
            var keycloakapi = new KeycloakAPI(httpClient, configData);
            var keycloakService = new KeycloakService(keycloakapi);

            var task = keycloakService.FindUsers(groupName);
            task.Wait();
            var users = task.Result;

            //UserDTO x = null;
            //if (users.Count > 0)
            //{
            //    x = (UserDTO)users[0];
            //}

            //var email = x.Properties["email"];

            //foreach (UserDTO u in users)
            //{
            //    u.
            //}

            //Dictionary<string, object> matthewProperties = new Dictionary<string, object>
            //{
            //    { "UserPrincipalName", "matthew.vorster@nintex.com" },
            //    { "Name", "matthew.vorster@nintex.com" },
            //    { "Description", "Matthew Test Account" },
            //    { "Email", email },
            //    { "DisplayName", "Matthew Vorster" },
            //    { "CommonName", "U1" },
            //    { "ObjectSID", "11342" },
            //};


            //Console.WriteLine("**** FindUsers CALLED ****");

            //UserCollectionDTO retCol = new UserCollectionDTO();
            //UserDTO user = new UserDTO
            //{
            //    UserID = "c613c096-ef29-4394-b3c1-778a0f61b37e",
            //    UserName = "matthew.vorster@nintex.com",
            //    Properties = matthewProperties
            //};

            //user.UserName = x.UserName;
            
            //retCol.Add(user);

            return users;
        }

        ///<summary>
        /// Gets a single user using the Name parameter to locate the user.
        ///</summary>
        ///<param name="name">A string representing the name of the user to retrieve.</param>
        ///<returns>Returns an IUser representing the user if the user is found, otherwise returns null.</returns>
        public IUser GetUser(string name)
        {
            //TODO: Add user retrieval code here and remove the NotImplementedException

            throw new NotImplementedException();

        }

        ///<summary>
        /// Gets a single user using the Name parameter along with extra data to locate the user.
        ///</summary>
        ///<param name="name">A string representing the name of the user to retrieve.</param>
        ///<param name="extraData">A string representing any extra data which may which may be needed.</param>
        ///<returns>Returns an IUser representing the user if the user is found, otherwise returns null.</returns>
        public IUser GetUser(string name, string extraData)
        {
            //TODO: Add user retrieval code here and remove the NotImplementedException

            //throw new NotImplementedException();
            //if your security provider does not implement this method

            return GetUser(name);
        }

        ///<summary>
        /// Retrieves the common properties and their types for a User.
        /// This method is only used to list the possible Properties for a user object
        ///</summary>
        ///<returns>A Dictionary containing the general user properties.</returns>
        public Dictionary<string, string> QueryUserProperties()
        {
            Dictionary<string, string> userProperties = new Dictionary<string, string>();
            userProperties.Add("Name", "System.String");
            userProperties.Add("Description", "System.String");
            userProperties.Add("Email", "System.String");
            userProperties.Add("Manager", "System.String");
            userProperties.Add("AdditionalCustomProperties", "String.Empty");

            return userProperties;
        }

        ///<summary>
        /// Formats an item"s name.
        ///</summary>
        ///<param name="name">A string representing the item name to format.</param>
        ///<returns>A string representing the formatted item name.</returns>
        public string FormatItemName(string name)
        {
            // Add item name formatting code here, if required

            // throw new NotImplementedException();
            // if your security provider does not implement this method

            return name;
        }

        ///<summary>
        /// Resolves the queue based on the provided queue data. Not implemented.
        ///</summary>
        ///<param name="data">A string representing the queue data to resolve.</param>
        ///<returns>An ArrayList representing the resolved queue data.</returns>
        ///<remarks>
        /// Method included for backward compatibility. Method always throws a NotImplementedException.
        ///</remarks>
        ///<exception cref="System.NotImplementedException" />
        public ArrayList ResolveQueue(string data)
        {
            //throw new NotImplementedException();
            //if your security provider does not implement this method
            try
            {
                //sample of logging debug output
                _logger.LogDebugMessage(base.GetType().ToString() + ".ResolveQueue", "Data: " + data);
            }
            catch (Exception ex)
            {
                //sample of logging error output
                _logger.LogErrorMessage(base.GetType().ToString() + ".ResolveQueue error", "Data: " + data + " Error: " + ex.Message);
            }
            return null;
        }
    }
}
