using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCourse.Models;
using AspCourse.Models.database.entity;
using AspCourse.Models.security;

namespace AspCourse.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatMember> ChatMembers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                       .HasMany(c => c.Chats)
                       .WithOne(e => e.User);

            modelBuilder.Entity<Chat>()
                       .HasMany(c => c.Messages)
                       .WithOne(e => e.Chat);

            modelBuilder.Entity<Chat>()
                       .HasMany(c => c.ChatMembers)
                       .WithOne(e => e.Chat);

            modelBuilder.Entity<User>()
                       .HasMany(c => c.ChatMembers)
                       .WithOne(e => e.User);

            string adminRoleName = "admin";
            string userRoleName = "user";

            string name = "Mike";
            string surname = "Chernikov";
            DateTime birthDay = new DateTime(1997, 09, 18);

            string adminEmail = "admin@mail.ru";
            string adminPassword = HashingPassword.GetHashPassword("123456");

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User {
                Id = 1,
                Name = name,
                Surname = surname,
                Birthday = birthDay,
                Email = adminEmail,
                Password = adminPassword,
                RoleId = adminRole.Id
            };
            Random random = new Random();
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });

            var users = new User[31];
            users[0] = adminUser;
            for (int i = 0; i < 30; i++)
            {
                
                int randomDay = random.Next(1, 28);
                int randomMonth = random.Next(1, 12);
                int randomYear = random.Next(1990, 2000);
                User user = new User
                {
                    Id = 2 + i,
                    Name = "MockName" + i,
                    Surname = "MockSurname" + i,
                    Birthday = new DateTime(randomYear, randomMonth, randomDay),
                    Email = "MockEmail" + i + "@mail.ru",
                    Password = HashingPassword.GetHashPassword("123456"),
                    RoleId = userRole.Id
                };
                users[i + 1] = user;
            }

            modelBuilder.Entity<User>().HasData(users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
