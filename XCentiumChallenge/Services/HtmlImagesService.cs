using HtmlAgilityPack;
using System;
using System.Linq;
using XCentiumChallenge.ViewModel;

namespace XCentiumChallenge.Services
{
    public class HtmlImagesService : IHtmlImagesService
    {
        private readonly IHtmlReaderService _htmlReaderService;

        public HtmlImagesService(IHtmlReaderService htmlReaderService)
        {
            _htmlReaderService = htmlReaderService;
        }

        public ResultViewModel<ImageCarrouselViewModel> GetImageCarrousel(string url)
        {
            try
            {
                string htmlCode = _htmlReaderService.GetHtml(url);

                if (!string.IsNullOrEmpty(htmlCode))
                {
                    HtmlDocument htmlDoc = new HtmlDocument() { OptionFixNestedTags = true };
                    htmlDoc.LoadHtml(htmlCode);

                    if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Any())
                    {
                        return new ResultViewModel<ImageCarrouselViewModel>(htmlDoc.ParseErrors.Select(x => x.Reason).ToArray());
                    }
                    else
                    {
                        if (htmlDoc.DocumentNode != null)
                        {
                            HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");

                            if (bodyNode != null)
                            {
                                var imgs = bodyNode.Descendants("img").Select(e => e.GetAttributeValue("src", null))
                                        .Where(s => !string.IsNullOrEmpty(s));
                                var imagesCarrousel = new ImageCarrouselViewModel(imgs);
                                return new ResultViewModel<ImageCarrouselViewModel>(imagesCarrousel);
                            }
                        }
                    }
                }

                return new ResultViewModel<ImageCarrouselViewModel>();
            }
            catch (Exception ex)
            {
                return new ResultViewModel<ImageCarrouselViewModel>(new[] { ex.Message });
            }
        }
    }
}