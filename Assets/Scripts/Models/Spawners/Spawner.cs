using System;
using Interfaces;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Models.Spawners
{
    public abstract class Spawner : MonoBehaviour, IInitializable, IDisposable
    {
        [Inject] protected ILevelMap m_levelMap = null;
        [Inject] protected DiContainer m_container = null;
        
        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
        }

        protected Vector3 GetRandomPosition()
        {
            Vector3 minPosition = m_levelMap.MinPosition;
            Vector3 maxPosition = m_levelMap.MaxPosition;
            Vector3 newPosition = Vector3.zero;
            
            newPosition.x = Random.Range(minPosition.x, maxPosition.x);
            newPosition.y = minPosition.y;
            newPosition.z = Random.Range(minPosition.z, maxPosition.z);

            return newPosition;
        }
    }
}