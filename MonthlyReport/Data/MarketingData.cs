using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonthlyReport.Models;
using System.Data;
using System.Data.SqlClient;

namespace MonthlyReport.Data
{
    public class MarketingData
    {
        public List<Marketing> GetMarketingData()
        {
            List<Marketing> marketings = new List<Marketing>();
            DataSet data = DBConnection.GetData("GetMarketing");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                Marketing marketing = new Marketing();            
                marketing.Type = !String.IsNullOrEmpty(row["Type"].ToString()) ? row["Type"].ToString() : string.Empty;
                marketing.TypeValue = !String.IsNullOrEmpty(row["TypeValue"].ToString()) ? row["TypeValue"].ToString() : string.Empty;
                marketing.Kpi1 = !String.IsNullOrEmpty(row["Kpi1"].ToString()) ? row["Kpi1"].ToString() : string.Empty;
                marketing.Kpi2 = !String.IsNullOrEmpty(row["Kpi2"].ToString()) ? row["Kpi2"].ToString() : string.Empty;
                marketing.Kpi3 = !String.IsNullOrEmpty(row["Kpi3"].ToString()) ? row["Kpi3"].ToString() : string.Empty;
                marketing.Result1 = !String.IsNullOrEmpty(row["Result1"].ToString()) ? row["Result1"].ToString() : string.Empty;
                marketing.Result2 = !String.IsNullOrEmpty(row["Result2"].ToString()) ? row["Result2"].ToString() : string.Empty;
                marketing.Result3 = !String.IsNullOrEmpty(row["Result3"].ToString()) ? row["Result3"].ToString() : string.Empty;
                marketings.Add(marketing);
            }
            return marketings;
        }

        public void UpdateMarketingData(List<Marketing> lst)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<Marketing>(lst);
                using (SqlCommand cmd = new SqlCommand("UpdateMarketing", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatable);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}