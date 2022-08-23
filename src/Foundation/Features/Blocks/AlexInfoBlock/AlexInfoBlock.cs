using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Foundation.Features.Shared;
using Foundation.Infrastructure;
using System.ComponentModel.DataAnnotations;


namespace Foundation.Features.Blocks.AlexInfoBlock
{
    [ContentType(DisplayName = "Alex Info Block",
        GUID = "64E95639-B7D8-400C-A53B-BC49D5E92DDA",
        Description = "This is my first custom block",
        GroupName = GroupNames.Content)]
    [ImageUrl("/icons/cms/blocks/CMS-icon-block-02.png")]
    public class AlexInfoBlock : FoundationBlockData
    { 
        [CultureSpecific]
        [Display(
            Name = "Main body",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString MainBody { get; set; }
    }
}

