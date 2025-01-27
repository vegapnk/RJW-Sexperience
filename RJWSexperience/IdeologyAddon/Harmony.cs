﻿extern alias BaseSexperience;
using BaseSexperience::RJWSexperience.ExtensionMethods;
using BaseSexperience::RJWSexperience;
using HarmonyLib;
using System.Reflection;
using Verse;

namespace RJWSexperience.Ideology
{
	[StaticConstructorOnStartup]
	internal static class First
	{
		static First()
		{
			var harmony = new Harmony("RJW_Sexperience.Ideology");
			harmony.PatchAll(Assembly.GetExecutingAssembly());

			if (ModLister.HasActiveModWithName("RJW Sexperience"))
			{
				harmony.Patch(AccessTools.Method(typeof(PawnExtensions), nameof(PawnExtensions.IsIncest)),
					prefix: new HarmonyMethod(typeof(Sexperience_Patch_IsIncest), nameof(Sexperience_Patch_IsIncest.Prefix)),
					postfix: null
					);
				harmony.Patch(AccessTools.Method(typeof(RJWUtility), nameof(RJWUtility.ThrowVirginHIstoryEvent)),
					prefix: null,
					postfix: new HarmonyMethod(typeof(Sexperience_Patch_ThrowVirginHIstoryEvent), nameof(Sexperience_Patch_ThrowVirginHIstoryEvent.Postfix))
					);
			}
		}
	}
}
