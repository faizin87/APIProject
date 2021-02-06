using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class UsersModel
    {
        public string Next { get; set; }
        public int? Start { get; set; }
        public int? Total { get; set; }
        public IQueryable<UsersTable> Data { get; set; }
        public List<UsersTable> Value { get; set; }
    }

    public class SPUserCount
    {
        [Key]
        public int Number { get; set; }
    }
    public class NumberModel
    {
        [Key]
        public string Number { get; set; }
    }

    public class UserPostModel
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string EmailAddress { get; set; }
    }

    public class BillPostModel
    {
        [Required]
        public string BillId { get; set; }

        [Required]
        public string Number { get; set; }
        [Required]
        public string LanguangeId { get; set; }
        [Required]
        public string CurrencyId { get; set; }
        public string From { get; set; }
        [Required]
        public string DestinationId { get; set; }
        
        [Required]
        public string Date { get; set; }
        [Required]
        public string InvoiceDue { get; set; }
        [Required]
        public string PurchaseOrderId { get; set; }
        [Required]
        public string MeasurementId { get; set; }
        [Required]
        public string SubTotal { get; set; }
        [Required]
        public string Discount { get; set; }
        [Required]
        public string Total { get; set; }
        [Required]
        public string Status { get; set; }
        public string DiscountName { get; set; }
        public BillDetailPostModel BillDetailPost { get; set; }
    }

    public class BillDetailPostModel
    {

        [Required]
        public string BillId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Quantity { get; set; }
        public string Rate { get; set; }
        [Required]
        public string Amount { get; set; }
    }

}
