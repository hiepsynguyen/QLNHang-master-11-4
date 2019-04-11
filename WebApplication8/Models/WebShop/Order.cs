using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.WebShop
{
    public partial class Order
    {
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RequireDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Receiver { get; set; }

        [Required]
        public string Address { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public double Amount { get; set; }

        public string Phone { get; set; }
        public int Status { get; set; }

        [EmailAddress]
        public string EmailContact { get; set; }
        public string LabelStatus { get { if (this.Status == 0) { return "Chờ xác nhận"; }
                else if (this.Status == 1) { return "Đã xác nhận"; }
                else if (this.Status == -1) { return "Đã xóa"; }
                return "Đã thanh toán";
            } }

        public string CodeOrder { get; set; }
        public string Alias { set; get; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
