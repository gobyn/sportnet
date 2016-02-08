namespace sportnet.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<sportnet.Models.SportNetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(sportnet.Models.SportNetContext context)
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

            // ROLES
            if (!context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "SuperAdmin" };
                roleManager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "ClubAdmin"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "ClubAdmin" };
                roleManager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Coach"))
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Coach" };
                roleManager.Create(role);
            }
            // USERS
            if (!(context.Users.Any(u => u.UserName == "superadmin@sportnet.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "superadmin@sportnet.com", Email = "superadmin@sportnet.com", LockoutEnabled = false, FirstName = "Super", LastName = "Admin" };
                userManager.Create(userToInsert, "Glenn123");
                userManager.AddToRole(userToInsert.Id, "SuperAdmin");
            }
            if (!(context.Users.Any(u => u.UserName == "clubadmin@sportnet.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "clubadmin@sportnet.com", Email = "clubadmin@sportnet.com", LockoutEnabled = true, FirstName = "Club", LastName = "Admin" };
                userManager.Create(userToInsert, "Glenn123");
                userManager.AddToRole(userToInsert.Id, "ClubAdmin");
            }
            if (!(context.Users.Any(u => u.UserName == "coach@sportnet.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "coach@sportnet.com", Email = "coach@sportnet.com", LockoutEnabled = true, FirstName = "Coach", LastName = "Glenn" };
                userManager.Create(userToInsert, "Glenn123");
                userManager.AddToRole(userToInsert.Id, "Coach");
            }
            // TEAMS
            var team = new Team
            {
                Name = "Miniemen B"
            };
            var team2 = new Team
            {
                Name = "Kadetten A"
            };
            context.Teams.AddOrUpdate(t => t.Name, team);
            context.Teams.AddOrUpdate(t => t.Name, team2);
            context.SaveChanges();
        }
    }
}
