using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Net_API.Entities;

public partial class DataNetContext : DbContext
{
    public DataNetContext()
    {
    }

    public DataNetContext(DbContextOptions<DataNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserView> UserViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HUE-ANHLTN\\SQLEXPRESS;Initial Catalog=DataNet;User ID=sa;Password=123456;Multiple Active Result Sets=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.ToTable("Donhang");

            entity.Property(e => e.IdProduct).HasColumnName("Id_product");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");
        });

        modelBuilder.Entity<UserView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UserView");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
