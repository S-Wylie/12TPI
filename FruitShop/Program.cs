namespace FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Adding 10 apples
            Fruit apple = new Fruit ("Apple",10,0.70m);
            Console.WriteLine(apple.ToString());
            Console.WriteLine($"Total fruit quantity in store: {Fruit.totalQty}");
            Console.WriteLine($"Total cost of fruit of inventory: {Fruit.totalCost}");

            //Adding 20 bananas
            Fruit banana = new Fruit ("Banana", 20, 0.50m);
            Console.WriteLine(banana.ToString());
            Console.WriteLine($"Total fruit quantity in store: {Fruit.totalQty}");
            Console.WriteLine($"Total cost of fruit of inventory: {Fruit.totalCost}");

            //Selling 5 bananas
            banana.sell(5);
            Console.WriteLine(banana.ToString());
            Console.WriteLine($"Total fruit quantity in store: {Fruit.totalQty}");
            Console.WriteLine($"Total cost of fruit of inventory: {Fruit.totalCost}");

            //Adding 15 oranges 
            Fruit orange = new Fruit ("Orange", 15, 0.80m);
            Console.WriteLine(orange.ToString());
            Console.WriteLine($"Total fruit quantity in store: {Fruit.totalQty}");
            Console.WriteLine($"Total cost of fruit of inventory: {Fruit.totalCost}");
        }
    }
}
