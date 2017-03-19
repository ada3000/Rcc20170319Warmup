using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskB
{
    class Program
    {
        static int Rows = 0;
        static int Pax = 0;
        static int PaxIndex = 0;

        static int MinFreeRow = 0;
        static int MinFreeRowL = 0;
        static int MinFreeRowR = 0;

        static int MaxFreeRow = -1;
        static int MaxFreeRowL = 0;
        static int MaxFreeRowR = 0;

        static List<int> MatchRed = new List<int>();
        static List<int> MatchBlue = new List<int>();
        static List<int> MatchBlack= new List<int>();
        static List<int> MatchYelow = new List<int>();
        static List<int> MatchPink = new List<int>();

        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            string line;
            int linesLimit = 2;

            //Console.WriteLine("Task A Start");

            //string[] init = line = Console.ReadLine();


            while (lines.Count < linesLimit && (line = Console.ReadLine()) != null && line != "")
                lines.Add(line);

            Run(lines[0], lines[1]);

            //Console.WriteLine("Task A END");
        }

        static void TestTaskA()
        {
            //Run("3", "2 5 3");
            Run("5", "-1 1 0 1 -1");
            Console.WriteLine("Task End");
            Console.ReadKey();
        }

        public static void Run(string sTotal, string sForces)
        {
            int total = int.Parse(sTotal);
            int[] forces = sForces.Split(' ').Select(s => int.Parse(s)).ToArray();

            int lastForceIndex = -1;

            for (int i = 0; i < total; i++)
            {
                int curForce = forces[i];
                long sumOther = 0;

                for (int j1 = 0; j1 < i; j1++)
                    sumOther += forces[j1];

                for (int j2 = i + 1; j2 < total; j2++)
                    sumOther += forces[j2];

                if (sumOther == curForce)
                {
                    lastForceIndex = i;
                    break;
                }
            }

            if (lastForceIndex == -1)
                Console.WriteLine("Solution not found!");
            else
            {
                for (int i = 0; i < total; i++)
                    if (i != lastForceIndex)
                        Console.Write(forces[i] + " ");

                Console.WriteLine(forces[lastForceIndex]);
            }
        }
    }
}
