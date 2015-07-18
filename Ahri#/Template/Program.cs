using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp.Common;

/**
 * Credits to Avenguard for this Template!
 */ 

namespace Ahri
{
    class Program
    {
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Ahri.OnGameLoad;
        }
    }
}
