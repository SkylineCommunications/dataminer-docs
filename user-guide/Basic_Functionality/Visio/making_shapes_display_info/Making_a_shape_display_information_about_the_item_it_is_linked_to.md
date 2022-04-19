---
uid: Making_a_shape_display_information_about_the_item_it_is_linked_to
---

# Making a shape display information about the item it is linked to

Using a shape data field of type **Info**, you can make shapes display information about the item to which they are linked:

- If a shape is linked to an element, a service or a redundancy group, an **Info** field can be used to display the name or the current alarm state of that item.

- If a shape is linked to an alarm, an **Info** field can be used to display information about that alarm.

- If a shape is linked to a view, an **Info** field can be used to display the name of the view as well as statistical data concerning the alarms in that view.

- If a shape is linked to a DCF Interface, an **Info** field can be used to display the custom name of the DCF interface.

- If a shape is linked to a view, a service or an element, an **Info** field can be used to display the number of tickets linked to that same view, service or element. See [Element statistics, service statistics, view statistics, etc](#element-statistics-service-statistics-view-statistics-etc).

- If a shape is linked to a virtual function resource, from DataMiner 9.5.13 onwards, an **Info** field can be used to display the name of the virtual function resource, the name of the main element generating the virtual function resource, the resource name or the name of the virtual function definition.

  > [!TIP]
  > See also: [Generating the connectivity chain for an SRM service instance](xref:Generating_the_connectivity_chain_for_an_SRM_service_instance)

> [!NOTE]
>
> - For an example of use, refer to the view "Linking Shapes" on the [Ziine Demo System](xref:ZiineDemoSystem). The example can be found on the Visual page _data > PROPERTIES_.

## Configuring the shape data field

Add a shape data field of type **Info** to the shape, and set its value to one of the keywords listed below.

> [!NOTE]
> From DataMiner 10.0.2 onwards, these keywords (wrapped in square brackets) can be used as placeholders in the value of other shape data fields. From DataMiner 10.0.13 onwards, these can also be used within other placeholders. See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

- **Elements**:

  To display information about the element to which the shape is linked, specify:

  - _ALARM TEMPLATE_

  - _DATAMINER_

  - _DESCRIPTION_

  - _DISPLAY TYPE_

  - _ELEMENT NAME_

  - _ELEMENT STATISTICS:..._

  - _ID_

  - _IMPACTED SERVICES_

  - _IP_

  - _NAME_

  - _POLLING IP_

  - _PORT INFO_

  - _PROTOCOL_

  - _PROTOCOL TYPE_

  - _PROTOCOL VERSION_

  - _REDUNDANCY STATE_

  - _STATE_

  - _TREND TEMPLATE_

  - _TYPE_

- **Services**:

  To display information about the service to which the shape is linked, specify:

  - _DATAMINER_

  - _DESCRIPTION_: The description of the service element.

  - _ELEMENT NAME_: Displays the element alias if one exists; otherwise the actual element name is displayed.

  - _FORCE ELEMENT NAME_: Displays the actual name of the service element, not the element alias.

  - _ID_

  - _NAME_

  - _SERVICE DESCRIPTION_: The description of the service itself (enhanced service only).

  - _SERVICE STATISTICS:..._

- **Redundancy groups**:

  To display information about the redundancy group to which the shape is linked, specify:

  - _DATAMINER_

  - _DESCRIPTION_

  - _ID_

  - _NAME_

- **Views**:

  To display information about the view to which the shape is linked, specify:

  - _ID_

  - _NAME_

  - _VIEW NAME_

  - _VIEW STATISTICS:..._

- **Alarms**:

  To display information about the alarm to which the shape is linked, specify:

  - _ALARM ID_

  - _ALARM TYPE_

  - _ALARMPROPERTY:\<PropertyName>_

  - _COMMENT_

  - _ELEMENT NAME_

  - _ELEMENT TYPE_

  - _ELEMENTPROPERTY:\<PropertyName>_

  - _OWNER_

  - _PARAMETER DESCRIPTION_

  - _PARAMETER KEY_

  - _RCA LEVEL_

  - _REDUNDANCY STATE_

  - _ROOT ALARM ID_

  - _ROOT TIME_

  - _SERVICE IMPACT_

  - _SERVICES_

  - _SEVERITY_

  - _SOURCE_

  - _STATUS_

  - _TIME_

  - _USER STATUS_

  - _VALUE_

- **Interfaces**:

  To display information about the DCF Interface to which the shape is linked, specify:

  - _CUSTOM NAME_

- **Virtual function resources**:

  To display information about the virtual function resource to which the shape is linked, specify:

  - _NAME_

  - _ELEMENT NAME_

  - _RESOURCE NAME_

  - _RESOURCE ID_

  - _FUNCTION NAME_

  - _IN USE_: Displays "true" or "false" depending on whether the resource is being used in any bookings (supported from DataMiner 10.3.0/10.2.3 onwards). This check is performed when the visual overview is opened or when the resource itself is changed. Note that using this placeholder may affect performance in case the system contains a large number of bookings.

- **Bookings**: See [Linking a shape to a booking](xref:Linking_a_shape_to_a_booking).

## Placeholder for Info value in shape text

The info specified in the **Info** field will only appear on the shape if you add shape text that contains a “\*” character. This character will then be replaced by the requested information.

To add text to a shape, just double-click the shape, and enter the text.

> [!NOTE]
> From DataMiner 9.0 onwards, if an **Info** shape data field is set to _DATAMINER_, the placeholder is replaced by the name of the DMA that is currently hosting the element, service or redundancy group. In DataMiner versions up to DataMiner 9.0, the placeholder is replaced by the name of the DMA where the element, service or redundancy group was created.

## Element statistics, service statistics, view statistics, etc.

To display element statistics, service statistics or view statistics, the same placeholders are used as when configuring _MaintenanceSettings.xml_ to display these statistics in the Surveyor.

For example, to display the number tickets for an element, you can set the value of the **Info** field to _ELEMENT STATISTICS:\[#Tickets\]_.

For more information, see [Displaying alarm statistics in the Surveyor](xref:Displaying_alarm_statistics_in_the_Surveyor) or [Displaying ticket statistics in the Surveyor](xref:Displaying_ticket_statistics_in_the_Surveyor).
