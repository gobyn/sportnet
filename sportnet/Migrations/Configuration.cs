namespace sportnet.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<sportnet.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "sportnet.Models.ApplicationDbContext";
        }

        protected override void Seed(sportnet.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "SuperAdmin" };

                manager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "glennobyn@admin.com"))
            {
                var store = new UserStore<Models.ApplicationUser>(context);
                var manager = new UserManager<Models.ApplicationUser>(store);
                var user = new Models.ApplicationUser { UserName = "glennobyn@admin.com" };

                manager.Create(user, "SuperAdmin");
                manager.AddToRole(user.Id, "SuperAdmin");
            }
        }
    }
}
