using Microsoft.EntityFrameworkCore;
using YouniLab.Member.Domain.Member;

namespace YouniLab.Member.Database
{
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MemberAccount> MemberAccounts { get; set; }
        public DbSet<Domain.Member.Member> Members { get; set; }
    }
}
