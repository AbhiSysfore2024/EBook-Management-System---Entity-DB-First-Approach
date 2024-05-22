using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EBook_Management_System___Entity_DB_First_Approach.Models;

public partial class AdobookManagementContext : DbContext
{
    public AdobookManagementContext()
    {
    }

    public AdobookManagementContext(DbContextOptions<AdobookManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adoaccess> Adoaccesses { get; set; }

    public virtual DbSet<Adoauthor> Adoauthors { get; set; }

    public virtual DbSet<Adobook> Adobooks { get; set; }

    public virtual DbSet<Adocredential> Adocredentials { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=BLRSFLT274\\SQLEXPRESS;Initial Catalog=ADOBookManagement;Integrated Security=True;Trusted_Connection=true;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adoaccess>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADOAccess");

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RoleAssigned)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Adoauthor>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__ADOAutho__70DAFC148D411840");

            entity.ToTable("ADOAuthor");

            entity.Property(e => e.AuthorId)
                .ValueGeneratedNever()
                .HasColumnName("AuthorID");
            entity.Property(e => e.Biography)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Adobook>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__ADOBook__3DE0C227FCB51EBC");

            entity.ToTable("ADOBook");

            entity.Property(e => e.BookId)
                .ValueGeneratedNever()
                .HasColumnName("BookID");
            entity.Property(e => e.BookLanguage)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Descriptions)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.PublicationDate).HasColumnType("datetime");
            entity.Property(e => e.Publisher)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.BookGenreNavigation).WithMany(p => p.Adobooks)
                .HasForeignKey(d => d.BookGenre)
                .HasConstraintName("FK__ADOBook__BookGen__489AC854");

            entity.HasMany(d => d.Authors).WithMany(p => p.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    r => r.HasOne<Adoauthor>().WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookAutho__Autho__4C6B5938"),
                    l => l.HasOne<Adobook>().WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__BookAutho__BookI__4B7734FF"),
                    j =>
                    {
                        j.HasKey("BookId", "AuthorId").HasName("PK__BookAuth__6AED6DE61E59ED23");
                        j.ToTable("BookAuthor");
                        j.IndexerProperty<Guid>("BookId").HasColumnName("BookID");
                        j.IndexerProperty<Guid>("AuthorId").HasColumnName("AuthorID");
                    });
        });

        modelBuilder.Entity<Adocredential>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ADOCredentials");

            entity.Property(e => e.Password)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.RoleAssigned)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genre__0385057EB6AB461E");

            entity.ToTable("Genre");

            entity.Property(e => e.GenreName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
