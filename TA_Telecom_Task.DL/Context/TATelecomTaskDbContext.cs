using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA_Telecom_Task.DL.Models;

namespace TA_Telecom_Task.DL.Context
{
    public class TATelecomTaskDbContext : IdentityDbContext<ApplicationUser>
    {
        public TATelecomTaskDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        { }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<SMSPhoneNumber> SMSPhoneNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static TATelecomTaskDbContext Create()
        {
            return new TATelecomTaskDbContext();
        }
    }
}
