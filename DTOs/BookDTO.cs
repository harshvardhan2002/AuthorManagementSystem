namespace AuthorWebApiProject.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
    }
}
