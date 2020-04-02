using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using BusinessLogic.Order;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SharedLibrary.Dto;

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
            if (string.Equals(context.Request.HttpMethod, "post", StringComparison.CurrentCultureIgnoreCase) == false)
            {
                context.Response.StatusCode = 404;
                return;
            }

            var stream = context.Request.InputStream;
            var requestBody = new StreamReader(stream).ReadToEnd();
            var pageInfo = JsonConvert.DeserializeObject<PageInfoDto>(requestBody);

            var orderList = OrderService.GetOrderList(pageInfo.Current - 1, pageInfo.RowCount);
            var json = JsonConvert.SerializeObject(new
            {
                pageInfo.Current,
                pageInfo.RowCount,
                total = orderList.TotalCount,
                rows = orderList.Items,
            }, new JsonSerializerSettings
            {
                // 把 Json Property 改成 小寫開頭 (CamelCase)
                ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
            });

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