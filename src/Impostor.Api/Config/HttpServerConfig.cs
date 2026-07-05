namespace Impostor.Api.Config;

/// <summary>
/// Configuration for HttpServer.
/// </summary>
public class HttpServerConfig
{
    /// <summary>
    /// Gets the name of this config section.
    /// </summary>
    public const string Section = "HttpServer";

    public bool Enabled { get; set; } = true;

    /// <summary>
    /// Gets or sets the IP address the HTTP Matchmaking server will listen on.
    /// </summary>
    /// Use "127.0.0.1" if you are running behind a reverse proxy or just testing locally.
    /// Use "0.0.0.0" if you are directly exposing this server to the internet.
    public string ListenIp { get; set; } = "0.0.0.0";

    /// <summary>
    /// Gets or sets the port the HTTP Matchmaking server will listen on.
    /// </summary>
    /// For port forwarding purposes, this is a TCP port.
    public ushort ListenPort { get; set; } = 22023;

    /// <summary>
    /// Gets or sets the path to a custom HTML file for the welcome page.
    /// </summary>
    /// If empty, the default plain text welcome message is shown.
    /// Set this to a relative or absolute path, e.g. "hello.html" or "/etc/impostor/welcome.html".
    public string WelcomePagePath { get; set; } = string.Empty;
}
