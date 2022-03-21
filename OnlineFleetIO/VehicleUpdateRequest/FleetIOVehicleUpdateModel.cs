using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFleetIO.VehicleUpdateRequest
{
    public class FleetIOVehicleUpdateModel
    {
        public int group_id { get; set; }
        public string license_plate { get; set; }
        public custom_fields custom_fields { get; set; }
    }
}
