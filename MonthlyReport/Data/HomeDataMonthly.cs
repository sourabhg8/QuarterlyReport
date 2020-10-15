using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MonthlyReport.Models;


namespace MonthlyReport.Data
{
    public class HomeDataMonthly
    {
        public Home GetHomeData()
        {
            Home home = new Home();
            DataSet data = DBConnection.GetData("getHomeDataMonthly");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                home.quarter = !String.IsNullOrEmpty(row["quarter"].ToString()) ? row["quarter"].ToString() : string.Empty;
            }
            return home;
        }

        public void UpdateHomeData(Home home)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("UpsertHomeDataMonthly", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@quartername", SqlDbType.VarChar).Value = home.quarter;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}