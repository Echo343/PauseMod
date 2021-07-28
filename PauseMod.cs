using UnityEngine;
using HarmonyLib;
using System.Reflection;

namespace com.blargs.raft.pause
{
    public class PauseMod : Mod
    {
        private Network_Player player = null;
        private const string harmonyId = "com.blargs.raft.pause";
        private Harmony harmony = null;

        public void Start()
        {
            harmony = new Harmony(harmonyId);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Debug.Log("PauseMod has been loaded!");
        }

        public void Update()
        {
            if (player == null)
            {
                player = RAPI.GetLocalPlayer();
            }
            else
            {
                SavedStats stats = SavedStats.GetSavedPlayerStats(player.name);
                if (stats.IsPaused)
                {
                    player.Stats.stat_hunger.Normal.Value = stats.Hunger;
                    player.Stats.stat_thirst.Normal.Value = stats.Thirst;
                }
            }
        }

        public void OnModUnload()
        {
            Debug.Log("PauseMod has been unloaded!");
            harmony.UnpatchAll(harmonyId);
            Destroy(gameObject);
        }
    }
}