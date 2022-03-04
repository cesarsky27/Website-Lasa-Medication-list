using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Siloam.Service.LasaMedication.Common;
using Siloam.Service.LasaMedication.Repositories;

namespace Siloam.Service.LasaMedication.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        //mendaftarkan dan mapping class repository yang digunakan
        internal DatabaseContext Context;
        //private ApplicationRepository Application_Repository;

        private LasaRepository Lasa_Repository;
        private UserRepository User_Repository;

        public UnitOfWork(DatabaseContext _context)
        {
            Context = _context;
        }

        //add new data

        //public ApplicationRepository UnitOfWork_Shg_application()
        //{
        //    if (Application_Repository == null)
        //    {
        //        Application_Repository = new ApplicationRepository(Context);
        //    }
        //    return Application_Repository;
        //}

        public LasaRepository UnitOfWork_TR_Lasa()
        {
            if (Lasa_Repository == null)
            {
                Lasa_Repository = new LasaRepository(Context);
            }

            return Lasa_Repository;
        }

        public UserRepository UnitOfWork_MS_User()
        {
            if (User_Repository == null)
            {
                User_Repository = new UserRepository(Context);
            }

            return User_Repository;
        }

        //public LasaRepository UnitOfData_Lasa()
        //{

        //}

        //end new data

        public bool Disposing;
        private void DisposingProperties()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        protected virtual void Disposed(bool _disposing)
        {
            if (!Disposing)
            {
                if (_disposing)
                {
                    DisposingProperties();
                }
            }

            Disposing = true;
        }

        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }
    }
}
