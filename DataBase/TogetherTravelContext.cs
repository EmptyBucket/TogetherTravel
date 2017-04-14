using System.Data.Entity;
using DataBase.Models.User;

namespace DataBase
{
    public class TogetherTravelContext : DbContext
    {
        public TogetherTravelContext()
            : base("name=TogetherTravel")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public virtual DbSet<User> Users { get; set; }
    }
}