using Models.Runes;
using UnityEngine;

namespace Models.States
{
    public class OrdinaryRuneActivationState : OrdinaryRuneState
    {
        private Vector3 m_startDirection = Vector3.zero;

        private float m_passedAngle = 0f;
        private float m_lastAngle = 0;

        private const float TARGET_ANGLE = 360f;

        public OrdinaryRuneActivationState(Vector3 startDirection, CharacterModel character, float minActivationDistance) : base(character, minActivationDistance)
        {
            m_startDirection = startDirection.normalized;
        }

        public override bool HandleActivation()
        {
            Vector3 direction = m_characterModel.transform.position - m_runeOfOrdinary.transform.position;
            
            HandleDistance(direction);
            HandleTargetAngle(direction);
            
            if (m_passedAngle >= TARGET_ANGLE)
            {
                return true;
            }

            return false;
        }

        private void HandleDistance(Vector3 direction)
        {
            float distance = direction.magnitude;

            if (distance > m_minActivationDistance)
            {
                m_runeOfOrdinary.SetState(new OrdinaryRuneIdleState(m_characterModel, m_minActivationDistance));
            }
        }

        private void HandleTargetAngle(Vector3 direction)
        {
            float angle = Vector3.Angle(direction, m_startDirection);
            float difference = angle - m_lastAngle;
            
            m_passedAngle += Mathf.Abs(difference);
            m_lastAngle = angle;
        }

    }
}