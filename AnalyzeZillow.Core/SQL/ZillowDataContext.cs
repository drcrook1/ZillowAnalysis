namespace AnalyzeZillow.Core.SQL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    /// <summary>
    /// Entity Framework Generated Code.  You will need to search in the app.config 
    /// for ZillowDataContext to find the connection string and replace with your own.
    /// </summary>
    public partial class ZillowDataContext : DbContext
    {
        public ZillowDataContext()
            : base("name=ZillowDataContext")
        {
        }

        public virtual DbSet<Home> Homes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Home>()
                .Property(e => e.State)
                .IsFixedLength();

            modelBuilder.Entity<Home>()
                .Property(e => e.Latitude)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Home>()
                .Property(e => e.Longitude)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Home>()
                .Property(e => e.TaxAssessment)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Home>()
                .Property(e => e.NumBathrooms)
                .HasPrecision(18, 0);
        }
    }
}
