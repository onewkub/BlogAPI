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
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseMySQL("Server=localhost;User=root;Database=blogdatabase");
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

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => new { e.Bid, e.TagName })
                    .HasName("PRIMARY");

                entity.ToTable("TAG", "BlogDatabase");

                entity.Property(e => e.Bid)
                    .HasColumnName("BID")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.TagName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.B)
                    .WithMany(p => p.Tag)
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("tag_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
