using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TopDownShooer.Network;
using System;
using UnityEngine.SceneManagement;

namespace TopDownShooer
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Manager/ScriptableSceneManager")]
    public class ScriptableSceneManager : AbstractScriptableManager<ScriptableSceneManager>
    {
        [SerializeField] private string _menuScene;
        [SerializeField] private string _gameScene;

        public override void Initialize()
        {
            base.Initialize();
            SceneManager.LoadScene(_menuScene);
            MessageBroker.Default.Receive<EventPlayerNetworkStateChange>().Subscribe(OnPlayerNetworkState).AddTo(_compositeDisposable);
        }

        public override void Destroy()
        {
            base.Destroy();
        }

        private void OnPlayerNetworkState(EventPlayerNetworkStateChange obj)
        {
            Debug.Log("network state change on scene manager to : " + obj.PlayerNetworkState);
            switch (obj.PlayerNetworkState)
            {
                case PlayerNetworkState.Offline:
                    break;
                case PlayerNetworkState.Connecting:
                    break;
                case PlayerNetworkState.Connected:
                    break;
                case PlayerNetworkState.JoiningRoom:
                    break;
                case PlayerNetworkState.InRoom:
                    PhotonNetwork.isMessageQueueRunning = false;
                    SceneManager.LoadScene(_gameScene);
                    break;
                default:
                    break;
            }
        }
    }
}

