using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

namespace Template.Modules
{
    internal class Control : Template
    {
        protected static string MenuLabel = "Vanguard# - Template";
        protected static MenuWrapper Settings;

        protected static Dictionary<string, MenuWrapper.BoolLink> Bools = new Dictionary<string, MenuWrapper.BoolLink>();
        protected static Dictionary<string, MenuWrapper.CircleLink> Circles = new Dictionary<string, MenuWrapper.CircleLink>();
        protected static Dictionary<string, MenuWrapper.KeyBindLink> Keys = new Dictionary<string, MenuWrapper.KeyBindLink>();
        protected static Dictionary<string, MenuWrapper.SliderLink> Sliders = new Dictionary<string, MenuWrapper.SliderLink>();
        protected static Dictionary<string, MenuWrapper.StringListLink> Strings = new Dictionary<string, MenuWrapper.StringListLink>();

        public static Dictionary<string, MenuWrapper.BoolLink> Bool { get { return Bools; } }
        public static Dictionary<string, MenuWrapper.CircleLink> Circle { get { return Circles; } }
        public static Dictionary<string, MenuWrapper.KeyBindLink> Key { get { return Keys; } }
        public static Dictionary<string, MenuWrapper.SliderLink> Slider { get { return Sliders; } }
        public static Dictionary<string, MenuWrapper.StringListLink> String { get { return Strings; } }

        private static void Link(string key, object value)
        {
            var type = value.GetType();
            if (type == typeof(MenuWrapper.BoolLink))
                Bools.Add(key, (MenuWrapper.BoolLink)value);
            else if (type == typeof(MenuWrapper.CircleLink))
                Circles.Add(key, (MenuWrapper.CircleLink)value);
            else if (type == typeof(MenuWrapper.KeyBindLink))
                Keys.Add(key, (MenuWrapper.KeyBindLink)value);
            else if (type == typeof(MenuWrapper.SliderLink))
                Sliders.Add(key, (MenuWrapper.SliderLink)value);
            else if (type == typeof(MenuWrapper.StringListLink))
                Strings.Add(key, (MenuWrapper.StringListLink)value);
        }

        public Control()
        {
            Initialize();
        }

        public static void Initialize()
        {
            Settings = new MenuWrapper(MenuLabel);

            #region Combat settings
            var Combat = Settings.MainMenu.AddSubMenu("Combo");

            #region Ignite configuration
            var igniteMenu = Combat.AddSubMenu("Ignite settings");
            Link("IgniteUsage", igniteMenu.AddLinkedBool("Use Ignite"));

            // Before with (selection menu)
            var bonusMenu = igniteMenu.AddSubMenu("Ignite before fight");
            Link("IgniteBeforeFight", bonusMenu.AddLinkedBool("Ignite before fight", false));
            foreach (var enemy in ObjectManager.Get<Obj_AI_Hero>().Where(h => !h.IsAlly))
                Link("EnemyChampion_" + enemy.ChampionName, bonusMenu.AddLinkedBool("When fighting against " + enemy.ChampionName));

            // Other ignite options.
            Link("IgniteBasedHP", igniteMenu.AddLinkedBool("Ignite based on damage"));
            Link("IgniteBasedHealth", igniteMenu.AddLinkedSlider("Health: ", 180, 0, 210));
            #endregion Ignite configuration - end;

            Link("Combat:Q", Combat.AddLinkedBool("Use Q"));
            Link("Combat:W", Combat.AddLinkedBool("Use W"));
            Link("Combat:E", Combat.AddLinkedBool("Use E"));
			Link("Combat:R", Combat.AddLinkedBool("Use R"));
            Link("Combat:Key", Combat.AddLinkedKeyBind("Combo active", 32, KeyBindType.Press));
            #endregion

            #region Harass settings
            var Harass = Settings.MainMenu.AddSubMenu("Harass");
            Link("Harass:Q", Harass.AddLinkedBool("Use Q"));
			Link("Harass:W", Harass.AddLinkedBool("Use W"));
            Link("Harass:E", Harass.AddLinkedBool("Use E"));
            Link("Harass:R", Harass.AddLinkedBool("Use R"));
            Link("Harass:Key", Harass.AddLinkedKeyBind("Harass active", 'C', KeyBindType.Press));
            #endregion

            #region Pushing settings
            var Pushing = Settings.MainMenu.AddSubMenu("Pushing");
			Link("Pushing:Q", Pushing.AddLinkedBool("Use Q"));
			Link("Pushing:W", Pushing.AddLinkedBool("Use W"));
            Link("Pushing:E", Pushing.AddLinkedBool("Use E"));
			Link("Pushing:R", Pushing.AddLinkedBool("Use R"));
            Link("Pushing:Key", Pushing.AddLinkedKeyBind("Pushing Key", 'V', KeyBindType.Press));
            #endregion

            var Freeze = Settings.MainMenu.AddSubMenu("Lane Freeze");
            Link("Freeze:Q", Freeze.AddLinkedBool("Last hit with Q", false));
			Link("Freeze:W", Freeze.AddLinkedBool("Last hit with W"));
            Link("Freeze:E", Freeze.AddLinkedBool("Last hit with E"));
			Link("Freeze:R", Freeze.AddLinkedBool("Last hit with R"));
            Link("Freeze:Key", Freeze.AddLinkedKeyBind("Lane freeze key", 'X', KeyBindType.Press));

            var Neutral = Settings.MainMenu.AddSubMenu("Jungle Clear");
            Link("Neutral:Q", Neutral.AddLinkedBool("Use Q"));
            Link("Neutral:W", Neutral.AddLinkedBool("Use W"));
            Link("Neutral:E", Neutral.AddLinkedBool("Use E"));
			Link("Neutral:R", Neutral.AddLinkedBool("Use R"));
            Link("Neutral:Key", Neutral.AddLinkedKeyBind("JungleClear active", 'V', KeyBindType.Press));

            var Flee = Settings.MainMenu.AddSubMenu("Flee");
            Link("Flee:Q", Flee.AddLinkedBool("Use Q on closest enemy"));
			Link("Flee:W", Flee.AddLinkedBool("Use W on closest enemy"));
			Link("Flee:E", Flee.AddLinkedBool("Use E on closest enemy"));
			Link("Flee:R", Flee.AddLinkedBool("Use R on closest enemy"));
            Link("Flee:Q", Flee.AddLinkedBool("Use Q for speed boost"));
			Link("Flee:W", Flee.AddLinkedBool("Use W for speed boost"));
			Link("Flee:E", Flee.AddLinkedBool("Use E for speed boost"));
			Link("Flee:R", Flee.AddLinkedBool("Use R for speed boost"));
            Link("Flee:Key", Flee.AddLinkedKeyBind("Flee active", 'T', KeyBindType.Press));

            // Misc
            var MiscMenu = Settings.MainMenu.AddSubMenu("Misc");
			Link("AutomaticQ", MiscMenu.AddLinkedBool("Auto Q when enemy in range", false));
			Link("AutomaticW", MiscMenu.AddLinkedBool("Auto W when enemy in range", false));
			Link("AutomaticE", MiscMenu.AddLinkedBool("Auto E when enemy in range", false));
            Link("AutomaticR", MiscMenu.AddLinkedBool("Auto R when enemy in range", false));
        }

        internal static bool UseIgnite
        {
            get
            {
                return Bool["IgniteUsage"].Value;
            }
        }

        internal static int IgniteUsageIndex
        {
            get
            {
                return Bool["IgniteBeforeFight"].Value ? 1 : 2;
            }
        }

        internal static bool ManaLimitation
        {
            get
            {
                return Slider["ManaLimit_Value"].Value.Value >= Hero.ManaPercent;
            }
        }

        internal static bool IsActive(Template action)
        {
            return Key[action.GetType().Name + ":Key"].Value.Active;
        }

        internal static bool IsEnabled(Template action, Spell spell)
        {
            return Bool[action.GetType().Name + ":" + spell.Slot].Value && spell.IsReady();
        }

  
    }
}
