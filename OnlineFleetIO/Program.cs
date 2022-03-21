using OnlineFleetIO.VehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFleetIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var fleetIOCallerObj = new FleetIOCaller();

            fleetIOCallerObj.GetFleetIOGroups();


            fleetIOCallerObj.LoopFleetIO();
        }

    }
}
