using System;
using System.Text.RegularExpressions;


class Program
{
    static void Main()
    {
        string path = "./input.txt";

        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            List<string> lines = new List<string>();
            while ((s = sr.ReadLine()) != null)
            {
                lines.Add(s);
            }

            //get the digits of line 0
            Match[] times = Regex.Matches(lines[0], @"\d+").Cast<Match>().ToArray();

            UInt64 time = UInt64.Parse(String.Join("", times.ToList()));


            //get the digits of line 1
            Match[] distances = Regex.Matches(lines[1], @"\d+").Cast<Match>().ToArray();
            UInt64 distance = UInt64.Parse(String.Join("", distances.ToList()));
            // int winProduct = 1;

            // for (int i = 0; i < times.Length; i++)
            // {
            int startTick = Environment.TickCount;
            int winning = 0;
            for (UInt64 j = 1; j < time; j++)
            {

                UInt64 movementTime = time - j;
                if (j * movementTime > distance)
                {
                    winning++;
                }
            }

            //     winProduct *= winning;

            // }
            Console.WriteLine($"ways is {winning}");
            Console.WriteLine($"it took is {Environment.TickCount - startTick}");
        }
    }
}

