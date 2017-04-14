using System;
using System.Data.Entity.Migrations;
using System.Linq;
using DataBase;
using DataBase.Models.User;

namespace TogetherTravel.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TogetherTravelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataBase.DataBase.TogetherTravel";
        }

        protected override void Seed(TogetherTravelContext context)
        {
            base.Seed(context);
            const int userCount = 1000;
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
                var user = new User
                {
                    SecondName = secondName,
                    FirstName = firstName,
                    BirthDay = birthDay,
                    LongitudeCoord = longitudeCoord,
                    LatitudeCoord = latitudeCoord
                };
                return user;
            });
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
