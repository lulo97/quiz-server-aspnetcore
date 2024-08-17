using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            string htmlContent = $@"
                <html>
                <head>
                    <script src='/_framework/aspnetcore-browser-refresh.js'></script>
                </head>
                <body>
                    <h1>Hello, this is the backend of the QuizQuest project!</h1>
                    <a href='http://localhost:{Const.getPort()}/swagger/index.html'>APIs</a>
                </body>
                </html>
            ";
            return Content(htmlContent, "text/html");
        }
    }
}
