﻿using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace BannerlordCheats.Patches.Workshops
{
    [HarmonyPatch(typeof(DefaultWorkshopModel), nameof(DefaultWorkshopModel.GetSellingCost))]
    public static class WorkshopSellingCostPatch
    {
        [HarmonyPostfix]
        public static void GetSellingCost(ref Workshop workshop, ref int __result)
        {
            if (BannerlordCheatsSettings.Instance.WorkshopSellingCostMultiplier > 1)
            {
                __result = (int) (__result * BannerlordCheatsSettings.Instance.WorkshopSellingCostMultiplier);
            }
        }
    }
}
