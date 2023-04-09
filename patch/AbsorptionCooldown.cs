using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class AbsorptionCooldown
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(NobetaRuntimeData).GetMethod(nameof(NobetaRuntimeData.FillAbsorbCDTimer), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref NobetaRuntimeData __instance)
	{
		__instance.absorbCDTimer = LittleModNobetaPlugin.configAbsorptionCooldownSec.Value;
		return;
	}
}