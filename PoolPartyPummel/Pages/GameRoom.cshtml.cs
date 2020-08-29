using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PoolPartyPummel
{
    public class GameRoomModel : PageModel
    {
        public string joinCode { get; set; }
        public string name { get; set; }
        public IActionResult OnGet(string joinCode, string name)
        {
            if(string.IsNullOrEmpty(joinCode) || string.IsNullOrEmpty(name))
            {
                return Redirect("Index");
            }
            this.joinCode = joinCode;
            this.name = name;
            return Page();
        }
    }
}