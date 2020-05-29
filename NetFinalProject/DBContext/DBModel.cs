namespace NetFinalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<notice> notices { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<notice>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<notice>()
                .Property(e => e.author)
                .IsUnicode(false);

            modelBuilder.Entity<notice>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<notice>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.nickname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.pwd)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.avatar)
                .IsUnicode(false);
        }
    }
}
