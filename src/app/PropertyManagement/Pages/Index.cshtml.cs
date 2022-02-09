using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PropertyManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, FSPropertyManagementContext context)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
