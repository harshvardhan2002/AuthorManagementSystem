using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuthorWebApiProject.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime PublishedDate { get; set; }

        public Author? Author { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }
}
