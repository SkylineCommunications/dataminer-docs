---
uid: Making_a_shape_display_information_about_the_item_it_is_linked_to
---

# Making a shape display information about the item it is linked to

Using a shape data field of type **Info**, you can make shapes display information about the item to which they are linked:

- If a shape is [linked to an element, a service or a redundancy group](xref:Linking_a_shape_to_an_element_a_service_or_a_redundancy_group), an **Info** field can be used to display the name or the current alarm state of that item.

- If a shape is [linked to an alarm](xref:Linking_a_shape_to_an_alarm), an **Info** field can be used to display information about that alarm.

- If a shape is [linked to a view](xref:Linking_a_shape_to_a_view), an **Info** field can be used to display the name of the view as well as statistical data concerning the alarms in that view.

- If a shape is [linked to a DCF interface](xref:Automatically_displaying_external_and_internal_connections), an **Info** field can be used to display the custom name of the DCF interface.

  > [!TIP]
  > See also: [Generating the connectivity chain for an SRM service instance](xref:Generating_the_connectivity_chain_for_an_SRM_service_instance)

- If a shape is linked to a view, a service or an element, an **Info** field can be used to display the number of tickets linked to that same view, service or element. See [Element statistics, service statistics, view statistics, etc](#element-statistics-service-statistics-view-statistics-etc).

- If a shape is [linked to a virtual function resource](xref:Linking_a_shape_to_a_resource), from DataMiner 9.5.13 onwards, an **Info** field can be used to display the name of the virtual function resource, the name of the main element generating the virtual function resource, the resource name or the name of the virtual function definition.

- If a shape is [linked to an EPM object](xref:Linking_a_shape_to_an_EPM_object), from DataMiner 10.1.0/10.0.4 onwards, an **Info** field can be used to display the system name or system type, and from DataMiner 10.3.2/10.4.0 onwards, it can be used to display statistics related to the EPM object.

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[data > PROPERTIES]* page.

## Configuring the shape data field

Add a shape data field of type **Info** to the shape, and set its value to one of the keywords listed below.

> [!NOTE]
> From DataMiner 10.0.2 onwards, these keywords (wrapped in square brackets) can be used as placeholders in the value of other shape data fields. From DataMiner 10.0.13 onwards, these can also be used within other placeholders. See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

- **Elements**:

  To display information about the element to which the shape is linked, specify:

  - *ALARM TEMPLATE*
  - *DATAMINER*
  - *DESCRIPTION*
  - *DISPLAY TYPE*
  - *ELEMENT NAME*
  - *ELEMENT STATISTICS:...*
  - *ID*
  - *IMPACTED SERVICES*
  - *IP*
  - *NAME*
  - *POLLING IP*
  - *PORT INFO*
  - *PROTOCOL*
  - *PROTOCOL TYPE*
  - *PROTOCOL VERSION*
  - *REDUNDANCY STATE*
  - *STATE*
  - *TREND TEMPLATE*
  - *TYPE*
  - *AVERAGE VALUE* (see [Displaying history values for parameters](xref:Linking_a_shape_to_an_element_parameter#displaying-history-values-for-parameters))
  - *MINIMUM VALUE* (see [Displaying history values for parameters](xref:Linking_a_shape_to_an_element_parameter#displaying-history-values-for-parameters))
  - *MAXIMUM VALUE* (see [Displaying history values for parameters](xref:Linking_a_shape_to_an_element_parameter#displaying-history-values-for-parameters))
  - *IN USE*: Displays "true" or "false" depending on whether the element is being used in a resource, is a DVE parent of a function resource, or represents the physical device corresponding with a virtual function resource (supported from DataMiner 10.3.0/10.2.6 onwards). Note that the [UseResource=true](xref:Linking_a_shape_to_a_resource) option must be specified on the element shape for this to work.
  - *Contributing Booking*: Displays the contributing booking ID of a resource (supported from DataMiner 10.3.0/10.2.11 onwards). Note that the [UseResource=true](xref:Linking_a_shape_to_a_resource) option must be specified on the element shape for this to work.

- **Services**:

  To display information about the service to which the shape is linked, specify:

  - *DATAMINER*
  - *DESCRIPTION*: The description of the service element.
  - *ELEMENT NAME*: Displays the element alias if one exists; otherwise the actual element name is displayed.
  - *FORCE ELEMENT NAME*: Displays the actual name of the service element, not the element alias.
  - *ID*
  - *NAME*
  - *SERVICE DESCRIPTION*: The description of the service itself (enhanced service only).
  - *SERVICE STATISTICS:...*

- **Redundancy groups**:

  To display information about the redundancy group to which the shape is linked, specify:

  - *DATAMINER*
  - *DESCRIPTION*
  - *ID*
  - *NAME*

- **Views**:

  To display information about the view to which the shape is linked, specify:

  - *ID*
  - *NAME*
  - *VIEW NAME*
  - *VIEW STATISTICS:...*

- **Alarms**:

  To display information about the alarm to which the shape is linked, specify:

  - *ALARM ID*
  - *ALARM TYPE*
  - *ALARMPROPERTY:\<PropertyName>*
  - *COMMENT*
  - *ELEMENT NAME*
  - *ELEMENT TYPE*
  - *ELEMENTPROPERTY:\<PropertyName>*
  - *OWNER*
  - *PARAMETER DESCRIPTION*
  - *PARAMETER KEY*
  - *RCA LEVEL*
  - *REDUNDANCY STATE*
  - *ROOT ALARM ID*
  - *ROOT TIME*
  - *SERVICE IMPACT*
  - *SERVICES*
  - *SEVERITY*
  - *SOURCE*
  - *STATUS*
  - *TIME*
  - *USER STATUS*
  - *VALUE*

- **Interfaces**:

  To display information about the DCF Interface to which the shape is linked, specify:

  - *CUSTOM NAME*

- **Virtual function resources**:

  To display information about the virtual function resource to which the shape is linked, specify:

  - *NAME*
  - *ELEMENT NAME*
  - *RESOURCE NAME*
  - *RESOURCE ID*
  - *FUNCTION NAME*
  - *IN USE*: Displays "true" or "false" depending on whether the resource is being used in any bookings (supported from DataMiner 10.3.0/10.2.3 onwards).

    > [!NOTE]
    >
    > - Prior to DataMiner 10.2.6/10.3.0, the "IN USE" check is only performed when the visual overview is opened or when the resource itself is changed.
    > - Using the "IN USE" placeholder may affect performance in case the system contains a large number of bookings.

- **Bookings**: See [Linking a shape to a booking](xref:Linking_a_shape_to_a_booking).

- **EPM objects**: See [Linking a shape to an EPM object](xref:Linking_a_shape_to_an_EPM_object).

## Placeholder for Info value in shape text

The info specified in the **Info** field will only appear on the shape if you add shape text that contains a "\*" character. This character will then be replaced by the requested information.

To add text to a shape, just double-click the shape, and enter the text.

> [!NOTE]
> From DataMiner 9.0 onwards, if an **Info** shape data field is set to *DATAMINER*, the placeholder is replaced by the name of the DMA that is currently hosting the element, service or redundancy group. In DataMiner versions up to DataMiner 9.0, the placeholder is replaced by the name of the DMA where the element, service or redundancy group was created.

## Element statistics, service statistics, view statistics, etc.

To display element statistics, service statistics or view statistics, the same placeholders are used as when configuring *MaintenanceSettings.xml* to display these statistics in the Surveyor.

For example, to display the number tickets for an element, you can set the value of the **Info** field to *ELEMENT STATISTICS:\[#Tickets\]*.

For more information, see [Displaying alarm statistics in the Surveyor](xref:Displaying_alarm_statistics_in_the_Surveyor) or [Displaying ticket statistics in the Surveyor](xref:Displaying_ticket_statistics_in_the_Surveyor).
