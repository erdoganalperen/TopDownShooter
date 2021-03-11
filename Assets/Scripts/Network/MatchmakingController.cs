using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace TopDownShooer.Network
{
    public enum PlayerNetworkState { Offline, Connecting, Connected, JoiningRoom, InRoom }
    public class MatchmakingController : Photon.PunBehaviour
    {
        public static MatchmakingController Instance;
        private float _delayToConnect = 1;
        private const string _networkVersion = "v1.0";
        private void Awake()
        {
            Instance = this;


        }
        IEnumerator Start()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Offline));
            yield return new WaitForSeconds(_delayToConnect);
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connecting));
            PhotonNetwork.ConnectUsingSettings(_networkVersion);
        }

        public void JoinRandomRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.JoiningRoom));
            PhotonNetwork.JoinRandomRoom();
        }

        public void CreateRoom()
        {
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.JoiningRoom));
            PhotonNetwork.CreateRoom(null);
        }
        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connected));
        }
        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.InRoom));
        }
        public override void OnLeftRoom()
        {
            base.OnLeftRoom();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Connected));
        }
        public override void OnDisconnectedFromPhoton()
        {
            base.OnDisconnectedFromPhoton();
            MessageBroker.Default.Publish(new EventPlayerNetworkStateChange(PlayerNetworkState.Offline));
        }
        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Debug.Log("joined lobby");
        }
    }

}


