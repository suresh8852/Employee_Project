using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeProject
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        EMDataAccessLayer emDAL;
        int employeeID;
        string chSkills;
        string updateSkills;
        protected void Page_Load(object sender, EventArgs e)
        {
            employeeID = Convert.ToInt32(Request.QueryString["EmpId"]);
            if (!IsPostBack)
            {
                UpdateData();
            }
            
        }
        public void UpdateData()
        {
            lblEmpID.Text = Convert.ToString(employeeID);
            lblEmpID.Visible = true;
            emDAL = new EMDataAccessLayer();
            try
            {
                Employee empObj = emDAL.FetchEmployee(employeeID);
                string val = empObj.Skills;
                for (int ctr = 0; ctr <= val.Length - 1; ctr++)
                {                    
                    if (val[ctr] != Convert.ToChar(","))
                    {
                        updateSkills = updateSkills + val[ctr];
                    }
                    else 
                    {                        
                        SelectCheckBoxList(updateSkills);
                        updateSkills = null;
                    }

                }
                SelectCheckBoxList(updateSkills);
                txtEmployeeName.Text = empObj.EmployeeName;
                txtDepartment.Text = empObj.Department;
                //cblSkills.Text = empObj.Skills;
                rbGender.Text = Convert.ToString(empObj.Gender);
                ddlStream.Text = empObj.Stream;

            }
            catch
            {
                lblStatus.Text = "Error in Fetching Employee Details";
            }
        }
        private void SelectCheckBoxList(string valueToSelect)
        {
            ListItem listItem = this.cblSkills.Items.FindByText(valueToSelect);

            if (listItem != null) listItem.Selected = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {           

            foreach (ListItem li in cblSkills.Items)
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
                        chSkills = chSkills + "," + val;
                    }
                }

            }
            emDAL = new EMDataAccessLayer();
            try
            {
                Employee empObj1 = new Employee();
                empObj1.EmployeeName = txtEmployeeName.Text;
                empObj1.Department = txtDepartment.Text;
                empObj1.Skills = chSkills;
                empObj1.Gender = Convert.ToChar(rbGender.SelectedValue);
                empObj1.Stream = ddlStream.SelectedValue;
                int retVal = emDAL.UpdateEmployee(empObj1, employeeID);

                if (retVal == 1)
                {
                    lblStatus.Text = "Employee Updated Successfully";
                    lblStatus.Visible = true;
                    UpdateData();
                }
                else
                    // lblStatus.Text = "Employee addition failed!";
                    lblStatus.Text = "error is " + retVal;
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
            foreach (ListItem li in cblSkills.Items)
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