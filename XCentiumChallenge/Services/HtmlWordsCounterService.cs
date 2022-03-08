using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using XCentiumChallenge.ViewModel;

namespace XCentiumChallenge.Services
{
    public class HtmlWordsCounterService : IHtmlWordsCounterService
    {
        private readonly IHtmlReaderService _htmlReaderService;

        public HtmlWordsCounterService(IHtmlReaderService htmlReaderService)
        {
            _htmlReaderService = htmlReaderService;
        }

        public ResultViewModel<WordsCounterViewModel> GetWordsCounter(string url)
        {
            try
            {
                string htmlCode = _htmlReaderService.GetHtml(url);

                if (!string.IsNullOrEmpty(htmlCode))
                {
                    HtmlDocument htmlDoc = new HtmlDocument() { OptionFixNestedTags = true };
                    htmlDoc.LoadHtml(htmlCode);
                    List<string> allWords = new List<string>();

                    if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Any())
                    {
                        return new ResultViewModel<WordsCounterViewModel>(htmlDoc.ParseErrors.Select(x => x.Reason).ToArray());
                    }
                    else
                    {
                        if (htmlDoc.DocumentNode != null)
                        {
                            char[] delimiter = new char[] { ' ' };
                            foreach (string text in htmlDoc.DocumentNode.SelectNodes("//body//text()[not(parent::script)]").Select(node => node.InnerText))
                            {
                                var words = text.Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                                    .Where(s => char.IsLetter(s[0]));
                                allWords.AddRange(words);
                            }
                        }
                    }

                    var wordCounter = new WordsCounterViewModel(allWords);
                    return new ResultViewModel<WordsCounterViewModel>(wordCounter);
                }

                return new ResultViewModel<WordsCounterViewModel>();
            }
            catch (Exception ex)
            {
                return new ResultViewModel<WordsCounterViewModel>(new [] { ex.Message });
            }
        }
    }
}