using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Models;
using System.Text;
using System.Web.Mvc;

namespace TaskApp.Extensions
{
    public static class HtmlHelperExtension
    {
        // Pagination should be expressed noat as function returning string
        // but as partial view with some helper functions
        // all html should be in view, calculation in functions and model
        public static MvcHtmlString PageLinks<TModel>(this HtmlHelper helper,
            PaginatedListViewModel<TModel> model,
            Func<int, string> pageUrl)
        {
            if(model.TotalPages > 1)
            {
                var stBuilder = new StringBuilder();

                TagBuilder aTag = new TagBuilder("a");
                TagBuilder liTag = new TagBuilder("li");
                if (!model.HasPreviosPage)
                {
                    liTag.AddCssClass("disabled");
                }

                aTag.MergeAttribute("href", pageUrl((model.HasPreviosPage ? model.CurrentPage - 1 : 1)));
                aTag.InnerHtml = helper.Encode("<<");
                liTag.InnerHtml = aTag.ToString();
                stBuilder.AppendLine(liTag.ToString());

                for (int i = 1; i <= model.TotalPages; i++)
                {
                    liTag = new TagBuilder("li");
                    aTag = new TagBuilder("a");

                    aTag.MergeAttribute("href", pageUrl(i));
                    aTag.InnerHtml = i.ToString();

                    if (model.CurrentPage == i)
                    {
                        liTag.AddCssClass("active");
                        TagBuilder spanTag = new TagBuilder("span");
                        spanTag.AddCssClass("sr-only");
                        spanTag.InnerHtml = "(current)";
                        aTag.InnerHtml = string.Format("{0} {1}", i.ToString(), spanTag.ToString());
                    }

                    liTag.InnerHtml = aTag.ToString();
                    stBuilder.AppendLine(liTag.ToString());
                }

                liTag = new TagBuilder("li");
                if (!model.HasNextPage)
                {
                    liTag.AddCssClass("disabled");
                }

                aTag.MergeAttribute("href", pageUrl((model.HasNextPage ? model.CurrentPage + 1 : model.CurrentPage)));
                aTag.InnerHtml = helper.Encode(">>");
                liTag.InnerHtml = aTag.ToString();
                stBuilder.AppendLine(liTag.ToString());

                TagBuilder ulTag = new TagBuilder("ul");
                ulTag.AddCssClass("pagination");
                ulTag.InnerHtml = stBuilder.ToString();

                return MvcHtmlString.Create(ulTag.ToString());
            }

            return MvcHtmlString.Empty;
        }
    }
}
