using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class InfiniteMidAirDodge
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(PlayerMagicData).GetMethod(nameof(PlayerMagicData.SkyDodgeUsed), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref PlayerMagicData __instance)
	{
		if (LittleModNobetaPlugin.configInfiniteMidAirDodge.Value)
			__instance.SkyDodgeReset();
		return;
	}
}