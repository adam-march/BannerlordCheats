﻿using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.SecurityChange), MethodType.Getter)]
    public static class SecurityPatch
    {
        [HarmonyPostfix]
        public static void SecurityChange(ref Town __instance, ref float __result)
        {
            if ((__instance?.Owner?.Owner?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.DailySecurityBonus > 0)
            {
                __result += BannerlordCheatsSettings.Instance.DailySecurityBonus;
            }
        }
    }
}
