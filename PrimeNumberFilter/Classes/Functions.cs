using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrimeNumberFilter.Classes
{
    public class Functions
    {

        public Functions()
        {

        }

        public string NewText(string oldText,string sorting)
        {
            
            if (oldText.Length > 0)
            {
                List<string> newLines = new List<string>();
                string newLine = "";
                List<string> lines = oldText.Split(Environment.NewLine).ToList();
                foreach (string line in lines)
                {
                    var numbers = ExtractIntegers(line);
                    newLine = line;
                    if (numbers.Count > 0)
                    {

                        foreach (long i in numbers)
                        {
                            if (IsPrime(i))
                            {
                                Regex regex = new Regex(i.ToString());
                                newLine = regex.Replace(newLine, "", 1);
                            }
                        }

                    }

                }
                newLines.Add(newLine);
                oldText = "";
                if (sorting == "Asc")
                    newLines = newLines.OrderBy(x => x).ToList();
                foreach (string l in newLines)
                {
                    oldText += l + Environment.NewLine;
                }
            }

            return oldText;
        }
        public List<long> ExtractIntegers(string line)
        {
            try
            {
                List<long> numbers = new List<long>();
                string integerString = string.Empty;
                foreach (Char c in line)
                {
                    if (Char.IsDigit(c))
                    {
                        integerString += c;
                    }
                    else if (integerString.Length > 0)
                    {
                        numbers.Add(Convert.ToInt64(integerString));
                        integerString = "";
                    }
                }
                return numbers;
            }
            catch (Exception ex)
            {               
                return null;
            }


        }
        public bool IsPrime(long num)
        {
            bool prime = true;
            // we just need to check for the odd numbers up to the root of the number itself
            long sqrt = (int)Math.Sqrt(num);
            // first lets check if its an even number
            if ((num % 2) == 0 && num != 2)
            {
                return false;
            }
            else
            {
                for (long i = 3; i <= sqrt; i = i + 2)
                {
                    if ((num % i) == 0)
                    {
                        prime = false;
                        break;
                    }
                }
            }

            return prime;
        }
    }

   
}
