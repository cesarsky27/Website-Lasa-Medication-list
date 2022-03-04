using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Siloam.Service.LasaMedication.Repositories;

namespace Siloam.Service.LasaMedication.Common
{
    public interface IUnitOfWork : IDisposable
    {
        //mendaftarkan class repository yang digunakan
        //ApplicationRepository UnitOfWork_Shg_application();
        LasaRepository UnitOfWork_TR_Lasa();

        UserRepository UnitOfWork_MS_User();
    }
}
