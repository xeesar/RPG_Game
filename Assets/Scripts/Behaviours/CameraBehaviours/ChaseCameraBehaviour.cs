using Interfaces;
using Managers;
using UnityEngine;

namespace Behaviours.CameraBehaviours
{
    public class ChaseCameraBehaviour : ICameraBehaviour
    {
        private Transform m_target = null;
        private Vector3 m_offset = Vector3.zero;
        
        public ChaseCameraBehaviour(Transform target, Vector3 offset)
        {
            m_target = target;
            m_offset = offset;
        }
        
        public void HandleBehaviour(CameraManager cameraManager)
        {
            MoveCamera(cameraManager.transform);
            LookAtTarget(cameraManager.transform);
        }

        private void MoveCamera(Transform cameraTransform)
        {
            Vector3 offset = Quaternion.AngleAxis(m_target.eulerAngles.y, Vector3.up) * m_offset;
            Vector3 targetPosition = m_target.position + offset;

            cameraTransform.position = targetPosition;
        }

        private void LookAtTarget(Transform cameraTransform)
        {
            Vector3 cameraLookAtTargetPosition = m_target.position;
            cameraLookAtTargetPosition.y += m_offset.y / 2f;
            
            cameraTransform.LookAt(cameraLookAtTargetPosition);
        }
    }
}