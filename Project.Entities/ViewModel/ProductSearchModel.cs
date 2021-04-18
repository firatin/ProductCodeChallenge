using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities.ViewModel {
    public class ProductSearchModel {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int? MinStock { get; set; }
        public int? MaxStock { get; set; }
    }
}
