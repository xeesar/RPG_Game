using Interfaces;
using Models.States;
using UnityEngine;
using Zenject;

namespace Models.Runes
{
    public class RuneOfOrdinary : Rune
    {
        [Header("Options")]
        [SerializeField] private float m_minDistanceToActivate = 5f;
        
        [Inject] private IUpdateManager m_updateManager = null;
        [Inject] private CharacterModel m_characterModel = null;

        private OrdinaryRuneState m_currentState = null;
        
        public void SetState(OrdinaryRuneState newState)
        {
            m_currentState = newState;
            m_currentState.OnStateEnter(this);
        }

        protected override void OnReset()
        {
            base.OnReset();
            
            SetState(new OrdinaryRuneIdleState(m_characterModel, m_minDistanceToActivate));
        }

        private void Start()
        {
            m_updateManager.EventOnUpdate += OnUpdate;
            
            SetState(new OrdinaryRuneIdleState(m_characterModel, m_minDistanceToActivate));
        }

        private void OnDestroy()
        {
            m_updateManager.EventOnUpdate -= OnUpdate;
        }

        private void OnUpdate(float deltaTime)
        {
            if(IsActivated || !IsPossibleToActivateRune) return;

            bool isActivated = m_currentState.HandleActivation();

            if (isActivated)
            {
                IsPossibleToActivateRune = false;
                OnActivated();
            }
        }
    }
}