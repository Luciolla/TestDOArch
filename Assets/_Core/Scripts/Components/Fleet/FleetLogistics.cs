using Unity.Entities;

namespace _Core.Scripts.Components
{
	public struct FleetLogistics : IComponentData
	{
		public int ServiceCost;
		public int FuelCost;
		public int MaxFuel;
		public int CurrentFuel;
		public int MaxCargo;
		public int CurrentCargo;
		public float CombatReadiness;
		public float CRRestorationRate;
		public int CRRestorationCost;
	}
}