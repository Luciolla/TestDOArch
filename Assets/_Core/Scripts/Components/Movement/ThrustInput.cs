using Unity.Entities;
using Unity.Mathematics;

// Направление движения (от -1 до 1 по осям X и Y)
namespace _Core.Scripts.Components.Movement
{
    public struct ThrustInput : IComponentData
    {
        public float2 Value; // x = поворот, y = газ
    }
}