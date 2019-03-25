public class Startup
{    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // Obs! Endres for .Net Core 3.0!
        app.UseSignalR(conf =>
        {
            conf.MapHub<ViewerHub>("/viewers");
            conf.MapHub<PingPongHub>("/pingpong");
        });
    }
}