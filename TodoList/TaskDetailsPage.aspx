<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskDetailsPage.aspx.cs" Inherits="TodoList.TaskDetailsPage" %>
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
                    <asp:Label ID="LabelTitle" Font-Size="Large" runat="server" Text="Title:"></asp:Label>
                </div>
                <div class="row">
                    <asp:TextBox ID="tbTitle" cssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Title is required" ControlToValidate="tbTitle" runat="server" />
                </div>
            </div>
            <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="LabelStartDate" Font-Size="Large" runat="server" Text="Start Date:"></asp:Label>
                        <asp:TextBox ID="tbStartDate" TextMode="DateTimeLocal" cssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Start date is required" ControlToValidate="tbStartDate" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="LabelEndDate" Font-Size="Large" runat="server" Text="End Date:"></asp:Label>
                        <asp:TextBox ID="tbEndDate" TextMode="DateTimeLocal" cssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Title is required" ControlToValidate="tbEndDate" runat="server" />
                     </div>
                </div>
            </div>
            <div class="form-group" style="padding:5px 5px">
                
                <div class="row">
                 <asp:Label runat="server" Font-Size="Large" >Select partner</asp:Label>
                <asp:GridView CssClass="table" BorderColor="#eeeeee" EnablePersistedSelection="true" DataKeyNames="id" ID="GridViewPartner" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="checkbox" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField ControlStyle-CssClass="form-control" DataField="id" HeaderText="ID">
                            <ControlStyle CssClass="form-control"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField ControlStyle-CssClass="form-control" DataField="name" HeaderText="Name">
                            <ControlStyle CssClass="form-control"></ControlStyle>
                        </asp:BoundField>

                    </Columns>
                </asp:GridView>
                </div>
            </div>
            <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <asp:Label ID="LabelStatus"  Font-Size="Large" runat="server" Text="Status:"></asp:Label>
                </div>
                <div class="row">
                    
                    <asp:DropDownList id="ListDropDown"
                        AutoPostBack="True"
                        runat="server">
                        <asp:ListItem Selected="True" Value="Prepare"> Prepare </asp:ListItem>
                        <asp:ListItem Value="Doing"> Doing </asp:ListItem>
                        <asp:ListItem Value="Finished"> Finished </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group form-check">
            <asp:CheckBox runat="server" ID="checkboxIsPrivate" />
            
            <label class="form-check-label" for="exampleCheck1">Private</label>
          </div>
            <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <asp:Label ID="Label1" runat="server" Text="Files:"></asp:Label>
                </div>
                <div class="row">
                    
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button  ID="btnUpload" runat="server"  Text="Upload" />
                </div>
            </div>  
            <div class="row">
                <asp:Button Text="Update" OnClick="Updating_Click"  cssClass="styleButtonUpdate" runat="server"></asp:Button>
                <asp:Button Text="Cancel" OnClick="Canceling_Click"  cssClass="styleButtonCancel" runat="server"></asp:Button>
            </div>  

        </div>
        <div class="col-md-2"></div>
    </div>
            <asp:DataList ID="DataList1" runat="server"   cssClass="row" RepeatLayout="Flow" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-sm-2 col-md-2 col-lg-2"></div>
                        <div class="col-sm-8 col-md-8 col-lg-8 card">
                        <div class="row">            
                            <div class="col-sm-6 col-md-6 col-lg-6">
                                <span class="label label-primary"><%# Eval("cmt_staffname") %> >></span></div>
                            <div class="col-sm-6 col-md-6 col-lg-6"><%# Eval("cmt_content") %></div>
                        </div>
                        </div>
                         <div class="col-sm-2 col-md-2 col-lg-2"></div>
                        
                        </div>            
                </ItemTemplate>
             </asp:DataList>            
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8"> 
                <div class="form-group" style="padding:5px 5px">
                <div class="row">
                    <asp:Label ID="Label2" Font-Size="Large" runat="server" Text="Comment:"></asp:Label>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:TextBox ID="TextBoxComment" cssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Title is required" ControlToValidate="tbTitle" runat="server" />
                    </div>
                     <div class="col-md-6">
                        <asp:Button Text="Send" OnClick="Comment_Click"   cssClass="styleButtonUpdate" runat="server"></asp:Button>   
                     </div>
                         
                </div>
            </div>
            </div>
            <div class="col-md-2"></div>
        </div>
        </div>
   
</asp:Content>
