using ClassLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace CoreWebAppOther.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Settings Settings { get; }

        public IndexModel(
            ILogger<IndexModel> logger,
            IOptionsSnapshot<Settings> options
            )
        {
            _logger = logger;
            Settings = options.Value;
        }

        public void OnGet()
        {

        }
    }
}