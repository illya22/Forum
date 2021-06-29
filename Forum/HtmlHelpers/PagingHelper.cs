using System;
using System.Text;
using System.Web.Mvc;
using Forum.Models;
namespace Forum.HtmlHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper helper,
           PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder rez = new StringBuilder();
            for (int i = 1; i <= pagingInfo.Total_Pages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.Current_Page)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                rez.Append(tag.ToString());
            }
            return MvcHtmlString.Create(rez.ToString());
        }
    }
}