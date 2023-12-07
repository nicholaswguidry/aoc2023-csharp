namespace DayFunctions
{
    using System.Text.RegularExpressions;
    public class Day1
    {
        public static string Part1(List<string> lines)
        {
            int total = 0;
            foreach (string s in lines)
            {
                List<char> digits = new List<char>();
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

            return total.ToString();
        }

        public static string Part2(List<string> lines)
        {
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
            int total = 0;
            foreach (string s in lines)
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

            return total.ToString();
        }


    }
}