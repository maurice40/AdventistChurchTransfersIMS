using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ACTMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserRole { get; set; }
        public string Names { get; set; }
        public string Levels { get; set; }
        public string  Email { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet <Christian> christians { get; set; }
        public DbSet<Church> churches { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Request> Requests { get; set; }
       


        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<ACTMS.Models.Logs> Logs { get; set; }

        public System.Data.Entity.DbSet<ACTMS.Models.TransferReason> TransferReasons { get; set; }

        public System.Data.Entity.DbSet<ACTMS.Models.Transfer> Transfers { get; set; }

        public System.Data.Entity.DbSet<ACTMS.Models.Churrch> Churrches { get; set; }

        public System.Data.Entity.DbSet<ACTMS.Models.Userdetails> Userdetails { get; set; }




        public System.Collections.IEnumerable IdentityUsers { get; set; }
    }
}