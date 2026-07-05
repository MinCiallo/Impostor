using System.IO;
using Impostor.Api.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Impostor.Server.Http;

/// <summary>
/// Generate a diagnostic page to show that the Impostor HTTP server is working.
/// </summary>
[Route("/")]
public sealed class HelloController : ControllerBase
{
    private static bool _shownHello = false;
    private readonly ILogger<HelloController> _logger;
    private readonly IOptions<HttpServerConfig> _httpConfig;

    public HelloController(ILogger<HelloController> logger, IOptions<HttpServerConfig> httpConfig)
    {
        _logger = logger;
        _httpConfig = httpConfig;
    }

    [HttpGet]
    public IActionResult GetHello()
    {
        if (!_shownHello)
        {
            _shownHello = true;
            _logger.LogInformation("Impostor's Http server is reachable (this message is only printed once per start)");
        }

        var welcomePagePath = _httpConfig.Value.WelcomePagePath;
        if (!string.IsNullOrEmpty(welcomePagePath) && System.IO.File.Exists(welcomePagePath))
        {
            var html = System.IO.File.ReadAllText(welcomePagePath);
            return Content(html, "text/html");
        }

        return Ok(
            """
            Impostor is running, please configure your Among Us to connect to a game
            To generate a region file, go to https://impostor.github.io/Impostor
            """
        );
    }
}
