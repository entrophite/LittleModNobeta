using System;
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
public class NoHitTakenRecoverySkyDamagedFlyStart
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(PlayerController).GetMethod(nameof(PlayerController.SkyDamagedFlyStart), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
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

[HarmonyPatch]
public class NoHitTakenRecoveryHighlyLand
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(MoveController).GetMethod(nameof(MoveController.Update), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPostfix]
	public static void Postfix(ref MoveController __instance)
	{
		if (LittleModNobetaPlugin.configNoHitTakenRecovery.Value)
			// patching GetHeightLand() should be the direct way to do, but that causes crashing during patching
			// instead, try exploit the GetHeightLand() logic, to lock the verticalForce being always greater than fallSpeedMax (since both are negative values)
			__instance.verticalForce = Math.Max(__instance.verticalForce, __instance.fallSpeedMax * 0.99f);
		return;
	}
}