using Microsoft.AspNetCore.Mvc;

namespace UCP.API.Controllers;

/// <summary>
/// UCP Discovery API - Implements .well-known/ucp endpoint for merchant profile discovery
/// </summary>
[ApiController]
[Route(".well-known")]
[Produces("application/json")]
public class DiscoveryController : ControllerBase
{
    private readonly ILogger<DiscoveryController> _logger;
    private readonly IConfiguration _configuration;

    public DiscoveryController(ILogger<DiscoveryController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    /// <summary>
    /// Get UCP merchant profile for discovery
    /// </summary>
    [HttpGet("ucp")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMerchantProfile()
    {
        _logger.LogInformation("UCP discovery profile requested");

        // TODO: Implement your merchant profile
        // This should return your merchant's UCP configuration including:
        // - Supported capabilities (checkout, payment, fulfillment)
        // - Service endpoints
        // - API version
        // - Merchant information
        
        var profile = new
        {
            ucp = new
            {
                version = "2026-01-11" // UCP version
            },
            merchant = new
            {
                id = _configuration["Merchant:Id"] ?? "your-merchant-id",
                name = _configuration["Merchant:Name"] ?? "Your Store Name",
                // TODO: Add your merchant details
            },
            services = new
            {
                shopping = new
                {
                    rest = new
                    {
                        endpoint = _configuration["UCP:BaseUrl"] ?? "https://your-store.com"
                    }
                }
            },
            capabilities = new
            {
                checkout = true,
                payment = true,
                fulfillment = true,
                // TODO: Configure which capabilities you support
            }
        };

        return Ok(profile);
    }
}
