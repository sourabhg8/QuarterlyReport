using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonthlyReport.Models;
using System.Data;
using System.Data.SqlClient;

namespace MonthlyReport.Data
{
    public class LoginTable
    {
        public Login GetValidation(Login login)
        {
            Login logindata = new Login();
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Authenticate";
                cmd.Parameters.AddWithValue("@username", login.username);
                cmd.Parameters.AddWithValue("@password", login.password);
                cmd.Connection = con;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dataSet);

            }
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                logindata.Isvalid = Convert.ToInt32(dr["ISVALID"].ToString())== 1 ;
                logindata.roleName = dr["rolename"].ToString();
                logindata.roleid = Convert.ToInt32(dr["roleid"].ToString());
            }
            return logindata;
        }

        public void ChangePassword(Login login)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("updatePassword", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", login.username);
                    cmd.Parameters.AddWithValue("@password", login.newPassword);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}