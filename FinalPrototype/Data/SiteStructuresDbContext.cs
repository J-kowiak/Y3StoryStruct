using Microsoft.EntityFrameworkCore;
using static FinalPrototype.Models.DBEntities.BuiltInStructure;

namespace FinalPrototype.Data
{
    public class SiteStructuresDbContext : DbContext
    {
        public SiteStructuresDbContext(DbContextOptions<SiteStructuresDbContext> options) : base(options)
        {
        }
            public DbSet<SiteStructure> siteStructures { get; set; }
        
    }
    
}
