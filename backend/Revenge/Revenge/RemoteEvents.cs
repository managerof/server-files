using GTANetworkAPI;

namespace Revenge
{
    class RemoteEvents : Script
    {
        [RemoteEvent("keypress:L")]
        private void OnKeyLPress(Player player)
        {
            player.SendNotification("Key 'L' pressed!", false);
        }
    }
}
