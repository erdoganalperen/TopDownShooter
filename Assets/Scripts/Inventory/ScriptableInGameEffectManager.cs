using System;
using System.Collections;
using System.Collections.Generic;
using TopDownShooer.Inventory;
using UniRx;
using UnityEngine;

namespace TopDownShooter.Inventory
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Inventory/ScriptableEffectManager")]

    public class ScriptableInGameEffectManager : AbstractScriptableManager<ScriptableInGameEffectManager>
    {
        [SerializeField] private GameObject _playerShootEffect;
        public override void Initialize()
        {
            MessageBroker.Default.Receive<EventPlayerShoot>().Subscribe(OnPlayerShoot).AddTo(_compositeDisposable);
        }

        private void OnPlayerShoot(EventPlayerShoot obj)
        {
            Instantiate(_playerShootEffect, obj.Origin, Quaternion.identity);
        }
    }

}
