using Models.Spawners;
using UnityEngine;

namespace Models
{
    public class RunesSpawner : Spawner
    {
        [SerializeField] private GameObject m_runesOfEternity = null;
        [SerializeField] private GameObject m_runesOfRoutine = null;
        [SerializeField] private GameObject m_runesOfWorship = null;

        public override void Initialize()
        {
            SpawnRunes();
        }

        private void SpawnRunes()
        {
            GameObject runesOfEternity = m_container.InstantiatePrefab(m_runesOfEternity, m_levelMap.Transform);
            GameObject runesOfRoutine = m_container.InstantiatePrefab(m_runesOfRoutine, m_levelMap.Transform);
            GameObject runesOfWorship = m_container.InstantiatePrefab(m_runesOfWorship, m_levelMap.Transform);

            runesOfEternity.transform.position = GetRandomPosition();
            runesOfRoutine.transform.position = GetRandomPosition();
            runesOfWorship.transform.position = GetRandomPosition();
        }
    }
}