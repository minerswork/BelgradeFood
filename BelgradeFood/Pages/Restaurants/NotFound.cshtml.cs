using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BelgradeFood
{
    public class NotFoundModel : PageModel
    {
        public string SearchTerm { get; set; }
        public void OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;
        }
    }
}