using UnityEngine;

namespace View
{
    public class RuneView : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private ParticleSystem m_successParticle = null;
        [SerializeField] private ParticleSystem m_unSuccessParticle = null;

        public void DisplaySuccessParticle()
        {
            m_successParticle.Play();
        }

        public void DisplayUnSuccessParticle()
        {
            m_unSuccessParticle.Play();
        }

        public void ResetParticles()
        {
            m_successParticle.Stop();
        }
    }
}

