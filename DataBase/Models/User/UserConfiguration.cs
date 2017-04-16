using System.Data.Entity.ModelConfiguration;

namespace DataBase.Models.User
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(user => user.FirstName)
                .IsOptional()
                .HasMaxLength(200);
            Property(user => user.SecondName)
                .IsOptional()
                .HasMaxLength(200);
            Property(user => user.BirthDay)
                .IsOptional();
            Property(user => user.LatitudeCoord)
                .IsOptional();
            Property(user => user.LongitudeCoord)
                .IsOptional();
        }
    }
}