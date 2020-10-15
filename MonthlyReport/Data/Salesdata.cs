using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MonthlyReport.Models;

namespace MonthlyReport.Data
{
    public class Salesdata
    {
        public List<SquareSales> GetSquareSalesdata()
        {
            List<SquareSales> lst = new List<SquareSales>();
            DataSet data = DBConnection.GetData("GetSquaresales");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                SquareSales Obj = new SquareSales();
                Obj.squareid = new Guid(row["squareid"].ToString());
                Obj.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                Obj.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                Obj.Psf1 = !String.IsNullOrEmpty(row["Psf1"].ToString()) ? row["Psf1"].ToString() : string.Empty;
                Obj.LY1 = !String.IsNullOrEmpty(row["LY1"].ToString()) ? row["LY1"].ToString() : string.Empty;
                Obj.sales1 = !String.IsNullOrEmpty(row["sales1"].ToString()) ? row["sales1"].ToString() : string.Empty;
                Obj.Sales2 = !String.IsNullOrEmpty(row["Sales2"].ToString()) ? row["Sales2"].ToString() : string.Empty;
                Obj.PSF2 = !String.IsNullOrEmpty(row["PSF2"].ToString()) ? row["PSF2"].ToString() : string.Empty;
                Obj.PSF3 = !String.IsNullOrEmpty(row["PSF3"].ToString()) ? row["PSF3"].ToString() : string.Empty;
                Obj.LY2 = !String.IsNullOrEmpty(row["LY2"].ToString()) ? row["LY2"].ToString() : string.Empty;
                Obj.LY3 = !String.IsNullOrEmpty(row["LY3"].ToString()) ? row["LY3"].ToString() : string.Empty;
                Obj.Sales3 = !String.IsNullOrEmpty(row["Sales3"].ToString()) ? row["Sales3"].ToString() : string.Empty;
                Obj.GrossRent = !String.IsNullOrEmpty(row["GrossRent"].ToString()) ? row["GrossRent"].ToString() : string.Empty;
                Obj.Groc = !String.IsNullOrEmpty(row["Groc"].ToString()) ? row["Groc"].ToString() : string.Empty;
                Obj.PctRent = !String.IsNullOrEmpty(row["PctRent"].ToString()) ? row["PctRent"].ToString() : string.Empty;
                lst.Add(Obj);
            }
            return lst;
        }



        public List<SquareSales> GetLifeStyledata()
        {
            List<SquareSales> lst = new List<SquareSales>();
            DataSet data = DBConnection.GetData("GetLifestyle");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                SquareSales Obj = new SquareSales();
                Obj.squareid = new Guid(row["squareid"].ToString());
                Obj.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                Obj.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                Obj.Psf1 = !String.IsNullOrEmpty(row["Psf1"].ToString()) ? row["Psf1"].ToString() : string.Empty;
                Obj.LY1 = !String.IsNullOrEmpty(row["LY1"].ToString()) ? row["LY1"].ToString() : string.Empty;
                Obj.sales1 = !String.IsNullOrEmpty(row["sales1"].ToString()) ? row["sales1"].ToString() : string.Empty;
                Obj.Sales2 = !String.IsNullOrEmpty(row["Sales2"].ToString()) ? row["Sales2"].ToString() : string.Empty;
                Obj.PSF2 = !String.IsNullOrEmpty(row["PSF2"].ToString()) ? row["PSF2"].ToString() : string.Empty;
                Obj.PSF3 = !String.IsNullOrEmpty(row["PSF3"].ToString()) ? row["PSF3"].ToString() : string.Empty;
                Obj.LY2 = !String.IsNullOrEmpty(row["LY2"].ToString()) ? row["LY2"].ToString() : string.Empty;
                Obj.LY3 = !String.IsNullOrEmpty(row["LY3"].ToString()) ? row["LY3"].ToString() : string.Empty;
                Obj.Sales3 = !String.IsNullOrEmpty(row["Sales3"].ToString()) ? row["Sales3"].ToString() : string.Empty;
                Obj.GrossRent = !String.IsNullOrEmpty(row["GrossRent"].ToString()) ? row["GrossRent"].ToString() : string.Empty;
                Obj.Groc = !String.IsNullOrEmpty(row["Groc"].ToString()) ? row["Groc"].ToString() : string.Empty;
                Obj.PctRent = !String.IsNullOrEmpty(row["PctRent"].ToString()) ? row["PctRent"].ToString() : string.Empty;
                lst.Add(Obj);
            }
            return lst;
        }

        public List<SalesComments> GetSalesComments()
        {
            List<SalesComments> lst = new List<SalesComments>();
            DataSet data = DBConnection.GetData("getSalesComments");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                SalesComments Obj = new SalesComments();
                Obj.commentid = Convert.ToInt32(row["commentid"].ToString());
                Obj.sector = !String.IsNullOrEmpty(row["sector"].ToString()) ? row["sector"].ToString() : string.Empty;
                Obj.comment = !String.IsNullOrEmpty(row["comments"].ToString()) ? row["comments"].ToString() : string.Empty;
                lst.Add(Obj);
            }
            return lst;
        }
        public void UpdateSquareSales(List<SquareSales> obj ,string comment)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<SquareSales>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateSquareSales", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatable);
                    cmd.Parameters.AddWithValue("@comment", comment);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void UpdateLifeStyleSales(List<SquareSales> obj, string comment)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<SquareSales>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateLifeStyleSales", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatable);
                    cmd.Parameters.AddWithValue("@comment", comment);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
       public void UpdateCommentSales(SalesComments obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {               
                using (SqlCommand cmd = new SqlCommand("UpdatesalesComment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@commentid", obj.commentid);
                    cmd.Parameters.AddWithValue("@comments", obj.comment);
                    cmd.Parameters.AddWithValue("@sector", obj.sector);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}