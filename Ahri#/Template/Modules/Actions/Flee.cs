using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace Ahri.Modules.Actions
{
    internal class Flee : Ahri
    {
        public Flee()
        {
            if (Control.IsActive(this) == false) return;
            var Targets = Hero.Position.GetObjects<Obj_AI_Hero>(SpellQ.Range);

            if (Targets == null) return;
            var FastestEnemy = Targets.FirstOrDefault(en => Math.Abs(en.MoveSpeed - Targets.Max(eos => eos.MoveSpeed)) < 1);

            //if (Control.IsEnabled(this, SpellQ) && FastestEnemy != null)
                //SpellQ.Cast(FastestEnemy);

            //if (Control.IsEnabled(this, SpellW))
                //SpellW.Cast(Hero);
        }
    }
}
