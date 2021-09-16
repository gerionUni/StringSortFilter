using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PrimeNumberFilter.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrimeNumberFilter.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private Functions fn = new Functions();
        private readonly ServerSettings _settings;
        public IndexModel(ILogger<IndexModel> logger, ServerSettings settings)
        {
            _logger = logger;
            _settings= settings;
        }
        public string ResultText { get; set; }
        public void OnGet()
        {


        }
        public void OnPost()
        {
            
            if (_settings.Filter== "PrimeNumbers")
            {
                ResultText = Request.Form[nameof(ResultText)];
                if (ResultText == null)
                    ResultText = "";
                else
                    ResultText = fn.NewText(ResultText,_settings.Sorting);
            }
            
        }


    }
}

