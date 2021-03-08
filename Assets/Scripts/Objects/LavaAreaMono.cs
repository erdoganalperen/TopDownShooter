using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Inventory;
using TopDownShooter.Stat;
using UnityEngine;

namespace TopDownShooter.Objects
{
    public class LavaAreaMono : MonoBehaviour, IDamage
    {
        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }

        [Range(0.1f, 2)]
        [SerializeField] private float _armorPen;
        public float ArmorPenetration { get { return _armorPen; } }

        [SerializeField] private float _timeBasedDamage;
        public float TimeBasedDamage { get { return _timeBasedDamage; } }

        [SerializeField] private float _timeBasedDamageDuration = 3;
        public float TimeBasedDamageDuration { get { return _timeBasedDamageDuration; } }

        private void OnTriggerEnter(Collider collider)
        {
            int colliderInstanceId = collider.GetInstanceID();
            if (DamagebleHelper.DamagebleList.ContainsKey(colliderInstanceId))
            {
                DamagebleHelper.DamagebleList[colliderInstanceId].Damage(this);
            }
        }
    }
}