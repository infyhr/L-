using LeagueSharp;
using LeagueSharp.Common;

namespace Ahri.Modules
{
    internal class Ability : Ahri
    {
        public Ability()
        {
            SpellQ = new Spell(SpellSlot.Q, 880);
            SpellW = new Spell(SpellSlot.W, 700);
            SpellE = new Spell(SpellSlot.E, 975);
            SpellR = new Spell(SpellSlot.R, 450);
            Ignite = Hero.GetSpellSlot("summonerdot");
        }
    }
}