using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webrusina;

public partial class ThingContext : DbContext
{
    public ThingContext()
    {
    }

    public ThingContext(DbContextOptions<ThingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<MovieStaff> MovieStaffs { get; set; }

    public virtual DbSet<MovieUser> MovieUsers { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<PlatformCountry> PlatformCountries { get; set; }

    public virtual DbSet<PlatformMovie> PlatformMovies { get; set; }

    public virtual DbSet<PlatformsUser> PlatformsUsers { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\Movies4; Database=thing; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_COUNTRIES");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GENRES");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descr)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MOVIES");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RelaseDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MovieGenre");

            entity.HasOne(d => d.GenreNavigation).WithMany()
                .HasForeignKey(d => d.Genre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MovieGenre_fk1");

            entity.HasOne(d => d.MovieNavigation).WithMany()
                .HasForeignKey(d => d.Movie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MovieGenre_fk0");
        });

        modelBuilder.Entity<MovieStaff>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MovieStaff");

            entity.HasOne(d => d.MovieNavigation).WithMany()
                .HasForeignKey(d => d.Movie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MovieStaff_fk1");

            entity.HasOne(d => d.StaffMemberNavigation).WithMany()
                .HasForeignKey(d => d.StaffMember)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MovieStaff_fk0");
        });

        modelBuilder.Entity<MovieUser>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Comment)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.User).HasColumnName("User_");

            entity.HasOne(d => d.MovieNavigation).WithMany()
                .HasForeignKey(d => d.Movie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MovieUsers_fk0");

            entity.HasOne(d => d.UserNavigation).WithMany()
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MovieUsers_fk1");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PLATFORMS");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PlatformCountry>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.CountryNavigation).WithMany()
                .HasForeignKey(d => d.Country)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlatformCountries_fk1");

            entity.HasOne(d => d.PlatformNavigation).WithMany()
                .HasForeignKey(d => d.Platform)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlatformCountries_fk0");
        });

        modelBuilder.Entity<PlatformMovie>(entity =>
        {
            entity.HasNoKey();

            entity.HasOne(d => d.MovieNavigation).WithMany()
                .HasForeignKey(d => d.Movie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlatformMovies_fk0");

            entity.HasOne(d => d.PlatformNavigation).WithMany()
                .HasForeignKey(d => d.Platform)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlatformMovies_fk1");
        });

        modelBuilder.Entity<PlatformsUser>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.SubscribedUntil).HasColumnType("datetime");
            entity.Property(e => e.User).HasColumnName("User_");

            entity.HasOne(d => d.PlatformNavigation).WithMany()
                .HasForeignKey(d => d.Platform)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlatformsUsers_fk0");

            entity.HasOne(d => d.UserNavigation).WithMany()
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlatformsUsers_fk1");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_STAFF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Bio)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Oskars).HasDefaultValueSql("('0')");
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('NO_PHOTO_URL')");
            entity.Property(e => e.Role)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_USERS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Country)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Users_fk0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
