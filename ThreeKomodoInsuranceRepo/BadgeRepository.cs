using System;
using System.Collections.Generic;

namespace ThreeBadgeRepository
{

    public class BadgeRepository
    {
        Dictionary<int, Badge> _badgesTwoDoors = new Dictionary<int, Badge>();
        public void AddContent(int id, Badge newBadge)
        {
            _badgesTwoDoors.Add(id, newBadge);
        }

        public Dictionary<int, Badge> GetDictionary()
        {
            return _badgesTwoDoors;
        }

        public void RemoveSingleDoor(int delBadgeId, String delDoor)
        {
            // Removes SINGLE Door from List
            foreach (KeyValuePair<int, Badge> _keyValuePairs in _badgesTwoDoors)
            {
                int badgeId = _keyValuePairs.Value.BadgeID;
                List<string> doors = _keyValuePairs.Value.DoorNames;
                               
               if (badgeId == delBadgeId)
               {
                    foreach (string door in doors)
                    {
                        if (delDoor == door)
                        {
                            doors.Remove(delDoor);
                            break;
                        }
                    }
               }
            }
        }

        public void RemoveAllDoors(int delBadgeId)
        {
            // Removes ALL doors from List<string> in Value
            foreach (KeyValuePair<int, Badge> _keyValuePairs in _badgesTwoDoors)
            {

                int badgeId = _keyValuePairs.Value.BadgeID;
                List<string> doors = _keyValuePairs.Value.DoorNames;
                
                if (badgeId == delBadgeId)
                {
                    doors.Clear();
                }
            }
        }

        public void RemoveAll(int delBadgeId)
        {
            foreach (KeyValuePair<int, Badge> _keyValuePairs in _badgesTwoDoors)
            {
                int badgeId = _keyValuePairs.Value.BadgeID;
                List<string> doors = _keyValuePairs.Value.DoorNames;
                
                if (badgeId == delBadgeId)
                {
                    _badgesTwoDoors.Remove(badgeId);
                    doors.Clear();
                    break;
                }
            }
        }

        public void AddDoor(int delBadgeId, string newDoor)
        {
            // Adds a door to the List<string> in Value
            foreach (KeyValuePair<int, Badge> _keyValuePairs in _badgesTwoDoors)
            {
                int badgeId = _keyValuePairs.Value.BadgeID;
                List<string> doors = _keyValuePairs.Value.DoorNames;

                if (badgeId == delBadgeId)
                {
                    doors.Add(newDoor);
                }
            }
        }
     
    }
}