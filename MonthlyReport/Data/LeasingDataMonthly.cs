using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonthlyReport.Models;
using System.Data;
using System.Data.SqlClient;

namespace MonthlyReport.Data
{
    public class LeasingDataMonthly
    {
        public List<NewTenantOpening> GetNewTenantOpeningData()
        {
            List<NewTenantOpening> openings = new List<NewTenantOpening>();
            DataSet data = DBConnection.GetData("getNewTenantOpeningsMonthly");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                NewTenantOpening opening = new NewTenantOpening();
                opening.OpeningId = new Guid(row["OpeningId"].ToString()); 
                opening.Months = !String.IsNullOrEmpty(row["Months"].ToString()) ? row["Months"].ToString() : string.Empty;
                opening.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                opening.Sector = !String.IsNullOrEmpty(row["Sector"].ToString()) ? row["Sector"].ToString() : string.Empty;
                opening.UnitNo = !String.IsNullOrEmpty(row["UnitNo"].ToString()) ? row["UnitNo"].ToString() : string.Empty;
                opening.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                opening.NetRent = !String.IsNullOrEmpty(row["NetRent"].ToString()) ? row["NetRent"].ToString() : string.Empty;
                opening.Ner = !String.IsNullOrEmpty(row["Ner"].ToString()) ? row["Ner"].ToString() : string.Empty;
                opening.TA = !String.IsNullOrEmpty(row["TA"].ToString()) ? row["TA"].ToString() : string.Empty;
                opening.Llw = !String.IsNullOrEmpty(row["Llw"].ToString()) ? row["Llw"].ToString() : string.Empty;
                opening.Commision = !String.IsNullOrEmpty(row["Commision"].ToString()) ? row["Commision"].ToString() : string.Empty;
                openings.Add(opening);
            }
            return openings;
        }
        public void UpdateNewTenantOpening(List<NewTenantOpening> obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatableNewTenant = DBConnection.ToDataTable<NewTenantOpening>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateNewTenantOpeningMonthly", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatableNewTenant);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DeliveredSpaces> GetDelieverdSpaces()
        {
            List<DeliveredSpaces> deliveredSpaces = new List<DeliveredSpaces>();
            DataSet data = DBConnection.GetData("GETDeliveredSpacesMonthly");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                DeliveredSpaces deliveredSpace = new DeliveredSpaces();
                deliveredSpace.OpeningId = new Guid(row["OpeningId"].ToString());
                deliveredSpace.Months = !String.IsNullOrEmpty(row["Months"].ToString()) ? row["Months"].ToString() : string.Empty;
                deliveredSpace.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                deliveredSpace.Sector = !String.IsNullOrEmpty(row["Sector"].ToString()) ? row["Sector"].ToString() : string.Empty;
                deliveredSpace.UnitNo = !String.IsNullOrEmpty(row["UnitNo"].ToString()) ? row["UnitNo"].ToString() : string.Empty;
                deliveredSpace.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                deliveredSpace.DeliveryDate = !String.IsNullOrEmpty(row["DeliveryDate"].ToString()) ? row["DeliveryDate"].ToString() : string.Empty;
                deliveredSpace.FixturingPeriod = !String.IsNullOrEmpty(row["FixturingPeriod"].ToString()) ? row["FixturingPeriod"].ToString() : string.Empty;
                deliveredSpace.ExpectedOpening = !String.IsNullOrEmpty(row["ExpectedOpening"].ToString()) ? row["ExpectedOpening"].ToString() : string.Empty;
                deliveredSpace.Ner = !String.IsNullOrEmpty(row["Ner"].ToString()) ? row["Ner"].ToString() : string.Empty;
                deliveredSpace.TA = !String.IsNullOrEmpty(row["TA"].ToString()) ? row["TA"].ToString() : string.Empty;
                deliveredSpace.Llw = !String.IsNullOrEmpty(row["Llw"].ToString()) ? row["Llw"].ToString() : string.Empty;
                deliveredSpace.Commision = !String.IsNullOrEmpty(row["Commision"].ToString()) ? row["Commision"].ToString() : string.Empty;
                deliveredSpaces.Add(deliveredSpace);
            }
            return deliveredSpaces;
        }

        public void UpdateDeliveredSpaces(List<DeliveredSpaces> obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatableNewTenant = DBConnection.ToDataTable<DeliveredSpaces>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateDeliveredSpacesMonthly", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatableNewTenant);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<KeyDeals> GetKeyDeals()
        {
            List<KeyDeals> keyDeals = new List<KeyDeals>();
            DataSet data = DBConnection.GetData("GetKeyDealsMonthly");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                KeyDeals keyDeal = new KeyDeals();
                keyDeal.OpeningId = new Guid(row["OpeningId"].ToString());
                keyDeal.Months = !String.IsNullOrEmpty(row["Months"].ToString()) ? row["Months"].ToString() : string.Empty;
                keyDeal.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                keyDeal.Sector = !String.IsNullOrEmpty(row["Sector"].ToString()) ? row["Sector"].ToString() : string.Empty;
                keyDeal.UnitNo = !String.IsNullOrEmpty(row["UnitNo"].ToString()) ? row["UnitNo"].ToString() : string.Empty;
                keyDeal.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                keyDeal.Term = !String.IsNullOrEmpty(row["Term"].ToString()) ? row["Term"].ToString() : string.Empty;
                keyDeal.NetBudget = !String.IsNullOrEmpty(row["NetBudget"].ToString()) ? row["NetBudget"].ToString() : string.Empty;
                keyDeal.NetRentActual = !String.IsNullOrEmpty(row["NetRentActual"].ToString()) ? row["NetRentActual"].ToString() : string.Empty;
                keyDeal.Ner = !String.IsNullOrEmpty(row["Ner"].ToString()) ? row["Ner"].ToString() : string.Empty;
                keyDeal.TA = !String.IsNullOrEmpty(row["TA"].ToString()) ? row["TA"].ToString() : string.Empty;
                keyDeal.Llw = !String.IsNullOrEmpty(row["Llw"].ToString()) ? row["Llw"].ToString() : string.Empty;
                keyDeal.Commision = !String.IsNullOrEmpty(row["Commision"].ToString()) ? row["Commision"].ToString() : string.Empty;
                keyDeals.Add(keyDeal);
            }
            return keyDeals;
        }

        public void UpdateKeyDeals(List<KeyDeals> obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatableKeyDeals = DBConnection.ToDataTable<KeyDeals>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateKeyDealsMonthly", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatableKeyDeals);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<CompletedRenewals> GetCompletedRenewals()
        {
            List<CompletedRenewals> completedRenewals = new List<CompletedRenewals>();
            DataSet data = DBConnection.GetData("GetCompletedRenewalsMonthly");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                CompletedRenewals completedRenewal = new CompletedRenewals();
                completedRenewal.OpeningId = new Guid(row["OpeningId"].ToString());
                completedRenewal.Months = !String.IsNullOrEmpty(row["Months"].ToString()) ? row["Months"].ToString() : string.Empty;
                completedRenewal.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                completedRenewal.Sector = !String.IsNullOrEmpty(row["Sector"].ToString()) ? row["Sector"].ToString() : string.Empty;
                completedRenewal.UnitNo = !String.IsNullOrEmpty(row["UnitNo"].ToString()) ? row["UnitNo"].ToString() : string.Empty;
                completedRenewal.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                completedRenewal.Term = !String.IsNullOrEmpty(row["Term"].ToString()) ? row["Term"].ToString() : string.Empty;
                completedRenewal.NetBudget = !String.IsNullOrEmpty(row["NetBudget"].ToString()) ? row["NetBudget"].ToString() : string.Empty;
                completedRenewal.NetRentActual = !String.IsNullOrEmpty(row["NetRentActual"].ToString()) ? row["NetRentActual"].ToString() : string.Empty;
                completedRenewal.Ner = !String.IsNullOrEmpty(row["Ner"].ToString()) ? row["Ner"].ToString() : string.Empty;
                completedRenewal.TA = !String.IsNullOrEmpty(row["TA"].ToString()) ? row["TA"].ToString() : string.Empty;
                completedRenewal.Llw = !String.IsNullOrEmpty(row["Llw"].ToString()) ? row["Llw"].ToString() : string.Empty;
                completedRenewal.Commision = !String.IsNullOrEmpty(row["Commision"].ToString()) ? row["Commision"].ToString() : string.Empty;
                completedRenewals.Add(completedRenewal);
            }
            return completedRenewals;

        }

        public void UpdateCompletedRenewals(List<CompletedRenewals> obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatableCompletedRenewals = DBConnection.ToDataTable<CompletedRenewals>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateCompletedRenewalsMonthly", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatableCompletedRenewals);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<HotDeals> GetHotDeals()
        {
            List<HotDeals> hotDeals = new List<HotDeals>();
            DataSet data = DBConnection.GetData("GetHotDealsMonthly");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                HotDeals hotDeal = new HotDeals();
                hotDeal.OpeningId = new Guid(row["OpeningId"].ToString());
                hotDeal.Months = !String.IsNullOrEmpty(row["Months"].ToString()) ? row["Months"].ToString() : string.Empty;
                hotDeal.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                hotDeal.Sector = !String.IsNullOrEmpty(row["Sector"].ToString()) ? row["Sector"].ToString() : string.Empty;
                hotDeal.UnitNo = !String.IsNullOrEmpty(row["UnitNo"].ToString()) ? row["UnitNo"].ToString() : string.Empty;
                hotDeal.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                hotDeal.Term = !String.IsNullOrEmpty(row["Term"].ToString()) ? row["Term"].ToString() : string.Empty;
                hotDeal.LoiSigned = !String.IsNullOrEmpty(row["LoiSigned"].ToString()) ? row["LoiSigned"].ToString() : string.Empty;
                hotDeal.BudgetRate = !String.IsNullOrEmpty(row["BudgetRate"].ToString()) ? row["BudgetRate"].ToString() : string.Empty;
                hotDeal.ProposedRate = !String.IsNullOrEmpty(row["ProposedRate"].ToString()) ? row["ProposedRate"].ToString() : string.Empty;
                hotDeal.Ner = !String.IsNullOrEmpty(row["Ner"].ToString()) ? row["Ner"].ToString() : string.Empty;
                hotDeal.TA = !String.IsNullOrEmpty(row["TA"].ToString()) ? row["TA"].ToString() : string.Empty;
                hotDeal.Llw = !String.IsNullOrEmpty(row["Llw"].ToString()) ? row["Llw"].ToString() : string.Empty;
                hotDeal.Commision = !String.IsNullOrEmpty(row["Commision"].ToString()) ? row["Commision"].ToString() : string.Empty;
                hotDeal.Comments = !String.IsNullOrEmpty(row["comments"].ToString()) ? row["comments"].ToString() : string.Empty;
                hotDeals.Add(hotDeal);
            }
            return hotDeals;

        }

        public void UpdateHotDeals(List<HotDeals> obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatableHotDeals = DBConnection.ToDataTable<HotDeals>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateHotDealsMonthly", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatableHotDeals);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<TenantsAtRisk> GetTenantAtRisk()
        {
            List<TenantsAtRisk> tenantsAtRisks = new List<TenantsAtRisk>();
            DataSet data = DBConnection.GetData("GetTenantAtRiskMonthly");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                TenantsAtRisk tenant = new TenantsAtRisk();
                tenant.OpeningId = new Guid(row["OpeningId"].ToString());
                tenant.Groc = !String.IsNullOrEmpty(row["Groc"].ToString()) ? row["Groc"].ToString() : string.Empty;
                tenant.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                tenant.Sales = !String.IsNullOrEmpty(row["Sales"].ToString()) ? row["Sales"].ToString() : string.Empty;
                tenant.UnitNo = !String.IsNullOrEmpty(row["UnitNo"].ToString()) ? row["UnitNo"].ToString() : string.Empty;
                tenant.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                tenant.RollingSales = !String.IsNullOrEmpty(row["RollingSales"].ToString()) ? row["RollingSales"].ToString() : string.Empty;
                tenant.ArYtd = !String.IsNullOrEmpty(row["ArYtd"].ToString()) ? row["ArYtd"].ToString() : string.Empty;
                tenant.Comments = !String.IsNullOrEmpty(row["Comments"].ToString()) ? row["Comments"].ToString() : string.Empty;

                tenantsAtRisks.Add(tenant);
            }
            return tenantsAtRisks;

        }

        public void UpdateTenantsAtrisk(List<TenantsAtRisk> obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<TenantsAtRisk>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateTenantAtRiskMonthly", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@data", datatable);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TenantClosure> GetTenantClosure()
        {
            List<TenantClosure> tenantClosures = new List<TenantClosure>();
            DataSet data = DBConnection.GetData("GetTenantClosureMonthly");
            foreach (DataRow row in data.Tables[0].Rows)
            {
                TenantClosure tenant = new TenantClosure();
                tenant.OpeningId = new Guid(row["OpeningId"].ToString());
                tenant.Sector = !String.IsNullOrEmpty(row["Sector"].ToString()) ? row["Sector"].ToString() : string.Empty;
                tenant.Tenant = !String.IsNullOrEmpty(row["Tenant"].ToString()) ? row["Tenant"].ToString() : string.Empty;
                tenant.DateOfClosure = !String.IsNullOrEmpty(row["DateOfClosure"].ToString()) ? row["DateOfClosure"].ToString() : string.Empty;
                tenant.ReasonOfClosure = !String.IsNullOrEmpty(row["ReasonOfClosure"].ToString()) ? row["ReasonOfClosure"].ToString() : string.Empty;
                tenant.Ar = !String.IsNullOrEmpty(row["Ar"].ToString()) ? row["Ar"].ToString() : string.Empty;
                tenant.Occupancy = !String.IsNullOrEmpty(row["Occupancy"].ToString()) ? row["Occupancy"].ToString() : string.Empty;
                tenant.CoTenancyRisk = !String.IsNullOrEmpty(row["CoTenancyRisk"].ToString()) ? row["CoTenancyRisk"].ToString() : string.Empty;
                tenant.TI = !String.IsNullOrEmpty(row["TI"].ToString()) ? row["TI"].ToString() : string.Empty;
                tenant.LLW = !String.IsNullOrEmpty(row["LLW"].ToString()) ? row["LLW"].ToString() : string.Empty;
                tenant.Gla = !String.IsNullOrEmpty(row["Gla"].ToString()) ? row["Gla"].ToString() : string.Empty;
                tenant.Comments = !String.IsNullOrEmpty(row["Comments"].ToString()) ? row["Comments"].ToString() : string.Empty;

                tenantClosures.Add(tenant);
            }
            return tenantClosures;

        }

        public void UpdateTenantClosure(List<TenantClosure> obj)
        {
            using (SqlConnection con = new SqlConnection(DBConnection.GetConnectionString()))
            {
                var datatable = DBConnection.ToDataTable<TenantClosure>(obj);
                using (SqlCommand cmd = new SqlCommand("UpdateTenantClosureMonthly", con))
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