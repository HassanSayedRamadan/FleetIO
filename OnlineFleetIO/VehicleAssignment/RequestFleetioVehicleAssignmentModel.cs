using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFleetIO.VehicleAssignment
{
    public class RequestFleetioVehicleAssignmentModel
    {
        public int vehicle_id { get; set; }
        public int contact_id { get; set; }
        public DateTime? started_at { get; set; }
        public DateTime? ended_at { get; set; }
        public starting_meter_entry_attributes starting_meter_entry_attributes { get; set; }
        public ending_meter_entry_attributes ending_meter_entry_attributes { get; set; }
    }
}
