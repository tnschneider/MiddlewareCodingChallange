using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MiddlewareCodingChallange.ConsoleApp.Models
{
    public class ServerResponseDbContext : DbContext
    {
        public virtual DbSet<ServerResponseLog> ServerResponseLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ae_code_challange;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServerResponseLog>(entity =>
            {
                entity.Property(e => e.DataString)
                    .HasMaxLength(10000000)
                    .IsUnicode(false);

                entity.Property(e => e.EndTimeUTC)
                    .IsRequired();

                entity.Property(e => e.StartTimeUTC)
                    .IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired();
            });

            modelBuilder.Entity<ServerResponseLog>()
                .HasKey(c => c.pk);

            modelBuilder.Entity<ServerResponseLog>()
                .ToTable("server_response_log", "dbo");
        }
    }
}