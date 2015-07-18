using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp.Common;

namespace Template.Modules.Actions
{
    internal class Freeze : Template
    {
        public Freeze()
        {
            if (Control.IsActive(this) == false) return;
            var minionList = MinionManager.GetMinions(525, MinionTypes.All, MinionTeam.Enemy, MinionOrderTypes.MaxHealth);
            var lowHealthMinions = 0;

            if (minionList.Count < 1)
                return;

            foreach (var minion in minionList)
            {
                if (Control.IsEnabled(this, SpellQ) && SpellQ.IsKillable(minion))
                    SpellQ.CastOnUnit(minion);

                if (Control.IsEnabled(this, SpellE) && SpellE.IsKillable(minion))
                    lowHealthMinions++;
            }

            if (lowHealthMinions >= 1)
                SpellE.Cast(Hero);
        }
    }
}
