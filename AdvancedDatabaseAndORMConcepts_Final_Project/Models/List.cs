using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMConcepts_Final_Project.Models
{
    public class List
    {
  
        public int Id { get; set; }
        public string Name { get; set; }
        public HashSet<Item> Items { get; set; } = new HashSet<Item>();
        public List() { }

    }
}
