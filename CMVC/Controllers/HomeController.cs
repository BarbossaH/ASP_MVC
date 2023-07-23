using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CMVC.Models;
using CMVC.Services;
using System.Text;

namespace CMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    //private readonly IScopedGuidServices _scoped1;
    //private readonly IScopedGuidServices _scoped2;

    //private readonly ITransientGuidService _transientGuid1;
    //private readonly ITransientGuidService _transientGuid2;

    //private readonly ISingletionGuidService _singletion1;
    //private readonly ISingletionGuidService _singletion2;

    //public HomeController(ISingletionGuidService s1, ISingletionGuidService s2,
    //    IScopedGuidServices c1, IScopedGuidServices c2,
    //    ITransientGuidService t1,ITransientGuidService t2)
    //{
    //    _singletion1 = s1;
    //    _singletion2 = s2;

    //    _transientGuid1 = t1;
    //    _transientGuid2 = t2;

    //    _scoped1 = c1;
    //    _scoped2 = c2;
    //}


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //public IActionResult Index()
    //{
    //    StringBuilder messages = new StringBuilder();
    //    messages.Append($"Transient 1:  {_transientGuid1.GetGuid()} \n");
    //    messages.Append($"Transient 2:  {_transientGuid2.GetGuid()} \n\n\n");
    //    messages.Append($"Scoped 1:  {_scoped1.GetGuid()} \n");
    //    messages.Append($"Scoped 2:  {_scoped2.GetGuid()} \n\n\n");
    //    messages.Append($"Singleton 1:  {_singletion1.GetGuid()} \n");
    //    messages.Append($"Singleton 2:  {_singletion2.GetGuid()} \n\n\n");

    //    return Ok(messages.ToString());
    //}

    public IActionResult Index()
    {
        //return View("Privacy"); //it will access the privacy.cshtml, not index.cshtml
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

