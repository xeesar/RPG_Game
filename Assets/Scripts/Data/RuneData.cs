using UnityEngine;

namespace Data
{
    [System.Serializable]
    public struct RuneData
    {
        [SerializeField] private Sprite m_runeIcon;

        public Sprite RuneIcon => m_runeIcon;
    }
}