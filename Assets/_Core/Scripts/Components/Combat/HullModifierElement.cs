using Unity.Entities;

namespace _Core.Scripts.Components
{
	[InternalBufferCapacity(8)]
	public struct HullModifierElement : IBufferElementData
	{
		public int SourceId;         // id источница модификатора
		public ModifierType Type;
		public float Additive;
		public float Multiplicative;
	}
}