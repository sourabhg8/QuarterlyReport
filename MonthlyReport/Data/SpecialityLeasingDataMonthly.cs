using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonthlyReport.Models;
using System.Data;
using System.Data.SqlClient;

namespace MonthlyReport.Data
{
    public class SpecialityLeasingDataMonthly
    {
        public SpecialityLeasingModel GetSpecialityLeasingData()
        {
            SpecialityLeasingModel specialityLeasingModel = new SpecialityLeasingModel();
            List<SpecialityLeasing> specialityLeasings = new List<SpecialityLeasing>();
            List<SpecialProject> specialProjects = new List<SpecialProject>();
            DataSet data = DBConnection.GetData("GetMonthlySpecialityLeasing");
            foreach(DataRow row in data.Tables[0].Rows)
            {
                SpecialityLeasing obj = new SpecialityLeasing();
                obj.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                obj.SpecialityLeasingId = new Guid(row["SpecialityLeasingId"].ToString()); 
                obj.Sector = !String.IsNullOrEmpty(row["Sector"].ToString()) ? row["Sector"].ToString() : string.Empty;
                obj.UnitNo = !String.IsNullOrEmpty(row["UnitNo"].ToString()) ? row["UnitNo"].ToString() : string.Empty;
                obj.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                obj.Term = !String.IsNullOrEmpty(row["Term"].ToString()) ? row["Term"].ToString() : string.Empty;
                obj.GrossRentBudget = !String.IsNullOrEmpty(row["GrossRentBudget"].ToString()) ? row["GrossRentBudget"].ToString() : string.Empty;
                obj.GrossRentActual = !String.IsNullOrEmpty(row["GrossRentActual"].ToString()) ? row["GrossRentActual"].ToString() : string.Empty;
                obj.SalesPercentage = !String.IsNullOrEmpty(row["SalesPercentage"].ToString()) ? row["SalesPercentage"].ToString() : string.Empty;
                obj.Comments = !String.IsNullOrEmpty(row["Comments"].ToString()) ? row["Comments"].ToString() : string.Empty;
                specialityLeasings.Add(obj);
            }
            foreach(DataRow row in  data.Tables[1].Rows)
            {
                SpecialProject obj = new SpecialProject();
                obj.ProjectId = new Guid(row["ProjectId"].ToString());
                obj.Title = !String.IsNullOrEmpty(row["Title"].ToString()) ? row["Title"].ToString() : string.Empty;
                obj.Content = !String.IsNullOrEmpty(row["Content"].ToString()) ? row["Content"].ToString() : string.Empty;
                specialProjects.Add(obj);
            }
            specialityLeasingModel.specialityLeasings = specialityLeasings;
            specialityLeasingModel.specialProjects = specialProjects;
            return specialityLeasingModel;
        }

        public void UpdateSpeciality(SpecialityLeasingModel obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatableLeasing = DBConnection.ToDataTable<SpecialityLeasing>(obj.specialityLeasings);
                var datatableProject = DBConnection.ToDataTable<SpecialProject>(obj.specialProjects);
                using (SqlCommand cmd = new SqlCommand("UpdateMonthlySpeciality", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LeasingData", datatableLeasing);
                    cmd.Parameters.AddWithValue("@ProjectData", datatableProject);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}