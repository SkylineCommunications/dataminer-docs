---
uid: Creating_a_list_view
---

# Creating a list view

To create a dynamic, filterable list view containing elements, services or bookings, you can configure a *ListView* component.

## Configuring the shape data field

To create a list view, add a shape on the Visio page with the following shape data items:

- **Component**: *ListView*  

- **ComponentOptions**: List of options, separated by pipe characters. For an overview of all possible component options, see [Component options](#component-options).

- **Columns**: The list of columns that have to be displayed. Preferably, this should be configured by specifying the name of a saved column configuration, e.g. *MyColumnconfig*. If you do not specify this shape data field or leave it empty, all columns will be displayed.
  
  Saving a column configuration is possible via the right-click menu of the list header in DataMiner Cube. This right-click menu also allows you to load a column configuration.

- **Source**: The type of items to be shown in the list:

  - *Elements*
  - *Services*
  - *Reservations* or *Bookings*
  - *Resources* (supported from DataMiner 10.1.11/10.2.0 onwards)

- **Filter**: See [List view filters](#list-view-filters).

> [!NOTE]
>
> - Viewing a list of elements will only be possible if you have the user permission *Elements* > *Access*.
> - Viewing a list of bookings will only be possible if the DMS has the necessary licenses and uses an [Elasticsearch](xref:Elasticsearch_database) database.
 > - If a *ListView* component with source *Reservations* or *Bookings* is used together with an embedded Resource Manager component, selecting an item in the list will select the corresponding block on the Resource Manager timeline and vice versa. See [Embedding a Resource Manager component](xref:Embedding_a_Resource_Manager_component).

## Component options

The following options can be specified in the *ComponentOptions* shape data field:

- **ColorRows=true/false**: Available from DataMiner 10.3.2/10.4.0 onwards. This option can be used to set the highlight color of the list view rows to the booking color. The booking color is a summary of the following reserved booking properties: *VisualForeground*, *VisualBackground*, *VisualSelectedForeground*, and *VisualSelectedBackground*. Each of those properties can be set to a string value representing a hexadecimal value, an (A)RGB value, or a predefined Windows color (the latter is not recommended). <!-- RN 35157 -->

  > [!NOTE]
  >
  > - The *ColorRows* feature is disabled by default ("ColorRows=False").
  > - At present, the *ColorRows* feature is only available on ListView components that have bookings as a source.
  > - Configuring gray-tinted foreground colors is not recommended as a ListView component uses a gray layer when you hover over its items. In the Skyline themes, that gray layer has the following color:
  >
  >   | Theme | Color of gray layer        |
  >   |-------|----------------------------|
  >   | Mixed | #E5E5E5 (RGB: 229,229,229) |
  >   | Light | #E5E5E5 (RGB: 229,229,229) |
  >   | Black | #333333 (RGB: 51,51,51)    |

- **DisableInUseItems=true/false**: When a list view is in edit mode, all list items have a checkbox in front of them. If *DisableInUseItems* is set to “true”, the checkboxes that should not be accessible will be shown as disabled. Default: false.

- **EditMode=true/false**: This option can be used to enable or disable the list view’s edit mode. If set to “true”, checkboxes will appear in front of every row.

- **Recursive**: This option can be used to link a list view to another list view. If, for example, a *ListView* component lists the services, and two other *ListView* components list the source and destination resources available and in use for the services in the first *ListView* component, then the *Recursive* option will allow the source and destination resource *ListView* components to link to the service *ListView* component, supporting any type of service hierarchy.

- **SessionVariablePrefix=\[prefix\]**: When you specify this option, a unique prefix is assigned to the session variable names. This option allows you to avoid having multiple *ListView* components using the exact same session variables.

- **SingleSelectionMode**: Available from DataMiner 10.3.4/10.4.0 onwards. By default, multiple rows can be selected in a list view (e.g. using the Ctrl or Shift key). With this option, you can set the selection mode of the list view to single instead, so that only one row can be selected at a time. <!-- RN 35320 -->

- **StartTime=** and **EndTime=**: If the list view is configured to list bookings, you can use these shape data to specify a time range, using an invariant format, for example: MM/DD/YYYY HH:MM:SS. These date/time values will always be **interpreted as UTC date/time values**. If these shape data are not specified, the following values are used by default:

  - StartTime = NOW - 8 hours
  - EndTime = NOW + 16 hours

  Prior to DataMiner 10.2.0 [CU13]/10.3.4, the following default values are used instead:

  - StartTime = NOW - 1 day
  - EndTime = NOW + 1 day

  Note that *SetVar* controls of type *DateTime* will automatically return a date and time in the correct format. See [Creating a DateTime control](xref:Adding_options_to_a_session_variable_control#creating-a-datetime-control). For more information on date and time format strings, see <https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings>.

  > [!NOTE]
  > If you use the *StartTime* and *EndTime* options for a *ListView* component with source *Reservations* or *Bookings*, the bookings in that time range will be added to the ones already present in the cache. If other bookings were already in the cache, these will be included in the list too. If you only want to include bookings from a specific time range, use a *Filter* shape data field instead.

## List view filters

In the Filters shape data field, it is possible to filter which information is displayed in the list view.

> [!NOTE]
> The filters are not case-sensitive. For example, a service with the name "MyName" will be found when the filter *Service.Name == 'myname'* is used

### Source: Reservations or Bookings

If you set the *Source* shape data field to “Reservations” or “Bookings”, the *Filter* shape data field can contain a booking filter based on any field or property. For example:

```txt
ReservationInstance.Name[string]== 'Encoder 2'
```

```txt
ReservationInstance.Name[string] contains 'Enc'
```

```txt
ReservationInstance.Status[Int32] == 3
```

> [!NOTE]
> The following values can be used for ReservationInstance.Status[Int32]:
>
> |Booking Status|Property value|
> |--------------|--------------|
> |Undefined     |0             |
> |Pending       |1             |
> |Confirmed     |2             |
> |Ongoing       |3             |
> |Ended         |4             |
> |Disconnected  |5             |
> |Interrupted   |6             |
> |Cancelled     |7             |

```txt
(ReservationInstance.End[DateTime] >01/22/2019 11:17:32)
```

```txt
ReservationInstance.Properties.Class[String] == 'Silver'
```

```txt
ReservationInstance.Name[string] notContains 'Decoder' AND (ReservationInstance.Start[DateTime] >02/16/2021 21:23:05)
```

To filter on a property with one or more spaces in the property name, use double quotation marks around the property name. For example:

```txt
ReservationInstance.Properties."Expected Service State"[String] contains 'STaRt'
```

From DataMiner 10.2.7/10.3.0 onwards, you can filter on type. For example:

```txt
ReservationInstance.ReservationInstanceType[Int32] == 1
```

> [!NOTE]
> The following values are supported for ReservationInstance.ReservationInstanceType[Int32]:
>
> | Booking type             | Property value |
> |--------------------------|----------------|
> | Default                  | 0              |
> | ProcessAutomation        | 1              |
> | CustomProcessAutomation  | 2              |
> | ResourceScheduling       | 3              |
> | ResourceOrchestration    | 4              |

### Source: Elements or Services

If you set the *Source* shape data field to “Elements” or “Services”, the *Filter* shape data field can contain different kinds of filters:

- A **view filter**, to make the list view only show items from one specific view.

  - You can filter on view ID or on view name. In case a specified view name cannot be found, the root view will be retrieved instead.

    For example:

    ```txt
    View=1001
    ```

    ```txt
    View=MyView
    ```

  - An alternative syntax, *ViewName=\<name>*, can be used from DataMiner 10.0.5 onwards. From this version onwards, you can also use the "==" operator instead of the "=" operator. If the *ViewName* syntax is used, DataMiner will first try to filter by name, and then by ID in case the name cannot be found. If the *View* syntax is used, DataMiner will first try to filter by ID and then by name if the ID cannot be found. The filter can contain only one *View* or *ViewName* part.

  - Session variables can be used in the filter. For example:

    ```txt
    View=[var:SRM_SelectedView]
    ```

- A **filter on the service name**.

  - The filter should contain the exposer "Service.Name" and the operator "not Contains" or "contains". The filter can be combined with a view filter, using a pipe (“\|”) character as separator. For example:

    ```txt
    View=[var:ViewFilter]|Service.Name notContains '1'|Service.Name notContains 'copy'
    ```

- An **element or service filter** (from DataMiner 10.0.5 onwards).

  - The following operators are supported: "*==*" (equals), "*!=*" (does not equal), "*contains*", "*notContains*", "*startswith*", "*notStartswith*", "*endsWith*", "*notEndsWith*", "*\<*" (smaller than, only usable with numbers) and "*\>*" (greater than, only usable with numbers). The value that is being compared with should always be included in single quotes.

    - The following terms can be used to filter on:

    | Filter term | Description |
    |--|--|
    | Element.ID | The ID of an element. |
    | Element.Name | The name of an element. |
    | Element.Description | The description of an element. |
    | Element.DataMiner | The name of the DMA on which an element is located. |
    | Element.AlarmLevel | The technical alarm level of the element. This is the non-localized, DataMiner-internal equivalent of the alarm state. For example, the alarm level "Undefined" is the same as the alarm state "Not monitored, the alarm level "Normal" is equivalent to the alarm state "Normaal" if the Dutch version of Cube is used. |
    | Element.AlarmState | The alarm state of the element. For the difference with the alarm level, see "Element.AlarmLevel". |
    | Element.AlarmCount | The number of alarms of the element. |
    | Element.Type | The type of element as defined in the protocol. |
    | Element.DisplayType | The display type of the element as defined in the protocol, e.g. *spectrum analyzer*, *element manager*. |
    | Element.IP | The IP of the element. |
    | Element.State | The current state of the element, e.g. Paused, Stopped. |
    | Element.Protocol | The protocol used by the element. |
    | Element.ProtocolVersion | The protocol version used by the element. |
    | Element.ProtocolType | The protocol type used by the element. |
    | Element.PollingIP | The polling IP used to communicate with the device. |
    | Element.AlarmTemplate | The alarm template used by the element. |
    | Element.TrendTemplate | The trend template used by the element. |
    | Element.Property.*PropertyName* | The property of the element with the specified property name. |
    | Service.ID | The ID of a service. |
    | Service.Name | The name of a service. |
    | Service.Description | The description of a service. |
    | Service.DataMiner | The name of the DMA on which a service is located. |
    | Service.AlarmLevel | The technical alarm level of the service. This is the non-localized, DataMiner-internal equivalent of the alarm state. For example, the alarm level "Undefined" is the same as the alarm state "Not monitored, the alarm level "Normal" is equivalent to the alarm state "Normaal" if the Dutch version of Cube is used. |
    | Service.AlarmState | The alarm state of the service. For the difference with the alarm level, see "Service.AlarmLevel". |
    | Service.AlarmCount | The number of alarms of the service. |
    | Service.Property.*PropertyName* | The property of the service with the specified property name. |

  - You can combine different search terms with each other and with one view filter, using pipe characters ("\|"). The pipe character is used as an AND operator.

  - Session variables can also be used in these filters.

  - Examples:

    - To filter on all elements of which the name contains the word "function" and the element property IDP is set to "Source":

      ```txt
      Element.Name contains 'function'|Element.Property.IDP == 'Source'
      ```

    - To filter on all services of which the name contains the word "\_booking" and that are hosted by the DataMiner Agent "MyDMA":

      ```txt
      Service.DataMiner == 'MyDMA'|Service.Name contains '_booking'
      ```

    - To filter on all elements using the protocol "MyProtocol" with the protocol type "serial" which are not of element type "Relay":

      ```txt
      Element.Protocol == 'MyProtocol'|Element.ProtocolType == 'serial'|Element.Type notContains 'Relay'
      ```

    - To filter on all element using the property IDP with a property value equal to that of the session variable "MySelectedValue":

      ```txt
      Element.Property.IDP == [var:MySelectedValue]
      ```

### Source: Resources

If you set the *Source* shape data field to “Resources”, the *Filter* shape data field can contain filters on the name, the ID, or any other field or property of the resources. For example:

```txt
Resource.Name[string]== 'Encoder'
```

```txt
Resource.Name contains 'res'
```

```txt
Resource.Name notContains 'res'
```

```txt
Resource.ID[Guid] == fad6a6dd-ca3a-4b6f-9ca7-b68fd2071786
```

```txt
Resource.MainDVEDmaID == 113
```

```txt
Resource.PoolGUIDs contains 0fb47f51-ad81-47f2-9e69-3d9477bdc961
```

```txt
Resource.MaxConcurrency != 1
```

```txt
Resource.PropertiesDict.Location[string] == '3'
```

```txt
Resource.Name[string] notContains 'RS' AND Resource.Name[string] notContains 'RT' AND Resource.Name[string] notContains 'ExposeFlow'
```

```txt
Resource.Mode[Int32] == 2
```

> [!NOTE]
> The following values can be used for Resource.Mode[Int32]:
>
> |Resource Mode |Property value|
> |--------------|--------------|
> |Undefined     |0             |
> |Available     |1             |
> |Maintenance   |2             |
> |Unavailable   |3             |

## Session variables

The following session variables can be used in conjunction with the *ListView* component:

- **DynamicList_CheckedItems**: When a list view is in edit mode, all list items have a checkbox in front of them. This session variable will contain the ID and the values of all editable columns of all list items of which the checkbox is selected.

- **FilterMode**: In situations with multiple linked *ListView* components, set the *FilterMode* variable to “true” if you want a second, linked list view to be filtered based on the item selected in the first list view. Default: false.

- **ListViewCheckingChanged**: When a list view is in edit mode, all list items have a checkbox in front of them. This session variable will contain the ID and the values of all editable columns of all list items of which the checkbox state has been changed.

- **ListViewDataChanged**: This session variable will indicate whether data has been changed in the list view.

- **ListViewSelectionChanged**: This session variable will indicate whether an item has been selected in the list view.

- **IDOfSelection**: This session variable contains a list of the IDs or GUIDs of the selected items, separated by pipe characters.

- **StateOfSelection**: When a booking is selected, this session variable the current state of the booking, which can be one of the following states:

  - Undefined (0)
  - Pending (1)
  - Confirmed (2)
  - Ongoing (3)
  - Ended (4)
  - Disconnected (5)
  - Interrupted (6)
  - Canceled (7)

- **ViewPort**: This session variable has to contain the time range that will be used when populating a dynamic list with bookings. For more information, see [ViewPort](xref:Embedding_a_Resource_Manager_component#viewport).

- **YAxisResources**: When the list is configured to show bookings, you can use this session variable to apply a filter. Example:

  ```json
  [{"Type":"custom","Background":"#FFFFFF","ItemHeight":64,"Filter":"(ReservationInstance.Name[String] notContains 'SRMExposeFlow')"}]
  ```

## Customizing a list view in DataMiner Cube

List view components can be found both in Visual Overview and in the DataMiner Bookings and Services apps. Regardless of this context, they can be configured in the same way.

- To sort the items in the list by a particular column, click the header of that column. Click the header again to reverse the sort order.

- To filter which items are displayed in the list, click the filter icon for the column you want to apply a filter to and enter a filter in the box below the column header.

  > [!NOTE]
  > When you filter a list view with source *Bookings* or *Reservations* on a GUID or a number, the list will show the matching booking as soon as a part of the entry matches the GUID or number. However, note that if you have combined the list view with [a timeline](xref:Embedding_a_Resource_Manager_component), the timeline will only show the matching booking if you enter the full and correct GUID or number.

- To apply a custom column configuration, see [Creating a new column configuration](#creating-a-new-column-configuration) and [Loading the default column configuration](#loading-the-default-column-configuration).

> [!NOTE]
> When an item is selected in the list, a session variable is populated with the booking ID, which can be of use for Visio drawings.

### Creating a new column configuration

1. Right-click in the list header, and apply the following configuration as you see fit:

   - Select *Add/Remove column* and indicate which columns should be added or removed.

   - Select *Alignment* and then choose a different text alignment for the columns.

   - Select *Change column name* and specify a new column name.

   - Select *Manage column configuration* (from DataMiner 10.0.4 onwards) or *Add/Remove column* \> *More* (up to DataMiner 10.0.3) to open a window where you can do the following:

     - Show or hide a column by selecting or clearing its checkbox, or by selecting it and clicking *Show* or *Hide*.

     - Move a column up or down by selecting it and clicking *Move up* or *Move down*.

     - For columns based on custom properties, select a different [column type](#available-column-types). For the default columns, the column type cannot be changed.

     - In the *Filter by type* section, indicate which type of columns you want to choose from: *Bookings* (or *Reservations* in earlier DataMiner versions) or *Properties*.

1. Right-click in the list header and select *Save current column configuration*

   When the module is opened again, this column configuration will be displayed. If you do not apply this last step, the column configuration will be reset when the module is closed.

### Loading the default column configuration

- Right-click in the list header, select *Load default column configuration*, and select the configuration you want to load.

### Available column types

When you manage the column configuration, you can select different column types. The following types are available:

- **Text**: Shows the value as text.

- **Alarm icon**: Use this type for a column indicating an ID of a service, element, or view. It will show the alarm icon for the relevant service, element, or view.

- **Custom icon**: Displays a custom icon. This relies on Automation scripts providing an icon library: a script that maps the custom icons, and a script that maps the column values to specific icon names. At present, this column type cannot be used.

- **Color**: Shows the color defined in the cell value. This can for example be used to show the color from the *VisualBackground* property of bookings.

- **Date**: Expects a Date object, or a string representing a date in UTC time, in the culture of the client.

- **Date (invariant)**: Available from DataMiner 10.2.12/10.3.0 onwards. Expects a Date object, or a string representing a date in UTC time, in [invariant culture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.invariantculture).

- **Colored text**: This type is specifically intended for the *AlarmCount* column for services and elements. It visualizes the alarm count by means of text surrounded by a circle showing the alarm level color.

## Copying list data to the Windows clipboard

From DataMiner 10.3.3/10.4.0 onwards, the *ListView* component allows you to copy data from the list to the Windows clipboard.

- To copy the contents of a single cell:

  1. Right-click in the cell.

  1. Choose *Copy \<cell contents\>*.

  > [!NOTE]
  > When you try to copy the contents of a single cell, the *Copy \<cell contents\>* command will only be available if that cell contains text.

- To copy the contents of one or more rows:

  1. Select the row(s).

  1. Choose *Copy selected row(s)*.

  > [!NOTE]
  >
  > - When you copy one or more rows, only cells that contain text will be included. For example, cells that only contain a colored rectangle will not be included.
  > - The order of the columns will be identical to the order of the columns in the *ListView* component. Column visibility and column order can be configured using the component's column manager.

The data copied to the Windows clipboard is split into a header section and a data section, separated by an empty line. The header section contains the column names, while the data section contains the actual row data.

<!-- RN 35170 -->