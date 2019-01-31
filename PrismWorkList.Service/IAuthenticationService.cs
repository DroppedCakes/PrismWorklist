using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWorkList.Service
{
    public interface IAuthenticationService
    {
        bool TryLoginAuthorization(string id, string password);
    }
}
