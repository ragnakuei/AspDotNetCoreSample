<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebForm.Order.Create"%>
<%@ Import Namespace="SharedLibrary.Entity"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Page.Title %></h1>
    <div class="form-group row">
        <label for="<%: nameof(Order.CustomerID) %>" class="col-sm-2 col-form-label">CustomerID</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.CustomerID %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.EmployeeID) %>" class="col-sm-2 col-form-label">EmployeeID</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.EmployeeID %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.OrderDate) %>" class="col-sm-2 col-form-label">OrderDate</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.OrderDate %>" type="date" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.RequiredDate) %>" class="col-sm-2 col-form-label">RequiredDate</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.RequiredDate %>" type="date" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShippedDate) %>" class="col-sm-2 col-form-label">ShippedDate</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.ShippedDate %>" type="date" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipVia) %>" class="col-sm-2 col-form-label">ShipVia</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.ShipVia %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.Freight) %>" class="col-sm-2 col-form-label">Freight</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.Freight %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipName) %>" class="col-sm-2 col-form-label">ShipName</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.ShipName %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipAddress) %>" class="col-sm-2 col-form-label">ShipAddress</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.ShipAddress %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipCity) %>" class="col-sm-2 col-form-label">ShipCity</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.ShipCity %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipRegion) %>" class="col-sm-2 col-form-label">ShipRegion</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.ShipRegion %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipPostalCode) %>" class="col-sm-2 col-form-label">ShipPostalCode</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.ShipPostalCode %>" type="text" class="form-control"/>
        </div>
    </div>
    <div class="form-group row">
        <label for="<%: nameof(Order.ShipCountry) %>" class="col-sm-2 col-form-label">ShipCountry</label>
        <div class="col-sm-10">
            <input value="<%: OrderDto?.ShipCountry %>" type="text" class="form-control"/>
        </div>
    </div>

    <div class="form-group row">
        <label class="col-sm-2 col-form-label">Details</label>
    </div>
    <table class="table table-striped">
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
                </td>
            </tr>
        <% } %>
        </tbody>
    </table>
    <asp:Button runat="server" ID="btnSubmit" OnClick="OnClickBtnSubmit" Text="Submit" class="btn btn-primary" />
    <%-- <button name="btnSubmit" class="btn btn-primary" runat="server" OnClick="OnClickBtnSubmit">Submit</button> --%>
    <a class="btn btn-primary" href="/order/list.aspx">Cancel</a>
</asp:Content>