using CommandInterceptor.Models;
using System.Reflection.Metadata;

namespace CommandInterceptor.Data
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeedSqlServer(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {

            }

            return app;
        }
    }
    internal class DbInitializer
    {
        internal static void Initialize(ApplicationDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var authors = new Author[]
            {
            new Author{ Name = "Muhammad" },
            new Author{ Name = "Dalim" }

            };

            foreach (var author in authors)
                dbContext.Authors.Add(author);

            dbContext.SaveChanges();
        }
    }
}
