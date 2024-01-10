using Entities.Models.Catalog;
using Entities.Models.Customers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Sales
{
    public class Order
    {
       [Key]
       public int ID { get; set; }    
       public DateTime StartDate { get; set; }
       public DateTime EndDate { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public OrderStatus OStatus { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public PaymentStatus PStatus { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public ShippingStatus SStatus { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public PaymentMethod paymentMethod { get; set; }
        public enum OrderStatus 
        {
            Pending,
            Processing,
            Completed,
            Cancelled
        }
        public enum PaymentStatus 
        {
            Pending,
            Authorized,
            Paid,
            Partially_Refunded,
            Refunded,
            Voided
        }
        public enum ShippingStatus 
        {
            Shipping_Not_Req,
            Not_Yet_Shipped,
            Partially_Shipped,
            Shipped,
            Delivered
        }
        public int BillingPhno {  get; set; }
        public string? BillingEmail { get; set; }
        public string? BillingName { get; set;}
        public string? BillingCountry { get; set;}
        public enum PaymentMethod 
        {
            PaypalCommerce,
            Check,
            CreditCard,
            DebitCard
        }
        public DateTime CreatedAt {  get; set; }
        public string? CreatedBy {  get; set; }
        public string? ModifiedBy {  get; set; }
        public DateTime ModifiedAt { get; set;}
        public bool IsDeleted { get; set; }=false;
        public int? Productsid { get; set; }
        public virtual Products? Products { get; set; }//fk
        public int? Vendorsid { get; set; }
        public virtual Vendors? Vendors { get; set; }//fk
        public int CustomerRegistrationid { get; set; }
        public virtual CustomerRegistration? CustomerRegistration { get; set; }
    }
}
