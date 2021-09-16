﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringSortFilter.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string ResultText { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        
        public void OnGet()
        {
           
            
        }
        public void OnPost()
        {
            ResultText = Request.Form[nameof(ResultText)];
            if (ResultText == null)
                ResultText = "";
            if (ResultText.Length > 0)
            {
                List<string> newLines = new List<string>();
                string newLine = "";
                List<string> lines = ResultText.Split(Environment.NewLine).ToList();
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
                ResultText = "";
                foreach (string l in newLines)
                {
                    ResultText += l + Environment.NewLine;
                }
            }
        }
        private List<long> ExtractIntegers(string line)
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
                ResultText = "Error extracting numbers from string";
                return null;
            }
           
            
        }

        public bool IsPrime(long num)
        {
            bool prime = true;
            // we just need to check for the odd numbers up to the root of the number itself
            long sqrt = (int)Math.Sqrt(num);
            // first lets check if its an even number
            if ((num % 2 ) == 0 && num != 2) 
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
