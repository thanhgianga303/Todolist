<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDetailsPage.aspx.cs" Inherits="TodoList.StaffDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row" style="text-align:center">
                <div class="col-md-3">
                    <asp:Button OnClick="SeeTaskList_Click" cssClass="btn btn-secondary styleButtonCancel" runat="server" Text="Task List"/>
                </div>
                <div class="col-md-6">
                    <h1><span class="label label-info"><%:Session["name"] %> 's Details</span></h1>
                </div>
                <div class="col-md-3"></div>
            </div>
        <div class="row" style="margin-top:10px">
        <div class="col-md-3"></div>
        <div  class=" col-md-6 card" >
            <div class="row form-group" style="padding:5px 5px">
                <div class="col-md-2">
                    <asp:Label ID="LabelId" Font-Size="Large" runat="server" Text="Id:"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox EnableTheming="true" ID="tbId" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Id is required" ControlToValidate="tbId" runat="server" />
                </div>
            </div>
            <div class="row form-group" style="padding:5px 5px">
                <div class="col-md-2">
                    <asp:Label ID="LabelName" Font-Size="Large" runat="server" Text="Name:"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="tbName" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Name is required" ControlToValidate="tbName" runat="server" />
                </div>
            </div>
            <div class="row form-group" style="padding:5px 5px">
                <div class="col-md-2">
                    <asp:Label ID="LabelEmail" Font-Size="Large" runat="server" Text="Email:"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox TextMode="Email" ID="tbEmail" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Email is required" ControlToValidate="tbEmail" runat="server" />
                </div>
            </div>
            <div class="row form-group" style="padding:5px 5px">
                <div class="col-md-2">
                    <asp:Label ID="LabelPassword" Font-Size="Large" runat="server" Text="Password:"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox ID="tbPassword" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Passsword is required" ControlToValidate="TbPassword" runat="server" />
                </div>
            </div>
            <div class="row form-group" style="padding:5px 5px">
                <div class="col-md-2">
                    <asp:Label ID="LabelPhone" Font-Size="Large" runat="server" Text="Phone:"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:TextBox TextMode="Phone" ID="tbPhone" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Phone is required" ControlToValidate="tbPhone" runat="server" />
                </div>
            </div>
            <div class="row form-group" style="padding:5px 5px">
                <div class="col-md-2">
                    <asp:Label ID="LabelStatus"  Font-Size="Large" runat="server" Text="Role:"></asp:Label>
                </div>
                <div class="col-md-10">
                    
                    <asp:DropDownList id="ListDropDown"
                        AutoPostBack="True"
                        runat="server">
                        <asp:ListItem Selected="True" Value="staff">Staff</asp:ListItem>
                        <asp:ListItem Value="admin">Manager</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <asp:Button Text="Update" OnClick="Updating_Click"  cssClass="styleButtonUpdate" runat="server"></asp:Button>
                <asp:Button Text="Cancel" OnClick="Canceling_Click"  cssClass="styleButtonCancel" runat="server"></asp:Button>
            </div>  

        </div>
        <div class="col-md-3"></div>
    </div>
        
        </div>


</asp:Content>
