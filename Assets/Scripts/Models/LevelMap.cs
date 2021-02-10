using Interfaces;
using UnityEngine;

namespace Models
{
    public class LevelMap : MonoBehaviour, ILevelMap
    {
        [SerializeField] private Collider m_groundCollider = null;

        public Transform Transform => transform;

        public Vector3 MinPosition => m_groundCollider.bounds.min;
        public Vector3 MaxPosition => m_groundCollider.bounds.max;

        public Vector3 GetRandomPosition()
        {
            Vector3 minPosition = MinPosition;
            Vector3 maxPosition = MaxPosition;
            Vector3 newPosition = Vector3.zero;
            
            newPosition.x = Random.Range(minPosition.x, maxPosition.x);
            newPosition.y = minPosition.y;
            newPosition.z = Random.Range(minPosition.z, maxPosition.z);

            return newPosition;
        }
    }
}