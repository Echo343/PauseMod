using Harmony;
using System;

namespace com.blargs.raft.pause.Patches
{
    [HarmonyPatch(typeof(CanvasHelper))]
    [HarmonyPatch("CloseMenu")]
    [HarmonyPatch(new Type[] { typeof(MenuType) })]
    class ResumeGamePatch
    {
        static void Postfix(MenuType menuType)
        {
            if (menuType == MenuType.PauseMenu)
            {
                Network_Player player = RAPI.getLocalPlayer();
                if (player != null)
                {
                    SavedStats.GetSavedPlayerStats(player.name).IsPaused = false;
                }
            }
        }
    }
}