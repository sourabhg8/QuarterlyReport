using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MonthlyReport.Models;

namespace MonthlyReport.Data
{
    public class OperationsDataMonthly
    {
        public List<Operations> GetOperations()
        {
            List<Operations> operations = new List<Operations>();
            DataSet data = DBConnection.GetData("GetMonthlyOperations");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                Operations operation = new Operations();
                operation.OperationId =   new Guid(row["OperationId"].ToString());
                operation.Project = !String.IsNullOrEmpty(row["Project"].ToString()) ? row["Project"].ToString() : string.Empty;
                operation.CompletionDate = !String.IsNullOrEmpty(row["CompletionDate"].ToString()) ? row["CompletionDate"].ToString() : string.Empty;
                operation.ForecastCompletionDate = !String.IsNullOrEmpty(row["ForecastCompletionDate"].ToString()) ? row["ForecastCompletionDate"].ToString() : string.Empty;
                operation.Budget = !String.IsNullOrEmpty(row["Budget"].ToString()) ? row["Budget"].ToString() : string.Empty;
                operation.CommitToDate = !String.IsNullOrEmpty(row["CommitToDate"].ToString()) ? row["CommitToDate"].ToString() : string.Empty;
                operation.ApprovedAmount = !String.IsNullOrEmpty(row["ApprovedAmount"].ToString()) ? row["ApprovedAmount"].ToString() : string.Empty;
                operation.Comments = !String.IsNullOrEmpty(row["Comments"].ToString()) ? row["Comments"].ToString() : string.Empty;
                operation.IsRecoverable = Convert.ToBoolean(row["IsRecoverable"]);
                operations.Add(operation);
            }
            return operations;
        }

        public void UpdateOperations(List<Operations> operations)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<Operations>(operations);
                using (SqlCommand cmd = new SqlCommand("updateMonthlyOperations", con))
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