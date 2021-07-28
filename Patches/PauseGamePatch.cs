using HarmonyLib;
using System;

namespace com.blargs.raft.pause.Patches
{
    [HarmonyPatch(typeof(CanvasHelper))]
    [HarmonyPatch("OpenMenu")]
    [HarmonyPatch(new Type[] { typeof(MenuType), typeof(bool) })]
    class PauseGamePatch
    {
        static bool Postfix(bool __result, MenuType menuType, bool force)
        {
            if (menuType == MenuType.PauseMenu)
            {
                Network_Player player = RAPI.GetLocalPlayer();
                if (player != null)
                {
                    SavedStats stats = SavedStats.GetSavedPlayerStats(player.name);
                    stats.Hunger = player.Stats.stat_hunger.Normal.Value;
                    stats.Thirst = player.Stats.stat_thirst.Normal.Value;
                    stats.IsPaused = true;
                }
            }
            return __result;
        }
    }
}