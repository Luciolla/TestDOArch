using _Core.Scripts.Components;
using _Core.Scripts.Components.Movement;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace _Core.Scripts.Authoring
{
	public class ShipAuthoring : MonoBehaviour
	{
		public float MaxCombatSpeed = 5f;
		public float Agility = 90f; // Градусы в секунду
		public float Mass = 1f;
    
		// Стартовое значение перегрева для теста
		public float MaxHeatCapacity = 100f;
		public float PassiveCooling = 5f;

		// В DOTS Baker (конвертит данные)
		private class Baker : Baker<ShipAuthoring>
		{
			public override void Bake(ShipAuthoring authoring)
			{
				// Получаем сущность. Dynamic - значит объект будет двигаться
				var entity = GetEntity(TransformUsageFlags.Dynamic);

				// Добавляем наши компоненты и заполняем данными из инспектора
				AddComponent(entity, new MovementStats
				{
					MaxCombatSpeed = authoring.MaxCombatSpeed,
					CurrentMaxSpeed = authoring.MaxCombatSpeed, // Изначально летаем на полной
					Agility = authoring.Agility
				});

				AddComponent(entity, new ShipHullData
				{
					Mass = authoring.Mass
				});

				AddComponent(entity, new HeatSystem
				{
					MaxCapacity = authoring.MaxHeatCapacity,
					CurrentHeat = 0f,
					PassiveCooling = authoring.PassiveCooling,
					IsOverloaded = false
				});

				// Компонент для ввода (пока пустой, его будет заполнять система)
				AddComponent(entity, new ThrustInput { Value = float2.zero });
			}
		}
	}
}