using System;
using UnityEngine;

namespace Managers
{
    public class PCInputManager : InputManager
    {
        public override event Action EventOnAttacked;
        public override event Action EventOnStrongAttacked;

        protected override void HandleMovement()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
        }

        protected override void HandleMouse()
        {
            MouseX = m_mouseXMultiplier * Input.GetAxis("Mouse X");
        }

        protected override void HandleAttack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventOnAttacked?.Invoke();
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                EventOnStrongAttacked?.Invoke();
            }
        }
    }   
}
