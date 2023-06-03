using Microsoft.EntityFrameworkCore;
using TraversalAPI.DAL.Entities;

namespace TraversalAPI.DAL.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=FARUK\\SQLEXPRESS;database=CoreTraversalApiDb;integrated security=true");
        }

        public DbSet<Visitor> Visitors { get; set; }

    }
}
