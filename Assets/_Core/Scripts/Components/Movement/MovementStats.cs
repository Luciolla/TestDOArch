using Unity.Entities;

namespace _Core.Scripts.Components
{
	public struct MovementStats : IComponentData
	{
		public float MaxCombatSpeed;
		public float CurrentMaxSpeed; // Изменяется при вкл/выкл щита (70%)
		public float Agility;
	}
}