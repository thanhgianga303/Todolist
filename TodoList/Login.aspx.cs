using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TodoList.App_Code.BLL;
using TodoList.App_Code.DTO;

namespace TodoList
{
    public partial class Login : System.Web.UI.Page
    {
        private List<Staff> listNhanVien = new List<Staff>();
        private StaffBLL nvBLL = new StaffBLL();
        public string Notification = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Convert.ToString(Session["id"]);
           if(!String.IsNullOrEmpty(id))
            {
                Response.Redirect("~/TaskPage.aspx");
            }
        }
        protected void checkLogin(object sender, EventArgs e)
        {

            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();
            Staff nv = nvBLL.Login(username, password);
            if (nv != null)
            {
                Session["id"] = nv.Id;
                Session["name"] = nv.Name;
                Session["email"] = nv.Email;
                Session["role"] = nv.Role;
                Response.Redirect("~/TaskPage.aspx");
            }
            else
            {
                lbError.Text = "Error username or password";
            }
            Notification = "Login success";
            this.DataBind();
         }

        
        }
}