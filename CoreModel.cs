using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace trr;

public partial class CoreModel : DbContext
{
    private static CoreModel instance;
    public static CoreModel init()
    {
        if(instance == null)
            instance = new CoreModel();
        return instance;
    }
    public CoreModel()
    {
    }

    public CoreModel(DbContextOptions<CoreModel> options)
        : base(options)
    {
    }

    public virtual DbSet<Avtorizaciya> Avtorizaciyas { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Lekciya> Lekciyas { get; set; }

    public virtual DbSet<Ocenka> Ocenkas { get; set; }

    public virtual DbSet<Polzovatel> Polzovatels { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Va> Vas { get; set; }

    public virtual DbSet<Vb> Vbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("port=3306;database=ISPr23-35_PetryakovaDS_school;password=ISPr23-35_PetryakovaDS;user id=ISPr23-35_PetryakovaDS;character set=utf8;server=cfif31.ru", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Avtorizaciya>(entity =>
        {
            entity.HasKey(e => e.IdAvtorizaciya).HasName("PRIMARY");

            entity.ToTable("Avtorizaciya");

            entity.Property(e => e.IdAvtorizaciya).HasColumnName("idAvtorizaciya");
            entity.Property(e => e.Login)
                .HasMaxLength(100)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.IdClass).HasName("PRIMARY");

            entity.ToTable("Class");

            entity.Property(e => e.IdClass).HasColumnName("idClass");
            entity.Property(e => e.BykvaClassa).HasMaxLength(45);
        });

        modelBuilder.Entity<Lekciya>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lekciya");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lec)
                .HasMaxLength(5000)
                .HasColumnName("lec");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ocenka>(entity =>
        {
            entity.HasKey(e => e.IdOcenka).HasName("PRIMARY");

            entity.ToTable("Ocenka");

            entity.HasIndex(e => e.IdPolzovatel, "idPolzovatel_idx");

            entity.Property(e => e.IdOcenka).HasColumnName("idOcenka");
            entity.Property(e => e.IdPolzovatel).HasColumnName("idPolzovatel");
            entity.Property(e => e.Result).HasMaxLength(45);

            entity.HasOne(d => d.IdPolzovatelNavigation).WithMany(p => p.Ocenkas)
                .HasForeignKey(d => d.IdPolzovatel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ocenka_idPolzovatel");
        });

        modelBuilder.Entity<Polzovatel>(entity =>
        {
            entity.HasKey(e => e.IdPolzovatel).HasName("PRIMARY");

            entity.ToTable("Polzovatel");

            entity.HasIndex(e => e.IdAvtorizaciya, "idAvtorizaciya_idx");

            entity.HasIndex(e => e.IdClass, "idClass_idx");

            entity.Property(e => e.IdPolzovatel).HasColumnName("idPolzovatel");
            entity.Property(e => e.IdAvtorizaciya).HasColumnName("idAvtorizaciya");
            entity.Property(e => e.IdClass).HasColumnName("idClass");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.IdAvtorizaciyaNavigation).WithMany(p => p.Polzovatels)
                .HasForeignKey(d => d.IdAvtorizaciya)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idAvtorizaciya");

            entity.HasOne(d => d.IdClassNavigation).WithMany(p => p.Polzovatels)
                .HasForeignKey(d => d.IdClass)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idClass");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Class)
                .HasMaxLength(45)
                .HasColumnName("class");
            entity.Property(e => e.Fio)
                .HasMaxLength(99)
                .HasColumnName("fio");
            entity.Property(e => e.Login)
                .HasMaxLength(45)
                .HasColumnName("login");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Idtest).HasName("PRIMARY");

            entity.ToTable("test");

            entity.Property(e => e.Idtest).HasColumnName("idtest");
            entity.Property(e => e.V1).HasColumnName("v1");
            entity.Property(e => e.V2).HasColumnName("v2");
            entity.Property(e => e.V3).HasColumnName("v3");
            entity.Property(e => e.V4).HasColumnName("v4");
            entity.Property(e => e.V5).HasColumnName("v5");
        });

        modelBuilder.Entity<Va>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("PRIMARY");

            entity.ToTable("va");

            entity.Property(e => e.Date).HasMaxLength(11);
            entity.Property(e => e.Анд).HasMaxLength(45);
            entity.Property(e => e.Борисов).HasMaxLength(45);
            entity.Property(e => e.Гофман).HasMaxLength(45);
            entity.Property(e => e.Козлов).HasMaxLength(45);
            entity.Property(e => e.Петрова).HasMaxLength(45);
        });

        modelBuilder.Entity<Vb>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vb");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Андреев).HasMaxLength(45);
            entity.Property(e => e.Баринова).HasMaxLength(45);
            entity.Property(e => e.Дата).HasMaxLength(15);
            entity.Property(e => e.Костратов).HasMaxLength(45);
            entity.Property(e => e.Лимонов).HasMaxLength(45);
            entity.Property(e => e.Яникс).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
