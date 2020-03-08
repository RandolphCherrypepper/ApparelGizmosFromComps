﻿using RimWorld;
using Verse;
using HarmonyLib;
using System.Reflection;
using System.Collections.Generic;

namespace Randolph_Cherrypepper
{
    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.randolphcherrypepper.rimworld.mod.apparelgizmosfromcomps");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(Apparel), "GetWornGizmos")]
    public static class CherrypepperPatch_RimWorld_Apparel_GetWornGizmos
    {
        [HarmonyPostfix]
        public static void ApparelGizmosFromComps(Apparel __instance, ref IEnumerable<Gizmo> __result)
        {
            if (__instance == null)
            {
                Log.Warning("ApparelGizmosFromComps cannot access Apparel.");
                return;
            }
            if (__result == null)
            {
                Log.Warning("ApparelGizmosFromComps creating new list.");
                return;
            }

            // Find all comps on the apparel. If any have gizmos, add them to the result returned from apparel already (typically empty set).
            List<Gizmo> l = new List<Gizmo>(__result);
            foreach (CompWearable comp in __instance.GetComps<CompWearable>())
            {
                foreach (Gizmo gizmo in comp.CompGetGizmosWorn())
                {
                    l.Add(gizmo);
                }
            }
            __result = l;
        }
    }

    public abstract class CompWearable : ThingComp
    {
        public virtual IEnumerable<Gizmo> CompGetGizmosWorn() {
            // return no Gizmos
            return new List<Gizmo>();
        }
    }
}