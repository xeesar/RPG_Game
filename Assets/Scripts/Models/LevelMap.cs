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
    }
}