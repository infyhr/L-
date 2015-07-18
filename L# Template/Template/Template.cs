using System;
using System.Reflection;
using System.Timers;
using Template.Modules;
using Template.Modules.Actions;
using LeagueSharp;
using LeagueSharp.Common;

namespace Template
{
    internal abstract class Template
    {
        public static readonly Obj_AI_Hero Hero = ObjectManager.Player;

        public static Spell SpellQ { get; internal set; }
        public static Spell SpellW { get; internal set; }
        public static Spell SpellE { get; internal set; }
        public static Spell SpellR { get; internal set; }
        public static SpellSlot Ignite { get; internal set; }

        public static int MiscTick = 0;

        public static System.Version Versija 
        {
            get { return Assembly.GetAssembly(typeof(Template)).GetName().Version; }
        }

        public static void OnGameLoad(EventArgs args)
        {
            //if (Hero.ChampionName != "Champ Name")
                //return;

            new Ability();
            new Control();
            Notifications.AddNotification(new Notification(Hero.ChampionName + " v" + Versija +" by Berb", 4000));
            Game.OnUpdate += OnGameUpdate;
        }

        public static void OnGameUpdate(EventArgs args)
        {
            new Combat();
            new Pushing();
            new Harass();
            new Neutral();
            new Freeze();
            new Flee();
            new Misc();
        }
    }
}
