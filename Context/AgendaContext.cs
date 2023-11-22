
using Microsoft.EntityFrameworkCore;
using moduloApi.Entities;

namespace moduloApi.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}