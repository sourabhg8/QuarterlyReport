using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonthlyReport.Models;
using System.Data;
using System.Data.SqlClient;


namespace MonthlyReport.Data
{
    public class FinancialDataMonthly
    {
        public Financial GetFinancialData()
        {
            Financial financial = new Financial();
            DataSet data = DBConnection.GetData("getMonthlyFinancial");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                financial.importantUpdate = row["important_update"].ToString();
                financial.masterPlanUpdate = row["masterplan_update"].ToString();
            }
            List<Revenue> revenues = new List<Revenue>();
            foreach(DataRow dr in data.Tables[1].Rows)
            {
                Revenue obj = new Revenue();
                obj.act =  (dr["act"].ToString());
                obj.bud =  dr["bud"].ToString();
                obj.var =  (dr["var"].ToString());
                obj.actfor = (dr["actfor"].ToString());
                obj.budfor = (dr["budfor"].ToString());
                obj.varfor = (dr["varfor"].ToString());
                obj.comment = dr["comment"].ToString();
                obj.action = dr["action"].ToString();
                revenues.Add(obj);
            }
            financial.revenues = revenues;
            return financial;
        }

        public void updateFinancialData(Financial financial)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<Revenue>(financial.revenues);
                using (SqlCommand cmd = new SqlCommand("updateMonthlyFinancialData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@impupdt", financial.importantUpdate);
                    cmd.Parameters.AddWithValue("@mPlanUpdt",   financial.masterPlanUpdate);
                    cmd.Parameters.AddWithValue("@data", datatable);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}