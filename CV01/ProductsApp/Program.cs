using System.Net.Http.Headers;

namespace ProductsApp
{

    delegate string MyDelegate(int x, int y);

    delegate bool FilterFn<T>(T condition);

    static class MyExt
    {
        public static string JoinNumbers(this IEnumerable<int> nums)
        {
            return string.Join("; ", nums);
        }

        public static IEnumerable<T> GetEven<T>(this IEnumerable<T> nums)
        {
            int i = 0;
            foreach (T x in nums)
            {
                if (i % 2 == 0)
                {
                    yield return x;
                }
                i++;
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> nums, FilterFn<T> fn)
        {
            int i = 0;
            foreach (T x in nums)
            {
                if (fn(x))
                {
                    yield return x;
                }
                i++;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //    Calculator calc = new Calculator();

            //    calc.OnSetXY += (object? sender, EventArgs args) =>
            //    {
            //        Console.WriteLine("XY nastaveno.");
            //    };

            //    calc.OnCompute += (sender, args) =>
            //    {
            //        Console.WriteLine("Výsledek: " + args.Result);
            //    };

            //    calc.SetXY(4, 10);
            //    calc.Execute((a, b) => a + b);
            //    calc.Execute((int a, int b) => a + b);
            //    calc.Execute((int a, int b) =>
            //    {
            //        return a + b;
            //    });


            //int[] nums = new int[] { 2, 4, 5, 6, 33, 27, 41 };
            //Console.WriteLine(MyExt.JoinNumbers(nums));
            //Console.WriteLine(nums.JoinNumbers());

            //List<int> nums2 = new List<int>() { 2, 4, 5, 6, 33, 27, 41 };
            //Console.WriteLine(nums2.JoinNumbers());

            //Console.WriteLine(nums.Filter(x => x < 10).JoinNumbers());
            //Console.WriteLine(nums.Filter(x => x > 10).Filter(x => x < 30).JoinNumbers());


            IEnumerable<Product> products = GetProducts();
            double? price_sum = products.Select(x => x.Price).Sum();

            int product_count = products.Count();

            double? average = price_sum / product_count;


            double? average2 = products.Select(x => x.Price).Average();
            // double average2 = products.Average(x => x.Price);

            // Spočítat průměrnou cenu jen produktů, které jsou skladem.
            double? average3 = products.Where(x => x.Quantity > 0).Average(x => x.Price);

            // Získat pouze názvy všech produktů.
            string[] names = products.Select(x => x.Name).ToArray();

            // Výběr prvního produktu.
            Product p1 = products.FirstOrDefault(x => x.Quantity == 0);

            // Výběr posledního produktu.
            Product p2 = products.LastOrDefault();

            // Rozdělení produktů do skupin na základě toho, zdali jsou, nebo nejsou skladem.
            foreach (IGrouping<int, Product> group in products.GroupBy(x => x.Quantity))
            {
                Console.WriteLine("Počet skladem: " + group.Key);
                foreach(Product product in group)
                {
                    Console.WriteLine(product.Name);
                }
                Console.WriteLine();
            }

            
        }

        private static string Format(int a, int b)
        {
            return a + " | " + b;
        }

        private static string Format2(int a, int b)
        {
            return a + " | " + b;
        }


        private static IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product(){ Id = 1, Name = "Auto", Price = 700_000, Quantity = 10 },
                new Product(){ Id = 1, Name = "Slon", Price = 1_500_000, Quantity = 0 },
                new Product(){ Id = 1, Name = "Kolo", Price = 26_000, Quantity = 5 },
                new Product(){ Id = 1, Name = "Brusle", Price = 2_800, Quantity = 30 },
                new Product(){ Id = 1, Name = "Hodinky", Price = 18_500, Quantity = 2 },
                new Product(){ Id = 1, Name = "Mobil", Price = 24_000, Quantity = 0 }
            };
        }
    }
}
