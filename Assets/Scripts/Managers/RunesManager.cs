using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Interfaces;
using Models.Runes;
using UnityEngine;
using View.UI;
using Zenject;

namespace Managers
{
    public class RunesManager : BaseManager
    {
        public event Action EventRunesActivated;
        
        [SerializeField] private List<Rune> m_runesPrefabs = null;

        [Inject] private ILevelMap m_levelMap = null;
        [Inject] private RunePanel m_runePanel = null;
        [Inject] private DiContainer m_diContainer = null;
        
        private List<Rune> m_runesSequence;
        
        private int m_currentSequenceIndex = 0;

        public override void Initialize()
        {
            SpawnRunes();
            GenerateSequence();
        }

        public override void Dispose()
        {
            DestroyRunes();
        }

        private void SpawnRunes()
        {
            m_runesSequence = new List<Rune>();
            
            for (int i = 0; i < m_runesPrefabs.Count; i++)
            {
                SpawnRune(m_runesPrefabs[i]);
            }
        }

        private void SpawnRune(Rune runePrefab)
        {
            Rune rune = m_diContainer.InstantiatePrefab(runePrefab, m_levelMap.Transform).GetComponent<Rune>();
            rune.transform.position = m_levelMap.GetRandomPosition();
            rune.EventRuneActivated += OnRuneActivated;
                
            m_runesSequence.Add(rune);
        }

        private void GenerateSequence()
        {
            m_runesSequence = m_runesSequence.OrderBy(x => Guid.NewGuid()).ToList();
            
            m_runePanel.DisplaySequence(m_runesSequence);
        }

        private void DestroyRunes()
        {
            for (int i = 0; i < m_runesSequence.Count; i++)
            {
                Rune rune = m_runesSequence[i];
                rune.EventRuneActivated += OnRuneActivated;
            }
        }

        private void OnRuneActivated(Rune rune)
        {
            bool isCorrectRune = m_runesSequence[m_currentSequenceIndex] == rune;
            rune.SetRuneActivationStatus(isCorrectRune ? ActivationStatus.Success : ActivationStatus.UnSuccess);

            if (!isCorrectRune)
            {
                ResetRunes();
                m_currentSequenceIndex = 0;
                return;
            }

            m_currentSequenceIndex++;
            HandleSequenceCompletion();
        }

        private void HandleSequenceCompletion()
        {
            if (m_currentSequenceIndex >= m_runesSequence.Count)
            {
                EventRunesActivated?.Invoke();
            }
        }

        private void ResetRunes()
        {
            for (int i = 0; i < m_runesSequence.Count; i++)
            {
                m_runesSequence[i].SetRuneActivationStatus(ActivationStatus.Reset);
            }
        }
    }
}