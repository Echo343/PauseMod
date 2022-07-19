using System;
using System.Collections.Generic;

namespace com.blargs.raft.pause
{
    class SavedStats
    {
        private static Dictionary<String, SavedStats> INSTANCE = new Dictionary<string, SavedStats>();

        public static SavedStats GetSavedPlayerStats(String playerName)
        {
            if (!INSTANCE.TryGetValue(playerName, out SavedStats stats))
            {
                stats = new SavedStats();
                INSTANCE.Add(playerName, stats);
            }
            return stats;
        }

        public float Thirst
        {
            get;
            set;
        }
        public float Hunger
        {
            get;
            set;
        }
        public bool IsPaused
        {
            get;
            set;
        }

        private SavedStats()
        {
            IsPaused = false;
        }
    }
}
