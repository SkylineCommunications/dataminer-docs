namespace Skyline.DataMiner.Library.Protocol.Snmp.Trap
{
	using System;
	using System.Collections.ObjectModel;

	/// <summary>
	/// Represents a keyed collection of trap variable bindings.
	/// </summary>
	internal class TrapInfoVariableBindingCollection : KeyedCollection<string, TrapInfoVariableBinding>
	{
		/// <summary>
		/// Extracts the key from the specified element.
		/// </summary>
		/// <param name="item">The element from which to extract the key.</param>
		/// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
		/// <returns>The key for the specified element.</returns>
		protected override string GetKeyForItem(TrapInfoVariableBinding item)
		{
			if (item != null)
			{
				return item.Oid;
			}
			else
			{
				throw new ArgumentNullException("item");
			}
		}

		/// <summary>
		/// Gets the trap variable binding associated with the specified OID.
		/// </summary>
		/// <param name="oid">The OID of the trap variable binding to get.</param>
		/// <param name="variableBinding">When this method returns, contains the value associated with the specified OID, if the OID is found; otherwise, <see langword="null"/>.
		/// This parameter is passed uninitialized.</param>
		/// <exception cref="ArgumentNullException"><paramref name="oid"/> is <see langword="null"/>.</exception>
		/// <returns><c>true</c> if the collection contains a trap variable binding with the specified OID; otherwise <c>false</c>.</returns>
		public bool TryGetValue(string oid, out TrapInfoVariableBinding variableBinding)
		{
			return this.Dictionary.TryGetValue(oid, out variableBinding);
		}

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
		{
			return string.Join(Environment.NewLine, this.Items);
		}
	}
}
