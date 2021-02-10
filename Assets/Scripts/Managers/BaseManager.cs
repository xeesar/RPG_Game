using System;
using UnityEngine;
using Zenject;

namespace Managers
{
    public abstract class BaseManager : MonoBehaviour, IInitializable, IDisposable
    {
        public virtual void Initialize()
        {
            
        }

        public virtual void Dispose()
        {
            
        }
    }
}