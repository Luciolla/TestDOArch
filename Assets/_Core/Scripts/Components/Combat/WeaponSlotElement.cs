using Unity.Entities;

namespace _Core.Scripts.Components
{
	[InternalBufferCapacity(0)]
	public struct WeaponSlotElement : IBufferElementData
	{
		public Entity MountedWeapon; // Ссылка на сущность оружия
		public SlotSize Size;        // Small, Medium, Large
		public SlotType Type;        // Hybrid, Energy, Ballistic
	}
}