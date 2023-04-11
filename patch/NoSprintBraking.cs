using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class NoSprintBraking
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(NobetaInputData).GetMethod(nameof(NobetaInputData.NeedBraking), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfit(ref bool __result)
	{
		__result &= (!LittleModNobetaPlugin.configNoSprintBraking.Value);
		return;
	}
}

