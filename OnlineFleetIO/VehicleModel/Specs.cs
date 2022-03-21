using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFleetIO.VehicleModel
{
    public class Specs
    {
        public int id { get; set; }
        public int vehicle_id { get; set; }
        public int account_id { get; set; }
        public string body_type { get; set; }
        public string body_subtype { get; set; }
        public string drive_type { get; set; }
        public string brake_system { get; set; }
        public int? msrp_cents { get; set; }
        public double? fuel_tank_capacity { get; set; }
        public object fuel_tank_2_capacity { get; set; }
        public double? front_track_width { get; set; }
        public double? ground_clearance { get; set; }
        public double? height { get; set; }
        public double? length { get; set; }
        public double? rear_track_width { get; set; }
        public double? width { get; set; }
        public double? wheelbase { get; set; }
        public object front_tire_psi { get; set; }
        public object rear_tire_psi { get; set; }
        public double? base_towing_capacity { get; set; }
        public double? curb_weight { get; set; }
        public double? gross_vehicle_weight_rating { get; set; }
        public double? bed_length { get; set; }
        public double? max_payload { get; set; }
        public string rear_axle_type { get; set; }
        public string front_tire_type { get; set; }
        public string front_wheel_diameter { get; set; }
        public string rear_tire_type { get; set; }
        public string rear_wheel_diameter { get; set; }
        public double? epa_city { get; set; }
        public double? epa_highway { get; set; }
        public double? epa_combined { get; set; }
        public string engine_description { get; set; }
        public string engine_brand { get; set; }
        public string engine_aspiration { get; set; }
        public string engine_block_type { get; set; }
        public double? engine_bore { get; set; }
        public string engine_cam_type { get; set; }
        public double? engine_compression { get; set; }
        public int? engine_cylinders { get; set; }
        public double? engine_displacement { get; set; }
        public string fuel_induction { get; set; }
        public string fuel_quality { get; set; }
        public int? max_hp { get; set; }
        public int? max_torque { get; set; }
        public double? oil_capacity { get; set; }
        public string redline_rpm { get; set; }
        public double? engine_stroke { get; set; }
        public int? engine_valves { get; set; }
        public string transmission_description { get; set; }
        public string transmission_brand { get; set; }
        public string transmission_type { get; set; }
        public int? transmission_gears { get; set; }
        public double? cargo_volume { get; set; }
        public double? interior_volume { get; set; }
        public string passenger_volume { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string duty_type { get; set; }
        public object weight_class { get; set; }
        public string engine_bore_with_units { get; set; }
        public string wheelbase_with_units { get; set; }
        public double? msrp { get; set; }
    }

}
