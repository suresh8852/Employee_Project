using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeProject
{
    public partial class _Default : System.Web.UI.Page
    {
        EMDataAccessLayer emDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewEmployee();
        }

        private void ViewEmployee()
        {
            emDAL = new EMDataAccessLayer();
            if (!IsPostBack)
            {
                try
                {
                    gvViewEmployee.DataSource = emDAL.ViewJoinedEmployee();
                    gvViewEmployee.DataBind();
                }
                catch
                {
                    lblStatus.Text = "Error in fetching the employee details!";
                    lblStatus.Visible = true;
                }
            }
        }

        protected void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateEmployee.aspx");
        }

        protected void gvViewEmployee_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            lblStatus.Text = "Row Deleted called";
            lblStatus.Visible = true;
        }

        protected void gvViewEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            TableCell cell = gvViewEmployee.Rows[e.RowIndex].Cells[1];
            int employeeID = Convert.ToInt32(cell.Text);

            emDAL = new EMDataAccessLayer();
            try
            {

                int retVal = emDAL.DeleteEmployee(employeeID);
                if (retVal == 1)
                {
                    lblStatus.Text = "Deleted Successfully!!!";
                    lblStatus.Visible = true;
                    try
                    {
                        gvViewEmployee.DataSource = emDAL.ViewJoinedEmployee();
                        gvViewEmployee.DataBind();
                    }
                    catch
                    {
                        lblStatus.Text = "Error in fetching the employee details!";
                        lblStatus.Visible = true;
                    }
                }
                else
                {
                    lblStatus.Text = "Error occured in deleting";
                    lblStatus.Visible = true;
                }
            }
            catch
            {
                lblStatus.Text = "Delete Operation Failed!!";
                lblStatus.Visible = true;
            }
                        
        }

        protected void gvViewEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblStatus.Text = "Row editing clicked";
            lblStatus.Visible = true;
            string cell = gvViewEmployee.Rows[e.NewEditIndex].Cells[1].Text;            
            int employeeID = Convert.ToInt32(cell);
            Response.Redirect("EditEmployee.aspx?EmpId=" + employeeID);

        }
        
       
    }
}