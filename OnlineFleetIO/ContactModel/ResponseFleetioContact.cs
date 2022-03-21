using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFleetIO.ContactModel
{
    public class ResponseFleetioContact
    {
        public int id { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public int group_id { get; set; }
        public string group_name { get; set; }
        public string last_name { get; set; }
        public int images_count { get; set; }
        public int documents_count { get; set; }
        public int comments_count { get; set; }
        public string email { get; set; }
        public object birth_date { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public bool employee { get; set; }
        public object employee_number { get; set; }
        public string home_phone_number { get; set; }
        public string job_title { get; set; }
        public object leave_date { get; set; }
        public string license_class { get; set; }
        public string license_number { get; set; }
        public string license_state { get; set; }
        public string mobile_phone_number { get; set; }
        public string other_phone_number { get; set; }
        public string postal_code { get; set; }
        public string region { get; set; }
        public object start_date { get; set; }
        public string street_address { get; set; }
        public string street_address_line_2 { get; set; }
        public bool technician { get; set; }
        public bool vehicle_operator { get; set; }
        public string work_phone_number { get; set; }
        public double? hourly_labor_rate { get; set; }
        public CustomFields custom_fields { get; set; }
        public AttachmentPermissions attachment_permissions { get; set; }
        public string default_image_url { get; set; }
        public User user { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
