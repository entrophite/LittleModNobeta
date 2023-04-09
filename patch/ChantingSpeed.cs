using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class ChantingSpeed
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CharacterBaseData).GetMethod(nameof(CharacterBaseData.SetChargeing), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref CharacterBaseData __instance, out float __state)
	{
		__state = __instance.g_fDeltaTime;
		__instance.g_fDeltaTime *= LittleModNobetaPlugin.configChantingSpeedMultiplier.Value;
		return true;
	}

	[HarmonyPostfix]
	public static void Postfix(ref CharacterBaseData __instance, float __state)
	{
		__instance.g_fDeltaTime = __state;
		return;
	}
}