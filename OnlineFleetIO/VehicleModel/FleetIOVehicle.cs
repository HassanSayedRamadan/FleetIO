using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFleetIO.VehicleModel
{
    public class FleetIOVehicle
    {
        public int id { get; set; }
        public int account_id { get; set; }
        public object archived_at { get; set; }
        public int? fuel_type_id { get; set; }
        public string fuel_type_name { get; set; }
        public string fuel_volume_units { get; set; }
        public int group_id { get; set; }
        public string group_name { get; set; }
        public string meter_unit { get; set; }
        public string name { get; set; }
        public string ownership { get; set; }
        public bool secondary_meter { get; set; }
        public object secondary_meter_unit { get; set; }
        public string system_of_measurement { get; set; }
        public int vehicle_status_id { get; set; }
        public string vehicle_status_name { get; set; }
        public string vehicle_status_color { get; set; }
        public int vehicle_type_id { get; set; }
        public string vehicle_type_name { get; set; }
        public int fuel_entries_count { get; set; }
        public int service_entries_count { get; set; }
        public int service_reminders_count { get; set; }
        public int vehicle_renewal_reminders_count { get; set; }
        public int comments_count { get; set; }
        public int documents_count { get; set; }
        public int images_count { get; set; }
        public int? current_location_entry_id { get; set; }
        public bool is_sample { get; set; }
        public object in_service_date { get; set; }
        public object in_service_meter { get; set; }
        public object estimated_service_months { get; set; }
        public object estimated_replacement_mileage { get; set; }
        public object estimated_resale_price { get; set; }
        public object out_of_service_date { get; set; }
        public object out_of_service_meter { get; set; }
        public string meter_name { get; set; }
        public string secondary_meter_name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public double current_meter_value { get; set; }
        public string current_meter_date { get; set; }
        public double secondary_meter_value { get; set; }
        public object secondary_meter_date { get; set; }
        public string group_ancestry { get; set; }
        public string color { get; set; }
        public string license_plate { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int registration_expiration_month { get; set; }
        public string registration_state { get; set; }
        public string trim { get; set; }
        public string vin { get; set; }
        public int? year { get; set; }
        public object loan_account_number { get; set; }
        public object loan_ended_at { get; set; }
        public object loan_interest_rate { get; set; }
        public object loan_notes { get; set; }
        public object loan_started_at { get; set; }
        public object loan_vendor_id { get; set; }
        public object loan_vendor_name { get; set; }
        public CustomFields custom_fields { get; set; }
        public int inspection_schedules_count { get; set; }
        public int issues_count { get; set; }
        public int work_orders_count { get; set; }
        public string type_name { get; set; }
        public object default_image_url { get; set; }
        public object default_image_url_medium { get; set; }
        public object default_image_url_small { get; set; }
        public object default_image_url_large { get; set; }
        public Driver driver { get; set; }
        public Specs specs { get; set; }
        public bool ai_enabled { get; set; }
    }

}
