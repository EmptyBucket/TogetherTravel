using System.Data.Entity.ModelConfiguration;

namespace DataBase.Models.Message
{
    public class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            HasKey(message => message.Id);
            Property(message => message.ChatId)
                .IsRequired();
            Property(message => message.DateCreated)
                .IsRequired();
            Property(message => message.MessageText)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(10000);
            Property(message => message.UserCreatorId)
                .IsRequired();

            HasRequired(message => message.UserCreator)
                .WithMany(user => user.Messages);
        }
    }
}