using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Inventory/Player Inventory Canon Item Data")]
    public class PlayerInventoryCanonItemData : AbstractPlayerInventoryItemData<PlayerInventoryCanonItemMono>, IDamage
    {
        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }

        [SerializeField] private float _rpm = 1f;
        public float RPM { get { return _rpm; } }

        [Range(0.1f, 2)]
        [SerializeField] private float _armorPen;
        public float ArmorPenetration { get { return _armorPen; } }

        [SerializeField] private float _timeBasedDamage;
        public float TimeBasedDamage { get { return _timeBasedDamage; } }

        [SerializeField] private float _timeBasedDamageDuration = 3;
        public float TimeBasedDamageDuration { get { return _timeBasedDamageDuration; } }

        private float _lastShootTime;
        public override void Initialize(PlayerInventoryController targetPlayerIventory)
        {
            base.Initialize(targetPlayerIventory);
            InstantiateAndInitializePrefab(targetPlayerIventory.CanonParent);
            targetPlayerIventory.ReactiveShootCommand.Subscribe(onReactiveShootCommand).AddTo(_compositDisposable);
        }

        private void onReactiveShootCommand(Unit obj)
        {
            Shoot();
        }

        public override void Destroy()
        {
            base.Destroy();
        }
        public void Shoot()
        {
            if (Time.time - _lastShootTime > _rpm)
            {
                _instantiated.Shoot(this);
                _lastShootTime = Time.time;
            }
            else
            {
                Debug.Log("cant shoot now");
            }
        }
    }
}
