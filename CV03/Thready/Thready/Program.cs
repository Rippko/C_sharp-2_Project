namespace Thready
{
    internal class Program
    {
        private static int x = 0;

        private static object lockObj = new object();

        private static object lockObj2 = new object();
        static async Task Main(string[] args)
        {
            //kritická sekce
            //object jako parametr sekce lock slouží pro to abych mohl rozlišit jestli na stejné objekty mohou přistupovat vícero vláken
            //lock (lockObj)
            //{
            //    x++;
            //}

            //lock (lockObj2)
            //{
            //    x++;
            //}

            //int x = 0;
            //Thread t = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        //Console.WriteLine("A");
            //        x++;
            //        if (x > 40)
            //        {
            //            return;
            //        }
            //    }

            //});
            //t.Start();

            //t.Join(); //vlákno nad kterém volám join se zastaví


            //SimpleStack<int> stack = new SimpleStack<int>();
            //Random rand = new Random();

            //object emptyObj = new object();

            //Thread insert_thread = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        lock (emptyObj)
            //        {
            //            stack.Push(rand.Next());
            //            Monitor.Pulse(emptyObj);
            //        }
            //        Thread.Sleep(1000);
            //    }
            //});
            //insert_thread.Start();

            

            //for (int i = 0; i < 5; i++)
            //{
            //    Thread thread = new Thread(() =>
            //    {
            //        while (true)
            //        {

            //            lock (emptyObj)
            //            {
            //                if (!stack.IsEmpty)
            //                {
            //                    int x = stack.Pop();
            //                    Console.WriteLine($"X: {x} Thread id: {Thread.CurrentThread.ManagedThreadId}");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Empty");
            //                    Monitor.Wait(emptyObj);
            //                }
            //            }
            //            Thread.Sleep(rand.Next(40, 1000));
            //        }
            //    });
            //    thread.Start();
            //}

            //object emptyObj2 = new object();

            //for (int i = 0; i < 5; i++)
            //{
            //    Thread thread = new Thread(() =>
            //    {
            //        while (true)
            //        {
            //            if(rand.NextDouble() < 0.6)
            //            {
            //                lock (emptyObj2)
            //                {
            //                    if (!stack.IsEmpty)
            //                    {
            //                        int x = stack.Pop();
            //                        Console.WriteLine($"X: {x} Thread id: {Thread.CurrentThread.ManagedThreadId}");
            //                    }
            //                }
            //                Thread.Sleep(rand.Next(40, 1000));
            //            }
            //            else
            //            {
            //                stack.Push(rand.Next());
            //            }
            //        }
            //    });
            //    thread.Start();
            //}
            

            //Task task = Task.Delay(1000);

            //Console.WriteLine("Jsem na kafi");
            
            //await task;

            //Console.WriteLine("Jáma vykopána");

            //await File.WriteAllTextAsync("data.txt", "500");
            //Task<string> txt = File.ReadAllTextAsync("data.txt");
            
            //string text = await txt;

            //string text2 = await File.ReadAllTextAsync("data.txt");

            //Console.WriteLine(text);

            int a = await GetInt();

            int b = await GetInt2();

            Console.ReadKey();
        }

        private static async Task<int> GetInt()
        {
            string text = await File.ReadAllTextAsync("data.txt");
            return int.Parse(text);
        }

        private static Task<int> GetInt2()
        {
            return Task.FromResult(1);
        }

        private static Task<int> GetInt3()
        {
            return GetInt2();
        }

        private static async Task Experiment()
        {
            Console.WriteLine("Start");
            await Task.Delay(1000);
            using StreamWriter sw = new StreamWriter("data.txt");
            await sw.WriteLineAsync("aa");
            await Task.Delay(1000);
            Console.WriteLine("End");
        }
    }
}
