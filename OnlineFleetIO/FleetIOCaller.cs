using OnlineFleetIO.VehicleModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineFleetIO.ContactModel;
using OnlineFleetIO.VehicleAssignment;

namespace OnlineFleetIO
{
    public class FleetIOCaller
    {
        private List<GroupModel> FleetIOGroups = new List<GroupModel>();
        public string POSTData(string destinationUrl, string RequestJsonBody)
        {
            HttpWebResponse response;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
                byte[] bytes;
                bytes = Encoding.ASCII.GetBytes(RequestJsonBody);
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", "Token token=\"Your Token\"");
                request.Headers.Add("account-token", "Your Account Token");
                request.ContentLength = bytes.Length;
                request.Method = "POST";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    return responseStr;
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception e)
            {
                return "Failed";
            }
        }
        public void PATCHData(string destinationUrl, string RequestJsonBody)
        {
            HttpWebResponse response;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
                byte[] bytes;
                bytes = Encoding.ASCII.GetBytes(RequestJsonBody);
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", "Token token=\"Your Token\"");
                request.Headers.Add("account-token", "Your Account Token");
                request.ContentLength = bytes.Length;
                request.Method = "PATCH";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    //return Response<string>.Valid(responseStr);
                }
                else
                {
                    //return Response<string>.Failed(response.StatusDescription);
                }
            }
            catch (Exception e)
            {
                //return Response<string>.Failed(e.Message);
            }
        }
        public string GetData(string destinationUrl)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
                request.Method = "GET";
                request.Headers.Add("Authorization", "Token token=\"Your Token\"");
                request.Headers.Add("account-token", "Your Account Token");
                request.ContentType = "application/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    return responseStr;
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception e)
            {
                return "Failed";
            }
        }
        public string DELETEData(string destinationUrl)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
                request.Method = "DELETE";
                request.Headers.Add("Authorization", "Token token=\"Your Token\"");
                request.Headers.Add("account-token", "Your Account Token");
                request.ContentType = "application/json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    Stream responseStream = response.GetResponseStream();
                    string responseStr = new StreamReader(responseStream).ReadToEnd();
                    return responseStr;
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception e)
            {
                return "Failed";
            }
        }


        public void LoopFleetIO()
        {
            var TotalFleetIOVehicles = new List<FleetIOVehicle>();
            var FleetIOVehicles = new List<FleetIOVehicle>();
            int Count = 1;
            bool Paging = true;
            string DistinationURL, Response;

            List<FleetIOVehicle> FoundVehicles = new List<FleetIOVehicle>();
            List<FleetIOVehicle> NotFoundVehicles = new List<FleetIOVehicle>();

            while (Paging)
            {
                DistinationURL = "https://secure.fleetio.com/api/v1/vehicles?page=" + Count;
                Response = GetData(DistinationURL);

                if (Response != "Failed")
                {
                    FleetIOVehicles = JsonConvert.DeserializeObject<List<FleetIOVehicle>>(Response);
                    if (FleetIOVehicles.Count != 0)
                    {
                        for (int i = 0; i < FleetIOVehicles.Count; i++)
                        {
                            TotalFleetIOVehicles.Add(FleetIOVehicles[i]);
                        }
                        for (int i = 0; i < FleetIOVehicles.Count; i++)
                        {
                            //FleetIOVehicleExists(FleetIOVehicles[i], ref FoundVehicles, ref NotFoundVehicles);
                        }
                        Count++;
                    }
                    else Paging = false;
                }
                else break;
            }

        }
        public void GetFleetIOGroups()
        {
            string DistinationURL = "https://secure.fleetio.com/api/v1/groups";
            string Response = GetData(DistinationURL);

            if (Response != "Failed")
            {
                FleetIOGroups = JsonConvert.DeserializeObject<List<GroupModel>>(Response);
            }
        }

        public void CreateNewContact(ref int ContactIdCreated)
        {
            string LocationName = "";

            string[] LocationNameArr = LocationName.ToString().Split(' ');

            for (int i = 1; i <= LocationNameArr.Length; i++)
            {
                string SearchedName = LocationNameArr[LocationNameArr.Length - i];

                if (SearchedName != "")
                {
                    LocationName = SearchedName;
                    break;
                }
            }

            var LocationList = FleetIOGroups.Where(c => c.name.ToLower().Contains(LocationName.ToLower())).Select(c => c.id).ToList();

            var FleetioContactModelObj = new RequestFleetioContactModel()
            {
                //first_name = CustomerObj.FirstName,
                //last_name = CustomerObj.LastName,
                group_id = LocationList[0],
                //city = CustomerObj.City,
                //country = CustomerObj.CountryCode.ToUpper(),
                //email = CustomerObj.Email,
                //license_number = CustomerObj.LicenseNumber,
                //postal_code = CustomerObj.Zip,
                //region = CustomerObj.Region,
                //mobile_phone_number = CustomerObj.Phone,
                //home_phone_number = CustomerObj.LocalPhone,
                //street_address = CustomerObj.Address,
                vehicle_operator = true
            };


            string DistinationURL = "https://secure.fleetio.com/api/v1/contacts";
            string json = JsonConvert.SerializeObject(FleetioContactModelObj);

            string ResponseContact = POSTData(DistinationURL, json);

            if (ResponseContact != "Failed")
            {
                var ResponseFleetioContactObj = JsonConvert.DeserializeObject<ResponseFleetioContact>(ResponseContact);
                ContactIdCreated = ResponseFleetioContactObj.id;
            }
        }
        public void CreateNewVehicleAssignment(int ContactId, int VehicleId, int StartingOdometer, int EndingOdometer)//Starting , and ending Odomter must be >= 120,000
        {
            var RequestFleetioVehicleAssignmentModelObj = new RequestFleetioVehicleAssignmentModel()
            {
                contact_id = ContactId,
                vehicle_id = VehicleId,
                started_at = DateTime.Now.AddDays(9),
                ended_at = DateTime.Now.AddDays(10)
            };

            RequestFleetioVehicleAssignmentModelObj.starting_meter_entry_attributes = new starting_meter_entry_attributes()
            {
                value = StartingOdometer
            };

            RequestFleetioVehicleAssignmentModelObj.ending_meter_entry_attributes = new ending_meter_entry_attributes()
            {
                value = EndingOdometer
            };

            string DistinationURL = "https://secure.fleetio.com/api/v1/vehicle_assignments";
            string json = JsonConvert.SerializeObject(RequestFleetioVehicleAssignmentModelObj);

            string ResponseVehicleAssignment = POSTData(DistinationURL, json);

            if (ResponseVehicleAssignment != "Failed")
            {
                var ResponseFleetioVehicleAssignmentObj = JsonConvert.DeserializeObject<ResponseFleetioVehicleAssignment>(ResponseVehicleAssignment);
            }
        }
        public void UpdateVehicleAssignment(int VehicleAssignmentId, int EndingOdometer)
        {
            string DistinationURL = "https://secure.fleetio.com/api/v1/vehicle_assignments/" + VehicleAssignmentId;
            string ResponseVehicleAssignment = GetData(DistinationURL);

            if (ResponseVehicleAssignment != "Failed")
            {
                var ResponseFleetioVehicleAssignmentObj = JsonConvert.DeserializeObject<ResponseFleetioVehicleAssignment>(ResponseVehicleAssignment);


                var RequestFleetioVehicleAssignmentModelObj = new RequestFleetioVehicleAssignmentModel()
                {
                    contact_id = ResponseFleetioVehicleAssignmentObj.contact_id,
                    vehicle_id = ResponseFleetioVehicleAssignmentObj.vehicle_id,
                    started_at = ResponseFleetioVehicleAssignmentObj.started_at,
                    ended_at = ResponseFleetioVehicleAssignmentObj.ended_at
                };

                RequestFleetioVehicleAssignmentModelObj.starting_meter_entry_attributes = new starting_meter_entry_attributes()
                {
                    value = Convert.ToInt32(Convert.ToDouble(ResponseFleetioVehicleAssignmentObj.starting_meter_entry_value))
                };

                RequestFleetioVehicleAssignmentModelObj.ending_meter_entry_attributes = new ending_meter_entry_attributes()
                {
                    value = EndingOdometer
                };

                string json = JsonConvert.SerializeObject(RequestFleetioVehicleAssignmentModelObj);

                PATCHData(DistinationURL, json);
            }
        }
        public void DeleteVehicleAssignment(int VehicleAssignmentId)
        {
            string DistinationURL = "https://secure.fleetio.com/api/v1/vehicle_assignments/" + VehicleAssignmentId;
            DELETEData(DistinationURL);
        }

        public void UpdateContact(int ContactId)
        {
            string LocationName = "Your Location Name";

            string[] LocationNameArr = LocationName.ToString().Split(' ');

            for (int i = 1; i <= LocationNameArr.Length; i++)
            {
                string SearchedName = LocationNameArr[LocationNameArr.Length - i];

                if (SearchedName != "")
                {
                    LocationName = SearchedName;
                    break;
                }
            }

            var LocationList = FleetIOGroups.Where(c => c.name.ToLower().Contains(LocationName.ToLower())).Select(c => c.id).ToList();

            var FleetioContactModelObj = new RequestFleetioContactModel()
            {
                //first_name = CustomerObj.FirstName,
                //last_name = CustomerObj.LastName,
                group_id = LocationList[0],
                //city = CustomerObj.City,
                //country = CustomerObj.CountryCode.ToUpper(),
                //email = CustomerObj.Email,
                //license_number = CustomerObj.LicenseNumber,
                //postal_code = CustomerObj.Zip,
                //region = CustomerObj.Region,
                //mobile_phone_number = CustomerObj.Phone,
                //home_phone_number = CustomerObj.LocalPhone,
                //street_address = CustomerObj.Address
            };


            string DistinationURL = "https://secure.fleetio.com/api/v1/contacts/" + ContactId;
            string json = JsonConvert.SerializeObject(FleetioContactModelObj);

            PATCHData(DistinationURL, json);
        }

        public void CreateNewVehicle()
        {
            string LocationName = "Your Location Name";

            string[] LocationNameArr = LocationName.ToString().Split(' ');

            for (int i = 1; i <= LocationNameArr.Length; i++)
            {
                string SearchedName = LocationNameArr[LocationNameArr.Length - i];

                if (SearchedName != "")
                {
                    LocationName = SearchedName;
                    break;
                }
            }

            var LocationList = FleetIOGroups.Where(c => c.name.ToLower().Contains(LocationName.ToLower())).Select(c => c.id).ToList();

            var RequestFleetIOVehicleModelObj = new RequestFleetIOVehicleModel()
            {
                fuel_volume_units = "liters",
                meter_unit = "km",
                //name = VehicleObj.AssignedID,
                ownership = "owned",
                system_of_measurement = "imperial",
                vehicle_status_id = 248250,
                vehicle_type_id = 665238,
                linked_vehicle_ids = new List<object>(),
                //color = VehicleObj.Colour,
                //license_plate = VehicleObj.LicenseNumber,
                //make = VehicleObj.Make,
                //model = VehicleObj.Model,
                //vin = VehicleObj.VINNumber,
                //year = VehicleObj.YearMade,
                group_id = LocationList[0]
            };

            RequestFleetIOVehicleModelObj.purchase_detail_attributes = new purchase_detail_attributes()
            {
                meter_entry_attributes = new meter_entry_attributes()
            };

            string DistinationURL = "https://secure.fleetio.com/api/v1/vehicles";
            string json = JsonConvert.SerializeObject(RequestFleetIOVehicleModelObj);

            string ResponseContact = POSTData(DistinationURL, json);

            if (ResponseContact != "Failed")
            {
                var ResponseFleetioContactObj = JsonConvert.DeserializeObject<FleetIOVehicle>(ResponseContact);

            }
        }

        public int VehicleExists(string VIN)
        {
            int Exist = -1;
            var FleetIOVehicles = new List<FleetIOVehicle>();

            int Count = 1;
            bool Paging = true;
            string DistinationURL, Response;

            List<FleetIOVehicle> FoundVehicles = new List<FleetIOVehicle>();
            List<FleetIOVehicle> NotFoundVehicles = new List<FleetIOVehicle>();

            while (Paging)
            {
                DistinationURL = "https://secure.fleetio.com/api/v1/vehicles?page=" + Count;
                Response = GetData(DistinationURL);

                if (Response != "Failed")
                {
                    FleetIOVehicles = JsonConvert.DeserializeObject<List<FleetIOVehicle>>(Response);

                    if (FleetIOVehicles.Count != 0)
                    {
                        var FleetioVehicleObj = FleetIOVehicles.Where(c => c.vin == VIN).SingleOrDefault();

                        if (FleetioVehicleObj != null)
                        {
                            Exist = FleetioVehicleObj.id;
                            break;
                        }
                        Count++;
                    }
                    else Paging = false;
                }
                else break;
            }
            return Exist;
        }

        public int ContactExists(string Email)
        {
            int Exist = -1;

            string DistinationURL, Response;

            DistinationURL = "https://secure.fleetio.com/api/v1/contacts";
            Response = GetData(DistinationURL);

            if (Response != "Failed")
            {
                var FleetioContacts = JsonConvert.DeserializeObject<List<ResponseFleetioContact>>(Response);

                var FleetioContactObj = FleetioContacts.Where(c => c.email == Email).SingleOrDefault();

                if (FleetioContactObj != null)
                    Exist = FleetioContactObj.id;
            }

            return Exist;
        }

        public int VehicleAssignmentExists(int ContactId, int VehicleId)
        {
            int Exist = -1;

            string DistinationURL, Response;

            DistinationURL = "https://secure.fleetio.com/api/v1/vehicle_assignments";
            Response = GetData(DistinationURL);

            if (Response != "Failed")
            {
                var FleetioVehicleAssignment = JsonConvert.DeserializeObject<List<ResponseFleetioVehicleAssignment>>(Response);

                var FleetioVehicleAssignmentObj = FleetioVehicleAssignment.Where(c => c.contact_id == ContactId && c.vehicle_id == VehicleId).SingleOrDefault();

                if (FleetioVehicleAssignmentObj != null)
                    Exist = FleetioVehicleAssignmentObj.id;
            }

            return Exist;
        }
    }
}
