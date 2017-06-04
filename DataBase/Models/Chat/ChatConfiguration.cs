using System.Data.Entity.ModelConfiguration;

namespace DataBase.Models.Chat
{
    public class ChatConfiguration : EntityTypeConfiguration<Chat>
    {
        public ChatConfiguration()
        {
            ToTable("Chat");
            HasKey(chat => chat.Id);
            Property(chat => chat.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(200);
            Property(chat => chat.DateCreated)
                .IsRequired();

            HasRequired(chat => chat.UserCreator)
                .WithMany(user => user.OwnerChats)
                .WillCascadeOnDelete(false);
            HasMany(chat => chat.Users)
                .WithMany(user => user.Chats)
                .Map(uc =>
                {
                    uc.ToTable("UserToChat");
                    uc.MapRightKey("UserId");
                    uc.MapLeftKey("ChatId");
                });
            HasMany(chat => chat.Messages)
                .WithRequired(message => message.Chat)
                .WillCascadeOnDelete(false);
        }
    }
}