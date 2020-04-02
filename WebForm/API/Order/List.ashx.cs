using System;
using System.Web;
using System.Web.UI;
using BusinessLogic.Order;
using Newtonsoft.Json;

namespace WebForm.API.Order
{
    /// <summary>
    /// Summary description for List
    /// </summary>
    public class List : Page /* IHttpHandler */
    {
        public IOrderService OrderService { get; set; }

        public override void ProcessRequest(HttpContext context)
        {
            if (string.Equals(context.Request.HttpMethod, "get", StringComparison.CurrentCultureIgnoreCase) == false)
            {
                context.Response.StatusCode = 404;
                return;
            }

            Int32.TryParse(context.Request.Form["pageIndex"], out int pageIndex);
            Int32.TryParse(context.Request.Form["pageSize"], out int pageSize);

            if (pageSize == 0)
            {
                pageSize = 10;
            }
            
            var orderList = OrderService.GetOrderList(pageIndex, pageSize);
            var json = JsonConvert.SerializeObject(orderList);

            context.Response.ContentType = "application/json";
            context.Response.Charset = "utf-8";
            context.Response.Write(json);
        }

        public new bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}