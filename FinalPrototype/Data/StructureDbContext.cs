using FinalPrototype.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace FinalPrototype.Data
{
    public class StructureDbContext : DbContext
    {
        public StructureDbContext(DbContextOptions<StructureDbContext> options) : base(options)
        {
        }

        public DbSet<UserStructure> userStructures { get; set; }
    }
}
