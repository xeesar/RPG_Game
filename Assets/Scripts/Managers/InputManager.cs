using System;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Managers
{
    public abstract class InputManager : BaseManager, IInputManager
    {
        public abstract event Action EventOnAttacked;
        public abstract event Action EventOnStrongAttacked;
        public abstract event Action EventOnJumped;

        [SerializeField] protected float m_mouseXMultiplier = 1f;
        
        [Inject] private IUpdateManager m_updateManager = null;
        
        public float Horizontal { get; protected set; }
        public float Vertical { get; protected set; }
        public float MouseX { get; protected set; }
        public bool IsInputHandled => Mathf.Abs(Horizontal) > 0 || Mathf.Abs(Vertical) > 0;

        public override void Initialize()
        {
            m_updateManager.EventOnUpdate += OnUpdate;
        }

        public override void Dispose()
        {
            m_updateManager.EventOnUpdate -= OnUpdate;
        }

        private void OnUpdate(float deltaTime)
        {
            HandleMovement();
            HandleMouse();
            HandleAttack();
            HandleJump();
        }

        protected abstract void HandleMovement();
        protected abstract void HandleMouse();
        protected abstract void HandleAttack();
        protected abstract void HandleJump();
    }
}