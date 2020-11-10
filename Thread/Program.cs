using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Hilos
{
    class Program
    {
        static void WorkOnItem(object item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }
        public static void Mesero2()
        {

            Console.WriteLine("ATENDIENDO - MESERO 2");
            Thread.Sleep(2000);
            Console.WriteLine("ATENCION TERMINA DE MESERO 2 ");
        }
        public static void Mesero1()
        {
            Console.WriteLine("ATENDIENDO - MESERO 1");
            Thread.Sleep(2000);
            Console.WriteLine("ATENCION TERMINA DE MESERO 1 ");

        }
        static void Main(string[] args)
        {
            //Parallel.Invoke(() => Mesero2(), () => Mesero1());    
            //var items = Enumerable.Range(0, 100).ToArray();
            //Parallel.For(0, items.Length, i =>
            //{
            //    WorkOnItem(items[i]);
            //});
            //Console.WriteLine("Finished processing. Press a key to end.");
            //Console.ReadKey();
            var items = Enumerable.Range(0, 20).ToArray();
            ParallelLoopResult result = Parallel.For(0, items.Count(), (int i, ParallelLoopState
            loopState) =>
            {
                if (i > 200)
                {
                    loopState.Break();
                }
                WorkOnItem(items[i]);
            });
            Console.WriteLine("Completed: " + result.IsCompleted);
            Console.WriteLine("Items: " + result.LowestBreakIteration);
            Console.WriteLine("Finished processing. Press a key to end.");
            Console.ReadKey();
        }
    }
}
