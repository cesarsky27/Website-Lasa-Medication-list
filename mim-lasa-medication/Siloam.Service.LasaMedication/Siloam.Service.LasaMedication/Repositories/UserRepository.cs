﻿using Siloam.Service.LasaMedication.Common;
using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModel;
using Siloam.Service.LasaMedication.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Siloam.Service.LasaMedication.Repositories
{
    public class UserRepository : DatabaseConfig, IUserRepository
    {
        public UserRepository() : base() 
        { }

        public UserRepository (DatabaseContext context) : base (context)
        {}

        public IEnumerable<ViewLogin> Login_User(ParamLogin paramLogin)
        {
            IEnumerable<ViewLogin> data;
            using (SqlConnection conn = new SqlConnection(Siloam.System.ApplicationSetting.ConnectionString))
            {
                var hashPassword = EncryptDecrypt.Encrypt(paramLogin.password);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "spLogin_Lasa";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("UserName", paramLogin.username));
                cmd.Parameters.Add(new SqlParameter("UserPassword", hashPassword));
                using (var reader = cmd.ExecuteReader())
                {
                    data = reader.MapToList<ViewLogin>();

                }
            }
            return data;
        }

        
    }
}
