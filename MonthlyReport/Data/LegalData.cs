using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MonthlyReport.Models;

namespace MonthlyReport.Data
{
    public class LegalData
    {
        public List<Legal> GetLegalData()
        {
            List<Legal> legals = new List<Legal>();
            DataSet data = DBConnection.GetData("GetLegal");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                Legal legal = new Legal();
                legal.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                legal.Ar = !String.IsNullOrEmpty(row["Ar"].ToString()) ? row["Ar"].ToString() : string.Empty;
                legal.CollectionProb = !String.IsNullOrEmpty(row["CollectionProb"].ToString()) ? row["CollectionProb"].ToString() : string.Empty;
                legal.Comments = !String.IsNullOrEmpty(row["Comments"].ToString()) ? row["Comments"].ToString() : string.Empty;
                legals.Add(legal);
            }
            return legals;
        }
        public void UpdateLegalData(List<Legal> legals)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<Legal>(legals);
                using (SqlCommand cmd = new SqlCommand("UpdateLegal", con))
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