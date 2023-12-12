<%@ Page Title="" Language="C#" MasterPageFile="~/views/sales/sales.Master" AutoEventWireup="true" CodeBehind="sales.aspx.cs" Inherits="flower_stock_monitoring.views.sales.sales1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style>
 
        .container{
            text-align: center;
          
        }
        .center-box{
            margin-top: 30px;
            display: inline-block;
        }
        #center-box{
            display: inline-block;
        }
        .d-flex{
            margin-left: 35rem;
      
            margin-top: 20px;
        }
        .d-flex2{
           margin-left: 18rem;
           margin-top: 30px;
        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

              <asp:TextBox ID="saleId" runat="server"></asp:TextBox>
    <div class="container">
            <h1 style="margin-top:100px">Flower Inventory Management System</h1>
        <div class="center-box">
            <input type="text" id="customerName" class="form-control" placeholder="Customer Name" runat="server"  />
        </div>
   <%--     <div class="col" id="center-box">
            <input type="number" id="number" class="form-control" placeholder="contact number" runat="server"  />
        </div>--%>
            <div class="col" id="center-box">
        <input type="text" id="address" class="form-control" placeholder="Address" runat="server"  />
    </div>

        <asp:DropDownList ID="order" runat="server">
                    <asp:ListItem Text="-- Select Ordeer --" Value="" />
        <asp:ListItem Text="Rose" Value="Rose" />
        <asp:ListItem Text="Lily" Value="Lily" />
        <asp:ListItem Text="Tulip" Value="Tulip" />
        </asp:DropDownList>

            <div class="col" id="center-box">
        <input type="number" id="price" class="form-control" placeholder="Price" runat="server"  />
    </div>
           <div class="col" id="center-box">
       <input type="number" id="quantity" class="form-control" placeholder="Quantity" runat="server" />            
           </div>


                 <label id="errorMsg" class="text-danger" runat="server"></label>
       
            <div class="d-flex">
           
               
                <asp:Button ID="addOrder" runat="server" Text="Add order" OnClick="addOrder_Click"  />
                <asp:Button ID="cancelOrder" runat="server" Text="Cancel Order" OnClick="cancelOrder_Click" />
            </div>
        

            <div class="d-flex2">
                <asp:GridView ID="saleDVG" runat="server"  Width="800px" AutoGenerateSelectButton="True" OnSelectedIndexChanged="saleDVG_SelectedIndexChanged"></asp:GridView>
            </div>

                   

</asp:Content>
