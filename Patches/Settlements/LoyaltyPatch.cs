﻿using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace BannerlordCheats.Patches.Settlements
{
    [HarmonyPatch(typeof(Town), nameof(Town.LoyaltyChange), MethodType.Getter)]
    public static class LoyaltyPatch
    {
        [HarmonyPostfix]
        public static void LoyaltyChange(ref Town __instance, ref float __result)
        {
            if ((__instance?.Owner?.Owner?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.DailyLoyaltyBonus > 0)
            {
                __result += BannerlordCheatsSettings.Instance.DailyLoyaltyBonus;
            }
        }
    }
}
