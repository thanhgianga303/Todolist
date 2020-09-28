<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDetailsPage.aspx.cs" Inherits="TodoList.StaffDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row" style="text-align:center">
                <div class="col-md-12">
                    <h1>Task list for <%:Session["name"] %></h1>
                </div>
            </div>
        <div class="row">
        <div class="col-md-2"></div>
        <div  class=" col-md-8 card" >
            <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <asp:Label ID="LabelId" Font-Size="Large" runat="server" Text="Id:"></asp:Label>
                </div>
                <div class="row">
                    <asp:TextBox EnableTheming="true" ID="tbId" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Id is required" ControlToValidate="tbId" runat="server" />
                </div>
            </div>
            <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <asp:Label ID="LabelName" Font-Size="Large" runat="server" Text="Name:"></asp:Label>
                </div>
                <div class="row">
                    <asp:TextBox ID="tbName" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Name is required" ControlToValidate="tbName" runat="server" />
                </div>
            </div>
            <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <asp:Label ID="LabelEmail" Font-Size="Large" runat="server" Text="Email:"></asp:Label>
                </div>
                <div class="row">
                    <asp:TextBox TextMode="Email" ID="tbEmail" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Email is required" ControlToValidate="tbEmail" runat="server" />
                </div>
            </div>
            <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <asp:Label ID="LabelPassword" Font-Size="Large" runat="server" Text="Password:"></asp:Label>
                </div>
                <div class="row">
                    <asp:TextBox ID="tbPassword" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Passsword is required" ControlToValidate="TbPassword" runat="server" />
                </div>
            </div>
            <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <asp:Label ID="LabelPhone" Font-Size="Large" runat="server" Text="Phone:"></asp:Label>
                </div>
                <div class="row">
                    <asp:TextBox TextMode="Phone" ID="tbPhone" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Phone is required" ControlToValidate="tbPhone" runat="server" />
                </div>
            </div>
            <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <asp:Label ID="LabelStatus"  Font-Size="Large" runat="server" Text="Role:"></asp:Label>
                </div>
                <div class="row">
                    
                    <asp:DropDownList id="ListDropDown"
                        AutoPostBack="True"
                        runat="server">
                        <asp:ListItem Selected="True" Value="Staff">Staff</asp:ListItem>
                        <asp:ListItem Value="Manager"> Manager</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <asp:Button Text="Update" OnClick="Updating_Click"  cssClass="styleButtonUpdate" runat="server"></asp:Button>
                <asp:Button Text="Cancel" OnClick="Canceling_Click"  cssClass="styleButtonCancel" runat="server"></asp:Button>
            </div>  

        </div>
        <div class="col-md-2"></div>
    </div>
        
        </div>


</asp:Content>
