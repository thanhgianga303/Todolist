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
    public partial class StaffDetails : System.Web.UI.Page
    {
        Staff staff = new Staff();
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
                getValueStaff();
            }
            if(!IsPostBack)
            {
                init();
            }
        }
        protected void init()
        {
            tbId.Text =Convert.ToString(staff.Id);
            tbName.Text = staff.Name;
            tbEmail.Text = staff.Email;
            tbPassword.Text = staff.Password;
            tbPhone.Text = staff.Phone;

            ListDropDown.SelectedValue = staff.Role;
        }
        private void getValueStaff()
        {
            int staffId = Convert.ToInt32(Request.QueryString["Id"]);
            staff = staffBll.getStaff(staffId);
        }

        protected void Updating_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            string name = tbName.Text.Trim();
            string email = tbEmail.Text.Trim();
            string password = tbPassword.Text.Trim();
            string phone = tbPhone.Text.Trim();
            string role = ListDropDown.SelectedValue;

            Staff newStaff = new Staff(id,name,email,password,phone,role);

            staffBll.Update(newStaff);

            Response.Redirect("/Staff.aspx");
        }
        protected void Canceling_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Staff.aspx");
        }

        protected void SeeTaskList_Click(object sender, EventArgs e)
        {
        //    string id = Request.QueryString["Id"];
          //  Response.Redirect("/TaskDetailsPage.aspx?id=" + id);
        }
    }
}