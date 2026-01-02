using System.Linq;
using UnityEditor;
using UnityEngine;

namespace StarterAssets
{
    public partial class StarterAssetsDeployMenu : ScriptableObject
    {
        // prefab paths
        private const string StarterAssetsPath = "Assets/StarterAssets";
        private const string ThirdPersonPrefabPath = "/ThirdPersonController/Prefabs/";
        private const string PlayerArmaturePrefabName = "PlayerArmature";
        private const string PlayerCapsulePrefabName = "PlayerCapsule";
        private const string PlayerTag = "Player";
        private const string MenuRoot = "Starter Assets";

#if STARTER_ASSETS_PACKAGES_CHECKED
        /// <summary>
        /// Check the Armature, main camera, cinemachine virtual camera, camera target and references
        /// </summary>
        [MenuItem(MenuRoot + "/Reset Third Person Controller Armature", false)]
        static void ResetThirdPersonControllerArmature()
        {
            var thirdPersonControllers = Object.FindObjectsByType<ThirdPersonController>(FindObjectsSortMode.None);
            var player = thirdPersonControllers.FirstOrDefault(controller => controller.GetComponent<Animator>() && controller.CompareTag(PlayerTag));
            GameObject playerGameObject;

            // player
            if (player == null)
                HandleInstantiatingPrefab(StarterAssetsPath + ThirdPersonPrefabPath,
                    PlayerArmaturePrefabName, out playerGameObject);
            else
                playerGameObject = player.gameObject;

            // cameras
            CheckCameras(ThirdPersonPrefabPath, playerGameObject.transform);
        }

        [MenuItem(MenuRoot + "/Reset Third Person Controller Capsule", false)]
        static void ResetThirdPersonControllerCapsule()
        {
            var thirdPersonControllers = Object.FindObjectsByType<ThirdPersonController>(FindObjectsSortMode.None);
            var player = thirdPersonControllers.FirstOrDefault(controller => !controller.GetComponent<Animator>() && controller.CompareTag(PlayerTag));
            GameObject playerGameObject;

            // player
            if (player == null)
                HandleInstantiatingPrefab(StarterAssetsPath + ThirdPersonPrefabPath,
                    PlayerCapsulePrefabName, out playerGameObject);
            else
                playerGameObject = player.gameObject;

            // cameras
            CheckCameras(ThirdPersonPrefabPath, playerGameObject.transform);
        }

        // Вам также понадобятся эти вспомогательные методы:
        static void HandleInstantiatingPrefab(string path, string prefabName, out GameObject gameObject)
        {
            // Реализация загрузки и инстанцирования префаба
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path + prefabName + ".prefab");
            gameObject = prefab != null ? PrefabUtility.InstantiatePrefab(prefab) as GameObject : new GameObject(prefabName);
        }

        static void CheckCameras(string prefabPath, Transform playerTransform)
        {
            // Реализация проверки и настройки камер
            // Эта логика должна быть определена в вашем проекте
        }
#endif
    }
}