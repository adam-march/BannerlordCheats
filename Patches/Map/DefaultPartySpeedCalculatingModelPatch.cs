﻿using BannerlordCheats.Extensions;
using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartySpeedCalculatingModel), nameof(DefaultPartySpeedCalculatingModel.CalculateFinalSpeed))]
    public static class DefaultPartySpeedCalculatingModelPatch
    {
        [HarmonyPostfix]
        public static void CalculateFinalSpeed(ref MobileParty mobileParty, ref ExplainedNumber finalSpeed, ref ExplainedNumber __result)
        {
            if ((mobileParty?.IsMainParty ?? false)
                && BannerlordCheatsSettings.Instance.MapSpeedMultiplier > 1)
            {
                __result.AddMultiplier(BannerlordCheatsSettings.Instance.MapSpeedMultiplier);
            }
        }
    }
}
