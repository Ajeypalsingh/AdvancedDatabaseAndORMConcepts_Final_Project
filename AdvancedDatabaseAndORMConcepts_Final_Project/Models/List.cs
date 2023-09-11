using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMConcepts_Final_Project.Models
{
    public class List
    {
        [Key]
        public int ListId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Title must have 3 characters")]
        [MaxLength(25, ErrorMessage = "Title must be less than 25 characters")]
        public string Title { get; set; }
        public HashSet<Item> Items { get; set; } = new HashSet<Item>();
        public List() { }
    }
}
