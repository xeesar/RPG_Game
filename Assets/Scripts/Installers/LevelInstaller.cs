using Models;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private CharacterSpawner m_characterSpawner = null;
        [SerializeField] private RunesSpawner m_runesSpawner = null;

        public override void InstallBindings()
        {
            CharacterSpawner characterSpawner = Container.InstantiatePrefab(m_characterSpawner, transform).GetComponent<CharacterSpawner>();
            RunesSpawner runesSpawner = Container.InstantiatePrefab(m_runesSpawner, transform).GetComponent<RunesSpawner>();

            Container.BindInterfacesAndSelfTo<CharacterSpawner>().FromInstance(characterSpawner).AsTransient();
            Container.BindInterfacesAndSelfTo<RunesSpawner>().FromInstance(runesSpawner).AsTransient();
        }
    }   
}
