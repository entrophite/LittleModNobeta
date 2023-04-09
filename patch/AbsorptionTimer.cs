using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class AbsorptionTimer
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(NobetaRuntimeData).GetMethod(nameof(NobetaRuntimeData.FillAbsorbTimer), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref NobetaRuntimeData __instance)
	{
		__instance.absorbTimer = LittleModNobetaPlugin.configAbsorptionTimerSec.Value;
		return;
	}
}