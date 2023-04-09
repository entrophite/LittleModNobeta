using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class LockState
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(WizardGirlManage).GetMethod(nameof(WizardGirlManage.Update), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref WizardGirlManage __instance)
	{
		var base_data = __instance.GetCharacterBaseData();

		if (LittleModNobetaPlugin.configLockHP.Value)
			base_data.g_fHP = base_data.g_fHPMax;

		if (LittleModNobetaPlugin.configLockMana.Value)
			base_data.g_fMP = base_data.g_fMPMax;

		if (LittleModNobetaPlugin.configLockStamina.Value)
			base_data.g_fSP = base_data.g_fSPMax;

		return true;
	}
}