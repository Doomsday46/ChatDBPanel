using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCourse.Models.database.entity
{
    public class ChatMember
    {
        public int Id { get; set; }

        public bool IsAdmin { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
