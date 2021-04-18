using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Models.ViewModel {
    public class CategoryViewModel {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int StockLimit { get; set; }
    }
}
