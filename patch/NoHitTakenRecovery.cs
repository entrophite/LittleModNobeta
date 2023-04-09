using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class NoHitTakenRecoveryDamagedStart
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(PlayerController).GetMethod(nameof(PlayerController.DamagedStart), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix()
	{
		return !LittleModNobetaPlugin.configNoHitTakenRecovery.Value;
	}
}

[HarmonyPatch]
public class NoHitTakenRecoveryDamagedFlyStart
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(PlayerController).GetMethod(nameof(PlayerController.DamagedFlyStart), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix()
	{
		return !LittleModNobetaPlugin.configNoHitTakenRecovery.Value;
	}
}

[HarmonyPatch]
public class NoHitTakenRecoveryDamagedLandStart
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(PlayerController).GetMethod(nameof(PlayerController.DamagedLandStart), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix()
	{
		return !LittleModNobetaPlugin.configNoHitTakenRecovery.Value;
	}
}