using System;
using Data;
using Enums;
using UnityEngine;
using View;

namespace Models.Runes
{
    public abstract class Rune : MonoBehaviour
    {
        public event Action<Rune> EventRuneActivated;

        [Header("Components")] 
        [SerializeField] private RuneView m_runeView = null;

        [Header("Options")] 
        [SerializeField] private RuneData m_runeData;
        
        public RuneData RuneData => m_runeData;
        public bool IsPossibleToActivateRune { get; set; }
        protected bool IsActivated { get; private set; }

        public void SetRuneActivationStatus(ActivationStatus activationStatus)
        {
            switch (activationStatus)
            {
                case ActivationStatus.Success:
                    m_runeView.DisplaySuccessParticle();
                    IsActivated = true;
                    break;
                case ActivationStatus.UnSuccess:
                    m_runeView.DisplayUnSuccessParticle();
                    break;
                default:
                    OnReset();
                    break;
            }
        }

        protected virtual void OnReset()
        {
            m_runeView.ResetParticles();
            IsActivated = false;
        }
        
        protected void OnActivated()
        {
            EventRuneActivated?.Invoke(this);
        }
    }   
}
