## Making a shape display information about the item it is linked to

Using a shape data field of type **Info**, you can make shapes display information about the item to which they are linked:

- If a shape is linked to an element, a service or a redundancy group, an **Info** field can be used to display the name or the current alarm state of that item.

- If a shape is linked to an alarm, an **Info** field can be used to display information about that alarm.

- If a shape is linked to a view, an **Info** field can be used to display the name of the view as well as statistical data concerning the alarms in that view.

- If a shape is linked to a DCF Interface, an **Info** field can be used to display the custom name of the DCF interface.

- If a shape is linked to a view, a service or an element, an **Info** field can be used to display the number of tickets linked to that same view, service or element. See [Element statistics, service statistics, view statistics, etc.](#element-statistics-service-statistics-view-statistics-etc).

- If a shape is linked to a virtual function resource, from DataMiner 9.5.13 onwards, an **Info** field can be used to display the name of the virtual function resource, the name of the main element generating the virtual function resource, the resource name or the name of the virtual function definition.

    > [!TIP]
    > See also:
    > [Generating the connectivity chain for an SRM service instance](Generating_the_connectivity_chain_for_an_SRM_service_instance.md)

### Configuring the shape data field

Add a shape data field of type **Info** to the shape, and set its value to one of the keywords listed below.

> [!NOTE]
> From DataMiner 10.0.2 onwards, these keywords (wrapped in square brackets) can be used as placeholders in the value of other shape data fields. From DataMiner 10.0.13 onwards, these can also be used within other placeholders. See [Placeholders for variables in shape data values](Placeholders_for_variables_in_shape_data_values.md). 

- **Elements**:

    To display information about the element to which the shape is linked, specify:

    - ALARM TEMPLATE

    - DATAMINER

    - DESCRIPTION

    - DISPLAY TYPE

    - ELEMENT NAME

    - ELEMENT STATISTICS:...

    - ID

    - IMPACTED SERVICES

    - IP

    - NAME

    - POLLING IP

    - PORT INFO

    - PROTOCOL

    - PROTOCOL TYPE

    - PROTOCOL VERSION

    - REDUNDANCY STATE

    - STATE

    - TREND TEMPLATE

    - TYPE

- **Services**:

    To display information about the service to which the shape is linked, specify:

    - DATAMINER

    - DESCRIPTION

    - ELEMENT NAME

    - FORCE ELEMENT NAME

    - ID

    - NAME

    - SERVICE DESCRIPTION *(enhanced service only)*

    - SERVICE STATISTICS:...

    > [!NOTE]
    > -  **ELEMENT NAME vs. FORCE ELEMENT NAME:**<br>In Visio drawings linked to a service, shapes that display the name of a service element (using a shape data field **Info** set to “ELEMENT NAME”) display the element alias if one exists. If you want to override this default behavior and force a shape to display the actual name of a service element, use a shape data field **Info** set to “FORCE ELEMENT NAME”.
    > -  **DESCRIPTION vs. SERVICE DESCRIPTION:**<br>When a shape is linked to an enhanced service, and you set the Info field to “DESCRIPTION”, the shape will contain the description of the service element. To make it display the description of the service instead, set the Info field to “SERVICE DESCRIPTION”.

- **Redundancy groups**:

    To display information about the redundancy group to which the shape is linked, specify:

    - DATAMINER

    - DESCRIPTION

    - ID

    - NAME

- **Views**:

    To display information about the view to which the shape is linked, specify:

    - ID

    - NAME

    - VIEW NAME

    - VIEW STATISTICS:...

- **Alarms**:

    To display information about the alarm to which the shape is linked, specify:

    - ALARM ID

    - ALARM TYPE

    - ALARMPROPERTY:*PropertyName*

    - COMMENT

    - ELEMENT NAME

    - ELEMENT TYPE

    - ELEMENTPROPERTY:*PropertyName*

    - OWNER

    - PARAMETER DESCRIPTION

    - PARAMETER KEY

    - RCA LEVEL

    - REDUNDANCY STATE

    - ROOT ALARM ID

    - ROOT TIME

    - SERVICE IMPACT

    - SERVICES

    - SEVERITY

    - SOURCE

    - STATUS

    - TIME

    - USER STATUS

    - VALUE

- **Interfaces**:

    To display information about the DCF Interface to which the shape is linked, specify:

    - CUSTOM NAME

- **Virtual function resources**:

    To display information about the virtual function resource to which the shape is linked, specify:

    - NAME

    - ELEMENT NAME

    - RESOURCE NAME

    - RESOURCE ID

    - FUNCTION NAME

- **Bookings**: See [Linking a shape to a booking](Linking_a_shape_to_a_booking.md).

### Placeholder for Info value in shape text

The info specified in the **Info** field will only appear on the shape if you add shape text that contains a “\*” character. This character will then be replaced by the requested information.

To add text to a shape, just double-click the shape, and enter the text.

> [!NOTE]
> From DataMiner 9.0 onwards, if an **Info** shape data field is set to *DATAMINER*, the placeholder is replaced by the name of the DMA that is currently hosting the element, service or redundancy group. In DataMiner versions up to DataMiner 9.0, the placeholder is replaced by the name of the DMA where the element, service or redundancy group was created.

### Element statistics, service statistics, view statistics, etc.

To display element statistics, service statistics or view statistics, the same placeholders are used as when configuring *MaintenanceSettings.xml* to display these statistics in the Surveyor.

For example, to display the number tickets for an element, you can set the value of the **Info** field to *ELEMENT STATISTICS:\[#Tickets\]*.

For more information, see [Displaying alarm statistics in the Surveyor](../alarms/Displaying_alarm_statistics_in_the_Surveyor.md) or [Displaying ticket statistics in the Surveyor](../../part_4/ticketing/Displaying_ticket_statistics_in_the_Surveyor.md).
