using Microsoft.EntityFrameworkCore;
using Touhouplanet.Models;

namespace Touhouplanet.Data
{
    public class MvcTouhouContext : DbContext
    {
        public MvcTouhouContext(DbContextOptions<MvcTouhouContext> options)
            : base(options)
        {
        }

        public DbSet<Touhou> Touhou { get; set; }
    }
}