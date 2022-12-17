using GTANetworkAPI;

namespace Revenge
{
    class Accounts
    {
        public enum AdminRanks {Player, Helper, Moderator, Administrator}

        public const string _accountKey = "Player_Data";
        public int _id, _adminlevel;
        public string _name;
        public long _money;
        public Player _player;

        public Accounts()
        {
            this._name = "";
            this._money = 1000;
            this._adminlevel = 0;
        }

        public Accounts(string name, long money = 1000)
        {
            this._name = name;
            this._money = money;
            this._adminlevel = 0;
        }
        public static bool IsPlayerLoggedIn(Player player)
        {
            if (player != null) return player.HasData(_accountKey);
            return false;
        }
    }
}
