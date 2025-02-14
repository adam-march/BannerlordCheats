﻿using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetUpgradeCost))]
    public static class WorkshopUpgradeCostPatch
    {
        [HarmonyPostfix]
        public static void GetUpgradeCost(ref int currentLevel, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance.WorkshopUpgradeCostPercentage < 100)
            {
                var factor = BannerlordCheatsSettings.Instance.WorkshopUpgradeCostPercentage / 100f;

                __result = (int) (__result * factor);
            }
        }
    }
}
