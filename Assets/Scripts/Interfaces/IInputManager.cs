using System;

namespace Interfaces
{
    public interface IInputManager
    {
        event Action EventOnAttacked;
        event Action EventOnStrongAttacked;
        event Action EventOnJumped;
        
        float Horizontal { get; }
        float Vertical { get; }
        float MouseX { get; }
        bool IsInputHandled { get; }
    }
}