﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TodoList.App_Code.BLL;
using TodoList.App_Code.DTO;

namespace TodoList
{
    public partial class TaskPage : System.Web.UI.Page
    {
        TaskBLL taskBll = new TaskBLL();
        StaffBLL staffBll = new StaffBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Convert.ToString(Session["id"]);

            if (String.IsNullOrEmpty(user))
            {
                Response.Redirect("/login.aspx");
            }
            if (!IsPostBack)
            {
                bind();
            }
            
        }
        protected void bind()
        {
            string StaffId = Convert.ToString(Session["id"]);
            string role = Convert.ToString(Session["role"]);
            List<Task> taskList = null;
            if (role == "admin")
            {
                taskList = taskBll.getAllTask();
            }
            else
            {
                taskList = taskBll.getAllTaskByStaffId(Int32.Parse(StaffId));
            }
            GridViewTask.DataSource = taskList;
            GridViewTask.DataBind();

            List<Staff> staffList = staffBll.getAllStaff();
            GridViewPartner.DataSource = staffList;
            GridViewPartner.DataBind();
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && FileUpload1.HasFile)
            {
                string fileName = "Upload/" + FileUpload1.FileName;
                string filePath = MapPath(fileName);
                FileUpload1.SaveAs(filePath);
            }
        }

        protected void AddNewTask_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text.Trim();
            DateTime startDate =Convert.ToDateTime(tbStartDate.Text);
            DateTime endDate = Convert.ToDateTime(tbEndDate.Text);
            string status = ListDropDown.SelectedValue.Trim();
            bool isPrivate = checkboxIsPrivate.Checked;
            bool isPublic = true;
            if (isPrivate == true)
            {
                isPublic = false;
            }
         
            string urlFile = null;

            if (FileUpload1.HasFile)
            {
                try
                {
                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    FileUpload1.SaveAs(Server.MapPath("~") + "/Upload/" + fileName);
                    urlFile = "/Upload/" + fileName;
                }
                catch (Exception ex)
                {

                }
            }
            List<int> arr = new List<int>();
            foreach (GridViewRow row in GridViewPartner.Rows)
            {

                CheckBox checkBox = (CheckBox)row.FindControl("checkbox");
                if (checkBox.Checked)
                {
                    arr.Add(Int32.Parse(GridViewPartner.DataKeys[row.RowIndex].Value.ToString()));
                }
            }
            int ownerId = Convert.ToInt32(Session["id"].ToString());
            Task task = new Task(title,startDate,endDate, isPublic, status,urlFile);

            taskBll.Insert(task, arr, ownerId);
            bind();
        }
        protected void GridViewTask_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewTask.EditIndex = -1;
            bind();
        }

        protected void GridViewTask_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridViewTask.Rows[e.RowIndex];
            TableCell Cell = (TableCell)row.Cells[0];

            Task task = taskBll.getTask(Int32.Parse(Cell.Text));

            taskBll.Delete(task);

            bind();
        }

        protected void GridViewTask_RowEditing(object sender, GridViewEditEventArgs e)
        {

            //GridViewRow row = (GridViewRow)GridViewTask.Rows[RowIndex];
            //TableCell Cell = (TableCell)row.Cells[1];
        }

        
    }
}