using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TodoList.App_Code.BLL;
using TodoList.App_Code.DTO;

namespace TodoList
{
    public partial class TaskDetailsPage : System.Web.UI.Page
    {
        Task task = new Task();
        TaskBLL taskBll = new TaskBLL();
        StaffBLL staffBll = new StaffBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Convert.ToString(Session["id"]);
            if (String.IsNullOrEmpty(user))
            {
                Response.Redirect("/login.aspx");
            }
            if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                getValueTask();
            }
            if (!IsPostBack)
            {
                init();
                bindComment();
            }
            
        }
        private void getValueTask()
        {
            int taskId = Convert.ToInt32(Request.QueryString["id"]);
            task = taskBll.getTask(taskId);
        }
        protected void init()
        {
            tbTitle.Text = task.Title;
            tbStartDate.Text = task.StartDate.ToString("s");
            tbEndDate.Text = task.EndDate.ToString("s");
            if(task.Public == true)
            {
                checkboxIsPrivate.Checked = false;
            }
            else
            {
                checkboxIsPrivate.Checked = true;
            }
            ListDropDown.SelectedValue = task.Status;

            bindPartner();

            List<Staff> listPartner = staffBll.getListIdPartnerByTaskId(task.Id);

            foreach (GridViewRow row in GridViewPartner.Rows)
            {
                int partnerCurrentId = Convert.ToInt32(GridViewPartner.DataKeys[row.RowIndex].Value.ToString());
                int index = listPartner.FindIndex(u => u.Id == partnerCurrentId);
                if (index != -1)
                {
                    CheckBox ckb = row.FindControl("checkbox") as CheckBox;
                    ckb.Checked = true;
                }

            }
        }
        private void bindPartner()
        {
            if (Session["id"] == null)
            {
                Response.Redirect("/login.aspx");
            } 
            GridViewPartner.DataSource = staffBll.getAllStaff();
            GridViewPartner.DataBind();
        }
        private void bindComment()
        {
            DataList1.DataSource = taskBll.getAllCommentByTaskId(task.Id);
            DataList1.DataBind();
        }
        protected void Updating_Click(object sender, EventArgs e)
        {
            int taskId = Convert.ToInt32(Request.QueryString["id"]);
            string title = tbTitle.Text.Trim();
            DateTime startDate = Convert.ToDateTime(tbStartDate.Text);
            DateTime endDate = Convert.ToDateTime(tbEndDate.Text);
            string status = ListDropDown.SelectedValue.Trim();
            bool isPrivate = checkboxIsPrivate.Checked;
            bool isPublic = true;
            if (isPrivate == true)
            {
                isPublic = false;
            }

            string files = FileUpload1.FileName;

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
            Task task = new Task(taskId,title, startDate, endDate, isPublic, status, files);

            taskBll.Update(task, arr);

            Response.Redirect("/TaskPage.aspx");
            
        }

        protected void Canceling_Click(object sender, EventArgs e)
        {
            Response.Redirect("/TaskPage.aspx");
        }

        protected void Comment_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["id"]);
            string staffName = Convert.ToString(Session["name"]);
            string content = TextBoxComment.Text;
            taskBll.insertComment(task.Id, id,staffName, content);

            bindComment();
        }
    }
}