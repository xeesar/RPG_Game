using Models;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private CharacterSpawner m_characterSpawner = null;

        public override void InstallBindings()
        {
            CharacterSpawner characterSpawner = Container.InstantiatePrefab(m_characterSpawner, transform).GetComponent<CharacterSpawner>();

            Container.BindInterfacesAndSelfTo<CharacterSpawner>().FromInstance(characterSpawner).AsCached();
        }
    }   
}
