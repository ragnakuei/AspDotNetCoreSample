﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic.Order;

namespace WebForm.Order
{
    public partial class List : Page
    {
        public IOrderService OrderService { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }
    }
}