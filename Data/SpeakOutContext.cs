using Microsoft.EntityFrameworkCore;
using speak_out.Models;

namespace speak_out.Data
{
    public partial class SpeakOutContext : DbContext
    {
        //public SpeakOutContext()
        //{
        //}

        public SpeakOutContext(DbContextOptions<SpeakOutContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Volunteers> Volunteers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost,1432;Initial Catalog=SpeakOut;Persist Security Info=True;User ID=sa;Password=!2E45678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName).HasMaxLength(250);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK__Posts__AA126038C4BE375D");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Post).HasMaxLength(250);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Posts__CategoryI__3C69FB99");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Posts__UserID__3D5E1FD2");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCACD8969D61");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName).HasMaxLength(250);

                entity.Property(e => e.UserPassword).HasMaxLength(250);
            });

            modelBuilder.Entity<Volunteers>(entity =>
            {
                entity.HasKey(e => e.VolunteerId)
                    .HasName("PK__Voluntee__716F6FCCEFE8FFA7");

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VolunteerEmail)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.VolunteerName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.VolunteerPassword)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.VolunteerPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.VolunteerSurname)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.VolunteerUserName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Volunteer__UserI__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
