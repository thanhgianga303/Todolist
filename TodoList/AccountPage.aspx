<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountPage.aspx.cs" Inherits="TodoList.AccountPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6 card" style="text-align:center"><h1><span class="label label-info">Your Account - <%:Session["name"]%></span></h1></div>
            <div class="col-md-3"></div>
         </div>
        <div class="row" style="margin-top:10px">
            <div class="col-md-3"></div>
            <div class="col-md-6 card">
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Id">ID:</label>
                    <div class="col-sm-10">
                       <asp:TextBox Enabled="false" runat="server" cssClass="form-control" id="tbId"/>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Name">Name:</label>
                    <div class="col-sm-10">
                       <asp:TextBox runat="server" cssClass="form-control" id="tbName"/>
                       <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Name is required" ControlToValidate="tbName" runat="server" />
                    </div>
                </div>
                
                <div class="form-group">
                    <label class="control-label col-sm-2" for="Email">Email:</label>
                    <div class="col-sm-10">
                       <asp:TextBox TextMode="Email" runat="server" cssClass="form-control" id="tbEmail"/>
                       <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Email is required" ControlToValidate="tbEmail" runat="server" />
                    </div>
                </div>
                  <div class="form-group">
                    <label class="control-label col-sm-2" for="pwd">Password:</label>
                    <div class="col-sm-10">
                      <asp:TextBox runat="server" cssClass="form-control" id="tbPassword"/>
                      <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Password is required" ControlToValidate="tbPassword" runat="server" />
                    </div>
                  </div>
                  <div class="form-group">
                    <label class="control-label col-sm-2" for="phone">Phone:</label>
                    <div class="col-sm-10">
                      <asp:TextBox TextMode="Phone" runat="server" cssClass="form-control" id="tbPhone"/>
                      <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Phone is required" ControlToValidate="tbPhone" runat="server" />
                    </div>
                  </div>
                   <div class="form-group">
                    <label class="control-label col-sm-2" for="Role">Role:</label>
                    <div class="col-sm-10">
                      <asp:TextBox Enabled="false" runat="server" cssClass="form-control" id="tbRole"/>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                      <asp:Button OnClick="Updating_Click" runat="server" Text="Update" cssClass="btn btn-default"></asp:Button>
                    </div>
                  </div>
                        </div>
            <div class="col-md-3"></div>
        </div>
    </div>
</asp:Content>
