namespace ToDoApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoModel : DbContext
    {
        public ToDoModel()
            : base("name=ToDoModel")
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<List> Lists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<List>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.List)
                .WillCascadeOnDelete(false);
        }
    }
}
