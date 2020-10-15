using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MonthlyReport.Models;

namespace MonthlyReport.Data
{
    public class AccountsDataMonthly
    {
        public List<Accounts> GetAccountsData()
        {
            List<Accounts> accounts = new List<Accounts>();
            DataSet data = DBConnection.GetData("GETMONTHLYACCOUNTS");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                Accounts account = new Accounts();
                account.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                account.BalanceOverdue = !String.IsNullOrEmpty(row["BalanceOverdue"].ToString()) ? row["BalanceOverdue"].ToString() : string.Empty;
                account.NetBalance = !String.IsNullOrEmpty(row["NetBalance"].ToString()) ? row["NetBalance"].ToString() : string.Empty;
                account.Provision = !String.IsNullOrEmpty(row["Provision"].ToString()) ? row["Provision"].ToString() : string.Empty;
                account.ReceivableBalance = !String.IsNullOrEmpty(row["ReceivableBalance"].ToString()) ? row["ReceivableBalance"].ToString() : string.Empty;
                account.ThirtyDays = !String.IsNullOrEmpty(row["ThirtyDays"].ToString()) ? row["ThirtyDays"].ToString() : string.Empty;
                account.SixtyDays = !String.IsNullOrEmpty(row["SixtyDays"].ToString()) ? row["SixtyDays"].ToString() : string.Empty;
                account.NintyDays = !String.IsNullOrEmpty(row["NintyDays"].ToString()) ? row["NintyDays"].ToString() : string.Empty;
                account.NintyPlusDays = !String.IsNullOrEmpty(row["NintyPlusDays"].ToString()) ? row["NintyPlusDays"].ToString() : string.Empty;
                account.Comment = !String.IsNullOrEmpty(row["Comment"].ToString()) ? row["Comment"].ToString() : string.Empty;
                account.Action  = !String.IsNullOrEmpty(row["Action"].ToString()) ? row["Action"].ToString() : string.Empty;
                accounts.Add(account);
            }
            return accounts;
        }

        public void UpdateAccounts(List<Accounts> accounts)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<Accounts>(accounts);
                using (SqlCommand cmd = new SqlCommand("updatemonthlyaccounts", con))
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