using Microsoft.AspNetCore.Mvc;
using PayPal.Extensions;

namespace TestApp.Controllers
{
    public class PayPalController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<PayPalController> _logger;

        public PayPalController(IHttpClientFactory httpClientFactory, ILogger<PayPalController> logger)
        {
            _httpClientFactory = httpClientFactory;    
            _logger = logger;
        }

        [HttpPost]        
        public async Task<IActionResult> Callback()
        {            
            _logger.LogInformation("Callback invoked");

            var result = await Request.VerifyPayPalTransactionAsync(PayPalEnvironment.Sandbox, _httpClientFactory, _logger);
            
            if (result.IsVerified)
            {

            }

            return Ok();
        }
    }
}
