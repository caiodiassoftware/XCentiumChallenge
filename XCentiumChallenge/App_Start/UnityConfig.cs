using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using XCentiumChallenge.Services;

namespace XCentiumChallenge
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IHtmlImagesService, HtmlImagesService>();
            container.RegisterType<IHtmlReaderService, HtmlReaderService>();
            container.RegisterType<IHtmlWordsCounterService, HtmlWordsCounterService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}