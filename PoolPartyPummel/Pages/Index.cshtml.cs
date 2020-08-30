using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;

namespace PoolPartyPummel.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string connectionGuid { get; set; }
        [BindProperty]
        public string username { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("GameRoom", new { joinCode = connectionGuid, name = username });
        }
    }
}
