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
    public partial class AccountPage : System.Web.UI.Page
    {
        StaffBLL staffBll = new StaffBLL();
        string id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Convert.ToString(Session["id"]);
            if (String.IsNullOrEmpty(user))
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                init();
            }
        }
        protected void init()
        {
            id = Session["id"].ToString();
            Staff staff = staffBll.getStaff(Convert.ToInt32(id));

            tbId.Text = Convert.ToString(staff.Id);
            tbName.Text = staff.Name;
            tbEmail.Text = staff.Email;
            tbPassword.Text = staff.Password;
            tbPhone.Text = staff.Phone;
            tbRole.Text = staff.Role;
        }

        protected void Updating_Click(object sender, EventArgs e)
        {
            int _id = Convert.ToInt32(tbId.Text);
            string name = tbName.Text.Trim();
            string email = tbEmail.Text.Trim();
            string password = tbPassword.Text.Trim();
            string phone = tbPhone.Text.Trim();
            string role = tbRole.Text;

            Staff newStaff = new Staff(_id, name, email, password, phone, role);

            staffBll.Update(newStaff);

            init();
        }
    }
}