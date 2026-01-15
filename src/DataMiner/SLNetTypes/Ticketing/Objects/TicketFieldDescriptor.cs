using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Skyline.DataMiner.Net.Exceptions;
using Skyline.DataMiner.Net.Messages;
using Skyline.DataMiner.Net.Ticketing.Interfaces;

namespace Skyline.DataMiner.Net.Ticketing.Objects
{
	/// <summary>
	/// Describes a ticket field used by <see cref="Helpers.TicketFieldResolver"/>. Obsolete. Ticketing is no longer available from DataMiner 10.6.0/10.6.2 onwards.
	/// </summary>
	/// <remarks>A <see cref="TicketFieldDescriptor"/> is uniquely identified by <see cref="TicketFieldDescriptor.FieldName"/>.</remarks>
	[Serializable]
    public class TicketFieldDescriptor : IEquatable<TicketFieldDescriptor>
    {
		#region Properties & Fields
		/// <summary>
		/// Gets or sets the uniquely identifiable name of the field.
		/// </summary>
		/// <value>The uniquely identifiable name of the field.</value>
		/// <remarks>
		/// <para>From DataMiner 10.1.11 onwards (RN 30962), the field name must meet the following requirements:</para>
		/// <para>It cannot start with an underscore character (“_”).</para>
		/// <para>It cannot contain any of the following characters:</para>
		/// <list type="bullet">
		/// <item><description>. (period)</description></item>
		/// <item><description># (number sign)</description></item>
		/// <item><description>* (asterisk)</description></item>
		/// <item><description>, (comma)</description></item>
		/// <item><description>" (double quote)</description></item>
		/// <item><description>' (single quote)</description></item>
		/// </list>
		/// </remarks>
		[JsonProperty]
        public string FieldName { get; set; }

		/// <summary>
		/// Gets or sets the display name of the field.
		/// </summary>
		/// <value>The display name of the field.</value>
		[JsonProperty]
        public string FieldDisplayName { get; set; }

		/// <summary>
		/// Gets or sets the type of value that will be saved in the field.
		/// </summary>
		/// <value>The type of value that will be saved in the field.</value>
		///<remarks>Usually basic types will be used (e.g. string, int, double), but any serializable type known to SLNet is supported.</remarks>
		[JsonProperty]
        public Type FieldType { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this field should be shown in the ticket overview.
		/// </summary>
		/// <value><c>true</c> if this field should be shown in the ticket overview; otherwise, <c>false</c>.</value>
		/// <remarks>This default value of this property is <c>true</c>.</remarks>
		[JsonProperty]
        public bool ShowColumnInTicketOverview { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether single filtering on the values of this field is allowed.
		/// </summary>
		/// <value><c>true</c> if single filtering on the values of this field is allowed; otherwise, <c>false</c>.</value>
		[JsonProperty]
        public bool SingleSelectionFilter { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether multiple filtering on the values of this field is allowed.
		/// </summary>
		/// <value><c>true</c> if multiple filtering on the values of this field is allowed; otherwise, false.</value>
		[JsonProperty]
        public bool MultiSelectionFilter { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this field is a required field (i.e. <see langword="null"/> is not allowed).
		/// </summary>
		/// <value><c>true</c> if this is a required field; otherwise, false.</value>
		[JsonProperty]
        public bool IsRequired { get; set; }

		/// <summary>
		/// Gets or sets the default value for this field when creating a new ticket.
		/// </summary>
		/// <value>The default value for this field when creating a new ticket.</value>
		[JsonProperty]
        public object DefaultValue
        {
			get; set;
        }

		/// <summary>
		///  Gets or sets the <see cref="ITicketFieldValidator"/> object used to validate the value of the field.
		/// </summary>
		/// <value>The <see cref="ITicketFieldValidator"/> object used to validate the value of the field.</value>
		[JsonProperty]
        public ITicketFieldValidator Validator { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this is a third-party field (i.e. a field from an external ticketing system).
		/// </summary>
		/// <value><c>true</c> if this is a third-party field; otherwise, false.</value>
		[JsonProperty]
        public bool IsThirdParty { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the third-party is master of this field.
		/// </summary>
		/// <value><c>true</c> if DataMiner is master of this field; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>The master will get priority when concurrent modifications happen.</para>
		/// <para>If both this property and <see cref="IsDataMinerMaster"/> are set to false, then clash resolving is done based on time stamps.</para>
		/// </remarks>
		[JsonProperty]
        public bool IsThirdPartyMaster
        {
			get; set;
        }

		/// <summary>
		/// Gets or sets a value indicating whether DataMiner is master of this field.
		/// </summary>
		/// <value><c>true</c> if DataMiner is master of this field; otherwise, <c>false</c>.</value>
		/// <remarks>
		/// <para>The master will get priority when concurrent modifications happen.</para>
		/// <para>If both this property and <see cref="IsThirdPartyMaster"/> are set to false, then clash resolving is done based on time stamps.</para>
		/// </remarks>
		[JsonProperty]
        public bool IsDataMinerMaster
        {
			get; set;
        }

		/// <summary>
		/// Gets a value indicating whether this is a placeholder.
		/// </summary>
		/// <value><c>true</c> if this <see cref="TicketFieldDescriptor" /> is a placeholder; otherwise, <c>false</c>.</value>
		public bool IsPlaceHolder;


		/// <summary>
		/// Gets the <see cref="TicketFieldDescriptor"/> instance representing a third-party ticket field placeholder.
		/// </summary>
		/// <value>The <see cref="TicketFieldDescriptor"/> instance representing a third-party ticket field placeholder.</value>
		public static TicketFieldDescriptor ThirdPartyPlaceHolder
        {
			get;
        }

		/// <summary>
		/// Gets the <see cref="TicketFieldDescriptor"/> instance representing a DataMiner ticket field placeholder.
		/// </summary>
		/// <value>The <see cref="TicketFieldDescriptor"/> instance representing a DataMiner ticket field placeholder.</value>
		public static TicketFieldDescriptor DataMinerPlaceHolder
        {
			get;
        }

		/// <summary>
		/// Gets or sets the name of the linked alarm property field.
		/// </summary>
		/// <value>The name of the linked alarm property field.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.5 (RN 21202).</remarks>
		[JsonProperty]
        public string AlarmProperty { get; set; }

		/// <summary>
		/// Gets or sets the name of the linked custom property.
		/// </summary>
		/// <value>The name of the linked custom property.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.5 (RN 21202).</remarks>
		[JsonProperty]
        public string CustomAlarmPropertyName { get; set; }

		/// <summary>
		/// Gets or sets the type of the linked custom property.
		/// </summary>
		/// <value>The type of the linked custom property.</value>
		/// <remarks>Feature introduced in DataMiner 9.6.5 (RN 21202).</remarks>
		[JsonProperty]
        public PropertyInfo.DataTypes CustomAlarmPropertyType { get; set; }

        /// <summary>
        /// Defines the string that will be filled in the TicketField.
        /// This value is used when <see cref="AlarmProperty"/> has value "StaticText"
        /// </summary>
        [JsonProperty]
        public string StaticTextValue { get; set; }

        /// <summary>
        /// Defines a list of extra variable or static fields that will be concatenated
        /// to the first field value defined by <see cref="AlarmProperty"/>
        /// if <see cref="FieldType"/> equals String.
        /// </summary>
        [JsonProperty]
        public List<TicketFieldConcatItem> TicketFieldConcatItems { get; set; }
		#endregion


		#region Construction
		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldDescriptor"/> class.
		/// </summary>
		public TicketFieldDescriptor()
        {
        }
		#endregion

		#region Serialization logic
		/// <summary>
		/// Creates a JSON string representation of this <see cref="TicketFieldDescriptor"/> object.
		/// </summary>
		/// <returns>The JSON string representation of this <see cref="TicketFieldDescriptor"/> object.</returns>
		public string ToJson()
        {
			return "";
        }

		/// <summary>
		/// Parses the specified JSON string and creates a <see cref="TicketFieldDescriptor"/> object.
		/// </summary>
		/// <param name="json">The JSON string from which to create a <see cref="TicketFieldDescriptor"/>.</param>
		/// <exception cref="DataMinerJsonDeserializationException">Invalid JSON string.</exception>
		/// <returns>The <see cref="TicketFieldDescriptor"/> object.</returns>
		public static TicketFieldDescriptor FromJson(string json)
        {
			return null;
		}
		#endregion

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		/// <remarks>
		/// <para>Only checks if <see cref="FieldName"/> is the same.</para>
		/// </remarks>
		public bool Equals(TicketFieldDescriptor other)
        {
            return true;
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
        {
            return true;
        }

		/// <summary>
		///	Calculates the hash code for this object.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override int GetHashCode()
        {
             return 1;
        }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override string ToString()
        {
            return "";
        }
    }
}
