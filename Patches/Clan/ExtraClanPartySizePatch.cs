﻿using BannerlordCheats.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace BannerlordCheats.Patches
{
    [HarmonyPatch(typeof(DefaultPartySizeLimitModel), nameof(DefaultPartySizeLimitModel.GetPartyMemberSizeLimit))]
    public static class ExtraClanPartySizePatch
    {
        [HarmonyPostfix]
        public static void GetPartyMemberSizeLimit(ref PartyBase party, ref bool includeDescriptions, ref ExplainedNumber __result)
        {
            if ((party.Owner?.Clan?.Leader?.IsHumanPlayerCharacter ?? false)
                && BannerlordCheatsSettings.Instance.ExtraClanPartySize > 0)
            {
                __result.Add(BannerlordCheatsSettings.Instance.ExtraClanPartySize);
            }
        }
    }
}
