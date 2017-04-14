using System;
using System.Collections.Generic;

namespace DataBase.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime? BirthDay { get; set; }
        public double LatitudeCoord { get; set; }
        public double LongitudeCoord { get; set; }

        public virtual ICollection<Chat.Chat> OwnerChats { get;set; }
        public virtual ICollection<Chat.Chat> Chats { get; set; }
        public virtual ICollection<Message.Message> Messages { get; set; }
    }
}