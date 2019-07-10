using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreServices.Models
{
    public partial class BlogDBContext : DbContext
    {
        public BlogDBContext()
        {
        }

        public BlogDBContext(DbContextOptions<BlogDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CommunicationPrefs> CommunicationPrefs { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=<dbserver>;Database=TestDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CommunicationPrefs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasColumnName("MAIL")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Membernumber)
                    .HasColumnName("MEMBERNUMBER")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Onlinenotification)
                    .HasColumnName("ONLINENOTIFICATION")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Sms)
                    .HasColumnName("SMS")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Transactionid).HasColumnName("TRANSACTIONID");
            });


            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Defaultcomm)
                    .HasColumnName("DEFAULTCOMM")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Transactioncategory)
                    .HasColumnName("TRANSACTIONCATEGORY")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Transactionid).HasColumnName("TRANSACTIONID");
            });
        }
    }
}
