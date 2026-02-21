using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketAutomation
{
    public class Product
    {
        public int ID { get; set; }
        public int categoryID { get; set; }

        public int subCategoryID { get; set; }

        public string barcode { get; set; }

        public string name { get; set; }

        public double salePrice { get; set; }

        public string unit { get; set; }

     
    }




}
