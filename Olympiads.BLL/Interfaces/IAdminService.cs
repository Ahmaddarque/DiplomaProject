using Olympiads.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Interfaces
{
    public interface IAdminService
    {
        AdminLoggedDTO Login(AuthAdminDTO auth);
        void ChangeCredentials(ChangeCredentialsDTO credentials);
        AdminInfo GetAdminInfo(int AdminId);
    }
}
