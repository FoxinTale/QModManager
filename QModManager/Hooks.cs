﻿using Harmony;
using UnityEngine.SceneManagement;

namespace QModManager
{
    public class Hooks
    {
        public static Delegates.Awake Awake;
        public static Delegates.OnLoadEnd OnLoadEnd;
        public static Delegates.SceneLoaded SceneLoaded;
        public static Delegates.Start Start;
        public static Delegates.FixedUpdate FixedUpdate;
        public static Delegates.Update Update;
        public static Delegates.LateUpdate LateUpdate;
        public static Delegates.OnApplicationQuit OnApplicationQuit;

        internal static void Patch()
        {
            HarmonyInstance.Create("qmodmanager.subnautica").PatchAll();
            SceneManager.sceneLoaded += (scene, loadSceneMode) => SceneLoaded(scene, loadSceneMode);
        }

        internal static class Patches
        {
            [HarmonyPatch(typeof(GameInput), "Awake")]
            internal static class Awake
            {
                [HarmonyPostfix]
                internal static void Postfix()
                {
                    Awake();
                }
            }

            [HarmonyPatch(typeof(), "Start")]
            internal static class Start
            {
                [HarmonyPostfix]
                internal static void Postfix()
                {
                    Start();
                }
            }

            [HarmonyPatch(typeof(), "FixedUpdate")]
            internal static class FixedUpdate
            {
                [HarmonyPostfix]
                internal static void Postfix()
                {
                    FixedUpdate();
                }
            }

            [HarmonyPatch(typeof(GameInput), "Update")]
            internal static class Update
            {
                [HarmonyPostfix]
                internal static void Postfix()
                {
                    Update();
                }
            }

            [HarmonyPatch(typeof(), "LateUpdate")]
            internal static class LateUpdate
            {
                [HarmonyPostfix]
                internal static void Postfix()
                {
                    LateUpdate();
                }
            }

            [HarmonyPatch(typeof(), "OnApplicationQuit")]
            internal static class OnApplicationQuit
            {
                [HarmonyPostfix]
                internal static void Postfix()
                {
                    OnApplicationQuit();
                }
            }
        }

        public class Delegates
        {
            public delegate void Awake();
            public delegate void OnLoadEnd();
            public delegate void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode);
            public delegate void Start();
            public delegate void FixedUpdate();
            public delegate void Update();
            public delegate void LateUpdate();
            public delegate void OnApplicationQuit();
        }
    }
}
