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

        public virtual DbSet<BlockTag> BlockTag { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;User=root;Password=;Database=BlogDatabase;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlockTag>(entity =>
            {
                entity.HasNoKey();
                
                entity.ToTable("BlockTag", "BlogDatabase");

                entity.HasIndex(e => e.Bid)
                    .HasName("BID");

                entity.HasIndex(e => e.Tid)
                    .HasName("TID");

                entity.Property(e => e.Bid)
                    .HasColumnName("BID")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Tid)
                    .HasColumnName("TID")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.B)
                    .WithMany()
                    .HasForeignKey(d => d.Bid)
                    .HasConstraintName("blocktag_ibfk_1");

                entity.HasOne(d => d.T)
                    .WithMany()
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("blocktag_ibfk_2");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog", "BlogDatabase");

                entity.Property(e => e.BlogId)
                    .HasColumnName("BlogID")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime).HasColumnName("create_time");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag", "BlogDatabase");

                entity.Property(e => e.TagId)
                    .HasColumnName("TagID")
                    .HasMaxLength(60)
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
