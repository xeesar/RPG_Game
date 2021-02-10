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
    }
}