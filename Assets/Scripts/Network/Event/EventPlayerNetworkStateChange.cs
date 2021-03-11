using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooer.Network
{
    public struct EventPlayerNetworkStateChange
    {

        public PlayerNetworkState PlayerNetworkState;

        public EventPlayerNetworkStateChange(PlayerNetworkState playerNetworkState)
        {
            PlayerNetworkState = playerNetworkState;
        }
    }
}