using Microsoft.EntityFrameworkCore;
using Usuario.Models;

namespace Usuario.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();
            user.ToTable("tb_users");
            user.HasKey(t => t.Id);
            user.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            user.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            user.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
        }
    }
}
