using Unity.Entities;

namespace _Core.Scripts.Components
{
	public struct ShipHullData : IComponentData 
	{
		public int HullId;
		public ShipSize ShipSize;
		public SkillType SkillType;
		public int FleetPoints;
		public float Mass;
	}
}