using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMConcepts_Final_Project.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Title must have 3 characters")]
        [MaxLength(250, ErrorMessage = "Title must have less than 250 characters")]
        public string Title { get; set; }

        [Display(Name = "Date of Creation")]
        public DateTime CreatedDate { get; set; }

        [MaxLength(1000, ErrorMessage = "Description should have less than 1000 characters")]
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; } = false;
        public List List { get; set; }
        public int ListId { get; set; }
        public Item() { }
    }

    public enum Priority
    {
        High,
        Midium, 
        Low
    }
}
