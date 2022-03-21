using OnlineFleetIO.ContactModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFleetIO.VehicleAssignment
{
    public class ResponseFleetioVehicleAssignment
    {
        public int id { get; set; }
        public int vehicle_id { get; set; }
        public int contact_id { get; set; }
        public DateTime? started_at { get; set; }
        public DateTime? ended_at { get; set; }
        public string starting_meter_entry_value { get; set; }
        public string ending_meter_entry_value { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int comments_count { get; set; }
        public bool current { get; set; }
        public bool future { get; set; }
        public string contact_full_name { get; set; }
        public string contact_image_url { get; set; }
        public CustomFields custom_fields { get; set; }
        public AttachmentPermissions attachment_permissions { get; set; }
        public List<object> comments { get; set; }
    }
}
