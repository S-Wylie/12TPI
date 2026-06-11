using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStoreConsole.Model
{
    public class Brands
    {
        public int BrandID { get; set; }
        public String BrandName { get; set; }
        public Brands() { }
        public Brands (int brandID, string brandName)
        {
            BrandID = brandID;
            BrandName = brandName;
        }
    }
}
