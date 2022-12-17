using System;
using GTANetworkAPI;

namespace Revenge
{
    class Events : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            DateTime date = new DateTime();
            mysql.InitConnection();
            NAPI.World.SetTime(date.Hour, date.Minute, date.Second);
            NAPI.World.SetWeather(Weather.XMAS);
            NAPI.Server.SetDefaultSpawnLocation(new Vector3(-200, 800, 30.46), -147f);
        }

        [ServerEvent(Event.PlayerConnected)]
        private void OnPlayerConnected(Player player)
        {
            NAPI.Notification.SendNotificationToPlayer(player, "Welocome to ~r~Revenge Role Play");
            if (mysql.IsAccountExist(player.Name))
            {
                player.SendChatMessage("~w~Your account already ~g~register~w~ on RevengeRP. Use /login to authorise");
            }
            else
            {
                player.SendChatMessage("Your account is not registered on RevengeRP. Use /reg to register");
            }
        }

        [ServerEvent(Event.PlayerSpawn)]
        private void OnPlayerSpawn(Player player)
        {
            player.Health = 50;
            player.Armor = 50;
            player.Name = player.SocialClubName;
            player.SendNotification("sup", false);
        }
    }
}
