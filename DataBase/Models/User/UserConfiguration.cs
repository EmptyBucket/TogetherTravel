using System.Data.Entity.ModelConfiguration;

namespace DataBase.Models.User
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(user => user.Id);
            Property(user => user.FirstName)
                .IsRequired()
                .HasMaxLength(200);
            Property(user => user.SecondName)
                .IsRequired()
                .HasMaxLength(200);
            Property(user => user.LatitudeCoord)
                .IsRequired();
            Property(user => user.LongitudeCoord)
                .IsRequired();
        }
    }
}