using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class SoulPickupEffect
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(WizardGirlManage).GetMethod(nameof(WizardGirlManage.SetReceiveSoul), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref float Quality)
	{
		Quality *= LittleModNobetaPlugin.configSoulPickupEffectMultiplier.Value;
		return true;
	}
}