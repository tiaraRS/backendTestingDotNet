using backend1.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace backend1.Data
{
    public class ChildrenWithCourageDBContext:DbContext
    {
        public DbSet<ChildEntity> Disciplines => Set<ChildEntity>();
        public DbSet<ChildEntity> Athletes => Set<ChildEntity>();
        //public DbSet<Customer> Customers => Set<Customer>();
        // public DbSet<Order> Orders => Set<Order>();
        public ChildrenWithCourageDBContext(DbContextOptions<ChildrenWithCourageDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ChildrenWithCourageConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //DISCIPLINES---------------------------------------
            //mappear entity a tabla con ese nombre
            modelBuilder.Entity<ChildEntity>().ToTable("Children");
            //indicar cual es el primary key y hacer que se agregue el valor incrementando el indice automaticamente
            modelBuilder.Entity<ChildEntity>().Property(d => d.Id).ValueGeneratedOnAdd();
            //indicar tipo de relacion entre entities
            //modelBuilder.Entity<ChildEntity>().HasMany(d => d.Athletes).WithOne(a => a.Discipline);

           


        }
    }
}
