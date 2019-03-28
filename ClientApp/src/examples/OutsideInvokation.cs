public class ExampleController : Controller
{
    private readonly IHubContext<ExampleHub> _hubContext;

    public ExampleController(IHubContext<ExampleHub> hubContext)
    {
        _hubContext = hubContext;
    }
}