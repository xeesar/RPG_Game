using Enums;
using UnityEngine;

namespace Models.Runes
{
    public abstract class Rune : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private GameObject m_successParticle = null;
        [SerializeField] private GameObject m_failuerParticle = null;

        [Header("Options")]
        [SerializeField] private RuneType m_runeType = RuneType.RuneOfEternity;
        
        protected void OnActivated()
        {
            m_failuerParticle.SetActive(true);
        }
    }   
}
