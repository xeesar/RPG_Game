using UnityEngine;

namespace View
{
    public class CharacterView : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Animator m_animator = null;

        [Header("Options")] 
        [SerializeField] private Vector3 m_rotationAxis = Vector3.zero;
        
        private readonly int m_horizontalMovementHash = Animator.StringToHash("HorizontalMovement");
        private readonly int m_verticalMovementHash = Animator.StringToHash("VerticalMovement");
        private readonly int m_speedHash = Animator.StringToHash("Speed");
        private readonly int m_movingHash = Animator.StringToHash("IsMoving");

        private readonly int m_attackTypeHash = Animator.StringToHash("AttackType");
        private readonly int m_attackHash = Animator.StringToHash("Attack");
        private readonly int m_strongAttackHash = Animator.StringToHash("StrongAttack");
        
        public void DisplayMovement(float horizontal, float vertical)
        {
            m_animator.SetFloat(m_horizontalMovementHash, horizontal);
            m_animator.SetFloat(m_verticalMovementHash, vertical);
        }

        public void RotateTo(float mouseX)
        {
            Vector3 eulerAngle = transform.eulerAngles;
            eulerAngle += m_rotationAxis * mouseX;

            transform.eulerAngles = eulerAngle;
        }

        public void DisplaySpeed(float speed)
        {
            m_animator.SetFloat(m_speedHash, speed);
            m_animator.SetBool(m_movingHash,  speed > 0);
        }
        
        public void DisplayAttack(int type)
        {
            m_animator.ResetTrigger(m_strongAttackHash);
            
            m_animator.SetInteger(m_attackTypeHash, type);
            m_animator.SetTrigger(m_attackHash);
        }

        public void DisplayStrongAttack()
        {
            m_animator.SetTrigger(m_strongAttackHash);
        }
    }
}