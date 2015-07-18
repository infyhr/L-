using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp.Common;

namespace Template.Modules.Actions
{
    internal class Harass : Template
    {
        public Harass()
        {
            if (Control.IsActive(this) == false) return;
            var Target = TargetSelector.GetTarget(SpellQ.Range, TargetSelector.DamageType.Magical);
            if (Target == null || Control.ManaLimitation) return;

            if (Control.IsEnabled(this, SpellQ))
                SpellQ.Cast(Target);

            if (Control.IsEnabled(this, SpellW) && Ability.CurrentRange == 125)
            {
                SpellE.Cast(Template.Hero);
            }
        }
    }
}
