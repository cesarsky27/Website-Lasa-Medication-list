using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Siloam.Service.LasaMedication.Models;
using Siloam.Service.LasaMedication.Models.ViewModel;
using Steeltoe.Discovery.Eureka.AppInfo;

namespace Siloam.Service.LasaMedication.Common
{
    public class DatabaseContext : DbContext
    {
        //deklarasi variable untuk setiap table
        public DbContextOptions<DatabaseContext> options;
        //public DbSet<Application> Application_DataSet { get; set; }
        public DbSet <Lasa> Lasa_DataSet { get; set; }

        public DbSet <User> User_DataSet { get; set; }
        


        public DatabaseContext() : base()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> _options) : base(_options)
        {
            options = _options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //mapping variable ke setiap table yang ada di database
            //builder.Entity<Application>().ToTable("shg_application").HasKey(m => new { m.application_id } );
            builder.Entity<Lasa>().ToTable("TR_Lasa").HasKey (m => new { m.LasaId });
            builder.Entity<User>().ToTable("MS_User").HasKey(m => new { m.UserId });
            
            base.OnModelCreating(builder);
        }
    }
}
