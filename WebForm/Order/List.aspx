<%@ Page Title="Order List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebForm.Order.List" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <a class="btn btn-primary float-right" asp-page="/order/create" role="button">Create</a>
    <table id="orderList" class="table table-condensed table-hover table-striped">
        <thead>
        <tr>
            <th data-column-id="orderID" data-identifier="true" scope="col">OrderID</th>
            <th data-column-id="customerID" scope="col">CustomerID</th>
            <th data-column-id="employeeID" scope="col">EmployeeID</th>
            <th data-column-id="orderDate"
                data-formatter="dateToString"
                scope="col">
                OrderDate
            </th>
            <th data-column-id="requiredDate"
                data-formatter="dateToString"
                scope="col">
                RequiredDate
            </th>
            <th data-column-id="shippedDate"
                data-formatter="dateToString"
                scope="col">
                ShippedDate
            </th>
            <th data-column-id="shipVia" scope="col">ShipVia</th>
            <%-- <th data-column-id="freight" scope="col">Freight</th> --%>
            <%-- <th data-column-id="shipName" scope="col">ShipName</th> --%>
            <%-- <th data-column-id="shipAddress" scope="col">ShipAddress</th> --%>
            <%-- <th data-column-id="shipCity" scope="col">ShipCity</th> --%>
            <%-- <th data-column-id="shipRegion" scope="col">ShipRegion</th> --%>
            <%-- <th data-column-id="shipPostalCode" scope="col">ShipPostalCode</th> --%>
            <%-- <th data-column-id="shipCountry" scope="col">ShipCountry</th> --%>
            <th
                data-width="230px"
                data-column-id="management"
                data-formatter="management"
                data-sortable="false">
                Management
            </th>
        </tr>
        </thead>
    </table>
</asp:Content>

<asp:Content ID="ScriptsContent" ContentPlaceHolderID="BottomScripts" runat="server">
    <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/jquery-bootgrid/1.3.1/jquery.bootgrid.css" type="text/css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.css" type="text/css"/>

    <script type="text/javascript" src="https://code.jquery.com/jquery-1.11.1.min.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="//cdnjs.cloudflare.com/ajax/libs/jquery-bootgrid/1.3.1/jquery.bootgrid.min.js"></script>

    <script>
        try {
            $("#orderList").bootgrid({
                navigation : 3,
                css : {
                    pagination:"pagination",
                    paginationButton:"page-link",
                },
                templates: {
                    search: '',
                    pagination:'<ul class="{{css.pagination}}"></ul>',
                    paginationItem:'<li class="{{ctx.css}}"><a data-page="{{ctx.page}}" class="{{css.paginationButton}}" href="#"><span aria-hidden="true">{{ctx.text}}</span></a></li>',
                },
                ajaxSettings: {
                                method: "POST",
                                cache: false,
                                contentType: "application/json",
                            },
                ajax: true,
                url : "/api/order/list.ashx",
                requestHandler: function (request) {
                       var model = {};
                       model.Current = request.current;
                       model.RowCount = request.rowCount;
                       // model.Search = request.searchPhrase;
                
                       // for (var key in request.sort) {
                       //     model.SortBy = key;
                       //     model.SortDirection = request.sort[key];
                       // }
                
                       return JSON.stringify(model);
                },
                formatters: {
                    "management": function(column, row) {
                        var detailButton = ' <a href="/order/detail/' + row.orderID +  '" class="btn btn-xs btn-default" data-row-id="' + row.orderID + '">Detail</a> ';
                        var editButton = ' <a href="/order/edit/' + row.orderID +  '" class="btn btn-xs btn-default command-edit" data-row-id="' + row.orderID + '">Edit</a> ';
                        var deleteButton = ' <button type="button" class="btn btn-default btn-xs command-delete" data-row-id="' + row.orderID + '">Delete</button>'; 
                        return  detailButton + editButton + deleteButton ;
                     },
                     "dateToString" : function(column, row) {
                        if(row[column.id])
                        {
                            return row[column.id].split('T')[0];
                        }
                        
                        return row[column.id];
                     }
                }
            });  
        } catch (e) {
            console.log("error occurs");
            console.log(e);
        }
    </script>
</asp:Content>