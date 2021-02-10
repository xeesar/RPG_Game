using System;

namespace Interfaces
{
    public interface IUpdateManager
    {
         event Action<float> EventOnFixedUpdate; 
         event Action<float> EventOnUpdate; 
         event Action<float> EventOnLateUpdate;    
    }   
}
