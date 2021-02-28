﻿using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultMapVisibilityModel), nameof(DefaultMapVisibilityModel.GetPartySpottingRange))]
    public static class DefaultMapVisibilityModelPatch
    {
        [HarmonyPostfix]
        public static void GetPartySpottingRange(ref MobileParty party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if (party?.IsMainParty ?? false)
            {
                __result.AddFactor(BannerlordCheatsSettings.Instance.MapVisibilityFactor);
            }
        }
    }
}
