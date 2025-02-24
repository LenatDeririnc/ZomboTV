﻿using System.Collections.Generic;
using ScriptableObjects.Scenes;
using UnityEngine;

namespace Managers.Data
{
    public static class SceneDataManager
    {
        private static SceneInfo currentSceneInfo;
        public static SceneInfo CurrentSceneInfo() => currentSceneInfo;
        public static void SetCurrentSceneInfo(SceneInfo newSceneInfo) => currentSceneInfo = newSceneInfo;

        private static Dictionary<string, Dictionary<string, object>> m_sceneData;

        public static object SceneValue(string sceneName, string valueName)
        {
            m_sceneData ??= new Dictionary<string, Dictionary<string, object>>();
            
            if (m_sceneData.ContainsKey(sceneName))
                if (m_sceneData[sceneName].ContainsKey(valueName))
                    return m_sceneData[sceneName][valueName];

            Debug.Log("unacceptable sceneName or valueName information: " +
                             $"SceneDataProvider doesn't has scene: {sceneName} and value: {valueName}");
            return null;
        }

        public static void SetSceneValue(string sceneName, string valueName, object value)
        {
            m_sceneData ??= new Dictionary<string, Dictionary<string, object>>();
            
            if (!m_sceneData.ContainsKey(sceneName))
                m_sceneData[sceneName] = new Dictionary<string, object>();

            m_sceneData[sceneName][valueName] = value;
        }
    }
}