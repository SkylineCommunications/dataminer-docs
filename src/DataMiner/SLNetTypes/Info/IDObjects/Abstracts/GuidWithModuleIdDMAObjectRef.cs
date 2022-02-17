using System;
using Skyline.DataMiner.Net.Ownership;

namespace Skyline.DataMiner.Net
{
	[Serializable]
	public abstract class GuidWithModuleIdDMAObjectRef<T> : GuidDMAObjectRef<T>, IModuleIdReferencer, IComparable<GuidWithModuleIdDMAObjectRef<T>> where T : class, IGuidDMAObjectRef
	{
		public abstract string ModuleId { get; set; }

		public int CompareTo(GuidWithModuleIdDMAObjectRef<T> other)
		{
			return 0;
		}

		public override void Write(SimpleByteWriter writer)
		{
		}
	}
}