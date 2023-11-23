using CommandInterceptor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommandInterceptor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //private static readonly CheckQueryCommandInterceptor _interceptor
        //= new CheckQueryCommandInterceptor();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.AddInterceptors(_interceptor);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Author> Authors { get; set; }
    }
}
