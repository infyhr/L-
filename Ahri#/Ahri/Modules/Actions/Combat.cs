using LeagueSharp;
using LeagueSharp.Common;

namespace AhriB.Modules.Actions
{
    internal class Combat : AhriB
    {
        public Combat()
        {
            var Target = TargetSelector.GetTarget(SpellE.Range, TargetSelector.DamageType.Magical);
            if (Control.IsActive(this) == false || Target == null)
                return;

            #region Ignite usage
            if (Control.UseIgnite)
            {
                if (Control.IgniteUsageIndex == 1)
                {
                    var value = "EnemyChampion_" + Target.ChampionName;

                    if (!Control.Bool[value].Value)
                    {
                        if (Control.Bool["IgniteBasedHP"].Value)
                        {
                            if (Target.Health <= Control.Slider["IgniteBasedHealth"].Value.Value)
                            {
                                Hero.Spellbook.CastSpell(Ignite, Target);
                            }
                        }
                    }

                    Hero.Spellbook.CastSpell(Ignite, Target);
                }
                else if (Control.IgniteUsageIndex == 2)
                    if (Target.Health <= Control.Slider["IgniteBasedHealth"].Value.Value)
                        Hero.Spellbook.CastSpell(Ignite, Target);
            }
            #endregion

            if (Control.IsEnabled(this, SpellE))
            {
                SpellE.CastIfHitchanceEquals(Target, HitChance.High);
            }

            if (Target.IsCharmed && Control.Bool["Combat:Charm"].Value)
            {
                if (Control.IsEnabled(this, SpellR))
                {
                    SpellR.Cast(Game.CursorPos);
                }

                if (Control.IsEnabled(this, SpellW))
                {
                    SpellW.Cast(Hero);
                }

                if (Control.IsEnabled(this, SpellQ))
                {
                    SpellQ.Cast(Target);
                }
            }
            else
            {
                if (Control.IsEnabled(this, SpellR))
                {
                    SpellR.Cast(Game.CursorPos);
                }

                if (Control.IsEnabled(this, SpellW))
                {
                    SpellW.Cast(Hero);
                }

                if (Control.IsEnabled(this, SpellQ))
                {
                    SpellQ.Cast(Target);
                }
            }
        }
    }
}