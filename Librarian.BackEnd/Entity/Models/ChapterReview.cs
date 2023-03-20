﻿namespace Librarian.BackEnd.Entity.Models
{
    public class ChapterReview
    {
        public Guid Id { get; set; }
        public User Author { get; set; }
        public Chapter Chapter { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
    }
}