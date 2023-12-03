
//regex
using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        string path = "./input.txt";

        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            int total = 0;
            while ((s = sr.ReadLine()) != null)
            {
                // start a digit List
                List<char> digits = new List<char>();
                // Regex to get the digits
                digits = Regex.Matches(s, @"\d").Cast<Match>().Select(m => m.Value[0]).ToList();

                if (digits.Count == 0)
                {
                    // if there are no digits in the line, skip it
                    continue;
                }
                else if (digits.Count == 1)
                {
                    digits.Add(digits[0]);
                }


                // Console.WriteLine("{0}{1}", digits[0], digits[digits.Count - 1]);
                int twoDigitVal = int.Parse(digits[0].ToString() + digits[digits.Count - 1]);
                total += twoDigitVal;
            }
            Console.WriteLine($"Total: {total}");
        }
    }
}