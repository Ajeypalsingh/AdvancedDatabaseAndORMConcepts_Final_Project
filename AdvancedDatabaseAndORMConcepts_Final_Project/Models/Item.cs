using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMConcepts_Final_Project.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
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
