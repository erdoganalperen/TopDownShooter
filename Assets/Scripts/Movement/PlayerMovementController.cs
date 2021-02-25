using System.Collections;
using System.Collections.Generic;
using TopDownShooter.PlayerInput;
using UnityEngine;

namespace TopDownShooter.PlayerMovement
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private InputData _inputData;
        [SerializeField] private PlayerMovementSettings _movementSettings;

        private void Update()
        {

            _rigidbody.MovePosition(_rigidbody.position + _rigidbody.transform.forward * _inputData.Vertical * _movementSettings.VerticalSpeed);
            _rigidbody.MovePosition(_rigidbody.position + _rigidbody.transform.right * _inputData.Horizontal * _movementSettings.HorizontalSpeed);
            if (_inputData.IsJump)
            {
                _rigidbody.AddForce(Vector3.up * _movementSettings.JumpForce, ForceMode.Impulse);
            }
        }
    }
}
