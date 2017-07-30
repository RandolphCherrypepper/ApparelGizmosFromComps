﻿Apparel Gizmos From Comps
by Randolph Cherrypepper

This mod is meant for Code modders.

If you pick up a weapon, a button appears to melee or ranged attack. That's a Gizmo associated with equipment used by a colonist. Unfortunately, RimWorld will not show Gizmos (buttons) associated with any apparel worn by a colonist. This is sad for modders.

AGFC defines an abstract ThingComp called CompWearable which provides CompGetGizmosWorn(). If apparel is worn by a selected colonist, Gizmos returned from CompGetGizmosWorn will be displayed.

Requires HugsLib for Harmony.

Compatibility note: AGFC applies a Postfix patch to RimWorld.Apparel.GetWornGizmos(). In other words, it should be safe to mix with other mods without issue.

Mod Order: Anywhere below HugsLib.

Feel free to leave a comment if you run into a problem.

Steam Download:
http://steamcommunity.com/sharedfiles/filedetails/?id=1095583324