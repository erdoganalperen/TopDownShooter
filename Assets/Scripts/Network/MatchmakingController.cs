using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooer.Network
{
    public enum PlayerNetworkState { None, Offline, Connecting, Connected, JoiningRoom, InRoom }
    public class MatchmakingController : Photon.PunBehaviour
    {
        private PlayerNetworkState _currentNetworkState = PlayerNetworkState.None;
        public PlayerNetworkState CurrentNetworkState
        {
            get
            {
                return _currentNetworkState;
            }
            private set
            {
                bool sendEvent = false;
                if (value != _currentNetworkState)
                {
                    sendEvent = true;
                }
                _currentNetworkState = value;
                if (sendEvent)
                {
                    MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(_currentNetworkState));
                }
            }
        }
        public static MatchmakingController Instance;
        private float _delayToConnect = 1;
        private const string _networkVersion = "v1.0";
        private void Awake()
        {
            Instance = this;
            PhotonNetwork.CacheSendMonoMessageTargets(typeof(MatchmakingController));
        }
        IEnumerator Start()
        {
            CurrentNetworkState = PlayerNetworkState.Offline;
            yield return new WaitForEndOfFrame();
            CurrentNetworkState = PlayerNetworkState.Connecting;
            PhotonNetwork.ConnectUsingSettings(_networkVersion);
        }

        public void JoinRandomRoom()
        {
            CurrentNetworkState = PlayerNetworkState.JoiningRoom;
            PhotonNetwork.JoinRandomRoom();
        }

        public void CreateRoom()
        {
            CurrentNetworkState = PlayerNetworkState.JoiningRoom;
            PhotonNetwork.CreateRoom(null);
        }
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            CurrentNetworkState = PlayerNetworkState.Connected;
        }
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            CurrentNetworkState = PlayerNetworkState.InRoom;
            PhotonNetwork.isMessageQueueRunning = false;
        }
        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            CurrentNetworkState = PlayerNetworkState.Connected;
        }
        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();
            CurrentNetworkState = PlayerNetworkState.Offline;
        }
        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("joined lobby");
        }
    }

}


