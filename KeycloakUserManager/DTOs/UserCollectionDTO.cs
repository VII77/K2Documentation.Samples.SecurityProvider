using SourceCode.Hosting.Server.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeycloakUserManager.DTOs
{
    public class UserCollectionDTO : List<IUser>, IUserCollection
    {
        public new IUser this[int index] => base[index];

        public new IEnumerator GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
