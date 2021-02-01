using OEWIO.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OEWIO.DAL
{
    public class OEWIOContext: DbContext
    {
        public OEWIOContext() : base("OEWIOContext")
        {

        }
        public virtual DbSet<OEWIOArticle> OEWIOArticle { get; set; }
        public virtual DbSet<OEWIOAuthor> OEWIOAuthor { get; set; }

        public virtual DbSet<OEWIOProduct> OEWIOProduct { get; set; }
        //public virtual DbSet<OEWIOCommentary> OEWIOCommentaries { get; set; }
        //public virtual DbSet<OEWIOProductRegion> OEWIOProductRegions { get; set; }
        //public virtual DbSet<OEWIORegion> OEWIORegions { get; set; }
        //public virtual DbSet<OEWIOSource> OEWIOSources { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}