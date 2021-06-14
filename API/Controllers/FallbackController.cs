using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace API.Controllers
{
    [AllowAnonymous]
    public class FallbackController : Controller
    {
        /** 
* Errors Controller for debugging purposes
*/
        public IActionResult Index(){
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot","index.html"),"text/HTML");
        }
    }
}