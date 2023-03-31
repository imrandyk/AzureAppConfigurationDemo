using ClassLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement.Mvc;

namespace CoreWebApp.Pages
{
    [FeatureGate("beta")]
    public class BetaModel : PageModel
    {
        private readonly ILogger<BetaModel> _logger;
        public Settings Settings { get; }

        public BetaModel(
            ILogger<BetaModel> logger,
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