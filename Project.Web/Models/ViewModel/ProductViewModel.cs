using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models.ViewModel {
    public class ProductViewModel {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int StockQuantity { get; set; }

        public decimal Price { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
