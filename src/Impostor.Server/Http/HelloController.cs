using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Impostor.Server.Http;

/// <summary>
/// Generate a diagnostic page to show that the Impostor HTTP server is working.
/// If a welcome.html file exists in the Http folder, it will be served as the welcome page.
/// </summary>
[Route("/")]
public sealed class HelloController : ControllerBase
{
    private static bool _shownHello = false;
    private readonly ILogger<HelloController> _logger;
    private readonly IWebHostEnvironment _env;

    public HelloController(ILogger<HelloController> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    [HttpGet]
    public IActionResult GetHello()
    {
        if (!_shownHello)
        {
            _shownHello = true;
            _logger.LogInformation("Impostor's Http server is reachable (this message is only printed once per start)");
        }

        var welcomePath = Path.Combine(_env.ContentRootPath, "Http", "welcome.html");
        if (System.IO.File.Exists(welcomePath))
        {
            var html = System.IO.File.ReadAllText(welcomePath);
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
