using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using Foundation.Features.Shared;
using Foundation.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Features.Blocks.AlexButtonBlock
{
    [ContentType(DisplayName = "Alex Button Block",
        GUID = "C5CFF88B-0C18-4823-B12D-C13B6743713A",
        Description = "My custom button block",
        GroupName = GroupNames.Content,
        AvailableInEditMode = true)]
    [ImageUrl("/icons/cms/blocks/CMS-icon-block-26.png")]
    public class AlexButtonBlock : FoundationBlockData
    {
        #region Button Content
        [CultureSpecific]
        [Display(Name = "Button Label", Order = 10, GroupName = SystemTabNames.Content)]
        public virtual string ButtonText { get; set; }

        [Display(Name = "Content Link", Order = 20, GroupName = SystemTabNames.Content)]
        public virtual Url ContentLink { get; set; }

        #endregion


        #region Button Background
        [CultureSpecific]
        [Searchable(false)]
        [Display(Name = "Use Custom Background Color", Order = 10, GroupName = TabNames.Background)]
        public virtual bool UseCustomBackgroundColor { get; set; }

        [CultureSpecific]
        [Searchable(false)]
        [ClientEditor(ClientEditingClass = "foundation/Editors/ColorPicker")]
        [Display(Name = "Button Background Color", GroupName = TabNames.Background, Order = 20)]
        public virtual string ButtonBackgroundColor
        {
            get { return this.GetPropertyValue(page => page.ButtonBackgroundColor) ?? "#ffffffff"; }
            set { this.SetPropertyValue(page => page.ButtonBackgroundColor, value); }
        }

        #endregion


        #region Button Border
        [CultureSpecific]
        [Searchable(false)]
        [Display(Name = "Use Custom Border", Order = 10, GroupName = TabNames.Border)]
        public virtual bool UseCustomBorder { get; set; }

        [CultureSpecific]
        [Display(Name = "Border Type", GroupName = TabNames.Border, Order = 20)]
        [SelectOne(SelectionFactoryType = typeof(BorderTypeFactory))]
        public virtual string BorderType { get; set; }

        [CultureSpecific]
        [Searchable(false)]
        [ClientEditor(ClientEditingClass = "foundation/Editors/ColorPicker")]
        [Display(Name = "Border Color", GroupName = TabNames.Border, Order = 30)]
        public virtual string ButtonBorderColor
        {
            get { return this.GetPropertyValue(page => page.ButtonBorderColor) ?? "#ffffffff"; }
            set { this.SetPropertyValue(page => page.ButtonBorderColor, value); }
        }

        #endregion



        // Sets the default values for the parameter for this block
        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            UseCustomBackgroundColor = false;
            ButtonBackgroundColor = "#ffffffff";
            UseCustomBorder = false;
            BorderType = "none";
            ButtonBorderColor = "#000000ff";
        }


        // Factory class for generating selectable options for which type of custom border to use
        public class BorderTypeFactory : ISelectionFactory
        {
            public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
            {
                return new ISelectItem[]
                {
                    new SelectItem { Text = "No Border", Value = "none" },
                    new SelectItem { Text = "Solid Border", Value = "solid" },
                    new SelectItem { Text = "Dotted Border", Value = "dotted" },
                    new SelectItem { Text = "Dashed Border", Value = "dashed" }
                };
            }
        }
    }
}