using UnityEngine;

namespace Interfaces
{
    public interface ILevelMap
    {
        Transform Transform { get; }
        Vector3 MinPosition { get; }
        Vector3 MaxPosition { get; }

        Vector3 GetRandomPosition();
    }
}