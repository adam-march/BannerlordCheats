﻿using BannerlordCheats.Settings;
using HarmonyLib;
using System.Linq;
using BannerlordCheats.Extensions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;

namespace BannerlordCheats.Patches.Sieges
{
    [HarmonyPatch(typeof(DefaultSiegeEventModel), nameof(DefaultSiegeEventModel.GetConstructionProgressPerHour))]
    public static class DefaultSiegeEventModelPatch
    {
        [HarmonyPostfix]
        public static void GetConstructionProgressPerHour(ref SiegeEngineType type, ref SiegeEvent siegeEvent, ref ISiegeEventSide side, ref float __result)
        {
            if ((side?.SiegeParties?.Any(x => x.IsPlayerParty()) ?? false)
                && BannerlordCheatsSettings.Instance.SiegeBuildingSpeedMultiplier > 1)
            {
                __result *= BannerlordCheatsSettings.Instance.SiegeBuildingSpeedMultiplier;
            }
        }
    }
}
