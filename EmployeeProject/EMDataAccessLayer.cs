using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace EmployeeProject
{
    public class EMDataAccessLayer
    {
        //Declaring the sql connection
        SqlConnection conEmployeeMgmt;
        private int EmployeeID;
        private int EmployeeID1;

        /// <summary>
        /// DAL default constructor
        /// </summary>
        public EMDataAccessLayer()
        {
            conEmployeeMgmt = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeManagementConnectionString"].ToString());
        }

        public DataTable ViewJoinedEmployee()
        {
            DataTable dtJoinedEmp = new DataTable();
            SqlCommand cmdJoinedEmp;
            SqlDataAdapter daJoinedEmp = new SqlDataAdapter();
            try
            {
                cmdJoinedEmp = new SqlCommand("usp_FetchEmployeeDetails",conEmployeeMgmt);
                cmdJoinedEmp.CommandType = CommandType.StoredProcedure;
                daJoinedEmp.SelectCommand = cmdJoinedEmp;
                daJoinedEmp.Fill(dtJoinedEmp);
            }
            catch
            {
                dtJoinedEmp = null;
            }
            return dtJoinedEmp;
        }
        public int AddEmployee(Employee empObj)
        {
            int returnValue;

            try
            {
                SqlCommand cmdAddEmployee = new SqlCommand(@"usp_AddEmployee", conEmployeeMgmt);
                cmdAddEmployee.CommandType = CommandType.StoredProcedure;
                cmdAddEmployee.Parameters.AddWithValue("@EmployeeName", empObj.EmployeeName);
                cmdAddEmployee.Parameters.AddWithValue("@Department", empObj.Department);
                cmdAddEmployee.Parameters.AddWithValue("@Skills", empObj.Skills);
                cmdAddEmployee.Parameters.AddWithValue("@Gender", empObj.Gender);
                cmdAddEmployee.Parameters.AddWithValue("@Stream", empObj.Stream);

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = ParameterDirection.ReturnValue;
                cmdAddEmployee.Parameters.Add(prmReturn);

                conEmployeeMgmt.Open();
                cmdAddEmployee.ExecuteNonQuery();
                returnValue = Convert.ToInt32(prmReturn.Value);
            }
            catch
            {
                returnValue = -99;
            }
            finally
            {
                conEmployeeMgmt.Close();
            }
            return returnValue;
        }

        public int DeleteEmployee(int EmployeeID)
        {
            int returnValue;            
            try
            {
                SqlCommand cmdAddEmployee = new SqlCommand(@"usp_DeleteEmployee", conEmployeeMgmt);
                cmdAddEmployee.CommandType = CommandType.StoredProcedure;
                cmdAddEmployee.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = ParameterDirection.ReturnValue;
                cmdAddEmployee.Parameters.Add(prmReturn);

                conEmployeeMgmt.Open();
                cmdAddEmployee.ExecuteNonQuery();
                returnValue = Convert.ToInt32(prmReturn.Value);
            }
            catch
            {
                returnValue = -99;
            }
            finally
            {
                conEmployeeMgmt.Close();
            }
            return returnValue;
        }
        public Employee FetchEmployee(int employeeID)
        {
            Employee empObj = new Employee();
            try
            {
                SqlCommand cmdAddEmployee = new SqlCommand(@"usp_FetchEmployeeDetailsByEmployeeID", conEmployeeMgmt);
                cmdAddEmployee.CommandType = CommandType.StoredProcedure;
                cmdAddEmployee.Parameters.AddWithValue("@EmployeeID", employeeID);
                conEmployeeMgmt.Open();
                using (SqlDataReader oReader = cmdAddEmployee.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        empObj.EmployeeName = oReader["EmployeeName"].ToString();
                        empObj.Department = oReader["DepartMent"].ToString();
                        empObj.Skills = oReader["Skills"].ToString();
                        empObj.Gender = Convert.ToChar(oReader["Gender"].ToString());
                        empObj.Stream = oReader["Stream"].ToString();
                    }

                    conEmployeeMgmt.Close();
                }               

            }
            catch
            {
            }
            finally
            {
                conEmployeeMgmt.Close();
            }
            return empObj;
        }

        public int UpdateEmployee(Employee empObj, int employeeID)
        {
            int returnValue;

            try
            {
                SqlCommand cmdUpdateEmployee = new SqlCommand(@"usp_UpdateEmployee", conEmployeeMgmt);
                cmdUpdateEmployee.CommandType = CommandType.StoredProcedure;
                cmdUpdateEmployee.Parameters.AddWithValue("@EmployeeID", employeeID);
                cmdUpdateEmployee.Parameters.AddWithValue("@EmployeeName", empObj.EmployeeName);
                cmdUpdateEmployee.Parameters.AddWithValue("@Department", empObj.Department);
                cmdUpdateEmployee.Parameters.AddWithValue("@Skills", empObj.Skills);
                cmdUpdateEmployee.Parameters.AddWithValue("@Gender", empObj.Gender);
                cmdUpdateEmployee.Parameters.AddWithValue("@Stream", empObj.Stream);

                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = ParameterDirection.ReturnValue;
                cmdUpdateEmployee.Parameters.Add(prmReturn);

                conEmployeeMgmt.Open();
                cmdUpdateEmployee.ExecuteNonQuery();
                returnValue = Convert.ToInt32(prmReturn.Value);
            }
            catch
            {
                returnValue = -99;
            }
            finally
            {
                conEmployeeMgmt.Close();
            }
            return returnValue;
        }
    }
}