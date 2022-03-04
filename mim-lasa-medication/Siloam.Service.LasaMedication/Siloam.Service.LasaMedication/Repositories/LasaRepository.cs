using Siloam.Service.LasaMedication.Common;
using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModel;
using Siloam.Service.LasaMedication.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
//using Syste

namespace Siloam.Service.LasaMedication.Repositories
{
    public class LasaRepository : DatabaseConfig, ILasaRepository
    {
        public LasaRepository() : base()
        { }

        public LasaRepository(DatabaseContext Context) : base(Context)
        { }

        

        //linq query select data basic
        public IEnumerable<CekLasa> GetAllData_Lasa()
        {
            IEnumerable<CekLasa> data;
            using (SqlConnection conn = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "spGetData_Lasa";
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    data = reader.MapToList<CekLasa>();
                  
                }
            }

            return data;
        }

        public IEnumerable<CekLasa> GetLasaById(Int64 SalesItemId)
        {
            {
                IEnumerable<CekLasa> data;
                using (SqlConnection conn = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
                {
                    //var hashPassword = EncryptDecrypt.Encrypt(paramLogin.password);
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "spGetDataById_Lasa";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("InputSalesItemId", SalesItemId));
                    cmd.CommandTimeout = 0;


                    using (var reader = cmd.ExecuteReader())
                    {
                        data = reader.MapToList<CekLasa>();

                    }
                }
                return data;
            }
        }

        public IEnumerable<ResponseLasa> PostLasa(ParamLasa paramLasa)
        {
            IEnumerable<ResponseLasa> data;
            using (SqlConnection conn = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
            {
                //var hashPassword = EncryptDecrypt.Encrypt(paramLogin.password);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "spPostData_Lasa";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("InputSalesItemId", paramLasa.InputSalesItemId));
                cmd.Parameters.Add(new SqlParameter("InputIsLasa", paramLasa.InputIsLasa));
                cmd.Parameters.Add(new SqlParameter("InputUserId", paramLasa.InputUserId));

                using (var reader = cmd.ExecuteReader())
                {
                    data = reader.MapToList<ResponseLasa>();

                }
            }
            return data;
        }

        //public IEnumerable<CekLasa> GetLasaById(Int64 SalesItemId)
        //{
        //    IEnumerable<CekLasa> data;
        //    using (SqlConnection conn = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
        //    {
        //        //var hashPassword = EncryptDecrypt.Encrypt(paramLogin.password);
        //        conn.Open();
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "spGetDataById_Lasa";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add(new SqlParameter("InputSalesItemId",SalesItemId));
              

        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            data = reader.MapToList<CekLasa>();

        //        }
        //    }
        //    return data;
        //}

    }
}
