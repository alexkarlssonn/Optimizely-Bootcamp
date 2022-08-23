using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Foundation.Features.Shared;
using Foundation.Infrastructure;
using Foundation.Infrastructure.Cms;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Features.Blocks.AlexNavigationBlock
{
    [ContentType(DisplayName = "Alex Navigation Block",
        GUID = "28374ACA-EBBF-4C75-99FB-E261C0D5BA1E",
        Description = "A simple navigation block",
        GroupName = GroupNames.Content)]
    [SiteImageUrl("/icons/cms/blocks/CMS-icon-block-30.png")]
    public class AlexNavigationBlock : FoundationBlockData
    {
        [Display(
            Name = "Root page",
            Description = "The navigation block will display the child pages of this root page",
            Order = 20,
            GroupName = SystemTabNames.Content)]
        public virtual PageReference RootPage { get; set; }
    }
}