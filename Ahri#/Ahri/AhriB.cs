using System;
using System.Reflection;
using System.Timers;
using LeagueSharp;
using LeagueSharp.Common;
using AhriB.Modules;
using AhriB.Modules.Actions;

namespace AhriB
{
    internal abstract class AhriB
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
            get { return Assembly.GetAssembly(typeof(AhriB)).GetName().Version; }
        }

        public static void OnGameLoad(EventArgs args)
        {
            if (Hero.ChampionName != "Ahri")
                Notifications.AddNotification(new Notification("This champ is not support!", 4000));
                return;

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
            new Flee();
            new Misc();
        }
    }
}
