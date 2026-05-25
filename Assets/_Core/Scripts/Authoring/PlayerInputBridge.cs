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

		private void Start()
		{
			// Получаем доступ к ECS миру
			_entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        
			// Создаем запрос, чтобы найти сущность с нашим тегом и компонентом ввода
			_playerQuery = _entityManager.CreateEntityQuery(typeof(PlayerTag), typeof(ThrustInput));
		}

		private void Update()
		{
			// Если сущность игрока еще не заспавнилась/не сконвертировалась - выходим
			if (_playerQuery.IsEmpty) return;

			// Читаем ввод с клавиатуры (возможно стоит переделать под NIS, но пока лень)
			var x = Input.GetAxis("Horizontal"); // A/D
			var y = Input.GetAxis("Vertical");   // W/S

			// Формируем данные
			var input = new ThrustInput
			{
				Value = new float2(x, y)
			};

			// Находим сущность игрока (она одна, так что GetSingletonEntity должен сработать)
			Entity playerEntity = _playerQuery.GetSingletonEntity();
        
			// Записываем ввод прямо в компонент сущности!
			_entityManager.SetComponentData(playerEntity, input);
		}
	}
}