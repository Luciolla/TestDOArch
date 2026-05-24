using _Core.Scripts.Components;
using Unity.Burst;
using Unity.Entities;

namespace _Core.Scripts.Systems
{
	[BurstCompile]
	public partial struct ModifierApplicationSystem : ISystem
	{
		[BurstCompile]
		public void OnUpdate(ref SystemState state)
		{
			var ecb = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>()
				.CreateCommandBuffer(state.WorldUnmanaged);

			foreach (var (baseStats, modifiers, movement, entity) in 
			         SystemAPI.Query<
					         RefRO<ShipHullData>, 
					         DynamicBuffer<HullModifierElement>,
					         RefRW<MovementStats>>()
				         .WithAll<RecalculateStatsTag>()
				         .WithEntityAccess())
			{
				var baseSpeed = baseStats.ValueRO.Mass;
				var addSpeed = 0f;
				var multSpeed = 1.0f;

				for (var i = 0; i < modifiers.Length; i++)
				{
					if (modifiers[i].Type == ModifierType.Speed)
					{
						addSpeed += modifiers[i].Additive;
						multSpeed *= modifiers[i].Multiplicative;
					}
				}

				movement.ValueRW.MaxCombatSpeed = (baseSpeed + addSpeed) * multSpeed;

				ecb.RemoveComponent<RecalculateStatsTag>(entity);
			}
		}
	}
}