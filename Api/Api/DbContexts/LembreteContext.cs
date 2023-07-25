using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.DbContexts
{
    public class LembreteContext : DbContext
    {
        public LembreteContext(DbContextOptions<LembreteContext> options)
        : base(options)
        {
        }

        public DbSet<Lembrete> Lembretes { get; set; } = null!;
    }
}
