using Unity.Entities;

namespace _Core.Scripts.Components
{
	public struct HeatSystem : IComponentData
	{
		public float MaxCapacity;
		public float CurrentHeat;
		public float PassiveCooling;
		public float ActiveCooling;
		public bool IsOverloaded;
	}
}