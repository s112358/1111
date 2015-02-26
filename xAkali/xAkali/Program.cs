using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using LeagueSharp;
using LeagueSharp.Common;
 
namespace Exploit_Framework
{
    class Program
    {
        public static Menu Config;
        public static List<GameObject> wards = new List<GameObject>();
        private static Spell _E = new Spell(SpellSlot.Q, 99999, TargetSelector.DamageType.Physical);
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += OnGameLoad;
        }
 
 
 
        private static void OnGameLoad(EventArgs args)
        {
            Config = new Menu("Exploit Framework", "Exploit", true);
            Config.AddSubMenu(new Menu("Exploits", "Exploits"));
            Config.SubMenu("Exploits")
                .AddItem(new MenuItem("LAG", "Lag exploit")).SetValue(new KeyBind("H".ToCharArray()[0], KeyBindType.Toggle));
               
            Config.AddToMainMenu();
            Game.OnGameUpdate += game_Update;
 
        }
 
        private static void game_Update(EventArgs args)
        {
            if (Config.Item("LAG").GetValue<KeyBind>().Active)
            {
                    foreach (Obj_AI_Base minion in ObjectManager.Get<Obj_AI_Base>().Where(minion => minion.IsEnemy))
                    {
                        if (minion.ServerPosition.Distance(ObjectManager.Player.ServerPosition) > 1000)
                        {
                                _E.CastOnUnit(minion);
                        }
                    }
            }
        }
 
        }
}
