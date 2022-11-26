using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace Revenge
{
    class Commands : Script
    {
        [Command("veh", Description = "/vehicle id color1 color2", Alias = "vehicle")]
        private void cmd_veh(Player player, string vehname, int color1, int color2)
        {
            uint vhash = NAPI.Util.GetHashKey(vehname);
            if (vhash <= 0)
            {
                player.SendChatMessage("~r~Unknown vehicle model");
                return;
            }
            Vehicle veh = NAPI.Vehicle.CreateVehicle(vhash, player.Position, player.Heading, color1, color2);
            veh.NumberPlate = "16REVENGERP";
            veh.Locked = false;
            veh.EngineStatus = true;
            player.SetIntoVehicle(veh, (int)VehicleSeat.Driver);
        }
    }
}
