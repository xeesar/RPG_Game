using System;
using Behaviours.CameraBehaviours;
using Interfaces;
using UnityEngine;
using View;
using Zenject;
using Random = UnityEngine.Random;

namespace Models
{
    public class CharacterModel : MonoBehaviour
    {
        public event Action EventOnAttacked;
        
        [Header("Components")]
        [SerializeField] private CharacterView m_characterView = null;
        
        [Header("Options")]
        [SerializeField] private Vector3 m_cameraOffset = Vector3.zero;
        [SerializeField] private float m_accelerationDuration = 1f;

        [Inject] private ICameraManager m_cameraManager = null;
        [Inject] private IInputManager m_inputManager = null;
        [Inject] private IUpdateManager m_updateManager = null;

        public bool IsMoving => m_accelerationTime / m_accelerationDuration > 0;

        private float m_accelerationTime = 0f;

        private void Start()
        {
            m_cameraManager.SetBehaviour(new ChaseCameraBehaviour(transform, m_cameraOffset));
            
            m_inputManager.EventOnAttacked += OnAttack;
            m_inputManager.EventOnStrongAttacked += OnStrongAttack;
            m_updateManager.EventOnUpdate += OnUpdate;
        }

        private void OnDisable()
        {
            m_cameraManager.SetBehaviour(new IdleCameraBehaviour());
            
            m_inputManager.EventOnAttacked -= OnAttack;
            m_inputManager.EventOnStrongAttacked -= OnStrongAttack;
            m_updateManager.EventOnUpdate -= OnUpdate;
        }

        private void OnUpdate(float deltaTime)
        {
            HandleAcceleration(deltaTime);

            m_characterView.DisplayMovement(m_inputManager.Horizontal, m_inputManager.Vertical);
            m_characterView.DisplaySpeed(m_accelerationTime / m_accelerationDuration);
            m_characterView.RotateTo(m_inputManager.MouseX);
        }

        private void HandleAcceleration(float deltaTime)
        {
            m_accelerationTime = m_inputManager.IsInputHandled ? m_accelerationTime + deltaTime : 0;
            m_accelerationTime = Mathf.Clamp(m_accelerationTime, 0, m_accelerationDuration);
        }
        
        private void OnAttack()
        {
            int attackType = Random.Range(1, 3);
            m_characterView.DisplayAttack(attackType);
        }

        private void OnStrongAttack()
        {
            m_characterView.DisplayStrongAttack();
        }

        private void OnAttacked()
        {
            EventOnAttacked?.Invoke();
        }
    }
}