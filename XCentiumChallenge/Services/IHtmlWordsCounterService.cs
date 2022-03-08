using XCentiumChallenge.ViewModel;

namespace XCentiumChallenge.Services
{
    public interface IHtmlWordsCounterService
    {
        ResultViewModel<WordsCounterViewModel> GetWordsCounter(string url);
    }
}
