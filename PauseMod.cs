using Harmony;
using System.Reflection;

namespace com.blargs.raft.pause
{
    [ModTitle("PauseMod")]
    [ModDescription("Allows the player to pause their thirst & hunger in multiplayer. Icon made by Lucy G <https://www.flaticon.com/authors/lucy-g> from https://www.flaticon.com/ is licensed by http://creativecommons.org/licenses/by/3.0/")]
    [ModAuthor("Echo343")]
    [ModIconUrl("https://i.imgur.com/hztBVwU.png")]
    [ModWallpaperUrl("https://i.imgur.com/uUvbe7D.png")]
    [ModVersion("1.1.0")]
    [RaftVersion("Update 9 Hotfix 3")]
    public class PauseMod : Mod
    {
        private Network_Player player = null;
        private const string harmonyId = "com.blargs.raft.pause";
        private HarmonyInstance harmony = null;

        private void Start()
        {
            harmony = HarmonyInstance.Create(harmonyId);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            RConsole.Log("PauseMod loaded!");
        }

        public void Update()
        {
            if (player == null)
            {
                player = RAPI.getLocalPlayer();
            }
            else
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
            harmony.UnpatchAll(harmonyId);
            Destroy(gameObject);
        }
    }
}