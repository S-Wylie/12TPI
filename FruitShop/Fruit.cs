
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitShop
{
    public class Fruit
    {
        public String Description { get; set; }
        public int Qty { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }

        private static readonly int markup = 75;
        public static int totalQty;
        public static decimal totalCost;
        public Fruit (string d, int qty, decimal c)
        {
            Description = d;
            Qty = qty;
            CostPrice = c;
            SellingPrice = CostPrice + (CostPrice * markup / 100);
            totalQty += qty;
            totalCost += CostPrice * qty;
        }

        public override string ToString()
        {
            return $"Description: {Description}, Qty: {Qty}, CostPrice: {CostPrice:C}, SellingPrice: {SellingPrice:C}";
        }

        public void sell (int q)
        {
            Qty = Qty - q;
            totalQty = totalQty - q;
            totalCost = CostPrice * totalQty;
        }
    }
}
