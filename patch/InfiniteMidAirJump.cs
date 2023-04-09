using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class InfiniteMidAirJump
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(PlayerMagicData).GetMethod(nameof(PlayerMagicData.SkyJumpUsed), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref PlayerMagicData __instance)
	{
		if (LittleModNobetaPlugin.configInfiniteMidAirJump.Value)
			__instance.SkyJumpReset();
		return;
	}
}