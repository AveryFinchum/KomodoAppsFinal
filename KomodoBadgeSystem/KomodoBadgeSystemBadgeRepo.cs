using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeSystem
{
    internal class KomodoBadgeSystemBadgeRepo
    {
        protected List<KomodoBadgeSystemBadge> _badges = new List<KomodoBadgeSystemBadge>();

        //Create Badge
        public bool AddBadgeToBadgeRepo(KomodoBadgeSystemBadge badges)
        {
            int startingCount = _badges.Count();
            _badges.Add(badges);
            bool wasAdded = (_badges.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        //Read (one)
        public List<KomodoBadgeSystemBadge> GetBadgeByNumber(int badgeNumber)
        {
            List<KomodoBadgeSystemBadge> ItemByNumber = new List<KomodoBadgeSystemBadge>();
            foreach (KomodoBadgeSystemBadge item in _badges)
            {
                if (item.BadgeNumber == badgeNumber)
                {
                    ItemByNumber.Add(item);
                }
            }
            return ItemByNumber.ToList(); // to list is needed in case this returns two badges with the same number
        }

        //Read (all ordered by badge number)
        public List<KomodoBadgeSystemBadge> GetAllBadges()
        {
            List<KomodoBadgeSystemBadge> BadgesByNumber = new List<KomodoBadgeSystemBadge>();
            foreach (KomodoBadgeSystemBadge item in _badges)
            {
                BadgesByNumber.Add(item);
            }
            // LINQ order by badge number
            return BadgesByNumber.OrderBy(c => c.BadgeNumber).ToList();
        }

        // Delete
        public bool DeleteExistingMenuItem(KomodoBadgeSystemBadge existingBadge)
        {
            bool deleteResult = _badges.Remove(existingBadge);
            return deleteResult;
        }
    }
}
