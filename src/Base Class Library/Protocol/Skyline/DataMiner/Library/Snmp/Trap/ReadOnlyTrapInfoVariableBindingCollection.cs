using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Skyline.DataMiner.Library.Protocol.Snmp.Trap
{
	/// <summary>
	/// Represents a read-only collection of trap variable bindings.
	/// </summary>
	public class ReadOnlyTrapInfoVariableBindingCollection : ReadOnlyCollection<TrapInfoVariableBinding>
	{
		readonly TrapInfoVariableBindingCollection trapInfoVariableBindings;

		internal ReadOnlyTrapInfoVariableBindingCollection(TrapInfoVariableBindingCollection trapInfoVariableBindings)
			: base(trapInfoVariableBindings)
		{
			if (trapInfoVariableBindings == null)
			{
				throw new ArgumentNullException("trapInfoVariableBindings");
			}

			this.trapInfoVariableBindings = trapInfoVariableBindings;
		}

		/// <summary>
		/// Gets the variable binding with the specified OID.
		/// </summary>
		/// <param name="oid">The OID of the trap variable binding to get.</param>
		/// <value>The trap variable binding with the specified OID. If a trap variable binding with the specified OID is not found, an exception is thrown.</value>
		/// <exception cref="ArgumentNullException"><paramref name="oid"/> is <see langword="null"/>.</exception>
		/// <exception cref="KeyNotFoundException">An element with the specified key does not exist in the collection.</exception>
		/// <example>
		/// <code>
		/// TrapInfoBinding binding = trapBindingCollection["1.1.1"];
		/// </code>
		/// </example>
		public TrapInfoVariableBinding this[string oid]
		{
			get
			{
				return this.trapInfoVariableBindings[oid];
			}
		}

		/// <summary>
		/// Determines whether the collection contains a trap variable binding with the specified OID.
		/// </summary>
		/// <param name="oid">The OID of the trap variable binding to locate.</param>
		/// <exception cref="ArgumentNullException"><paramref name="oid"/> is <see langword="null"/>.</exception>
		/// <returns><c>true</c> if the collection contains a trap variable binding with the specified OID; otherwise, <c>false</c>.</returns>
		/// <example>
		/// <code>
		/// bool containsTheBinding = trapBindingCollection.Contains("1.1.1");
		/// </code>
		/// </example>
		public bool Contains(string oid)
		{
			return trapInfoVariableBindings.Contains(oid);
		}

		/// <summary>
		/// Gets the trap variable binding associated with the specified OID.
		/// </summary>
		/// <param name="oid">The OID of the trap variable binding to get.</param>
		/// <param name="variableBinding">When this method returns, contains the value associated with the specified OID, if the OID is found; otherwise, <see langword="null"/>. This parameter is passed uninitialized.</param>
		/// <exception cref="ArgumentNullException"><paramref name="oid"/> is <see langword="null"/>.</exception>
		/// <returns><c>true</c> if the collection contains a trap variable binding with the specified OID; otherwise <c>false</c>.</returns>
		public bool TryGetValue(string oid, out TrapInfoVariableBinding variableBinding)
		{
			return trapInfoVariableBindings.TryGetValue(oid, out variableBinding);
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
