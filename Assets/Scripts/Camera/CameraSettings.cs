using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.Camera
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Camera/Camera Settings")]
    public class CameraSettings : ScriptableObject
    {
        [Header("Rotation")]
        [SerializeField] private float _lerpSpeed = 1;
        public float RotationLerpSpeed { get { return _lerpSpeed; } }

        [Header("Position")]
        [SerializeField] private Vector3 _positionOffset;
        public Vector3 PositionOffset { get { return _positionOffset; } }
        [SerializeField] private float _positionSpeed = 1;
        public float PositionLerp { get { return _positionSpeed; } }
    }
}

