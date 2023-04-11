using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class NoShootingCooldown
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(CharacterBaseData).GetMethod(nameof(CharacterBaseData.SetCDAdd), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref CharacterBaseData __instance)
	{
		if (LittleModNobetaPlugin.configNoShootingCooldown.Value)
		{
			__instance.g_fCDNull = 100;
			__instance.g_fCDIce = 100;
			__instance.g_fCDFire = 100;
			__instance.g_fCDLightning = 100;
		}
		return;
	}
}
