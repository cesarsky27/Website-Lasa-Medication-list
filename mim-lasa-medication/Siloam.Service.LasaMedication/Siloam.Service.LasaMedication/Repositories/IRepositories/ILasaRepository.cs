using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Repositories.IRepositories
{
    interface ILasaRepository
    {
        IEnumerable<CekLasa> GetAllData_Lasa();
        IEnumerable<CekLasa> GetLasaById(Int64 SalesItemId);
    }
}
