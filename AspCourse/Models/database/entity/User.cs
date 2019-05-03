﻿using AspCourse.Models.database.entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCourse.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Chat> Chats { get; set; }
        public ICollection<ChatMember> ChatMembers { get; set; }

        public User()
        {
        }
    }
}
