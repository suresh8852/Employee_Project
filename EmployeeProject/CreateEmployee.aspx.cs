using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeProject
{
    public partial class CreateEmployee : System.Web.UI.Page
    {
        EMDataAccessLayer emDAL;
        string chSkills;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            foreach (ListItem li in chkSkills.Items)
            {
                string val;
                if (li.Selected == true)
                {
                    val = li.Value;
                    if (string.IsNullOrEmpty(chSkills) == true)
                    {
                        chSkills = chSkills + val;
                    }
                    else
                    {
                        chSkills = chSkills +","+ val;
                    }
                }
               
            }

            emDAL = new EMDataAccessLayer();
            try
            {
            Employee empObj = new Employee();
            empObj.EmployeeName = txtEmployeeName.Text;
            empObj.Department = txtDepartment.Text;
            empObj.Skills = chSkills;
            empObj.Gender = Convert.ToChar(rbGender.SelectedValue);
            empObj.Stream = ddlStream.SelectedValue;
            int retVal = emDAL.AddEmployee(empObj);

            if (retVal == 1)
            {
                lblStatus.Text = "Employee Added Successfully";
                //lblStatus.Text = chSkills;
                lblStatus.Visible = true;
            }
            else
                // lblStatus.Text = "Employee addition failed!";
                lblStatus.Text = "error is "+retVal;
                lblStatus.Visible = true;
            }
            catch
            {
                lblStatus.Text = "Operation failed!";
                lblStatus.Visible = true;
            }
            finally
            {

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtEmployeeName.Text = null;
            txtDepartment.Text = null;
            foreach (ListItem li in chkSkills.Items)
            {
                li.Selected = false;
            }
            rbGender.SelectedIndex = -1;
            ddlStream.SelectedIndex = 0;
            lblStatus.Text = null;
            lblStatus.Visible = false;
        }
    }
}