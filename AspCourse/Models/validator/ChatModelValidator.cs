using AspCourse.Models.database.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCourse.Models.validator
{
    public class ChatModelValidator : IValidator<Chat>
    {
        private bool isValid;
        private Chat chat;

        public ChatModelValidator()
        {
        }

        public string GetInformation()
        {
            return GetMessage(isValid);
        }

        private string GetMessage(bool isValid)
        {
            if (isValid) return "Valid";
            else return GetErrorMesagge();
        }

        private string GetErrorMesagge()
        {
            var nameField = !IsValidChatName(chat.Name) ? "name" : "";
            var chatTypeField = !IsValidChatType(chat.ChatType) ? "Chat type" : "";
            var dateField = !IsValidDate(chat.Date) ? "Date" : "";

            var membersField = "";

            if (chat.ChatMembers == null || chat.ChatMembers.Count == 0)
            {
                membersField = "Field is null or empty";
            }
            else
            {
                membersField = !IsValidChatAdmin(chat.ChatMembers) ? "Admin is missing" : "";
            }

            return MessageFormat(nameField, chatTypeField, dateField, membersField);
        }

        private string MessageFormat(string nameField, string chatTypeField, string dateField, string membersField)
        {
            return nameField + GetSeperator(nameField) + chatTypeField + GetSeperator(chatTypeField) + dateField + GetSeperator(dateField) + membersField;
        }

        private string GetSeperator(string str)
        {
            return String.IsNullOrEmpty(str) ? "" : ",";
        }

        public bool IsValid()
        {
            return isValid;
        }

        public IValidator<Chat> SetModel(Chat model)
        {
            this.chat = model;
            SetValidStatus();
            return this;
        }

        private void SetValidStatus()
        {
            if (chat.ChatMembers == null || chat.ChatMembers.Count == 0)
            {
                isValid = false;
            }
            else
            {
                isValid = IsValidChatName(chat.Name) && IsValidChatType(chat.ChatType) && IsValidDate(chat.Date) && IsValidChatAdmin(chat.ChatMembers);
            }           
        }

        private bool IsValidChatAdmin(ICollection<ChatMember> chatMembers)
        {
            return chatMembers.Any(a => a.IsAdmin.Equals(true));
        }

        private bool IsValidDate(DateTime date)
        {
            return date.CompareTo(DateTime.Now) >= 0;
        }

        private bool IsValidChatType(int chatType)
        {
            return chatType > 0 && chatType < 12;
        }

        private bool IsValidChatName(string name)
        {
            return !String.IsNullOrEmpty(name);
        }
    }
}
