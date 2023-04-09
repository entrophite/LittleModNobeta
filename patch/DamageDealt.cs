using System.Reflection;
using HarmonyLib;

namespace LittleModNobeta.Patch;

[HarmonyPatch]
public class DamageDealt
{
	[HarmonyTargetMethod]
	public static MethodBase TargetMethod()
	{
		return typeof(NPCManage).GetMethod(nameof(NPCManage.Hit), BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
	}

	[HarmonyPrefix]
	public static bool Prefix(ref AttackData Data, out float __state)
	{
		// LittleModNobetaPlugin.Log.LogInfo("player dealt: " + Data.g_fStrength + ", " + Data.name);
		// some AttackData instances seems to be static/shared
		// we need to restore g_fStrength back to its original value to avoid exponentially changing it
		__state = Data.g_fStrength;
		Data.g_fStrength *= LittleModNobetaPlugin.configDamageDealtMultiplier.Value;
		return true;
	}

	[HarmonyPostfix]
	public static void Postfix(ref AttackData Data, float __state)
	{
		Data.g_fStrength = __state;
		return;
	}
}