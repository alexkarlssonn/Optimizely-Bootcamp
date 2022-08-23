using EPiServer.Core;
using EPiServer.Web.Mvc.Html;
using Foundation.Features.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Foundation.Features.Blocks.AlexNavigationBlock
{
    public class AlexNavigationBlockViewModel : BlockViewModel<AlexNavigationBlock>
    {
        public AlexNavigationBlockViewModel(AlexNavigationBlock currentBlock) : base(currentBlock)
        {
            NavigationItems = new List<PageItem>();
        }

        public List<PageItem> NavigationItems { get; set; }
    }

    // Represents a Page that is displayed in this Navigation Block
    public class PageItem
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public PageItem(PageData page, IUrlHelper urlHelper)
        {
            Name = page.Name;
            Url = urlHelper.ContentUrl(page.ContentLink);
        }
    }
}
