

namespace KeycloakUserManager.Service.DTOs
{
    using System.Collections.Generic;
    using System.Linq;
    using SourceCode.Hosting.Server.Interfaces;
    using System.Diagnostics.CodeAnalysis;
    using KeycloakUserManager.API.KeycloakObjects;

    /// <summary>
    /// The info group.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GroupDTO : IGroup
    {
        #region Fields

        /// <summary>
        /// Static property displaying all queryable properties.
        /// Queryable properties are loaded by reflection, and should be decorated with "DataMember" attribute
        /// </summary>
        private static Dictionary<string, string> propertyNames = (from property in typeof(GroupDTO).GetProperties()
                                                                   where property.GetCustomAttributes(true).Any()
                                                                   select property)
                                                                    .ToDictionary(p => p.Name, t => "System.String");

        /// <summary>
        /// The properties.
        /// </summary>
        private IDictionary<string, object> properties = new Dictionary<string, object>();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoGroup" /> class
        /// </summary>
        public GroupDTO()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoGroup" /> class
        /// </summary>
        /// <param name="securityLabel">The K2 security label</param>
        /// <param name="groupData">The <see cref="SimplexInfoGroup"/></param>
        public GroupDTO(KeycloakGroup keycloakGroup)
        {
            this.GroupID = keycloakGroup.id;
            this.Name = keycloakGroup.name;
            this.GroupName = keycloakGroup.name;
            this.Description = string.Empty;
            this.Email = string.Empty;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the property names
        /// </summary>
        public static Dictionary<string, string> PropertyNames
        {
            get
            {
                return propertyNames;
            }
        }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        public IDictionary<string, object> Properties
        {
            get
            {
                return this.properties;
            }

            set
            {
                this.properties = value;
            }
        }

        #region Required properties for K2

        /// <summary>
        /// Gets or sets the group id.
        /// </summary>
        public string GroupID
        {
            get
            {
                return this["GroupID"] as string;
            }

            set
            {
                this["GroupID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        public string GroupName
        {
            get
            {
                return this["GroupName"] as string;
            }

            set
            {
                this["GroupName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this["Name"] as string;
            }

            set
            {
                this["Name"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this["Description"] as string;
            }

            set
            {
                this["Description"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the group email
        /// </summary>
        public string Email
        {
            get
            {
                return this["Email"] as string;
            }

            set
            {
                this["Email"] = value;
            }
        }

        #endregion

        /// <summary>
        /// Indexed property
        /// </summary>
        /// <param name="key">Property to retreive from the property dictionary</param>
        /// <returns>Value associated to the specified key</returns>
        protected object this[string key]
        {
            get
            {
                return this.properties.ContainsKey(key) ? this.properties[key] : null;
            }

            set
            {
                if (this.properties.ContainsKey(key))
                {
                    this.properties[key] = value;
                }
                else
                {
                    this.properties.Add(key, value);
                }
            }
        }

        #endregion
    }
}
