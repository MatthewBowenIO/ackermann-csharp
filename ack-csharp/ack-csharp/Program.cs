using System;
using System.Threading.Tasks;

namespace ack_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            var ackReturn = acks();
            sw.Stop();

            Console.Out.WriteLine(sw.Elapsed.TotalMilliseconds);
            foreach (int i in ackReturn)
            {
                Console.Out.WriteLine(i);
            }
        }

        static private int ack(int x, int y)
        {
            if (x == 0)
                return y + 1;
            else if (y == 0)
                return ack(x - 1, 1);
            else
                return ack(x - 1, ack(x, y - 1));
        }

        static private int[] acks()
        {
            int[] returnVals = new int[3];
            Parallel.For(1, 3, i => returnVals.SetValue(ack(i, i + 1), i));
            return returnVals;
        }
    }
}
