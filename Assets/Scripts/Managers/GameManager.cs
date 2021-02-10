using UnityEngine.SceneManagement;
using Zenject;

namespace Managers
{
    public class GameManager : BaseManager
    {
        [Inject] private RunesManager m_runesManager = null;
        
        public override void Initialize()
        {
            m_runesManager.EventRunesActivated += OnGameCompleted;
        }

        public override void Dispose()
        {
            m_runesManager.EventRunesActivated -= OnGameCompleted;
        }

        private void OnGameCompleted()
        {
            SceneManager.LoadScene(0);
        }
    }
}