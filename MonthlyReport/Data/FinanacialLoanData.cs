using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonthlyReport.Models;
using System.Data.SqlClient;
using System.Data;

namespace MonthlyReport.Data
{
    public class FinanacialLoanData
    {
        public List<FinancialLoan> GetFinancialLoanData()
        {
            List<FinancialLoan> lst = new List<FinancialLoan>();
            DataSet data = DBConnection.GetData("GetFinancialLoan");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                FinancialLoan obj = new FinancialLoan();
                obj.LoanId = new Guid(row["LoanId"].ToString());
                obj.Phase = !String.IsNullOrEmpty(row["Phase"].ToString()) ? row["Phase"].ToString() : string.Empty;
                obj.Lender = !String.IsNullOrEmpty(row["Lender"].ToString()) ? row["Lender"].ToString() : string.Empty;
                obj.Loanbalance = !String.IsNullOrEmpty(row["Loanbalance"].ToString()) ? row["Loanbalance"].ToString() : string.Empty;
                obj.Rate = !String.IsNullOrEmpty(row["Rate"].ToString()) ? row["Rate"].ToString() : string.Empty;
                obj.Term = !String.IsNullOrEmpty(row["Term"].ToString()) ? row["Term"].ToString() : string.Empty;
                obj.Expiryterm = !String.IsNullOrEmpty(row["Expiryterm"].ToString()) ? row["Expiryterm"].ToString() : string.Empty;
                obj.date = !String.IsNullOrEmpty(row["date"].ToString()) ? row["date"].ToString() : string.Empty;
                lst.Add(obj);
            }
            return lst;
        }

        public void UpdateFinancialLoan(List<FinancialLoan> obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<FinancialLoan>(obj);
                using (SqlCommand cmd = new SqlCommand("updateFinancialLoan", con))
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