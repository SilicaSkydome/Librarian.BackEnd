﻿namespace Librarian.BackEnd.Mapper.Dto.Book
{
    public class BookGetDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string? CoverUrl { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime Date { get; set; }
        public int Symbols { get; set; }
        public ICollection<string> Tags { get; set; } = null!;
        public string? Description { get; set; }
    }
}
