using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFleetIO.ContactModel
{
    public class RequestFleetioContactModel
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public int group_id { get; set; }
        public bool? vehicle_operator { get; set; }
        public string license_number { get; set; }
        public string street_address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string mobile_phone_number { get; set; }
        public string home_phone_number { get; set; }
    }
}
