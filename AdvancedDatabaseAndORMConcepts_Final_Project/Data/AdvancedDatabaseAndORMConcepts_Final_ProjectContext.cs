using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdvancedDatabaseAndORMConcepts_Final_Project.Models;

namespace AdvancedDatabaseAndORMConcepts_Final_Project.Data
{
    public class AdvancedDatabaseAndORMConcepts_Final_ProjectContext : DbContext
    {
        public AdvancedDatabaseAndORMConcepts_Final_ProjectContext (DbContextOptions<AdvancedDatabaseAndORMConcepts_Final_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<List> List { get; set; } = default!;
        public DbSet<Item> Item { get; set; } = default!;
    }
}
