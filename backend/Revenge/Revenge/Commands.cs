using System;
using GTANetworkAPI;

namespace Revenge
{
    class Commands : Script
    {
        [Command("veh", Description = "/vehicle id color1 color2", Alias = "vehicle")]
        private void cmd_veh(Player player, string vehname, int color1)
        {
            uint vhash = NAPI.Util.GetHashKey(vehname);
            if (vhash <= 0)
            {
                player.SendChatMessage("~r~Unknown vehicle model");
                return;
            }
            Vehicle veh = NAPI.Vehicle.CreateVehicle(vhash, player.Position, player.Heading, color1, color1);
            veh.NumberPlate = "ADMIN";
            veh.Locked = false;
            veh.EngineStatus = true;
            player.SetIntoVehicle(veh, (int)VehicleSeat.Driver);
            NAPI.Vehicle.SetVehicleEnginePowerMultiplier(veh, 500.0f);
            NAPI.Vehicle.SetVehicleMod(veh, 3, 2);
        }

        [Command("q3")]
        private void cmd_q3(Player player, uint dimension)
        {
            NAPI.Entity.SetEntityDimension(player, dimension);
        }

        [Command("b4")]
        private void cmd_b4(Player player, string model)
        {
            NAPI.Entity.SetEntityModel(player, (uint)NAPI.Util.PedNameToModel(model));
        }

        [Command("selfpos")]
        private void cmd_selfpos(Player player)
        {
            player.SendChatMessage($"{player.Position}, {player.Heading}");
        }

        [Command("tun")]
        private void cmd_tuning(Player player, int modType, int mod)
        {
            Vehicle vehicle = NAPI.Player.GetPlayerVehicle(player);
            NAPI.Vehicle.SetVehicleMod(vehicle, modType, mod);
        }

        [Command("anim", Alias = "anims")]
        private void cmd_anims(Player player, int flag)
        {
            player.PlayAnimation("mp_arresting", "idle", flag);
        }

        [Command("stopanim", Alias = "stopanims")]
        private void cmd_stopanims(Player player)
        {
            player.StopAnimation();
        }

        [Command("clothes")]
        private void cmd_clothes(Player player, int slot, int drawable, int texture)
        {
            player.SetClothes(slot, drawable, texture);
            return;
        }

        [Command("freeze", "/freeze [nickname] [true/false]")]
        private void cmd_freezeplayer(Player player, Player target, bool freezestatus)
        {
            NAPI.ClientEvent.TriggerClientEvent(target, "PlayerFreeze", freezestatus);
        }

        [Command("give")]
        private void cmd_give(Player player)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Hello babe ;)");
        }

        [Command("ped")]
        private void cmd_markpoint(Player player, string pedname)
        {
            uint pedhash = NAPI.Util.GetHashKey(pedname);
            NAPI.Ped.CreatePed(pedhash, player.Position, player.Heading, 4294967295);

        }

        [Command("weap", Description = "/weapon [weapon_(Weapon Name) [ammo]]", Alias = "weapon")]
        private void cmd_weapon(Player player, string weaponname, int ammo)
        {
            WeaponHash weaphash = NAPI.Util.WeaponNameToModel(weaponname);
            player.GiveWeapon(weaphash, ammo);
            player.GiveWeapon((WeaponHash)0x0781FE4A, 10);
        }

        [Command("tolpa")]
        private void cmd_tolpa(Player player)
        {
            for (int i=0; i<10; i++)
            {
                NAPI.Ped.CreatePed(0x81441B71, player.Position, player.Heading, 4294967295);
            }
        }

        [Command("tp", Description = "/teleport [x] [y] [z]", Alias = "teleport")]
        private void cmd_teleport(Player player, double x, double y, double z)
        {
            player.Position = new Vector3(x, y, z);
        }

        private void cmd_teleport(Player player, int id)
        {
            Player target = Utils.GetPlayerObject(id);
        }
    }
}
