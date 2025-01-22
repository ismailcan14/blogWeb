using blogWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace blogWeb.Context
{
    public class BlogDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-G7IMFP4\\MSSQLSERVER02; database=Blog; Integrated Security=True;");
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
