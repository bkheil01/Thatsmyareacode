using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using thatsmyareacode.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace thatsmyareacode.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<thatsmyareacode.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(thatsmyareacode.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user@example.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(thatsmyareacode.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
            context.Profiles.AddOrUpdate(p => p.Name,
               new Profiles
               {
                   Name = "Alex Batovsky",
                   Address = "703 Tin Dor Way",
                   City = "Louisville",
                   State = "KY",
                   Zip = "40118",
                   AreaCode = "502",
                   Email = "alex@example.com",
               },
                new Profiles
                {
                    Name = "Brett",
                    Address = "703 Tin Dor Way",
                    City = "Louisville",
                    State = "KY",
                    Zip = "40118",
                    AreaCode = "502",
                    Email = "brett@example.com",
                },
                new Profiles
                {
                    Name = "Alicia",
                    Address = "703 Tin Dor Way",
                    City = "Louisville",
                    State = "KY",
                    Zip = "40118",
                    AreaCode = "502",
                    Email = "alicia@example.com",
                }
                );
        }
    }
}
