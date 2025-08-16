using Microsoft.EntityFrameworkCore;
using BlurApi.Models; 

namespace BlurApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Console.WriteLine("Connected to database.");
        }

        public DbSet<TaxAddress> TaxAddress {get; set;}
        public DbSet<Enterprices> Enterprices {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enterprices>(entity =>{
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()").HasColumnName("id");
                entity.Property(e => e.Title).IsRequired().HasMaxLength(255).HasColumnName("title");
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(12).HasColumnName("phone");
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255).HasColumnName("email");
                entity.Property(e => e.Balance).HasColumnType("real").HasColumnName("balance");
                entity.Property(e => e.Address).HasMaxLength(1000).HasColumnName("address");
                entity.Property(e => e.TaxNumber).IsRequired().HasColumnName("tax_number");
                entity.Property(e => e.Verified).HasDefaultValue(true).HasColumnName("verified");
                entity.Property(e => e.Disabled).HasDefaultValue(false).HasColumnName("disabled");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at");
                
               
                entity.Property(e => e.InsertedBy).IsRequired(false).HasColumnName("inserted_by");
                entity.Property(e => e.InsertedDate).HasColumnName("inserted_date").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.ChangedDate).IsRequired(false).HasColumnName("changed_date");
                entity.Property(e => e.ChangedBy).IsRequired(false).HasColumnName("changed_by");
                
                entity.HasOne(e => e.TaxAddress)
                    .WithMany()
                    .HasForeignKey("tax_address_id")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TaxAddress>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasDefaultValueSql("NEWID()").HasColumnName("id");
                entity.Property(t => t.Province).IsRequired().HasMaxLength(100).HasColumnName("province");
                entity.Property(t => t.District).IsRequired().HasMaxLength(100).HasColumnName("district");
                
                entity.Property(t => t.InsertedBy).IsRequired(false).HasColumnName("inserted_by");
                entity.Property(e => e.InsertedDate).HasColumnName("inserted_date").HasDefaultValueSql("GETDATE()"); 
                entity.Property(t => t.ChangedDate).IsRequired(false).HasColumnName("changed_date");
                entity.Property(t => t.ChangedBy).IsRequired(false).HasColumnName("changed_by");
            });
        }

        
    }
}