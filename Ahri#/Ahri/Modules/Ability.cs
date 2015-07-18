using LeagueSharp;
using LeagueSharp.Common;

namespace AhriB.Modules
{
    internal class Ability : AhriB
    {
        public Ability()
        {
            SpellQ = new Spell(SpellSlot.Q, 0);
            SpellW = new Spell(SpellSlot.W, 0);
            SpellE = new Spell(SpellSlot.E, 0);
            SpellR = new Spell(SpellSlot.R, 0);
            Ignite = Hero.GetSpellSlot("summonerdot");
        }
    }
}