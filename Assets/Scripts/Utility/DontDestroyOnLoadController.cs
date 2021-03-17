using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooer.Utility
{
    public class DontDestroyOnLoadController : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}