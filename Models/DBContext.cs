using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace blogApi.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

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

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TAG", "BlogDatabase");

                entity.HasIndex(e => e.Bid)
                    .HasName("BID");

                entity.Property(e => e.Bid)
                    .HasColumnName("BID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TagName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.B)
                    .WithMany()
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("tag_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
