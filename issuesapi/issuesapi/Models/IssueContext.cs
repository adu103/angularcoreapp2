using Microsoft.EntityFrameworkCore;

namespace issuesapi.Models
{
    public class IssueContext : DbContext
    {
        public IssueContext(DbContextOptions<IssueContext> options)
            : base(options)
        {
        }

        public DbSet<Issues> Issues { get; set; }
    }
}