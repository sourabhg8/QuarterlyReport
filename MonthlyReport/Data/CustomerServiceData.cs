using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MonthlyReport.Models;

namespace MonthlyReport.Data
{
    public class CustomerServiceData
    {
        public List<SocialMedia> GetSocialMediaData()
        {
            List<SocialMedia> lst = new List<SocialMedia>();
            DataSet data = DBConnection.GetData("GetSocialMedia");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                SocialMedia obj = new SocialMedia();
                obj.Year2 = !String.IsNullOrEmpty(row["Year2"].ToString()) ? row["Year2"].ToString() : string.Empty;
                obj.Month1 = !String.IsNullOrEmpty(row["Month1"].ToString()) ? row["Month1"].ToString() : string.Empty;
                obj.Month2 = !String.IsNullOrEmpty(row["Month2"].ToString()) ? row["Month2"].ToString() : string.Empty;
                obj.Change1 = !String.IsNullOrEmpty(row["Change1"].ToString()) ? row["Change1"].ToString() : string.Empty;
                obj.Change2 = !String.IsNullOrEmpty(row["Change2"].ToString()) ? row["Change2"].ToString() : string.Empty;
                lst.Add(obj);
            }
            return lst;
        }


        public List<Interactive> GetInteractiveData()
        {
            List<Interactive> lst = new List<Interactive>();
            DataSet data = DBConnection.GetData("getinteractive");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                Interactive obj = new Interactive();
                obj.Year2 = !String.IsNullOrEmpty(row["Year2"].ToString()) ? row["Year2"].ToString() : string.Empty;
                obj.Month1 = !String.IsNullOrEmpty(row["Month1"].ToString()) ? row["Month1"].ToString() : string.Empty;
                obj.Month2 = !String.IsNullOrEmpty(row["Month2"].ToString()) ? row["Month2"].ToString() : string.Empty;
                obj.Change1 = !String.IsNullOrEmpty(row["Change1"].ToString()) ? row["Change1"].ToString() : string.Empty;
                obj.Change2 = !String.IsNullOrEmpty(row["Change2"].ToString()) ? row["Change2"].ToString() : string.Empty;
                obj.Year1 = !String.IsNullOrEmpty(row["Year1"].ToString()) ? row["Year1"].ToString() : string.Empty;
                lst.Add(obj);
            }
            return lst;
        }

        public List<GiftCard> GetGiftCardData()
        {
            List<GiftCard> lst = new List<GiftCard>();
            DataSet data = DBConnection.GetData("getgiftCard");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                GiftCard obj = new GiftCard();
                obj.Year2 = !String.IsNullOrEmpty(row["Year2"].ToString()) ? row["Year2"].ToString() : string.Empty;
                obj.Month1 = !String.IsNullOrEmpty(row["Month1"].ToString()) ? row["Month1"].ToString() : string.Empty;
                obj.Month2 = !String.IsNullOrEmpty(row["Month2"].ToString()) ? row["Month2"].ToString() : string.Empty;
                obj.Change1 = !String.IsNullOrEmpty(row["Change1"].ToString()) ? row["Change1"].ToString() : string.Empty;
                obj.Change2 = !String.IsNullOrEmpty(row["Change2"].ToString()) ? row["Change2"].ToString() : string.Empty;
                obj.Year1 = !String.IsNullOrEmpty(row["Year1"].ToString()) ? row["Year1"].ToString() : string.Empty;
                lst.Add(obj);
            }
            return lst;
        }

        public List<Header> GetHeaderData()
        {
            List<Header> lst = new List<Header>();
            DataSet data = DBConnection.GetData("getheader");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                Header obj = new Header();
                obj.Year2 = !String.IsNullOrEmpty(row["Year2"].ToString()) ? row["Year2"].ToString() : string.Empty;
                obj.Month1 = !String.IsNullOrEmpty(row["Month1"].ToString()) ? row["Month1"].ToString() : string.Empty;
                obj.Month2 = !String.IsNullOrEmpty(row["Month2"].ToString()) ? row["Month2"].ToString() : string.Empty;
                obj.Year3 = !String.IsNullOrEmpty(row["Year3"].ToString()) ? row["Year3"].ToString() : string.Empty;
                obj.Year4 = !String.IsNullOrEmpty(row["Year4"].ToString()) ? row["Year4"].ToString() : string.Empty;
                obj.Year1 = !String.IsNullOrEmpty(row["Year1"].ToString()) ? row["Year1"].ToString() : string.Empty;
                lst.Add(obj);
            }
            return lst;
        }

        public CustomerService GetCustomerServiceData()
        {
            CustomerService customerService = new CustomerService();
            customerService.SocialMedias = GetSocialMediaData();
            customerService.Interactives = GetInteractiveData();
            customerService.Headers = GetHeaderData();
            customerService.GiftCards = GetGiftCardData();
            return customerService;
        }

        public void UpdateInteractiveData(List<Interactive> obj, Header header)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<Interactive>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateInteractive", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatable);
                    cmd.Parameters.AddWithValue("@Month1", header.Month1);
                    cmd.Parameters.AddWithValue("@Month2", header.Month2);
                    cmd.Parameters.AddWithValue("@Year1", header.Year1);
                    cmd.Parameters.AddWithValue("@Year2", header.Year2);
                    cmd.Parameters.AddWithValue("@Year3", header.Year3);
                    cmd.Parameters.AddWithValue("@Year4", header.Year4);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void UpdateGiftCardData(List<GiftCard> obj, Header header)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<GiftCard>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateGiftCards", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatable);
                    cmd.Parameters.AddWithValue("@Month1", header.Month1);
                    cmd.Parameters.AddWithValue("@Month2", header.Month2);
                    cmd.Parameters.AddWithValue("@Year1", header.Year1);
                    cmd.Parameters.AddWithValue("@Year2", header.Year2);
                    cmd.Parameters.AddWithValue("@Year3", header.Year3);
                    cmd.Parameters.AddWithValue("@Year4", header.Year4);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSocialMediaData(List<SocialMedia> obj, Header header)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<SocialMedia>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateSocialMedia", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatable);
                    cmd.Parameters.AddWithValue("@Month1", header.Month1);
                    cmd.Parameters.AddWithValue("@Month2", header.Month2);
                    cmd.Parameters.AddWithValue("@Year1", header.Year1);
                    cmd.Parameters.AddWithValue("@Year2", header.Year2);
                    cmd.Parameters.AddWithValue("@Year3", header.Year3);
                    cmd.Parameters.AddWithValue("@Year4", header.Year4);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}