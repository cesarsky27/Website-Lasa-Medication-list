using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Repositories.IRepositories
{
    interface IUserRepository
    {
        IEnumerable<ViewLogin> Login_User(ParamLogin paramLogin);
        
    }
}
