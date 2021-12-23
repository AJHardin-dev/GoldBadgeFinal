using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Badges.Lib
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public string DoorNames { get; set; }
        public string BadgeName { get; set; }

        public Badge(int badgeId, string doorNames, string badgeName)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;
            BadgeName = badgeName;
        }
    }
}
