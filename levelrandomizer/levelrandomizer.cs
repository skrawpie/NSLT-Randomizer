using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using BepInEx;
using HarmonyLib;
using Playful.SuperLucky.Sequences;
using UnityEngine;
using BepInEx.Logging;
using Playful.SuperLucky.Gameplay.Player;
using Playful.SuperLucky.Gameplay.Motors.Player;

namespace levelrandomizer
{
    [BepInPlugin("com.skrawpie.levelrandomizer", "Level Randomizer", "1.0.0.0")]
    public class LevelRandomizerPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            var harmony = new Harmony("com.skrawpie.levelrandomizer");
            harmony.PatchAll();
            Logger.LogInfo("Level Randomizer loaded successfully!");
        }
    }

    [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.DoubleJump))]
    public class RemoveDoubleJump
    {
        public static bool Prefix()
        {
            return false;
        }
    }
    
    // TODO figure out how to allow the palyer to still use spring boards, if possible.
    [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.Jump), new Type[] { typeof(Vector3), typeof(bool) })]
    public class RemoveJump
    {
        public static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.SpinJump))]
    public class RemoveSpinJump
    {
        public static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerController), nameof(PlayerController.TailSwipe))]
    public class RemoveTailSwipe
    {
        public static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerBurrowMotor), "BeginBurrow")]
    public class RemoveBurrow
    {
        public static bool Prefix()
        {
            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerDiveMotor), "Start")]
    public class RemoveDive
    {
        public static bool Prefix()
        {
            return false;
        }
    }
}