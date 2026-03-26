using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReadCity;

public partial class LibraryReadCityContext : DbContext
{
    public LibraryReadCityContext()
    {
    }

    public LibraryReadCityContext(DbContextOptions<LibraryReadCityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookLoan> BookLoans { get; set; }

    public virtual DbSet<LoanStatus> LoanStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=libraryReadCity;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Annotation).HasColumnName("annotation");
            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Genre).HasColumnName("genre");
            entity.Property(e => e.Isbn).HasColumnName("isbn");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.PublishingHouse).HasColumnName("publishing_house");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.YearOfPublication).HasColumnName("year_of_publication");
        });

        modelBuilder.Entity<BookLoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("book_loans_pkey");

            entity.ToTable("book_loans");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualReturnDate).HasColumnName("actual_return_date");
            entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");
            entity.Property(e => e.IsbnBook).HasColumnName("isbn_book");
            entity.Property(e => e.LibraryCard).HasColumnName("library_card");
            entity.Property(e => e.PlannedReturnDate).HasColumnName("planned_return_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.IsbnBookNavigation).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.IsbnBook)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_book_loans_books");

            entity.HasOne(d => d.LibraryCardNavigation).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.LibraryCard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_book_loans_users");

            entity.HasOne(d => d.Status).WithMany(p => p.BookLoans)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_book_loans_loan_statuses");
        });

        modelBuilder.Entity<LoanStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("loan_statuses_pkey");

            entity.ToTable("loan_statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Role1).HasColumnName("role");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.LibraryCard).HasColumnName("library_card");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
