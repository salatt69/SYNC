using BepInEx;
using HarmonyLib;
using SYNClib.Core;
using System;
using UnityEngine;

namespace SYNClib
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    internal class Plugin : BaseUnityPlugin
    {
        public const string PluginGUID = "com." + PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "salattwav";
        public const string PluginName = "SYNClib";
        public const string PluginVersion = "0.0.0";

        internal static Plugin Instance;
        internal static Harmony Harmony;

        internal static bool LogBeats = false;

        public void Awake()
        {
            Instance = this;

            Log.Init(Logger);

            Log.Info("SYNClib initializing...");

            Harmony = new Harmony(PluginGUID);
            Harmony.PatchAll();

            try
            {
                var go = new GameObject("SYNClib_MusicSyncRunner")
                {
                    hideFlags = HideFlags.HideAndDontSave
                };
                go.AddComponent<MusicSyncRunner>();
                DontDestroyOnLoad(go);
            }
            catch (Exception e)
            {
                Log.Warning($"Failed to create MusicSyncRunner: {e}");
            }

            Log.Info("SYNClib initialized!");
        }
    }
}
