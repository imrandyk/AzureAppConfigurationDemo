using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        // Part 1
        //public Settings Settings { get; }

        public IndexModel(
            ILogger<IndexModel> logger
            //IOptionsSnapshot<Settings> options
            )
        {
            _logger = logger;
            //Settings = options.Value;
        }

        public void OnGet()
        {

        }
    }
}