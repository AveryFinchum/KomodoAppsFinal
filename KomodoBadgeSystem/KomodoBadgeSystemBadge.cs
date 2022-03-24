using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeSystem
{
    internal class KomodoBadgeSystemBadge
    {
        public KomodoBadgeSystemBadge() { }
        public KomodoBadgeSystemBadge(int number, List<string> doors)
        {
            BadgeNumber = number;
            Doors = doors;

        }

        public int BadgeNumber { get; set; }
        public List<string> Doors { get; set; }


    }
}
