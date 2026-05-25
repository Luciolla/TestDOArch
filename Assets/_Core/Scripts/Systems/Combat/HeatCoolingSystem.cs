using _Core.Scripts.Components;
using Unity.Burst;
using Unity.Entities;

namespace _Core.Scripts.Systems.Combat
{
    [BurstCompile]
    public partial struct HeatCoolingSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var dt = SystemAPI.Time.DeltaTime;

            foreach (var heat in SystemAPI.Query<RefRW<HeatSystem>>())
            {
                if(!(heat.ValueRO.CurrentHeat > 0f))
                    continue;

                // Остужаем
                heat.ValueRW.CurrentHeat -= heat.ValueRO.PassiveCooling * dt;
                
                // Если остыл до нуля после перегруза
                if(!(heat.ValueRW.CurrentHeat <= 0f))
                    continue;

                heat.ValueRW.CurrentHeat = 0f;
                heat.ValueRW.IsOverloaded = false;
            }
        }
    }
}
