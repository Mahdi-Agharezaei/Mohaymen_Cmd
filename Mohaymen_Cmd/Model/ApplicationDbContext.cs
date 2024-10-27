using Microsoft.EntityFrameworkCore;

namespace Mohaymen_Cmd.Model
{
    internal class ApplicationDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\MSSQLLocalDB;Initial Catalog=Mohaymen_CmdDB;Integrated Security=True");
        }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)//base("name=DefaultConnection")
        //{

        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().ToTable("myPersonTbl");

        //    modelBuilder.Entity<User>().HasKey(x => x.ID);

        //    modelBuilder.Entity<User>().Property(x => x.UserName)
        //        .IsRequired()
        //        .HasMaxLength(63);

        //    modelBuilder.Entity<User>().Property(x => x.Password)
        //        .IsRequired()
        //        .HasMaxLength(63);

        //    modelBuilder.Entity<User>().Property(x => x.Status)
        //        .IsRequired()
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<User>().Property(x => x.CreationDate)
        //        .IsRequired()
        //        .ValueGeneratedOnAdd();

        //    modelBuilder.Entity<User>().Property(x => x.ModificationDate)
        //        .IsRequired()
        //        .ValueGeneratedOnAddOrUpdate();
        //}
    }
}
