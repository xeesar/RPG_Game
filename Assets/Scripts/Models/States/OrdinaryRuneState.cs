using Models.Runes;

namespace Models.States
{
    public abstract class OrdinaryRuneState
    {
        protected RuneOfOrdinary m_runeOfOrdinary;
        protected float m_minActivationDistance;
        protected CharacterModel m_characterModel;

        protected OrdinaryRuneState(CharacterModel character, float minActivationDistance)
        {
            m_minActivationDistance = minActivationDistance;
            m_characterModel = character;
        }

        public virtual void OnStateEnter(RuneOfOrdinary runeOfOrdinary)
        {
            m_runeOfOrdinary = runeOfOrdinary;
        }
        
        public abstract bool HandleActivation();
    }
}