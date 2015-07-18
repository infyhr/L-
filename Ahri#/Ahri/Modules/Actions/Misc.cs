using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace AhriB.Modules.Actions
{
    internal class Misc : AhriB
    {
        public Misc()
        {
            if (Utils.TickCount - MiscTick < 200) return;

            /*

            if (Control.Bool["AutomaticE"].Value)
            {
                if (Hero.Position.GetObjects<Obj_AI_Hero>(SpellQ.Range).Count > 0 && SpellE.IsReady())
                    SpellE.Cast(Hero);
            }

            if (Control.Bool["Sustain:Enabled"].Value)
            {
                if (Hero.IsRecalling())
                    return;

                if (Hero.HealthPercent <= Control.Slider["Sustain:WH"].Value.Value && Control.Bool["Sustain:W"].Value)
                    SpellW.Cast(Hero);
            }
             */

            MiscTick = Utils.TickCount;
        }
    }
}
