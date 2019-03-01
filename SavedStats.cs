using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.blargs.raft.pause
{
    class SavedStats
    {
        private static Dictionary<String, SavedStats> INSTANCE = new Dictionary<string, SavedStats>();

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

        public SavedStats()
        {
            IsPaused = false;
        }

        public static SavedStats GetSavedPlayerStats(String playerName)
        {
            if (!INSTANCE.TryGetValue(playerName, out SavedStats stats))
            {
                stats = new SavedStats();
                INSTANCE.Add(playerName, stats);
            }
            return stats;
        }
    }
}
