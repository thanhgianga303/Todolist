﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskPage.aspx.cs" Inherits="TodoList.TaskPage" %>

    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
    <div class="row">
            <div class="col-md-10">
                <h1>Staff Table</h1>
            </div>
            <div class="col-md-2" style="text-align:center">
                <h1>Add Staff</h1> 
            </div>
        </div>
        <div>
            <div class="col-md-12">
                <hr style="color:deepskyblue"/>
            </div>
        </div>
    <div class="row">
        <div class="col-md-10 card">
            <asp:GridView ID="GridViewTask"
                                runat="server"
                                CssClass="table table-condensed"
                                OnRowDeleting="GridViewTask_RowDeleting"                       
                                OnRowEditing="GridViewTask_RowEditing"
                                OnRowCancelingEdit="GridViewTask_RowCancelingEdit" AutoGenerateColumns="False" 
                                                 >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="task_id" />
                <asp:TemplateField HeaderText="Title" SortExpression="asdas">
                    <ItemTemplate>
                        <a href="/TaskDetailsPage.aspx?id=<%#Eval("Id") %>"><%#Eval("Title")%> </a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="task_startdate" />
                <asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="task_enddate" />
                <asp:BoundField DataField="Public" HeaderText="Public" SortExpression="task_public" />
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label CssClass='<%# Eval("status").Equals("Prepare") ? "label label-primary" : (Eval("status").Equals("Doing") ? "label label-danger" : "label label-success") %>' ID="Label4" runat="server" Text='<%# Eval("Status") %>'></asp:Label> 
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Files" HeaderText="Files" SortExpression="task_files" />
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-primary styleButton" HeaderText="Actions" ShowDeleteButton="True"/>
            </Columns>
            </asp:GridView>

        </div>
        <div class="col-md-2" style="text-align:center">
            <button type="button" class="btn btn-success" data-toggle="modal" data-target="#exampleModal">
            Add new task
            </button>
        </div>
    </div>
</div>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title label label-primary" id="exampleModalLabel">Add new task</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <div class="form-group">
            <asp:Label ID="LabelTitle" runat="server" Text="Title:"></asp:Label>
            <asp:TextBox ID="tbTitle" cssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Title is required" ControlToValidate="tbTitle" runat="server" />
          </div>
          <div class="form-group">
            <asp:Label ID="LabelStartDate" runat="server" Text="Start Date:"></asp:Label>
            <asp:TextBox ID="tbStartDate" TextMode="DateTimeLocal" cssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Start date is required" ControlToValidate="tbStartDate" runat="server" />
          </div>
          <div class="form-group">
            <asp:Label ID="LabelEndDate" runat="server" Text="End Date:"></asp:Label>
            <asp:TextBox ID="tbEndDate" TextMode="DateTimeLocal" cssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Title is required" ControlToValidate="tbEndDate" runat="server" />
          </div>
          <div class="form-group">
            <label for="endDate">Select partner</label>
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
          <div class="form-group form-check">
            <asp:CheckBox runat="server" ID="checkboxIsPrivate" />
            
            <label class="form-check-label" for="exampleCheck1">Private</label>
          </div>
          <div class="form-group">
            <asp:Label ID="LabelStatus" runat="server" Text="Status:"></asp:Label>
            <asp:DropDownList id="ListDropDown"
                AutoPostBack="True"
                runat="server">
                <asp:ListItem Selected="True" Value="Prepare"> Prepare </asp:ListItem>
                <asp:ListItem Value="Doing"> Doing </asp:ListItem>
                <asp:ListItem Value="Finished"> Finished </asp:ListItem>
            </asp:DropDownList>
        </div>
          <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Files:"></asp:Label>
            <asp:FileUpload ID="FileUpload1" runat="server" />
           </div>
              
            </div>
    
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <asp:Button cssClass="btn btn-primary"  runat="server" OnClick="AddNewTask_Click" Text="Add"></asp:Button>
      </div>
    </div>
  </div>
</div>
</asp:Content>
