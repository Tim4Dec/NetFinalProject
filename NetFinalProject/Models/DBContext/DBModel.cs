namespace NetFinalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Notice> notices { get; set; }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Article> articles { get; set; }
        public virtual DbSet<Speech> speeches { get; set; }
        public virtual DbSet<Comment> comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Notice>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Notice>()
                .Property(e => e.author)
                .IsUnicode(false);

            modelBuilder.Entity<Notice>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<Notice>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.author)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<Article>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.nickname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.pwd)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.avatar)
                .IsUnicode(false);

        }
    }
}
