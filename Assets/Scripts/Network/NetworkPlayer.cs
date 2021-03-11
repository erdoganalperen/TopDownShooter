using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooer.Network
{
    public class NetworkPlayer : Photon.PunBehaviour
    {
        [SerializeField] private PhotonView[] _photonViewsForOwnership;
        public void SetOwnership(PhotonPlayer photonPlayer)
        {
            for (int i = 0; i < _photonViewsForOwnership.Length; i++)
            {
                _photonViewsForOwnership[i].TransferOwnership(photonPlayer);
            }
        }
    }
}
