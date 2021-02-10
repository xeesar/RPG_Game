using Models.Runes;
using UnityEngine;

namespace Models.States
{
    public class OrdinaryRuneIdleState : OrdinaryRuneState
    {
        public OrdinaryRuneIdleState(CharacterModel character, float minActivationDistance) : base(character, minActivationDistance)
        {
            
        }

        public override void OnStateEnter(RuneOfOrdinary runeOfOrdinary)
        {
            base.OnStateEnter(runeOfOrdinary);

            m_runeOfOrdinary.IsPossibleToActivateRune = true;
        }

        public override bool HandleActivation()
        {
            Vector3 direction = m_characterModel.transform.position - m_runeOfOrdinary.transform.position;
            float distance = direction.magnitude;

            if (distance <= m_minActivationDistance)
            {
                Vector3 startDirection = direction;
                startDirection.y = 0;
                m_runeOfOrdinary.SetState(new OrdinaryRuneActivationState(startDirection, m_characterModel, m_minActivationDistance));
            }

            return false;
        }
    }
}