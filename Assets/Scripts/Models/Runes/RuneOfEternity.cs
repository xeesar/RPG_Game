using UnityEngine;
using Zenject;

namespace Models.Runes
{
    public class RuneOfEternity : Rune
    {
        [Header("Options")] 
        [SerializeField] private float m_activationMinDistance = 0.5f;
        
        [Inject] private CharacterModel m_characterModel;

        private void Start()
        {
            m_characterModel.EventOnAttacked += OnCharacterAttacked;
        }

        private void OnDestroy()
        {
            m_characterModel.EventOnAttacked -= OnCharacterAttacked;
        }

        private void OnCharacterAttacked()
        {
            float distance = Vector3.Distance(m_characterModel.transform.position, transform.position);

            if (distance < m_activationMinDistance)
            {
                OnActivated();
            }
        }
    }   
}
