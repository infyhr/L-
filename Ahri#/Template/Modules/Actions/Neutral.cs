using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp.Common;

namespace Ahri.Modules.Actions
{
    internal class Neutral : Ahri
    {
        public Neutral()
        {
            if (Control.IsActive(this) == false) return;
            var minions = MinionManager.GetMinions(525, MinionTypes.All, MinionTeam.Neutral, MinionOrderTypes.MaxHealth);
            if (minions.Count == 0 || Control.ManaLimitation)
                return;

            //if (Control.IsEnabled(this, SpellE) && minions.Count >= 1)
                //SpellE.Cast(Hero);

            var StrongestEnemy = minions.FirstOrDefault(ws => Math.Abs(ws.MaxHealth - minions.Max(wx => wx.MaxHealth)) < 1);
            //if (Control.IsEnabled(this, SpellQ) && StrongestEnemy != null)
                //SpellQ.CastOnUnit(StrongestEnemy);

            //if (Control.IsEnabled(this, SpellW) && Hero.HealthPercent <= Control.Slider["Neutral:WH"].Value.Value)
                //SpellW.Cast(Hero);
        }
    }
}
