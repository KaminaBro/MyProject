using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PickupPoint> PickupPoints { get; set; }

    public virtual DbSet<Tovar> Tovars { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Zakaz> Zakazs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.1.65;Port=5432;Database=postgres;Username=postgres;Password=toor");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PickupPoint>(entity =>
        {
            entity.HasKey(e => e.Index).HasName("newtable_pk");

            entity.ToTable("pickup_point");

            entity.Property(e => e.Index)
                .HasColumnType("character varying")
                .HasColumnName("index");
            entity.Property(e => e.City)
                .HasColumnType("character varying")
                .HasColumnName("city");
            entity.Property(e => e.House)
                .HasColumnType("character varying")
                .HasColumnName("house");
            entity.Property(e => e.Street)
                .HasColumnType("character varying")
                .HasColumnName("street");
        });

        modelBuilder.Entity<Tovar>(entity =>
        {
            entity.HasKey(e => e.Article).HasName("tovar_pk");

            entity.ToTable("tovar");

            entity.Property(e => e.Article)
                .HasMaxLength(6)
                .HasColumnName("article");
            entity.Property(e => e.Category)
                .HasColumnType("character varying")
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Manufacture)
                .HasColumnType("character varying")
                .HasColumnName("manufacture");
            entity.Property(e => e.NameTovar)
                .HasColumnType("character varying")
                .HasColumnName("name_tovar");
            entity.Property(e => e.Photo)
                .HasColumnType("character varying")
                .HasColumnName("photo");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Supplier)
                .HasColumnType("character varying")
                .HasColumnName("supplier");
            entity.Property(e => e.Unit)
                .HasColumnType("character varying")
                .HasColumnName("unit");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Login).HasName("user_pk");

            entity.ToTable("User");

            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasColumnType("character varying")
                .HasColumnName("role");
            entity.Property(e => e.Логин)
                .HasMaxLength(50)
                .HasColumnName("логин");
            entity.Property(e => e.Пароль)
                .HasMaxLength(50)
                .HasColumnName("пароль");
            entity.Property(e => e.РольСотрудника)
                .HasMaxLength(50)
                .HasColumnName("Роль сотрудника");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .HasColumnName("фио");
        });

        modelBuilder.Entity<Zakaz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("zakaz_pk");

            entity.ToTable("zakaz");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.Articul)
                .HasMaxLength(6)
                .HasColumnName("articul");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.Address)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zakaz_pickup_point_fk");

            entity.HasOne(d => d.ArticulNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.Articul)
                .HasConstraintName("zakaz_tovar_fk");

            entity.HasOne(d => d.LoginNavigation).WithMany(p => p.Zakazs)
                .HasForeignKey(d => d.Login)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zakaz_user_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
