using Models.Spawners;
using UnityEngine;

namespace Models
{
    public class CharacterSpawner : Spawner
    {
        [Header("Components")]
        [SerializeField] private GameObject m_playerPrefab = null;
        

        public override void Initialize()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            CharacterModel characterModel = m_container.InstantiatePrefab(m_playerPrefab, m_levelMap.Transform).GetComponent<CharacterModel>();
            m_container.BindInterfacesAndSelfTo<CharacterModel>().FromInstance(characterModel).AsTransient();
        }
    }
}