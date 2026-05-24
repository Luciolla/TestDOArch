using Unity.Entities;

namespace _Core.Scripts.Components
{
	public struct CombatStats : IComponentData
	{
		public int MaxHp;
		public int CurrentHp;
		public int MaxArmour;
		// Броню лучше сделать буфером (ArmourGrid) 
		// чтобы пробитие было локальным, как в WoT
	}
}