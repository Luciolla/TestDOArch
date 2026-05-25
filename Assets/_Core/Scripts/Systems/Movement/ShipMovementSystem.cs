using _Core.Scripts.Components;
using _Core.Scripts.Components.Movement;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace _Core.Scripts.Systems.Movement
{
    [BurstCompile]
    public partial struct ShipMovementSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            // Система не будет работать, пока не появится хотя бы одна сущность с нужными компонентами
            state.RequireForUpdate<MovementStats>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;

            // SystemAPI.Query - самый простой и эффективный способ итерации (см. паттерны подсказки)
            // RefRW - Read/Write, RefRO - Read Only
            foreach (var (transform, stats, input, heat) in 
                     SystemAPI.Query<RefRW<LocalTransform>, RefRO<MovementStats>, RefRO<ThrustInput>, RefRO<HeatSystem>>())
            {
                // Если корабль перегружен (Overloaded), он теряет управление
                if (heat.ValueRO.IsOverloaded)
                    continue;

                var thrust = input.ValueRO.Value;
                var currentSpeed = stats.ValueRO.CurrentMaxSpeed;

                // Поворот корабля (вращение вокруг оси Y)
                var currentRotation = transform.ValueRO.Rotation.value.y;
            
                // Инвертируем, т.к. в 2D Top-Down поворот влево - это +Y, а ввод влево - это -X
                var newRotationY = currentRotation + (-thrust.x * stats.ValueRO.Agility * deltaTime);
            
                // Движение вперед (локальный вектор "вперед" для 2D - это up, но в 3D трансформах - это forward. 
                // Для 2D Top-Down мы смотрим на ось Z, поэтому берем forward)
                var forward = math.forward(quaternion.Euler(0, math.radians(newRotationY), 0));
            
                // Смещение позиции
                var newPosition = transform.ValueRO.Position + (forward * thrust.y * currentSpeed * deltaTime);

                // Записываем новые значения
                transform.ValueRW.Position = newPosition;
                transform.ValueRW.Rotation = quaternion.Euler(0, math.radians(newRotationY), 0);
            }
        }
    }
}