using System;
using System.Collections.Generic;

namespace DataBase.Models.Chat
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User.User UserCreator { get; set; }
        public virtual ICollection<User.User> Users { get; set; } = new List<User.User>();
        public virtual ICollection<Message.Message> Messages { get; set; } = new List<Message.Message>();
    }
}