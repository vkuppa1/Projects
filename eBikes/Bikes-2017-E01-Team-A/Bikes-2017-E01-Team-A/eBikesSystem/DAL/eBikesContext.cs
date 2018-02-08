using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using eBikes.Data.Entities;

namespace eBikesSystem.DAL
{
    internal class eBikesContext : DbContext
    {
        public eBikesContext() : base("name = eBikesDB")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobDetailPart> JobDetailParts { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<OnlineCustomer> OnlineCustomers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<ReceiveOrderDetail> ReceiveOrderDetails { get; set; }
        public DbSet<ReceiveOrder> ReceiveOrders { get; set; }
        public DbSet<ReturnedOrderDetail> ReturnedOrderDetails { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<SaleRefundDetail> SaleRefundDetails { get; set; }
        public DbSet<SaleRefund> SaleRefunds { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<StandardJobPart> StandardJobParts { get; set; }
        public DbSet<StandardJob> StandardJobs { get; set; }
        public DbSet<UnorderedPurchaseItemCart> UnorderedPurchaseItemCarts { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}
