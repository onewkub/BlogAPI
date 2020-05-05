using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace blogApi.Models
{
    public partial class DBContext : DbContext
    {
        private IConfiguration Configuration;
        public DBContext()
        {
            
        }


        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<BlogTag> BlogTag { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog", "BlogDatabase");

                entity.Property(e => e.BlogId)
                    .HasColumnName("BlogID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime)
                    .HasColumnName("update_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<BlogTag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BlogTag", "BlogDatabase");

                entity.HasIndex(e => e.Bid)
                    .HasName("BID");

                entity.HasIndex(e => e.Tid)
                    .HasName("TID");

                entity.Property(e => e.Bid)
                    .HasColumnName("BID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Tid)
                    .HasColumnName("TID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.B)
                    .WithMany()
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("blogtag_ibfk_1");

                entity.HasOne(d => d.T)
                    .WithMany()
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("blogtag_ibfk_2");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag", "BlogDatabase");

                entity.HasIndex(e => e.TagName)
                    .HasName("TagName")
                    .IsUnique();

                entity.Property(e => e.TagId)
                    .HasColumnName("TagID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
