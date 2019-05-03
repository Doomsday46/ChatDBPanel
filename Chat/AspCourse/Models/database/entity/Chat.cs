using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCourse.Models.database.entity
{
    public class Chat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int ChatType { get; set; }
                
        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<Message> Messages { get; set; }
        public ICollection<ChatMember> ChatMembers { get; set; }

        

    }
}
