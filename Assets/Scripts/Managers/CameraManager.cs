using Interfaces;
using Zenject;

namespace Managers
{
    public class CameraManager : BaseManager, ICameraManager
    {
        [Inject] private IUpdateManager m_updateManager;
        
        private ICameraBehaviour m_cameraBehaviour;

        public void SetBehaviour(ICameraBehaviour cameraBehaviour)
        {
            m_cameraBehaviour = cameraBehaviour;
        }

        public override void Initialize()
        {
            m_updateManager.EventOnUpdate += OnUpdate;
        }

        public override void Dispose()
        {
            m_updateManager.EventOnUpdate -= OnUpdate;
        }

        private void OnUpdate(float deltaTime)
        {
            m_cameraBehaviour?.HandleBehaviour(this);
        }
    }   
}
