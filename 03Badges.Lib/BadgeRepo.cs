using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Badges.Lib
{
    public class BadgeRepo
    {
        Dictionary<int, Badge> _badges = new Dictionary<int, Badge>();

        public bool CreateBadge(Badge badge)
        {
            _badges.Add(badge.BadgeId, badge);

            if (_badges.ContainsKey(badge.BadgeId))
                return true;
            else return false;
        }

        public bool CreateBadge(int id, List<string> doorNames, string badgeName)
        {
            if (!_badges.ContainsKey(id))
            {
                Badge badge = new Badge(id, doorNames, badgeName);
                _badges.Add(badge.BadgeId, badge);
                return true;
            }
            else return false;
        }

        public Badge GetById(int id)
        {
            if (_badges.ContainsKey(id))
                return _badges[id];
            return null;
        }

        public Dictionary<int, Badge> GetAll()
        {
            return _badges;
        }

        public bool UpdateBadgeById(Badge newBadge)
        {
            if (newBadge != null)
            {
                if (GetById(newBadge.BadgeId) != null)
                {
                    _badges[newBadge.BadgeId].DoorNames = newBadge.DoorNames;
                    _badges[newBadge.BadgeId].BadgeName = newBadge.BadgeName;
                    return true;
                }
            }
            return false;
        }

        public bool DeleteById(int id)
        {
            if (_badges.ContainsKey(id))
            {
                _badges.Remove(id);
                return true;
            }
            else return false;
        }
    }
}
