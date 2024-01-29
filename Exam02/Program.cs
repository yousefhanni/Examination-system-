using System.Diagnostics;
using System.Threading.Channels;

namespace Exam02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject Sub1 = new Subject(10, "C#");
            Sub1.CreateExam();
            Console.Clear();

            Console.Write("Do You want To Start The Exam (y | n): ");
            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Stopwatch sw = Stopwatch.StartNew();
                 sw.Start();
                Console.Clear();

                Sub1.ShowExam();

                Console.Clear();
                Console.WriteLine("Exam Results:");
                Sub1.ShowExamResults();

                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }


        }
    }
}
