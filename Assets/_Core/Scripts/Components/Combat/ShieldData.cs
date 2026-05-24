using Unity.Entities;

namespace _Core.Scripts.Components
{
	public struct ShieldData : IComponentData
	{
		public ShieldType Type;
		public float MaxAngle;     // Угол покрытия
		public float CurrentAngle; // Текущий (зависит от активации)
		public float ActivateSpeed;
		public float UpkeepHeat;   // Нагрев за секунду
		public float DamageToHeat; // 0.8 единиц перегрева за 1 урона
	}
}