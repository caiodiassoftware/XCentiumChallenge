using XCentiumChallenge.ViewModel;

namespace XCentiumChallenge.Services
{
    public interface IHtmlImagesService
    {
        ResultViewModel<ImageCarrouselViewModel> GetImageCarrousel(string url);
    }
}
