using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonthlyReport.Models
{
    public class CustomerService
    {
        public List<Interactive> Interactives { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
        public List<GiftCard>  GiftCards { get; set; }
        public List<Header> Headers { get; set; }
    }
}