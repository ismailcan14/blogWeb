﻿namespace blogWeb.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int BlogId { get; set; }
        public DateTime PublishDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
