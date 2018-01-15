using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyBearKingdom.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "${0:0.00}")]  
        public int Cost { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                return this.Id.Equals(newProduct.Id);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
