using System.Web.Mvc;
using XCentiumChallenge.Services;

namespace XCentiumChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHtmlImagesService _htmlImagesService;
        private readonly IHtmlWordsCounterService _htmlWordsCounterService;

        public HomeController(IHtmlImagesService htmlImagesService, IHtmlWordsCounterService htmlWordsCounterService)
        {
            _htmlImagesService = htmlImagesService;
            _htmlWordsCounterService = htmlWordsCounterService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Images(string url)
        {
            var model = _htmlImagesService.GetImageCarrousel(url);
            return View(model);
        }

        public ActionResult Words(string url)
        {
            var model = _htmlWordsCounterService.GetWordsCounter(url);
            return View(model);
        }
    }
}