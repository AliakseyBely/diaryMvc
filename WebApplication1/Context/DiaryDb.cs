namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DiaryDb : DbContext
    {
        public DiaryDb()
            : base("name=DiaryContext")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<MessDiary> MessDiaries { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.Message)
                .IsFixedLength();

            modelBuilder.Entity<MessDiary>()
                .Property(e => e.Topic)
                .IsFixedLength();

            modelBuilder.Entity<MessDiary>()
                .Property(e => e.Message)
                .IsFixedLength();

            modelBuilder.Entity<MessDiary>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.MessDiary)
                .HasForeignKey(e => e.IdMDiary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);
        }
    }
}
