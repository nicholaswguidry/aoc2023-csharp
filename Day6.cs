namespace DayFunctions
{
    using System.Text.RegularExpressions;
    public class Day6
    {

        public static string Part1(List<string> lines)
        {
            //get the digits of line 0
            Match[] times = Regex.Matches(lines[0], @"\d+").Cast<Match>().ToArray();
            //get the digits of line 1
            Match[] distances = Regex.Matches(lines[1], @"\d+").Cast<Match>().ToArray();
            int winProduct = 1;

            for (int i = 0; i < times.Length; i++)
            {
                int winning = 0;
                for (int j = 1; j < int.Parse(times[i].Value); j++)
                {

                    int movementTime = int.Parse(times[i].Value) - j;
                    if (j * movementTime > int.Parse(distances[i].Value))
                    {
                        winning++;
                    }
                }

                winProduct *= winning;

            }

            return winProduct.ToString();

        }

        public static string Part2(List<string> lines)
        {

            //get the digits of line 0
            Match[] times = Regex.Matches(lines[0], @"\d+").Cast<Match>().ToArray();

            UInt64 time = UInt64.Parse(String.Join("", times.ToList()));


            //get the digits of line 1
            Match[] distances = Regex.Matches(lines[1], @"\d+").Cast<Match>().ToArray();
            UInt64 distance = UInt64.Parse(String.Join("", distances.ToList()));

            int winning = 0;
            for (UInt64 j = 1; j < time; j++)
            {

                UInt64 movementTime = time - j;
                if (j * movementTime > distance)
                {
                    winning++;
                }
            }

            return winning.ToString();

        }


    }
}