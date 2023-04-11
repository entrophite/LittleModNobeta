using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace LittleModNobeta
{
	[BepInPlugin("little-mod-nobeta", "LittleModNobeta", "1.1")]
	public class LittleModNobetaPlugin : BepInEx.Unity.IL2CPP.BasePlugin
	{
		internal static new BepInEx.Logging.ManualLogSource Log;
		// config entries
		internal static ConfigEntry<bool> configLockHP;
		internal static ConfigEntry<bool> configLockMana;
		internal static ConfigEntry<bool> configLockStamina;
		internal static ConfigEntry<float> configSoulPickupEffectMultiplier;
		internal static ConfigEntry<float> configChantingSpeedMultiplier;
		internal static ConfigEntry<bool> configNoShootingCooldown;
		internal static ConfigEntry<float> configAbsorptionTimerSec;
		internal static ConfigEntry<float> configAbsorptionCooldownSec;
		internal static ConfigEntry<float> configDamageDealtMultiplier;
		internal static ConfigEntry<float> configDamageTakenMultiplier;
		internal static ConfigEntry<bool> configInfiniteMidAirJump;
		internal static ConfigEntry<bool> configInfiniteMidAirDodge;
		internal static ConfigEntry<bool> configNoSprintBraking;
		internal static ConfigEntry<bool> configNoHitTakenRecovery;

		public override void Load()
		{
			LittleModNobetaPlugin.Log = base.Log;
			LoadConfigs();

			var harmony = new Harmony("little-mod-nobeta.harmony");
			harmony.PatchAll();

			return;
		}

		internal void LoadConfigs()
		{
			configLockHP = Config.Bind("GENERAL",
				"lock_hp",
				false,
				"lock HP at maximum");
			configLockMana = Config.Bind("GENERAL",
				"lock_mana",
				false,
				"lock Mana at maximum");
			configLockStamina = Config.Bind("GENERAL",
				"lock_stamina",
				false,
				"lock Stamina at maximum");
			configSoulPickupEffectMultiplier = Config.Bind("GENERAL",
				"soul_pickup_effect_multiplier",
				1f,
				"multiply HP/Mana/Chanting/Currency gain by this value, 1 means unchanged");
			configNoShootingCooldown = Config.Bind("GENERAL",
				"no_shooting_cooldown",
				false,
				"remove shooting/magic cooldown");
			configChantingSpeedMultiplier = Config.Bind("GENERAL",
				"chanting_speed_multiplier",
				1f,
				"multiply spell chanting speed by this value, 1 means unchanged");
			configAbsorptionTimerSec = Config.Bind("GENERAL",
				"absorption_timer_sec",
				0.15f,
				"grace time to trigger Magic Absorption in seconds, original value is 0.15");
			configAbsorptionCooldownSec = Config.Bind("GENERAL",
				"absorption_cooldown_sec",
				1f,
				"cooldown between Magic Absorption triggerings in seconds, original value is 1");
			configDamageDealtMultiplier = Config.Bind("GENERAL",
				"damage_dealt_multiplier",
				1f,
				"multiply damage dealt to enemies by this value, 1 means unchanged");
			configDamageTakenMultiplier = Config.Bind("GENERAL",
				"damage_taken_multiplier",
				1f,
				"multiply damage taken by this value, 1 means unchanged");
			configInfiniteMidAirJump = Config.Bind("GENERAL",
				"infinite_mid_air_jump",
				false,
				"allow infinite use of mid-air jump");
			configInfiniteMidAirDodge = Config.Bind("GENERAL",
				"infinite_mid_air_dodge",
				false,
				"allow infinite use of mid-air dodge");
			configNoSprintBraking = Config.Bind("GENERAL",
				"no_sprint_braking",
				false,
				"remove sprint braking animation");
			configNoHitTakenRecovery = Config.Bind("GENERAL",
				"no_hit_taken_recovery",
				false,
				"remove control recovery penalty after taking hit");
			return;
		}
	}
}
