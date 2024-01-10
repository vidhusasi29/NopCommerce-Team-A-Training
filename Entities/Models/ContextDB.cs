using Entities.Models.Catalog;
using Entities.Models.ContentManagement;
using Entities.Models.Customers;
using Entities.Models.Promotions;
using Entities.Models.Sales;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Models
{
    public class ContextDB : DbContext
    {
        public ContextDB() { }
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasOne(e => e.Customer_ID)
                .WithMany()
                .HasForeignKey(e => e.CustomerRegistrationid)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CustomerRegistration>()
              .HasOne(e => e.vendor)
              .WithMany()
              .HasForeignKey(e => e.Vendorsid)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CustomerRegistration>()
              .HasOne(e => e.NewsItems)
              .WithMany()
              .HasForeignKey(e => e.NewsItemsid)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
               .HasOne(e => e.Vendors)
               .WithMany()
               .HasForeignKey(e => e.Vendorsid)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
              .HasOne(e => e.Products)
              .WithMany()
              .HasForeignKey(e => e.Productsid)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
              .HasOne(e => e.CustomerRegistration)
              .WithMany()
              .HasForeignKey(e => e.CustomerRegistrationid)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Products>()
              .HasOne(e => e.vendors)
              .WithMany()
              .HasForeignKey(e => e.VendorsId)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Products>()
             .HasOne(e => e.Discounts)
             .WithMany()
             .HasForeignKey(e => e.DiscountsId)
             .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Products>()
            .HasOne(e => e.Categories)
            .WithMany()
            .HasForeignKey(e => e.CategoriesId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Products>()
            .HasOne(e => e.Manufacturers)
            .WithMany()
            .HasForeignKey(e => e.ManufacturersId)
            .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Shipments>()
            .HasOne(e => e.Order)
            .WithMany()
            .HasForeignKey(e => e.Orderid)
            .OnDelete(DeleteBehavior.NoAction);
           


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<NewsItems> NewsItems { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<CustomerRegistration> CustomerRegistration { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }
        public virtual DbSet<Affiliates> Affiliates { get; set; }
        public virtual DbSet<Campaigns> Campaigns { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<NewsletterSubscribers> News { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ReturnRequest> ReturnRequest { get; set; }
        public virtual DbSet<Shipments> Shipments { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Nopcom;Integrated Security=True;TrustServerCertificate=True;");
    }
}
