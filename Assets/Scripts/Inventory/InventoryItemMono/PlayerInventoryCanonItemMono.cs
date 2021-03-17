using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    public class PlayerInventoryCanonItemMono : AbstractPlayerInventoryItemMono
    {
        [SerializeField] private Transform _canonShootPoint;
        public void Shoot(IDamage damage, int shooterId)
        {
            ScriptableShootManager.Instance.Shoot(_canonShootPoint.position, _canonShootPoint.forward, damage, shooterId);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(_canonShootPoint.position, .1f);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_canonShootPoint.position, _canonShootPoint.position + _canonShootPoint.forward * 10);
        }
    }
}