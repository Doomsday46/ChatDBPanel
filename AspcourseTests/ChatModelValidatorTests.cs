using AspCourse.Models.database.entity;
using AspCourse.Models.validator;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AspcourseTests
{
    class ChatModelValidatorTests
    {
        private IValidator<Chat> charModelValidator;
        private Chat chatValid;

        [SetUp]
        public void Setup()
        {
            charModelValidator = new ChatModelValidator();

            chatValid = new Chat();

            chatValid.Date = DateTime.Now.AddHours(5);
            chatValid.ChatType = 1;
            chatValid.Name = "chat";
            chatValid.ChatMembers = new List<ChatMember>()
            {
                new ChatMember() { IsAdmin = true } 
            };
        }

        [Test]
        public void TestInitClass()
        {
            IValidator<Chat> charModelValidator = new ChatModelValidator();
        }

        [Test]
        public void TestSetModel()
        {
            charModelValidator.SetModel(chatValid);
        }

        [Test]
        public void TestIsValidWhenValidModelResultTrue()
        {
            charModelValidator.SetModel(chatValid);
            Assert.True(charModelValidator.IsValid());
        }

        [Test]
        public void TestIsValidWhenNoValidModelResultFalse()
        {
            Chat chat = new Chat();

            chat.Date = DateTime.Now.AddHours(-5);
            chat.ChatType = 0;
            chat.Name = "chat";
            chat.ChatMembers = new List<ChatMember>()
            {
                new ChatMember() { IsAdmin = true }
            };

            charModelValidator.SetModel(chat);

            Assert.False(charModelValidator.IsValid());
        }

        [Test]
        public void TestIsValidWhenNoValidDateResultFalse()
        {
            Chat chat = new Chat();

            chat.Date = DateTime.Now.AddHours(-5);
            chat.ChatType = 1;
            chat.Name = "chat";
            chat.ChatMembers = new List<ChatMember>()
            {
                new ChatMember() { IsAdmin = true }
            };

            charModelValidator.SetModel(chat);

            Assert.False(charModelValidator.IsValid());
        }

        [Test]
        public void TestIsValidWhenNoValidNameResultFalse()
        {
            Chat chat = new Chat();

            chat.Date = DateTime.Now.AddHours(5);
            chat.ChatType = 1;
            chat.Name = "";
            chat.ChatMembers = new List<ChatMember>()
            {
                new ChatMember() { IsAdmin = true }
            };

            charModelValidator.SetModel(chat);

            Assert.False(charModelValidator.IsValid());
        }

        [Test]
        public void TestIsValidWhenNoValidChatTypeResultFalse()
        {
            Chat chat = new Chat();

            chat.Date = DateTime.Now.AddHours(5);
            chat.ChatType = 0;
            chat.Name = "chat";
            chat.ChatMembers = new List<ChatMember>()
            {
                new ChatMember() { IsAdmin = true }
            };

            charModelValidator.SetModel(chat);

            Assert.False(charModelValidator.IsValid());
        }

        [Test]
        public void TestIsValidWhenNoValidChatMemberNoAdminResultFalse()
        {
            Chat chat = new Chat();

            chat.Date = DateTime.Now.AddHours(5);
            chat.ChatType = 1;
            chat.Name = "chat";
            chat.ChatMembers = new List<ChatMember>()
            {
                new ChatMember() { IsAdmin = false }
            };

            charModelValidator.SetModel(chat);

            Assert.False(charModelValidator.IsValid());
        }

        [Test]
        public void TestIsValidWhenNoValidChatMemberListIsEmptyResultFalse()
        {
            Chat chat = new Chat();

            chat.Date = DateTime.Now.AddHours(5);
            chat.ChatType = 1;
            chat.Name = "chat";
            chat.ChatMembers = new List<ChatMember>();

            charModelValidator.SetModel(chat);

            Assert.False(charModelValidator.IsValid());
        }

        [Test]
        public void TestIsValidWhenNoValidChatMemberListIsNullResultFalse()
        {
            Chat chat = new Chat();

            chat.Date = DateTime.Now.AddHours(5);
            chat.ChatType = 1;
            chat.Name = "chat";

            charModelValidator.SetModel(chat);

            Assert.False(charModelValidator.IsValid());
        }

        [Test]
        public void TestGetInformationWhenValidModelResultStringValueValid()
        {

            charModelValidator.SetModel(chatValid);
            Assert.AreEqual("Valid", charModelValidator.GetInformation());
        }

        [Test]
        public void TestGetInformationWhenNoValidModelResultErrorMessage()
        {

            Chat chat = new Chat();

            chat.Date = DateTime.Now.AddHours(-5);
            chat.ChatType = 0;
            chat.Name = "";
            chat.ChatMembers = new List<ChatMember>()
            {
                new ChatMember() { IsAdmin = true }
            };

            charModelValidator.SetModel(chat);

            Assert.AreEqual("name,Chat type,Date,", charModelValidator.GetInformation());
        }
    }
}
