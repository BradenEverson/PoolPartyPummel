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
        public void OnGet(string joinCode, string name)
        {
            this.joinCode = joinCode;
            this.name = name;
        }
    }
}