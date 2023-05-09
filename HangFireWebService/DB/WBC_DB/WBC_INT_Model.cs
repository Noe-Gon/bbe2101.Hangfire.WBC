namespace HangFireWebService.DB.WBC_DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WBC_INT_Model : DbContext
    {
        public WBC_INT_Model()
            : base("name=SmartOrderModel")
        {
        }

        public virtual DbSet<so_binnacle_visit> so_binnacle_visit { get; set; }
        public virtual DbSet<so_branch> so_branch { get; set; }
        public virtual DbSet<so_customer> so_customer { get; set; }
        public virtual DbSet<so_user> so_user { get; set; }
        public virtual DbSet<delta_catalogs> delta_catalogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<so_branch>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<so_branch>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<so_branch>()
                .HasMany(e => e.so_user)
                .WithRequired(e => e.so_branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<so_customer>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<so_customer>()
                .Property(e => e.contact)
                .IsUnicode(false);

            modelBuilder.Entity<so_customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<so_customer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<so_customer>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<so_customer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<so_customer>()
                .HasMany(e => e.so_binnacle_visit)
                .WithRequired(e => e.so_customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<so_user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<so_user>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<so_user>()
                .Property(e => e.tag)
                .IsUnicode(false);

            modelBuilder.Entity<so_user>()
                .HasMany(e => e.so_binnacle_visit)
                .WithRequired(e => e.so_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<delta_catalogs>()
               .Property(e => e.code)
               .IsUnicode(false);

            modelBuilder.Entity<delta_catalogs>()
                .Property(e => e.catalog_name)
                .IsUnicode(false);
        }
    }
}
