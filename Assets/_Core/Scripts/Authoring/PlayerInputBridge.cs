using _Core.Scripts.Components;
using _Core.Scripts.Components.Movement;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace _Core.Scripts.Authoring
{
	public class PlayerInputBridge : MonoBehaviour
	{
		private EntityManager _entityManager;
		private EntityQuery _playerQuery;

		private void Awake()
		{
			// Ищем ECS World, только если еще не нашли
			var world = World.DefaultGameObjectInjectionWorld;
			if(world == null)
				return;

			_entityManager = world.EntityManager;
			// Ищем сущность, у которой есть и PlayerTag, и ThrustInput
			_playerQuery = _entityManager.CreateEntityQuery(typeof(PlayerTag), typeof(ThrustInput));

		}

		private void Update()
		{
			// Если мир еще не прогрузился или сущность не создана - выходим
			if(_playerQuery == null || _playerQuery.IsEmpty) return;

			// Считываем клавиатуру
			var x = Input.GetAxis("Horizontal"); // A/D
			var y = Input.GetAxis("Vertical"); // W/S

			var input = new ThrustInput {
				Value = new float2(x, y)
			};

			// Находим нашего игрока и пушим данные
			Entity playerEntity = _playerQuery.GetSingletonEntity();
			_entityManager.SetComponentData(playerEntity, input);
		}
	}
}