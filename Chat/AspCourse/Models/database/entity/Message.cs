using System;

namespace AspCourse.Models.database.entity
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SendingDate { get; set; }

        public int? ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}