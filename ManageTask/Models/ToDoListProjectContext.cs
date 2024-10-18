using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ToDoListProject.Models;

public partial class ToDoListProjectContext : DbContext
{
    public ToDoListProjectContext()
    {
    }

    public ToDoListProjectContext(DbContextOptions<ToDoListProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Member> Members { get; set; } = null!;
    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<ToDo> ToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        base.OnConfiguring(optionsBuilder);
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json",
                                     optional: false,
                                     reloadOnChange: true);

        var configurationRoot = builder.Build();

        var connectionString = configurationRoot.GetConnectionString("MyCnn");
        optionsBuilder.UseSqlServer(connectionString);


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(entity =>
        {
            entity.ToTable("Member");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(15);
        });

        modelBuilder.Entity<ToDo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Todo");

            entity.ToTable("ToDo");

            entity.Property(e => e.Deadline).HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.ToDos)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ToDo__StatusId__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
