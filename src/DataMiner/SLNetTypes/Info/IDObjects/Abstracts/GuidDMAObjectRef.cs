using System;
using Skyline.DataMiner.Net.Ownership;

namespace Skyline.DataMiner.Net
{
	public interface IGuidDMAObjectRef
	{
		Guid Id { get; }
	}

	public static class GuidDMAObjectRefExtentions
	{
		public static Guid SafeId(this IGuidDMAObjectRef obj)
		{
			if (obj == null)
				return Guid.Empty;
			return obj.Id;
		}
	}

	[Serializable]
	public abstract class GuidDMAObjectRef<T> : DMAObjectRef, IEquatable<T>, IComparable<T>
		where T : class, IGuidDMAObjectRef
	{
		public abstract Guid Id { get; }

		protected GuidDMAObjectRef()
		{
		}

		public bool Equals(T other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Id.Equals(other.Id);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as T);
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override void Write(SimpleByteWriter writer)
		{
		}

		public int CompareTo(T other)
		{
			return 0;
		}
	}
}
