using System;

namespace DataBase.Models.Message
{
    public class Message
    {
        public int Id { get; set; }
        public int UserCreatorId { get; set; }
        public int ChatId { get; set; }
        public string MessageText { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User.User UserCreator { get; set; }
        public virtual Chat.Chat Chat { get; set; }
    }
}