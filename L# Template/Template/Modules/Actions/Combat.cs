using LeagueSharp.Common;

namespace Template.Modules.Actions
{
    internal class Combat : Template
    {
        public Combat()
        {
            var Target = TargetSelector.GetTarget(SpellQ.Range, TargetSelector.DamageType.Magical);
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

            if (Control.IsEnabled(this, SpellQ))
                //SpellQ.Cast(Target);

            if (Control.IsEnabled(this, SpellW))
            {
				/*
                if (Control.Bool["Combat:AW"].Value)
                {
                    if (Hero.Distance(Target) > Ability.CurrentRange)
                    {
                        SpellW.Cast(Hero);
                    }
                }
                else if (Hero.HealthPercent <= Control.Slider["Combat:WM"].Value.Value)
                {
                    SpellW.Cast(Hero);
                }
				*/
            }
           
            if (Control.IsEnabled(this, SpellE) && Ability.CurrentRange == 125) {
                //SpellE.Cast(Hero);
			}
        }
    }
}
