using Managers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ManagersInstaller : MonoInstaller
    {
        [SerializeField] private UpdateManager m_updateManager = null;
        [SerializeField] private CameraManager m_cameraManager = null;
        [SerializeField] private InputManager m_inputManager = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UpdateManager>().FromComponentInNewPrefab(m_updateManager).AsSingle();
            Container.BindInterfacesAndSelfTo<CameraManager>().FromComponentInNewPrefab(m_cameraManager).AsSingle();
            Container.BindInterfacesAndSelfTo<InputManager>().FromComponentInNewPrefab(m_inputManager).AsSingle();
        }
    }   
}
