using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFleetIO.VehicleModel
{
    public class RequestFleetIOVehicleModel
    {
        public string fuel_volume_units { get; set; }
        public string meter_unit { get; set; }
        public string name { get; set; }
        public string ownership { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string color { get; set; }
        public string license_plate { get; set; }
        public int group_id { get; set; }
        public string vin { get; set; }
        public string system_of_measurement { get; set; }
        public int vehicle_status_id { get; set; }
        public int vehicle_type_id { get; set; }
        public List<object> linked_vehicle_ids { get; set; }
        public purchase_detail_attributes purchase_detail_attributes { get; set; }
    }
}
