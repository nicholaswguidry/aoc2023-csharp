using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string path = "./input.txt";

        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";

            while ((s = sr.ReadLine()) != null)
            {
                // do something here for each line of the input, `s`

                //parse the integer in the digit-only substring until we hit the first `:`
                //gameString is the string of the game number
                string gameString = Regex.Match(s.Substring(0, s.IndexOf(':')), @"\d+").Value;

                int firstInt = int.Parse(gameString);
                Console.WriteLine($"This is Game: {firstInt}");

            }
        }
    }
}