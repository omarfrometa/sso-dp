﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SSO.BO.Entities;

namespace SSO.BO.Data
{
    public partial class SSOContext : DbContext
    {
        public SSOContext()
        {
        }

        public SSOContext(DbContextOptions<SSOContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginType> LoginType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginType>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.LoginTypeCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .HasConstraintName("FK_LoginType_User");

                entity.HasOne(d => d.ModifiedByUser)
                    .WithMany(p => p.LoginTypeModifiedByUser)
                    .HasForeignKey(d => d.ModifiedByUserId)
                    .HasConstraintName("FK_LoginType_User1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceId).IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(140)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.EmailComfirmedDate).HasColumnType("datetime");

                entity.Property(e => e.LastAccessDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginIpAddress)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LastPwdChanged).HasColumnType("datetime");

                entity.Property(e => e.LockedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneComfirmedDate).HasColumnType("datetime");

                entity.Property(e => e.PictureProfile)
                    .HasMaxLength(260)
                    .IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LoginType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.LoginTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_LoginType");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProfile)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_User");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.UserTypeCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .HasConstraintName("FK_UserType_User");

                entity.HasOne(d => d.ModifiedByUser)
                    .WithMany(p => p.UserTypeModifiedByUser)
                    .HasForeignKey(d => d.ModifiedByUserId)
                    .HasConstraintName("FK_UserType_User1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}