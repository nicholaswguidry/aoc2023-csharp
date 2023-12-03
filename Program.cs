//regex
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string path = "./input.txt";

        Dictionary<string, char> stringToInt = new Dictionary<string, char>
        {
            // define one to nine
            { "one", '1' },
            { "two", '2' },
            { "three", '3' },
            { "four", '4' },
            { "five", '5' },
            { "six", '6' },
            { "seven", '7' },
            { "eight", '8' },
            { "nine", '9' }
        };


        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            int total = 0;
            while ((s = sr.ReadLine()) != null)
            {

                List<char> digits = new List<char>();

                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    string subString = s.Substring(i);
                    if (c >= '0' && c <= '9')
                    {
                        digits.Add(c);
                    }
                    else
                    {

                        Match match = Regex.Match(subString, @"^one|^two|^three|^four|^five|^six|^seven|^eight|^nine");
                        if (match.Success)
                        {
                            digits.Add(stringToInt[match.Value]);
                        }
                    }
                }
                if (digits.Count == 0)
                {
                    continue;
                }
                else if (digits.Count == 1)
                {
                    digits.Add(digits[0]);
                }


                int twoDigitVal = int.Parse(digits[0].ToString() + digits[digits.Count - 1]);
                total += twoDigitVal;
            }
            Console.WriteLine($"Total: {total}");
        }
    }
}