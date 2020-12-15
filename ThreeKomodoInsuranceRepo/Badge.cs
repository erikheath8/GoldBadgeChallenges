using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeBadgeRepository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        public List<Badge> BadgeIndv { get; set; }
        public Badge() { }

        public Badge(int badgeId, List<string> doorName)
        {
            BadgeID = badgeId;
            DoorNames = doorName;
        }
    }
}
