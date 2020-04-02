using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
        }
        
        public OrderDto OrderDto { get; set; }

        protected void OnClickBtnSubmit(object sender, EventArgs e)
        {

        }
    }
}