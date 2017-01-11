using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Zadanko.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString MultiSelectBoxFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TEnum>>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            TagBuilder tg = new TagBuilder("div");
            string innerHtml = "";
            var model = metadata.Model as IEnumerable<TEnum>;

            foreach(var item in Enum.GetValues(typeof(TEnum)))
            {
                bool ischecked = (model == null) ? false : model.Any(x => x.ToString() == item.ToString());

                innerHtml = innerHtml  + htmlHelper.Label(metadata.PropertyName + item, Enum.GetName(typeof(TEnum), item)).ToString() + "  " +

                    @"<input name='" + metadata.PropertyName + "' id='" + metadata.PropertyName + "' type='checkbox' " + ((ischecked) ? "checked='checked'" : "") + "  value=" + item + ">" + "  ";
            }
            tg.SetInnerText(innerHtml);
            return new MvcHtmlString(innerHtml);
        }
    }
}