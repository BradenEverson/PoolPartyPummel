using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PoolPartyPummel
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string name { get; set; }
        public IActionResult OnPost()
        {
            return RedirectToPage("./GameRoom", new { joinCode = Guid.NewGuid().ToString().Split('-')[0], name = this.name });
        }
    }
}