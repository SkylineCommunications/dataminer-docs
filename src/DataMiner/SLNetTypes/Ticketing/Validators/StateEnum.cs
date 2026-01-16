using System;
using Newtonsoft.Json;

namespace Skyline.DataMiner.Net.Ticketing.Validators
{
	/// <summary>
	/// Represents a state enum. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
    [Serializable]
    public class StateEnum : GenericEnum<int>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="StateEnum"/> class.
		/// </summary>
		public StateEnum()
        {
        }

		/// <summary>
		/// Class for constructing the default <see cref="StateEnum"/>. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
		/// </summary>
		public static class Default
        {
			/// <summary>
			/// Default state enum name.
			/// </summary>
			public static string EnumName = "StateEnum";

			/// <summary>
			/// Holds predefined state names. Obsolete. Ticketing is being retired (see <see href="xref:Software_support_life_cycles">DataMiner functionality evolution and retirement</see>).
			/// </summary>
			public static class States
            {
				/// <summary>
				/// The "Undefined" state.
				/// </summary>
				public static string Undefined = "Undefined";
				/// <summary>
				/// The "New" state.
				/// </summary>
				public static string New = "New";
				/// <summary>
				/// The "Assigned" state.
				/// </summary>
				public static string Assigned = "Assigned";
				/// <summary>
				/// The "In progress" state.
				/// </summary>
				public static string InProgress = "In Progress";
				/// <summary>
				/// The "On Hold" state.
				/// </summary>
				public static string OnHold = "On Hold";
				/// <summary>
				/// The "Solved" state.
				/// </summary>
				public static string Solved = "Solved";
				/// <summary>
				/// The "Closed" state.
				/// </summary>
				public static string Closed = "Closed";
            }

			/// <summary>
			/// Gets a default state enum.
			/// </summary>
			/// <remarks>
			/// <para>A state enum with name "StateEnum" and the following entries is returned:</para>
			/// <list type="bullet">
			/// <item>
			/// <description>Undefined</description>
			/// </item>
			/// <item>
			/// <description>New</description>
			/// </item>
			/// <item>
			/// <description>Assigned</description>
			/// </item>
			/// <item>
			/// <description>InProgress</description>
			/// </item>
			/// <item>
			/// <description>OnHold</description>
			/// </item>
			/// <item>
			/// <description>Solved</description>
			/// </item>
			/// <item>
			/// <description>Closed</description>
			/// </item>
			/// </list>
			/// </remarks>
			public static StateEnum DefaultEnum
            {
				get;
            }
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
            return false;
        }
    }
}