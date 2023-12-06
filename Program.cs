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
            Console.WriteLine($"Product is {winProduct}");
        }
    }
}

