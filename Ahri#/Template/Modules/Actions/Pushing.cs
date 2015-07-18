using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp.Common;

namespace Ahri.Modules.Actions
{
    internal class Pushing : Ahri
    {
        public Pushing()
        {
            if (Control.IsActive(this) == false) return;
            var minions = MinionManager.GetMinions(525, MinionTypes.All, MinionTeam.Enemy, MinionOrderTypes.MaxHealth);
            if (minions.Count == 0 || Control.ManaLimitation)
                return;

            var ModeIndex = Control.String["Pushing:Q"].Value.SelectedIndex;
            if (Control.IsEnabled(this, SpellE) && Control.Slider["EActivateLC"].Value.Value <= minions.Count)
                SpellE.Cast(Hero);

            foreach (var money in minions)
            {
                if (ModeIndex == 0 && money.CharData.BaseSkinName.Contains("MinionSiege"))
                {
                    if (SpellQ.IsKillable(money))
                        SpellQ.CastOnUnit(money);
                }
                else if (ModeIndex == 1)
                {
                    if (SpellQ.IsKillable(money))
                        SpellQ.CastOnUnit(money);
                }
            }

        }
    }
}
