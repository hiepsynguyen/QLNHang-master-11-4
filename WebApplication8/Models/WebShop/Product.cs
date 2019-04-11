using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Data;

namespace WebApplication8.Models.WebShop
{
    public partial class Product
    {
       // WebShopContext webcontext =new WebShopContext();
       

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [Range(0,100000000000, ErrorMessage = "Price must be between 0 and 100 000 000 000.00")]
        public double PriceP { get; set; }


        [Required]
        public string Image { get; set; }

        public DateTime ProductDate { get; set; }

        public bool Available { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        public int ? CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierId { get; set; }

        public int Quantity { get; set; }

        public double Discount { get; set; }

        public bool Special { get; set; }

        public bool Latest { get; set; }

        public int Views { get; set; }

        public Category Category {
            get;set;
        }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
