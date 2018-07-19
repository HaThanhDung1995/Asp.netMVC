using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public static class XHtml
{
    public static MvcHtmlString Button(this HtmlHelper helper, 
        String label, object attrs = null)
    {
        var span = new TagBuilder("span");
        span.Attributes["class"] = "glyphicon glyphicon-star-empty";

        var tag = new TagBuilder("button");
        tag.InnerHtml = span.ToString(TagRenderMode.Normal) + " " + label;
        if (attrs != null)
        {
            var props = attrs.GetType().GetProperties();
            foreach (var prop in props)
            {
                tag.Attributes[prop.Name] = prop.GetValue(attrs).ToString();
            }
        }
        return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
    }
}