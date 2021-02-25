using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    [SerializeField] private InputData _inputData;
    [SerializeField] private Transform _tower;
    void Update()
    {
        // _tower.Rotate(0, _inputData.Horizontal, Space.Self);
    }
}
