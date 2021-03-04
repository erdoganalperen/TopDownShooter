using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.PlayerInput
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        public float Horizontal;
        public float Vertical;
        public bool IsJump;

        [Header("Axis Base Control")]
        [SerializeField] private bool _axisActive;
        [SerializeField] private string AxisNameHorizontal;
        [SerializeField] private string AxisNameVertical;

        [Header("Key Base Control")]
        [SerializeField] private bool _keyBaseHorizonalActive;
        [SerializeField] private KeyCode PositiveHorizontalKeyCode;
        [SerializeField] private KeyCode NegativeHorizontalKeyCode;
        [SerializeField] private bool _keyBaseVerticalActive;
        [SerializeField] private KeyCode PositiveVerticalKeyCode;
        [SerializeField] private KeyCode NegativeVerticalKeyCode;
        [SerializeField] private float _increaseAmount = .05f;


        public void ProcessInput()
        {
            if (_axisActive)
            {
                Horizontal = Input.GetAxis(AxisNameHorizontal);
                Vertical = Input.GetAxis(AxisNameVertical);
            }
            else
            {
                if (_keyBaseHorizonalActive)
                {
                    KeyBaseAxisControl(ref Horizontal, PositiveHorizontalKeyCode, NegativeHorizontalKeyCode);
                }
                if (_keyBaseVerticalActive)
                {
                    KeyBaseAxisControl(ref Vertical, PositiveVerticalKeyCode, NegativeVerticalKeyCode);
                }
            }
        }
        private void KeyBaseAxisControl(ref float value, KeyCode positive, KeyCode negative)
        {

            bool positiveActive = Input.GetKey(positive);
            bool negativeActive = Input.GetKey(negative);
            if (positiveActive)
            {
                Debug.Log("test");
                value += _increaseAmount;
            }
            else if (negativeActive)
            {
                value -= _increaseAmount;

            }
            else
            {
                value = 0;
            }
            value = Mathf.Clamp(value, -3, 3);
        }

    }
}