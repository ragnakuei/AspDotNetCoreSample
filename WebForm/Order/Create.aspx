<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebForm.Order.Create"%>
<%@ Import Namespace="SharedLibrary.Entity"%>

<asp:Content ID="ScriptContent" ContentPlaceHolderID="BottomScripts" runat="server">
    <script>
        var hiddenFieldId = '<%= nameof(formData) %>';
        
        $("form").submit(function (e) {
            try {
              const dto = {
                              CustomerID : $("#CustomerID").val(),
                              EmployeeID : $("#EmployeeID").val(),
                              OrderDate : $("#OrderDate").val(),
                              RequiredDate : $("#RequiredDate").val(),
                              ShippedDate : $("#ShippedDate").val(),
                              ShipVia : $("#ShipVia").val(),
                              Freight : $("#Freight").val(),
                              ShipName : $("#ShipName").val(),
                              ShipAddress : $("#ShipAddress").val(),
                              ShipCity : $("#ShipCity").val(),
                              ShipRegion : $("#ShipRegion").val(),
                              ShipPostalCode : $("#ShipPostalCode").val(),
                              ShipCountry : $("#ShipCountry").val(),
                          };
                          
              dto.Details = [];
  
              var detailRows = $("#Details")[0].tBodies[0].rows;
              for (let i = 0; i < detailRows.length; i ++)
              {
                  var detail = {
                      ProductID : $(detailRows[i]).find("input[name='ProductID_" + i + "']")[0].value,
                      UnitPrice : $(detailRows[i]).find("input[name='UnitPrice_" + i + "']")[0].value,
                      Quantity : $(detailRows[i]).find("input[name='Quantity_" + i + "']")[0].value,
                      Discount : $(detailRows[i]).find("input[name='Discount_" + i + "']")[0].value,
                  };
               
                  dto.Details.push(detail);
              }
              
              console.log(dto);
              
              const dtoJson = JSON.stringify(dto);
              console.log(dtoJson);         
                $("#" + hiddenFieldId).val(dtoJson);
              
            } catch (e) {
              console.log(e);
              return false;
            }
        });
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <div class="form-group row">
        <label for="<%: nameof(Order.CustomerID) %>" class="col-sm-2 col-form-label">CustomerID</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.CustomerID) %>" value="<%: OrderDto?.CustomerID %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.EmployeeID) %>" class="col-sm-2 col-form-label">EmployeeID</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.EmployeeID) %>" value="<%: OrderDto?.EmployeeID %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.OrderDate) %>" class="col-sm-2 col-form-label">OrderDate</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.OrderDate) %>" value="<%: OrderDto?.OrderDate?.ToString("yyyy-MM-dd") %>" type="date" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.RequiredDate) %>" class="col-sm-2 col-form-label">RequiredDate</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.RequiredDate) %>" value="<%: OrderDto?.RequiredDate?.ToString("yyyy-MM-dd") %>" type="date" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShippedDate) %>" class="col-sm-2 col-form-label">ShippedDate</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.ShippedDate) %>" value="<%: OrderDto?.ShippedDate?.ToString("yyyy-MM-dd") %>" type="date" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipVia) %>" class="col-sm-2 col-form-label">ShipVia</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.ShipVia) %>" value="<%: OrderDto?.ShipVia %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.Freight) %>" class="col-sm-2 col-form-label">Freight</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.Freight) %>" value="<%: OrderDto?.Freight %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipName) %>" class="col-sm-2 col-form-label">ShipName</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.ShipName) %>" value="<%: OrderDto?.ShipName %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipAddress) %>" class="col-sm-2 col-form-label">ShipAddress</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.ShipAddress) %>" value="<%: OrderDto?.ShipAddress %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipCity) %>" class="col-sm-2 col-form-label">ShipCity</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.ShipCity) %>" value="<%: OrderDto?.ShipCity %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipRegion) %>" class="col-sm-2 col-form-label">ShipRegion</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.ShipRegion) %>" value="<%: OrderDto?.ShipRegion %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipPostalCode) %>" class="col-sm-2 col-form-label">ShipPostalCode</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.ShipPostalCode) %>" value="<%: OrderDto?.ShipPostalCode %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipCountry) %>" class="col-sm-2 col-form-label">ShipCountry</label>
        <div class="col-sm-10">
            <input id="<%: nameof(Order.ShipCountry) %>" value="<%: OrderDto?.ShipCountry %>" type="text" class="form-control"/>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-sm-2 col-form-label">Details</label>
    </div>
    <table id="Details" class="table table-striped">
        <thead>
        <tr>
            <th><%: nameof(OrderDetail.ProductID) %></th>
            <th><%: nameof(OrderDetail.UnitPrice) %></th>
            <th><%: nameof(OrderDetail.Quantity) %></th>
            <th><%: nameof(OrderDetail.Discount) %></th>
        </tr>
        </thead>
        <tbody>
        <%
            for (var index = 0; index < OrderDto?.Details?.Length; index++)
            {
        %>
            <tr>
                <td>
                    <input name="<%: nameof(OrderDetail.ProductID) %>_<%: index %>" value="<%: OrderDto?.Details[index]?.ProductID %>" class="form-control"/>
                </td>
                <td>
                    <input name="<%: nameof(OrderDetail.UnitPrice) %>_<%: index %>" value="<%: OrderDto?.Details[index]?.UnitPrice %>" class="form-control"/>
                </td>
                <td>
                    <input name="<%: nameof(OrderDetail.Quantity) %>_<%: index %>" value="<%: OrderDto?.Details[index]?.Quantity %>" class="form-control"/>
                </td>
                <td>
                    <input name="<%: nameof(OrderDetail.Discount) %>_<%: index %>" value="<%: OrderDto?.Details[index]?.Discount %>" class="form-control"/>
                </td></tr>
        <% } %>
        </tbody>
    </table>
    <asp:Button runat="server" ID="btnSubmit" OnClick="OnClickBtnSubmit" Text="Submit" class="btn btn-primary" />
    <a class="btn btn-primary" href="/order/list.aspx">Cancel</a>
    <asp:HiddenField runat="server" ID="formData" ClientIDMode="Static" />
</asp:Content>