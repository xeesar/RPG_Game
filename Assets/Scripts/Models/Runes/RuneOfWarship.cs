using System;
using UnityEngine;
using Zenject;

namespace Models.Runes
{
    public class RuneOfWarship : Rune
    {
        [Inject] private CharacterModel m_characterModel = null;
        
        private void OnCollisionEnter(Collision other)
        {
            IsPossibleToActivateRune = other.gameObject.GetComponent<CharacterModel>();
        }

        private void OnCollisionStay(Collision other)
        {
            if(IsActivated || !IsPossibleToActivateRune) return;

            if (!m_characterModel.IsMoving)
            {
                OnActivated();
                IsPossibleToActivateRune = false;
            }
        }
    }
}