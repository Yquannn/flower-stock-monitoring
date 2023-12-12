<%@ Page Title="" Language="C#" MasterPageFile="~/views/mainPage/mainPage.Master" AutoEventWireup="true" CodeBehind="mainPage.aspx.cs" Inherits="flower_stock_monitoring.views.mainPage.mainPage1" %>

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
        h1{
            margin-top: 100px;
        }
 
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
          <asp:TextBox ID="stockId" runat="server"></asp:TextBox>
    <div class="container">

 
            <h1>Flower Inventory Management System</h1>
        <div class="center-box">
            <input type="text" id="flowerType" class="form-control" placeholder="Flower Type" runat="server"  />
        </div>
        <div class="col" id="center-box">
            <input type="number" id="quantity" class="form-control" placeholder="Quantity" runat="server"  />
        </div>
           <div class="col" id="center-box">
       <input type="number" id="unitPrice" class="form-control" placeholder="Unit Price" runat="server" />            
           </div>
  <div class="center-box">
    <asp:DropDownList ID="categoryDd" runat="server" CssClass="category" Width="171px" placeholder="Select Category">
        <asp:ListItem Text="-- Select Category --" Value="" />
        <asp:ListItem Text="Rose" Value="Rose" />
        <asp:ListItem Text="Lily" Value="Lily" />
        <asp:ListItem Text="Tulip" Value="Tulip" />

    </asp:DropDownList>
</div>

                 <label id="errorMsg" class="text-danger" runat="server"></label>
       
            <div class="d-flex">
           
                <asp:Button ID="save" runat="server" Text="Save" OnClick="save_Click" />
                <asp:Button ID="edit" runat="server" Text="Edit" OnClick="edit_Click" />
                <asp:Button ID="delete" runat="server" Text="Delete"  OnClick="delete_Click" />
            </div>
        

            <div class="d-flex2">
                <asp:GridView ID="stockDVG" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="stockDVG_SelectedIndexChanged" Width="800px"></asp:GridView>
            </div>

                   
</div>
      </div>
</asp:Content>
