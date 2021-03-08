using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Stat;
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
        public void Shoot(Vector3 origin, Vector3 direction, IDamage damage)
        {
            RaycastHit hit;
            var physic = Physics.Raycast(origin, direction, out hit);
            if (physic)
            {
                int colliderInstanceId = hit.collider.GetInstanceID();
                if (DamagebleHelper.DamagebleList.ContainsKey(colliderInstanceId))
                {
                    DamagebleHelper.DamagebleList[colliderInstanceId].Damage(damage);
                }
            }
        }
    }
}