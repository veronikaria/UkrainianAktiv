using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace UkrainianAktiv.TagHelpers
{
    [HtmlTargetElement("menulink", Attributes = "controller-name, action-name, menu-text")]
    public class MenuLinkTagHelper : TagHelper
    {
        //        private IUrlHelper ulrHelper;
        private readonly IUrlHelperFactory urlHelperFactory;
        private readonly IActionContextAccessor actionAccessor;


        public MenuLinkTagHelper(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionAccessor)
        {
            this.urlHelperFactory = urlHelperFactory;
            this.actionAccessor = actionAccessor;
        }

        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string MenuText { get; set; }
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = urlHelperFactory.GetUrlHelper(this.actionAccessor.ActionContext);
            var menuUrl = urlHelper.Action(ActionName, ControllerName);
            output.TagName = "li";

            var link = new TagBuilder("a");
            link.MergeAttribute("href", menuUrl);
            link.MergeAttribute("title", MenuText);
            link.InnerHtml.Append(MenuText);

            var routeData = ViewContext.RouteData.Values;
            var currentController = routeData["controller"];
            var currentAction = routeData["action"];

            if (string.Equals(ActionName, currentAction as string, StringComparison.OrdinalIgnoreCase)
               && string.Equals(ControllerName, currentController as string, StringComparison.OrdinalIgnoreCase))
            {
                output.Attributes.Add("class", "active");
            }

            output.Content.AppendHtml(link);
        }
    }
}
