using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JAG.Toddler.Core.Models.Default
{
    public partial class JAGToddlerDatabaseContext : DbContext
    {
        public JAGToddlerDatabaseContext()
        {
        }

        public JAGToddlerDatabaseContext(DbContextOptions<JAGToddlerDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classifications> Classifications { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Consultants> Consultants { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<LogEntries> LogEntries { get; set; }
        public virtual DbSet<Markup> Markup { get; set; }
        public virtual DbSet<ReportSelect> ReportSelect { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=JAG.Toddler.Database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Classifications>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("tblClassifications$PrimaryKey");

                entity.HasIndex(e => e.DeptId)
                    .HasName("tblClassifications$Reference");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassDescription).HasMaxLength(50);

                entity.Property(e => e.Classes).HasMaxLength(25);

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.InternalClass)
                    .HasColumnName("Internal Class")
                    .HasMaxLength(50);

                entity.Property(e => e.Mupercent)
                    .HasColumnName("MUPercent")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0.55))");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Classifications)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("tblClassifications$Reference");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => new { e.LogDate, e.StoreId })
                    .HasName("tblComment$PrimaryKey");

                entity.HasIndex(e => e.LogDate)
                    .HasName("tblComment$LogDate");

                entity.HasIndex(e => e.StoreId)
                    .HasName("tblComment$Reference9");

                entity.Property(e => e.LogDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Comment1).HasColumnName("Comment");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("tblComment$Reference9");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("tblCompanies$PrimaryKey");

                entity.HasIndex(e => e.Company)
                    .HasName("tblCompanies$Company");

                entity.HasIndex(e => e.ConsultId)
                    .HasName("tblCompanies$Reference4");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ComAddess2).HasMaxLength(50);

                entity.Property(e => e.ComAddress1).HasMaxLength(50);

                entity.Property(e => e.ComCity).HasMaxLength(50);

                entity.Property(e => e.ComState).HasMaxLength(2);

                entity.Property(e => e.ComZip).HasMaxLength(10);

                entity.Property(e => e.Company).HasMaxLength(50);

                entity.Property(e => e.ConsultId)
                    .HasColumnName("ConsultID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Owner).HasMaxLength(50);

                entity.Property(e => e.OwnerPhone).HasMaxLength(50);

                entity.Property(e => e.StartFiscalYear).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Consult)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.ConsultId)
                    .HasConstraintName("tblCompanies$Reference4");
            });

            modelBuilder.Entity<Consultants>(entity =>
            {
                entity.HasKey(e => e.ConsultId)
                    .HasName("tblConsultants$PrimaryKey");

                entity.Property(e => e.ConsultId).HasColumnName("ConsultID");

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(20);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(14);
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("tblDepartments$PrimaryKey");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("tblDepartments$Reference6");

                entity.Property(e => e.DeptId).HasColumnName("DeptID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.DeptDescription).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(25);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("tblDepartments$Reference6");
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.LogDate })
                    .HasName("tblExpenses$PrimaryKey");

                entity.HasIndex(e => e.LogDate)
                    .HasName("tblExpenses$LogDate");

                entity.HasIndex(e => e.StoreId)
                    .HasName("tblExpenses$StoreID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.LogDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.Expenses1)
                    .HasColumnName("Expenses")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("tblExpenses$Reference8");
            });

            modelBuilder.Entity<LogEntries>(entity =>
            {
                entity.HasKey(e => new { e.LogDate, e.StoreId, e.ClassId })
                    .HasName("tblLogEntries$PrimaryKey");

                entity.HasIndex(e => e.ClassId)
                    .HasName("tblLogEntries$Reference2");

                entity.HasIndex(e => e.LogDate)
                    .HasName("tblLogEntries$LogDate");

                entity.HasIndex(e => e.StoreId)
                    .HasName("tblLogEntries$StoreID");

                entity.Property(e => e.LogDate).HasColumnType("datetime2(0)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Markdowns).HasDefaultValueSql("((0))");

                entity.Property(e => e.MarkdownsPlanRatio)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Markups).HasDefaultValueSql("((0))");

                entity.Property(e => e.Physical).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhysicalNext).HasDefaultValueSql("((0))");

                entity.Property(e => e.RecAtRetailPlan).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedAtCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedAtRetail).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sales).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesPlan).HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.StockPlan).HasDefaultValueSql("((0))");

                entity.Property(e => e.StockPlanRatio)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Stocks).HasDefaultValueSql("((0))");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime2(0)");

                entity.Property(e => e.TransfersIn).HasDefaultValueSql("((0))");

                entity.Property(e => e.TransfersOut).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac10o)
                    .HasColumnName("UFAC10O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac1o)
                    .HasColumnName("UFAC1O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac2o)
                    .HasColumnName("UFAC2O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac3o)
                    .HasColumnName("UFAC3O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac4o)
                    .HasColumnName("UFAC4O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac5o)
                    .HasColumnName("UFAC5O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac6o)
                    .HasColumnName("UFAC6O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac7o)
                    .HasColumnName("UFAC7O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac8o)
                    .HasColumnName("UFAC8O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Ufac9o)
                    .HasColumnName("UFAC9O")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VendorReturnRetail).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.LogEntries)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblLogEntries$Reference2");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.LogEntries)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblLogEntries$Reference7");
            });

            modelBuilder.Entity<Markup>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ClassId })
                    .HasName("tblMarkup$PrimaryKey");

                entity.HasIndex(e => e.ClassId)
                    .HasName("tblMarkup$tblClassificationstblMarkup");

                entity.HasIndex(e => e.StoreId)
                    .HasName("tblMarkup$tblStorestblMarkup");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Locked).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mupercent)
                    .HasColumnName("MUPercent")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Otb)
                    .HasColumnName("OTB")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Report).HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Markup)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblMarkup$tblClassificationstblMarkup");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Markup)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tblMarkup$tblStorestblMarkup");
            });

            modelBuilder.Entity<ReportSelect>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.ReportId })
                    .HasName("tblReportSelect$PrimaryKey");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("tblReportSelect$Reference3");

                entity.HasIndex(e => e.ReportId)
                    .HasName("tblReportSelect$ReportID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ReportSelect)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("tblReportSelect$Reference3");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("tblStores$PrimaryKey");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("tblStores$Reference5");

                entity.HasIndex(e => e.ConsultId)
                    .HasName("tblStores$ConsultID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ConsultId)
                    .HasColumnName("ConsultID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Selected).HasDefaultValueSql("((0))");

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.StoreAddress1).HasMaxLength(50);

                entity.Property(e => e.StoreAddress2).HasMaxLength(50);

                entity.Property(e => e.StoreCity).HasMaxLength(50);

                entity.Property(e => e.StoreManager).HasMaxLength(50);

                entity.Property(e => e.StoreManagerPhone).HasMaxLength(50);

                entity.Property(e => e.StoreName).HasMaxLength(50);

                entity.Property(e => e.StoreState).HasMaxLength(2);

                entity.Property(e => e.StoreZip).HasMaxLength(10);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("tblStores$Reference5");
            });
        }
    }
}
