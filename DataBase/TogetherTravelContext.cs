using System.Data.Entity;
using DataBase.Models.Chat;
using DataBase.Models.Message;
using DataBase.Models.User;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataBase
{
    public class TogetherTravelContext : IdentityDbContext<User>
    {
        public TogetherTravelContext()
            : base("name=TogetherTravel", false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ChatConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
    }
}