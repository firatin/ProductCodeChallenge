using Project.Core.Object;
using System.ComponentModel.DataAnnotations;

namespace Project.Entities.Object {
    public class Product : ObjectBase, IEntity {
        [Required(ErrorMessage = "Title zorunludur.")]
        [MaxLength(200,ErrorMessage ="Maksimum 200 karakter.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description zorunludur.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "StockQuantity zorunludur.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Price zorunludur.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "CategoryId zorunludur.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
