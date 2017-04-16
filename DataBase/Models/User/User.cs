using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataBase.Models.User
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime? BirthDay { get; set; }
        public double? LatitudeCoord { get; set; }
        public double? LongitudeCoord { get; set; }

        public virtual ICollection<Chat.Chat> OwnerChats { get;set; } = new List<Chat.Chat>();
        public virtual ICollection<Chat.Chat> Chats { get; set; } = new List<Chat.Chat>();
        public virtual ICollection<Message.Message> Messages { get; set; } = new List<Message.Message>();
    }
}