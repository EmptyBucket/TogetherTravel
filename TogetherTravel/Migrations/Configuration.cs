using System;
using System.Data.Entity.Migrations;
using System.Linq;
using DataBase;
using DataBase.Models.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TogetherTravel.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TogetherTravelContext>
    {
        private readonly bool _hasPendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataBase.DataBase.TogetherTravel";
            var dbMigrator = new DbMigrator(this);
            _hasPendingMigrations = dbMigrator.GetPendingMigrations().Any();
        }

        protected override void Seed(TogetherTravelContext context)
        {
            base.Seed(context);
            if (!_hasPendingMigrations) return;
            const int userCount = 10;
            var personNameGenerator = new RandomNameGeneratorLibrary.PersonNameGenerator();
            var names = personNameGenerator.GenerateMultipleFirstAndLastNames(userCount);
            var random = new Random();
            var users = names.Select(name =>
            {
                var splittedName = name.Split(' ');
                var firstName = splittedName[0];
                var secondName = splittedName[1];
                var birthDayYear = random.Next(1940, DateTime.Now.Year + 1);
                var birthDayMonth = random.Next(1, 13);
                var maxDayInCurMonth = new DateTime(birthDayYear, birthDayMonth, 1).AddMonths(1).AddDays(-1).Day;
                var birthDayDay = random.Next(1, maxDayInCurMonth + 1);
                var birthDay = new DateTime(birthDayYear, birthDayMonth,
                    birthDayDay);
                var longitudeCoord = random.NextDouble() * 360 - 180;
                var latitudeCoord = random.NextDouble() * 170 - 85;
                return new User
                {
                    UserName = firstName + secondName,
                    SecondName = secondName,
                    FirstName = firstName,
                    BirthDay = birthDay,
                    LongitudeCoord = longitudeCoord,
                    LatitudeCoord = latitudeCoord
                };
            });
            foreach (var user in users)
                context.Users.Add(user);

            var roles = new[]
            {
                new IdentityRole("Admin"),
                new IdentityRole("User")
            };
            foreach (var role in roles)
                context.Roles.Add(role);

            context.SaveChanges();
        }
    }
}
