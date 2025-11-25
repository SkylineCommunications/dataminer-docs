using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Skyline.DataMiner.Net.Automation;

namespace Skyline.DataMiner.Automation
{
	/// <summary>
	/// Represents an Automation entry point type.
	/// </summary>
	public sealed class AutomationEntryPointType : IEquatable<AutomationEntryPointType>
	{
		/// <summary>
		/// Gets the Automation entry point type ID.
		/// </summary>
		/// <value>The Automation entry point type ID.</value>
		public AutomationEntryPointType.Types ID
		{
			get; set;
		}

		/// <summary>
		/// Gets the entry point delegate type.
		/// </summary>
		/// <value>The entry point delegate type.</value>
		public Type DelegateType
		{
			get;
			private set;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <note type="note">
		/// The Automation entry point type is considered equal if the <see cref="ID"/> of the specified object equals the <see cref="ID"/> of this object.
		/// </note>
		/// </remarks>
		[return: MarshalAs(UnmanagedType.U1)]
		public override sealed bool Equals(object obj)
		{
			return false;
		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>The Automation entry point type is considered equal if the <see cref="ID"/> of the specified object equals the <see cref="ID"/> of this object.</remarks>
		[return: MarshalAs(UnmanagedType.U1)]
		public bool Equals(AutomationEntryPointType other)
		{
			return true;
		}

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override sealed int GetHashCode()
		{
			return 1;
		}

		/// <summary>
		/// Determines whether the two specified objects are equal.
		/// </summary>
		/// <param name="a1">The first value to compare.</param>
		/// <param name="a2">The second value to compare.</param>
		/// <returns><c>true</c> if the operands are equal; otherwise, <c>false</c>.</returns>
		public static bool operator ==(AutomationEntryPointType a1, AutomationEntryPointType a2)
		{
			return false;
		}

		/// <summary>
		/// Determines whether the two specified objects are not equal.
		/// </summary>
		/// <param name="a1">The first value to compare.</param>
		/// <param name="a2">The second value to compare.</param>
		/// <returns><c>false</c> if the operands are equal; otherwise, <c>true</c>.</returns>
		public static bool operator !=(AutomationEntryPointType a1, AutomationEntryPointType a2)
		{
			return !(a1 == a2);
		}

		/// <summary>
		/// Retrieves the entry point type by ID.
		/// </summary>
		/// <param name="id">The entry point type ID.</param>
		/// <returns>The entry point type.</returns>
		public static AutomationEntryPointType GetEntryPointTypeByID(AutomationEntryPointType.Types id)
		{
			return null;
		}

		/// <summary>
		/// Specifies the entry point method type.
		/// </summary>
		public enum Types
		{
			/// <summary>
			/// Default.
			/// </summary>
			Default = 0,
			/// <summary>
			/// SRM service info state change.
			/// </summary>
			SRMServiceInfoStateChanges = 1,
			/// <summary>
			/// On SRM quarantine trigger.
			/// </summary>
			OnSrmQuarantineTrigger = 2,
			/// <summary>
			/// On SRM start actions failure.
			/// </summary>
			OnSrmStartActionsFailure = 3,
			/// <summary>
			/// Install App package.
			/// </summary>
			InstallAppPackage = 4,
			/// <summary>
			/// Configure App package.
			/// </summary>
			ConfigureApp = 5,
			/// <summary>
			/// Uninstall App package.
			/// </summary>
			UninstallApp = 6,
			/// <summary>
			/// On SFM bookings updated by reference.
			/// </summary>
			OnSrmBookingsUpdatedByReference = 7,
			/// <summary>
			/// On DOM instance CRUD.
			/// </summary>
			OnDomInstanceCrud = 8,
			/// <summary>
			/// On ticket CRUD.
			/// </summary>
			OnTicketCrud = 9,
			/// <summary>
			/// On DOM action.
			/// </summary>
			OnDomAction = 10,
			/// <summary>
			/// On Request script info.
			/// Detailed information about implementing this entry point type is available in <see href="xref:Implementing_OnRequestScriptInfo_Entry_Point">Implementing the OnRequestScriptInfo entry point</see>.
			/// </summary>
			OnRequestScriptInfo = 13,
			/// <summary>
			/// Automation test entry point.
			/// </summary>
			AutomationEntryPointTest = 2147483647,
		}
	}
}