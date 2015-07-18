using LeagueSharp;
using LeagueSharp.Common;

namespace Template.Modules
{
    internal class Ability : Template
    {
        public Ability()
        {
            SpellQ = new Spell(SpellSlot.Q, 0);
            SpellW = new Spell(SpellSlot.W, 0);
            SpellE = new Spell(SpellSlot.E, 0);
            SpellR = new Spell(SpellSlot.R, 0);
            Ignite = Hero.GetSpellSlot("summonerdot");
        }

        internal static int CurrentRange
        {
           get { return Hero.HasBuff("JudicatorRighteousFury") ? 525 : 125; }
        }
    }
}