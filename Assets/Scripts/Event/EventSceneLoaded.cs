using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooer
{
    public struct EventSceneLoaded
    {
        public string SceneName;
        public EventSceneLoaded(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}