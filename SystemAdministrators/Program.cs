using System;
using System.CodeDom;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.InteropServices;

namespace SystemAdministrators
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            string[] line;
            HolidayShift shift;
            Console.Write("Please enter the read path of the file :\n");
            string input = Console.ReadLine();
            Console.Write("Please enter the write path of the file :\n");
            string output = Console.ReadLine();
            string[] content = File.ReadAllLines(input);

            int N = int.Parse(content[0]);
            const int forecastMax = 1000;
            if (N < forecastMax)
            {
                int K = int.Parse(content[1]);

                Alice alice = new Alice(K);
                if (K <= N)
                {
                    for (int i = 2; i < K + 2; i++)
                    {
                        line = content[i].Split(';');
                        shift = new HolidayShift(int.Parse(line[0]), int.Parse((line[1])));
                        alice.AddShift(shift);
                    }
                }
                int L = int.Parse(content[K + 2]);
                Bob bob = new Bob(L);
                if (L <= N)
                {
                    for (int i = K + 3; i < L + K + 3; i++)
                    {
                        line = content[i].Split(';');
                        shift = new HolidayShift(int.Parse(line[0]), int.Parse(line[1]));
                        bob.AddShift(shift);
                    }
                }
                int[] a = new int[N + 1];
                result += Calculate(bob, alice, a);
                string[] lines = result.Split('\n');
                File.WriteAllLines(output, lines);
            }
        }
        public static string Calculate(Bob bob, Alice alice, int[] array)
        {
            string result = "";

            foreach (HolidayShift s in alice.GetShifts())
            {
                for (int i = s.GetStart(); i <= s.GetEnd(); i++)
                {
                    array[i]++;
                }
            }
            foreach (HolidayShift s in bob.GetShifts())
            {
                for (int i = s.GetStart(); (i <= s.GetEnd()); i++)
                {
                    array[i]++;
                }
            }
            result += CalculateSafety(array);
            result += CalculateUnSafety(array);

            return result;
        }
        public static string CalculateSafety(int[] array)
        {
            string result = "";
            int safetyNum = 0;
            int start = 0;
            int end = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    safetyNum++;
                    start = i;
                    end = i;
                    while (end < array.Length && array[end] == 0)
                        end++;
                    result += start + ";" + (end - 1) + "\n";
                    i = end;
                }
            }

            result = safetyNum + "\n" + result + "\n";
            return result;
        }
        public static string CalculateUnSafety(int[] array)
        {
            string result = "";
            int unsafetyNum = 0;
            int start = 0;
            int end = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == 2)
                {
                    unsafetyNum++;
                    start = i;
                    end = i;
                    while (end < array.Length && array[end] == 2)
                        end++;
                    result += (start) + ";" + (end - 1) + "\n";
                    i = end;
                }
            }
            result = unsafetyNum + "\n" + result + "\n";
            return result;
        }
    }
}

