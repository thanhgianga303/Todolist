<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TodoList.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <div class="row">
        <div class="col-md-3">   
        </div>
        <div class="col-md-6">
            <div class="wrapper fadeInDown">
              <div id="formContent">
                <!-- Tabs Titles -->

                <!-- Icon -->
                <div class="fadeIn first">
                  <img src="programmer.png" id="icon" alt="User Icon" style="width:50px;height:50px"/>
                </div>

                <!-- Login Form -->
                  <asp:TextBox ID="tbUsername" cssClass="fadeIn third" runat="server"></asp:TextBox>
                  <div>
                      <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Username is required" ControlToValidate="tbUsername" runat="server" />
                   </div>                             
                  <asp:TextBox ID="tbPassword" TextMode="Password" cssClass="fadeIn third" runat="server"></asp:TextBox>
                  <div>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Password is required" ControlToValidate="tbPassword" runat="server" />
                  </div>
                   <asp:Button cssClass="fadeIn fourth" Text="Log In" OnClick="checkLogin" runat="server"/>
                                    
                      <!-- Remind Passowrd -->
                <div id="formFooter" runat="server">
                  <asp:Label ID="lbError" CssClass="label label-danger"  runat="server" />
                </div>

              </div>
            </div>
        </div>
        <div class="col-md-3">
            
        </div>
    </div>
    </div>
</asp:Content>
