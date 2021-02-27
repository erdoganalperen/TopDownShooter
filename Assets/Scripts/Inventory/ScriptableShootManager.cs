using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Inventory/ScriptableShootManager")]
    public class ScriptableShootManager : AbstractScriptableManager<ScriptableShootManager>
    {
        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("scriptableshoot manager activated");
        }
        private void OnDestroy()
        {
            base.Destroy();
            Debug.Log("scriptableshoot manager destroyed");
        }
        public void Shoot()
        {
        }
    }
}