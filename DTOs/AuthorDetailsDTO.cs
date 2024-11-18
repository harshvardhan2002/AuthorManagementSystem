namespace AuthorWebApiProject.DTOs
{
    public class AuthorDetailsDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
    }
}
