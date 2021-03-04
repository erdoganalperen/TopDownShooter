using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Inventory/Player Inventory Canon Item Data")]
    public class PlayerInventoryCanonItemData : AbstractPlayerInventoryItemData<PlayerInventoryCanonItemMono>
    {
        [SerializeField] private float _damage;
        public float Damage { get { return _damage; } }
        [SerializeField] private float _rpm = 1f;
        public float RPM { get { return _rpm; } }
        private float _lastShootTime;
        public override void Initialize(PlayerInventoryController targetPlayerIventory)
        {
            base.Initialize(targetPlayerIventory);
            InstantiateAndInitializePrefab(targetPlayerIventory.CanonParent);
            targetPlayerIventory.ReactiveShootCommand.Subscribe(onReactiveShootCommand).AddTo(_compositDisposable);
            Debug.Log("canonitemdata");
        }

        private void onReactiveShootCommand(Unit obj)
        {
            Debug.Log("reactive commannd shoot");
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
                _instantiated.Shoot();
                _lastShootTime = Time.time;
            }
            else
            {
                Debug.Log("cant shoot now");
            }
        }
    }
}
