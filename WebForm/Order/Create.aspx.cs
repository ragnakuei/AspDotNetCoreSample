using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SharedLibrary.Dto;

namespace WebForm.Order
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Order Create";
            
            if (!IsPostBack)
            {
                OrderDto = new OrderDto
                {
                    Details = new []
                    {
                        new OrderDetailDto(), 
                        new OrderDetailDto(), 
                    }
                };
            }
            else
            {
                OrderDto = JsonConvert.DeserializeObject<OrderDto>(formData.Value);
                Debug.WriteLine(formData.Value);
            }
        }
        
        public OrderDto OrderDto { get; set; }

        protected void OnClickBtnSubmit(object sender, EventArgs e)
        {
            
        }
    }
}