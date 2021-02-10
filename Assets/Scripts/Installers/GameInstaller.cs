using Managers;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private RunesManager m_runesManager = null;
        [SerializeField] private GameManager m_gameManager = null;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RunesManager>().FromComponentInNewPrefab(m_runesManager).AsCached();
            Container.BindInterfacesAndSelfTo<GameManager>().FromComponentInNewPrefab(m_gameManager).AsCached();
        }
    }
}