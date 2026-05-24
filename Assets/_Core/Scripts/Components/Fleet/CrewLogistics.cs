using Unity.Entities;

namespace _Core.Scripts.Components
{
	public struct CrewLogistics : IComponentData
	{
		public int RequiredCrew;
		public int CurrentCrew;
		public float CrewExperience;
		public int MaxPassengers;
	}
}