using System;
using Interfaces;
using UnityEngine;

namespace Managers
{
    public class UpdateManager : BaseManager, IUpdateManager
    {
        public event Action<float> EventOnFixedUpdate;
        public event Action<float> EventOnUpdate;
        public event Action<float> EventOnLateUpdate;

        private void FixedUpdate()
        {
            EventOnFixedUpdate?.Invoke(Time.deltaTime);
        }

        private void Update()
        {
            EventOnUpdate?.Invoke(Time.deltaTime);
        }

        private void LateUpdate()
        {
            EventOnLateUpdate?.Invoke(Time.deltaTime);
        }
    }
}
