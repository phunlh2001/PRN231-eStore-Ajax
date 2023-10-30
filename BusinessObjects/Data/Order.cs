using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Data
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string MemberId { get; set; }
        public string OrderDate { init; get; } = DateTime.Now.ToString("dd/MM/yyyy");
        public string RequiredDate { get; set; }
        public string ShippedDate { get; set; }
        [Required] public decimal Freight { get; set; }

        public Member Member { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
