using System.Collections.Generic;
using Models.Runes;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public class RunePanel : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField] private Image m_runeElement = null;
        [SerializeField] private Transform m_imagesParent = null;

        private readonly List<Image> m_runesImages = new List<Image>();
        
        public void DisplaySequence(List<Rune> runes)
        {
            for (int i = 0; i < runes.Count; i++)
            {
                Image image = GetImage(i);
                image.sprite = runes[i].RuneData.RuneIcon;
            }
        }

        private Image GetImage(int index)
        {
            if (index < m_runesImages.Count)
            {
                return m_runesImages[index];
            }

            Image image = Instantiate(m_runeElement, m_imagesParent);
            m_runesImages.Add(image);

            return image;
        }
    }
}