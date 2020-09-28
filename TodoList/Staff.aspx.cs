using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.EntityFramework;
using TodoList.App_Code.BLL;
using TodoList.App_Code.DTO;

namespace TodoList
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private StaffBLL staffBll = new StaffBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }           
        }
        protected void bind()
        {

            List<Staff> listNhanVien = staffBll.getAllStaff();
            GridViewEmployee.DataSource = listNhanVien;
            GridViewEmployee.DataBind();
        }
        protected void Insert_Click(object sender, EventArgs e)
        {
            
            var name= tbName.Text.Trim();
            var email= tbEmail.Text.Trim();
            var password= tbPassword.Text.Trim();
            var phone = tbPhone.Text.Trim();
            var role = tbRole.Text.Trim();

            Staff nhanVien = new Staff(name, email, password,phone,role);
            StaffBLL nvBLL= new StaffBLL();

            nvBLL.Insert(nhanVien);

            bind();
    }

        protected void GridViewEmployee_DeleteRow(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow) GridViewEmployee.Rows[e.RowIndex];
            TableCell Cell=(TableCell) row.Cells[0];

            Staff staff = staffBll.getStaff(Int32.Parse(Cell.Text));

            staffBll.Delete(staff);

            bind();
        }
        protected void GridViewEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEmployee.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void GridViewEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEmployee.EditIndex = -1;
            bind();
        }

        protected void GridViewEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            /*GridViewRow row = (GridViewRow)GridViewEmployee.Rows[e.RowIndex];
            TextBox textId = (TextBox)row.Cells[0].Controls[0];
            TextBox textName = (TextBox)row.Cells[1].Controls[0];
            TextBox textEmail = (TextBox)row.Cells[2].Controls[0];
            TextBox textPassword = (TextBox)row.Cells[3].Controls[0];
            TextBox textPhone = (TextBox)row.Cells[4].Controls[0];
            TextBox textRole = (TextBox)row.Cells[5].Controls[0];

            Staff staff = new Staff(textName.Text, textEmail.Text, textPassword.Text, textPhone.Text, textRole.Text);
            staff.Id = Int32.Parse(textId.Text);
            staffBll.Update(staff);
            GridViewEmployee.EditIndex = -1;
            bind();
            */
            string text = "asdasdasd";
        }
    }
}