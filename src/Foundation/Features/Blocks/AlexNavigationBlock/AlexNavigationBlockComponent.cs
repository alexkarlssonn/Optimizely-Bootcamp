using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foundation.Features.Blocks.AlexNavigationBlock
{
    public class AlexNavigationBlockComponent : AsyncBlockComponent<AlexNavigationBlock>
    {
        private readonly IContentLoader _contentLoader;
        private readonly IPageRouteHelper _pageRouteHelper;

        public AlexNavigationBlockComponent(IContentLoader contentLoader, IPageRouteHelper pageRouteHelper)
        {
            _contentLoader = contentLoader;
            _pageRouteHelper = pageRouteHelper;
        }



        protected override async Task<IViewComponentResult> InvokeComponentAsync(AlexNavigationBlock currentBlock)
        {
            // Create the ViewModel
            var model = new AlexNavigationBlockViewModel(currentBlock);


            // Get the current root page
            var root = currentBlock.RootPage as ContentReference;
            if (ContentReference.IsNullOrEmpty(currentBlock.RootPage))
            {
                root = _pageRouteHelper.ContentLink;
            }

            // Get the child pages for the given root page
            var pages = _contentLoader.GetChildren<PageData>(root);
            if (pages != null && pages.Count() > 0)
            {
                var pageList = new List<PageItem>();
                foreach (var page in pages)
                {
                    // Only add the pages to the list that has been flagged to be shown in the menu
                    if (page.VisibleInMenu) {
                        pageList.Add(new PageItem(page, Url));
                    }
                }

                // All all the pages to the model as long as their url is not null/empty
                model.NavigationItems.AddRange(pageList.Where(x => !string.IsNullOrEmpty(x.Url)));
            }

            // Create and return the view using the given razor file and the model that was created above
            return await Task.FromResult(View("~/Features/Blocks/AlexNavigationBlock/AlexNavigationBlock.cshtml", model));
        }
    }
}