using Harmony;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace com.blargs.raft.pause
{
    [ModTitle("PauseMod")]
    [ModDescription("Allows the game to be paused in multiplayer.")]
    [ModAuthor("Echo343")]
    [ModIconUrl("https://www.raftmodding.com/images/missing.jpg")]
    [ModWallpaperUrl("https://www.raftmodding.com/images/missing.jpg")]
    [ModVersion("0.0.1")]
    [RaftVersion("Update 9 (3556813)")]
    public class PauseMod : Mod
    {
        private void Start()
        {
            var harmony = HarmonyInstance.Create("com.blargs.raft.pause");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            RConsole.Log("PauseMod loaded!");
        }

        public void Update()
        {
            Network_Player player = RAPI.getLocalPlayer();
            if (player != null)
            {
                SavedStats stats = SavedStats.GetSavedPlayerStats(player.name);
                if (stats.IsPaused)
                {
                    player.Stats.stat_hunger.Normal.Value = stats.Hunger;
                    player.Stats.stat_thirst.Value = stats.Thirst;
                }
            }
        }

        public void OnModUnload()
        {
            RConsole.Log("PauseMod has been unloaded!");
            Destroy(gameObject);
        }
    }
}