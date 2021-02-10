using System;

namespace Interfaces
{
    public interface IInputManager
    {
        event Action EventOnAttacked;
        event Action EventOnStrongAttacked;
        
        float Horizontal { get; }
        float Vertical { get; }
        float MouseX { get; }
        bool IsInputHandled { get; }
    }
}