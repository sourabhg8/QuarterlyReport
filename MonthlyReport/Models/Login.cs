using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
        public bool Isvalid { get; set; }
        public string validationMessage { get; set; }
        public bool redirectToLogin { get; set; }
        public string roleName { get; set; }
        public int roleid { get; set; }

    }
}