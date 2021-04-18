using Project.Core.Object;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Entities.Object {
    public class Category : ObjectBase, IEntity {
        [Required(ErrorMessage = "CategoryName zorunludur.")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Description zorunludur.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "StockLimit zorunludur.")]
        public int StockLimit { get; set; }


    }
}
