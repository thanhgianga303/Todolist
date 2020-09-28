<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="TodoList.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <h1>Staff Table</h1>
            </div>
            <div class="col-md-4">
                <h1>Add Staff</h1> 
            </div>
        </div>
        <div>
            <div class="col-md-12">
                <hr style="color:deepskyblue"/>
            </div>
        </div>
        <div class="row" >
            <div class="col-md-10">
                <asp:GridView ID="GridViewEmployee"
                        runat="server"
                        CssClass="table table-condensed table-hover"
                        Width="50%"
                        OnRowDeleting="GridViewEmployee_DeleteRow"
                        AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField ControlStyle-CssClass="inputText" DataField="Id" HeaderText="staff_id" InsertVisible="False" ReadOnly="True" SortExpression="staff_id" >
<ControlStyle CssClass="inputText"></ControlStyle>
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="/StaffDetailsPage.aspx?id=<%#Eval("Id") %>"><%#Eval("Name")%> </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ControlStyle-CssClass="inputText" DataField="Email" HeaderText="staff_email" SortExpression="staff_email" >
<ControlStyle CssClass="inputText"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField ControlStyle-CssClass="inputText" DataField="Password" HeaderText="staff_password" SortExpression="staff_password" >
<ControlStyle CssClass="inputText"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField ControlStyle-CssClass="inputText" DataField="Phone" HeaderText="staff_phone" SortExpression="staff_phone" >
<ControlStyle CssClass="inputText"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField ControlStyle-CssClass="inputText" DataField="Role" HeaderText="staff_role" SortExpression="staff_role" >
<ControlStyle CssClass="inputText"></ControlStyle>
                        </asp:BoundField>
                        <asp:CommandField ControlStyle-CssClass="styleButton" ButtonType="Button" ShowDeleteButton="True"/>
                       </Columns>
                </asp:GridView>
             </div>
            <div class="col-md-2"> 
                
                <button type="button" class="btn btn-success" data-toggle="modal" data-target="#exampleModal">
                  Add new staff</button>

                <!-- Modal -->
                <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                  <div class="modal-dialog" role="document">
                    <div class="modal-content">
                      <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                      </div>
                      <div class="modal-body">
                        <div class="form-group">    
                            <asp:Label ID="Label3" runat="server" Text="Name:"></asp:Label>
                            <asp:TextBox ID="tbName" cssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Name is required" ControlToValidate="tbName" runat="server" />
                        </div>
                        <div class="form-group">     
                            <asp:Label ID="Label6" runat="server" Text="Email:"></asp:Label>
                            <asp:TextBox TextMode="Email" ID="tbEmail" cssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Email is required" ControlToValidate="tbEmail" runat="server" />
                        </div>
                        <div class="form-group">    
                            <asp:Label ID="Label1" runat="server" Text="Password:"></asp:Label>
                            <asp:TextBox TextMode="Password" ID="tbPassword" cssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Password is required" ControlToValidate="tbPassword" runat="server" />
                        </div>
                        <div class="form-group">    
                            <asp:Label ID="Label7" runat="server" Text="Phone:"></asp:Label>
                            <asp:TextBox TextMode="Phone" ID="tbPhone" cssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Phone is required" ControlToValidate="tbPhone" runat="server" />
                       </div>
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Role:"></asp:Label>
                            <asp:TextBox ID="tbRole" cssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Role is required" ControlToValidate="tbRole" runat="server" />
                        </div>
                    </div>
                      </div>
                      <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button Text="Add" runat="server" OnClick="Insert_Click" cssClass="btn btn-primary"></asp:Button>
                      </div>
                    </div>
                  </div>
                </div>

            </div>
</div>
</asp:Content>