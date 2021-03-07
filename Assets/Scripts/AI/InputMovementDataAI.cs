using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter.AI
{
    [CreateAssetMenu(menuName = "TopDown Shooter/Input/AI/Movement Input Data")]
    public class InputMovementDataAI : InputDataAI
    {
        public override void ProcessInput()
        {
            float distance = Vector3.Distance(_targetTransform.position, _currentTarget);
            if (distance > 3)
            {
                Vertical = 1;
            }
            else
            {
                Vertical = 0;
            }
            Vector3 dir = _currentTarget - _targetTransform.position;

            var rotation = Quaternion.LookRotation(dir, Vector3.up).eulerAngles;

            if (rotation.y > 360)
            {
                rotation.y = 360 - rotation.y;
            }

            var rotationGap = rotation.y - _targetTransform.rotation.eulerAngles.y;

            bool isGapNegative = rotationGap < 0;

            if (Mathf.Abs(rotationGap) > 5)
            {
                float horizontalClamp = Mathf.Clamp(Mathf.Abs(rotationGap / 180), -1, 1);
                Horizontal = horizontalClamp;
            }
            else
            {
                Horizontal = 0;
            }
        }
    }
}
