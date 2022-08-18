using System;
using System.Text;

namespace Skyline.DataMiner.Library.Protocol.Snmp.Trap
{
	/// <summary>
	/// Represents a trap variable binding.
	/// </summary>
	[Serializable]
	public sealed class TrapInfoVariableBinding : IEquatable<TrapInfoVariableBinding>
	{
		/// <summary>
		/// Gets the value of this variable binding.
		/// </summary>
		/// <value>The value of this variable binding.</value>
		public string Value { get { return value; } }

		/// <summary>
		/// Gets the OID of this trap variable binding.
		/// </summary>
		/// <value>The OID of this trap variable binding.</value>
		public string Oid { get { return oid; } }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			if (object.ReferenceEquals(obj, null))
				return false;

			if (object.ReferenceEquals(this, obj))
				return true;

			if (this.GetType() != obj.GetType())
				return false;

			return this.Equals(obj as TrapInfoVariableBinding);
		}

		/// <summary>
		/// Returns a value indicating whether the value of this instance is equal to the value of the specified <see cref="TrapInfoVariableBinding"/>  instance.
		/// </summary>
		/// <param name="other">The object to compare to this instance.</param>
		/// <returns><c>true</c> if the <paramref name="other"/> equals the value of this instance; otherwise, <c>false</c>.</returns>
		/// <remarks><paramref name="other"/> is considered equal to this binding if both the OID and value are equal.</remarks>
		public bool Equals(TrapInfoVariableBinding other)
		{
			if (other == null)
			{
				return false;
			}

			return Value == other.Value && Oid == other.Oid;
		}

		/// <summary>
		/// Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
		{
			int hash = 13;
			hash = (hash * 7) + Value.GetHashCode();
			hash = (hash * 7) + Oid.GetHashCode();
			return hash;
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("[OID: ");
			sb.Append(Oid);
			sb.Append(", value: ");
			sb.Append(Value);
			sb.Append(']');

			return sb.ToString();
		}
	}
}