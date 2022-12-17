using System;
using RAGE;

namespace Freeze
{
    class Freeze : Events.Script
    {
        private Freeze()
        {
            Events.Add("PlayerFreeze", PlayerFreeze);
        }

        private void PlayerFreeze(object[] args)
        {
            RAGE.Elements.Player.LocalPlayer.FreezePosition((bool)args[0]);
        }
    }
}
