using Skyline.DataMiner.Net.Messages;
using System;
using System.Collections.Generic;
using Skyline.DataMiner.Net.Ticketing.Objects;

namespace Skyline.DataMiner.Net.Correlation
{
	/// <summary>
	/// Represents a ticket field configuration override. This class is used to define a TicketField when creating a correlation ticket action. Obsolete. Ticketing is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.
	/// </summary>
	[Serializable]
    public class TicketFieldOverrideConfig
    {
		/// <summary>
		/// Gets or sets the field name.
		/// </summary>
		/// <value>The name of the ticket field.</value>
		public string FieldName { get; set; }

		/// <summary>
		/// Gets or sets the alarm property exposer name.
		/// </summary>
		/// <value>The name of the exposer used to retrieve the alarm property.</value>
		public string AlarmPropertyExposerName { get; set; }

		/// <summary>
		/// Gets or sets the custom property name.
		/// </summary>
		/// <value>The name of the custom property when using a custom alarm property.</value>
		public string CustomPropertyName { get; set; }

		/// <summary>
		/// Gets or sets the custom property type.
		/// </summary>
		/// <value>The type of the custom property when using a custom alarm property.</value>
		public PropertyInfo.DataTypes CustomPropertyType { get; set; }

		/// <summary>
		/// Gets or sets the default value.
		/// </summary>
		/// <value>The default value that will be used when there is no alarm property defined or <see cref="AlarmPropertyExposerName"/> has value "StaticText".</value>
		public string DefaultValue { get; set; }

		/// <summary>
		/// Gets or sets a list of extra variable or static fields that will be concatenated to the first field value defined by <see cref="AlarmPropertyExposerName"/> if the field type of this ticket field is a string.
		/// </summary>
		/// <value>A list of extra variable or static fields that will be concatenated to the first field value defined by <see cref="AlarmPropertyExposerName"/> if the field type of this ticket field is a string.</value>
		public List<TicketFieldConcatItem> TicketFieldConcatItems { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldOverrideConfig"/> class.
		/// </summary>
		public TicketFieldOverrideConfig()
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldOverrideConfig"/> class using the specified field name, default value, alarm property exposer name and name and type of the custom property.
		/// </summary>
		/// <param name="fieldName">The field name.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <param name="alarmPropertyExposerName">The alarm property exposer name.</param>
		/// <param name="customPropertyName">The custom property name.</param>
		/// <param name="customPropertyType">The custom property type.</param>
		public TicketFieldOverrideConfig(string fieldName, string defaultValue, string alarmPropertyExposerName, string customPropertyName, PropertyInfo.DataTypes customPropertyType) 
            : this()
        {
        }

		/// <summary>
		/// Initializes a new instance of the TicketFieldOverrideConfig class using the specified field name and default value.
		/// </summary>
		/// <param name="fieldName">The field name.</param>
		/// <param name="defaultValue">The default value.</param>
		public TicketFieldOverrideConfig(string fieldName, string defaultValue)
            : this(fieldName, defaultValue, "", "", PropertyInfo.DataTypes.Alarm)
        {
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="TicketFieldOverrideConfig"/> class using the specified field name, alarm property exposer name and the name and type of the custom property.
		/// </summary>
		/// <param name="fieldName">The field name.</param>
		/// <param name="alarmPropertyExposerName">The alarm property exposer name.</param>
		/// <param name="customPropertyName">The custom property name.</param>
		/// <param name="customPropertyType">The custom property type.</param>
		public TicketFieldOverrideConfig(string fieldName, string alarmPropertyExposerName, string customPropertyName, PropertyInfo.DataTypes customPropertyType)
            : this(fieldName, "", alarmPropertyExposerName, customPropertyName, customPropertyType)
        {
        }
    }
}
