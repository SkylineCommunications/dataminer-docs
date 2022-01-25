---
uid: Creating_a_list_view
---

## Creating a list view

To create a dynamic, filterable list view containing elements, services or bookings, from DataMiner 9.6.4 onwards, it is possible to configure a *ListView* component.

> [!NOTE]
> - In DataMiner 9.6.4, this component can only be used in the visual overview of view cards. From DataMiner 9.6.5 onwards, element cards are also supported.
> - This component functions in a similar way as the bookings list in the Bookings module and the services list in the Services module. For more information on how to use this component in DataMiner Cube, see [Bookings list](xref:The_Bookings_module#bookings-list).

### Configuring the shape data field

To create a list view, add a shape on the Visio page with the following shape data items:

- **Component**: *ListView*  

- **ComponentOptions**: List of options, separated by pipe characters. For an overview of all possible component options, see [Component options](#component-options)

- **Columns**: The list of columns that have to be displayed. Preferably, this should be configured by specifying the name of a saved column configuration, e.g. *MyColumnconfig*. If you do not specify this shape data field or leave it empty, all columns will be displayed.
  
  Saving a column configuration is possible via the right-click menu of the list header in DataMiner Cube. This right-click menu also allows you to load a column configuration.

  Prior to DataMiner 9.6.13, the column configuration should be specified in JSON format, for example:

  ```json
  Columns='{"Name": "SetVar visioshape columnfilters","Version": 1,"Columns": [{"ColumnKey": "AlarmIcon","Position": 1,"PredefinedWidth": 50, "HorizontalAlignment":"center" },{"ColumnKey": "Name", "Position": 2,"PredefinedWidth": 200, },{"ColumnKey": "ID", "Position": 3,"PredefinedWidth": 80, }]}'
  ```

- **Source**: The type of items to be shown in the list:

   - *Elements*
   - *Services*
   - *Reservations* or *Bookings*
   - *Resources* (supported from DataMiner 10.1.11/10.2.0 onwards)

  Note that viewing a list of elements will only be possible if you have the user permission *Elements* > *Access*. Viewing a list of bookings will only be possible if the DMS has the necessary licenses. From DataMiner 10.0.0 onwards, DataMiner Indexing is also required to view a list of bookings.

- **Filter**: See [List view filters](#list-view-filters).

> [!NOTE]
> - If a *ListView* component with source *Reservations* or *Bookings* is used together with an embedded Resource Manager component, selecting an item in the list will select the corresponding block on the Resource Manager timeline and vice versa. See [Embedding a Resource Manager component](Embedding_a_Resource_Manager_component.md).
> - If colors are defined using the *Visual.Background* property of bookings, from DataMiner 9.6.13 onwards, these are displayed in the *Color* column of a *ListView* component showing bookings. In DataMiner 10.0.0/10.0.2, this property is renamed to *VisualBackground*. See [Customizing the color of booking blocks](Embedding_a_Resource_Manager_component.md#customizing-the-color-of-booking-blocks).

### Component options

The following options can be specified in the *ComponentOptions* shape data field:

- **DisableInUseItems=true/false**: When a list view is in edit mode, all list items have a checkbox in front of them. If *DisableInUseItems* is set to “true”, the checkboxes that should not be accessible will be shown as disabled. Default: false.

- **EditMode=true/false**: This option can be used to enable or disable the list view’s edit mode. If set to “true”, checkboxes will appear in front of every row.

- **Recursive**: This option can be used to link a list view to another list view. If, for example, a *ListView* component lists the services, and two other *ListView* components list the source and destination resources available and in use for the services in the first *ListView* component, then the *Recursive* option will allow the source and destination resource *ListView* components to link to the service *ListView* component, supporting any type of service hierarchy.

- **SessionVariablePrefix=\[prefix\]**: When you specify this option, a unique prefix is assigned to the session variable names. This option allows you to avoid having multiple *ListView* components using the exact same session variables.

- **StartTime=** and **EndTime=**: Available from DataMiner 9.6.5 onwards. If the list view is configured to list bookings, you can use these shape data to specify a time range, using an invariant format, for example: MM/DD/YYYY HH:MM:SS. If these shape data are not specified, the following values are used by default:

  - StartTime = NOW - 1 day
  - EndTime = NOW + 2 days

  Note that *SetVar* controls of type *DateTime* will automatically return a date and time in the correct format. See [Creating a DateTime control](Adding_options_to_a_session_variable_control.md#creating-a-datetime-control). For more information on date and time format strings, see <https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings>.

> [!NOTE]
> If you use the *StartTime* and *EndTime* options for a *ListView* component with source *Reservations* or *Bookings*, the bookings in that time range will be added to the ones already present in the cache. If other bookings were already in the cache, these will be included in the list too. If you only want to include bookings from a specific time range, use a *Filter* shape data field instead.

### List view filters

In the Filters shape data field, it is possible to filter which information is displayed in the list view.

> [!NOTE]
> The filters are not case-sensitive. For example, a service with the name "MyName" will be found when the filter *Service.Name == 'myname'* is used

#### Source: Reservations or Bookings

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

```txt
ReservationInstance.End[DateTime] >01/22/2019 11:17:32
```

```txt
ReservationInstance.Properties.Class[String] == 'Silver'
```

To filter on a property with one or more spaces in the property name, use double quotation marks around the property name. For example:

```txt
ReservationInstance.Properties."Expected Service State"[String] contains 'STaRt'
```

#### Source: Elements or Services

If you set the *Source* shape data field to “Elements” or “Services”, the *Filter* shape data field can contain a view filter to make the list view only show items from one specific view.

- Prior to DataMiner 9.6.8, filtering is only possible on view ID. For example:

    ```txt
    View=1001
    ```

- From DataMiner 9.6.8 onwards, view filters using the view name instead of the view ID are supported. In case the specified view cannot be found, the root view will be retrieved instead. For example:

    ```txt
    View=MyView
    ```

    An alternative syntax, *ViewName=\<name>*, can be used from DataMiner 10.0.5 onwards. From this version onwards, you can also use the "==" operator instead of the "=" operator. If the *ViewName* syntax is used, DataMiner will first try to filter by name, and then by ID in case the name cannot be found. If the *View* syntax is used, DataMiner will first try to filter by ID, and then by name if the ID cannot be found. The filter can contain only one *View* or *ViewName* part.

- From DataMiner 9.6.8 onwards, session variables can be used in the filter. For example:

    ```txt
    View=[var:SRM_SelectedView]
    ```

From DataMiner 9.6.11 onwards, if you set the *Source* shape data field to “Elements” or “Services”, the *Filter* shape data field can be used to apply a filter on the service name. The filter should contain the exposer "Service.Name" and the operator "not Contains" or "contains". The filter can be combined with a view filter, using a pipe (“\|”) character as separator. For example:

```txt
View=[var:ViewFilter]|Service.Name notContains '1'|Service.Name notContains 'copy'
```

From DataMiner 10.0.5 onwards, if you set the *Source* shape data field to “Elements” or “Services”, additional possibilities are available to add an element or service filter in the *Filter* shape data field:

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

#### Source: Resources

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

### Session variables

The following session variables can be used in conjunction with the *ListView* component:

- **DynamicList_CheckedItems**: When a list view is in edit mode, all list items have a checkbox in front of them. This session variable will contain the ID and the values of all editable columns of all list items of which the checkbox is selected.

- **FilterMode**: In situations with multiple linked *ListView* components, set the *FilterMode* variable to “true” if you want a second, linked list view to be filtered based on the item selected in the first list view. Default: false.

- **ListViewCheckingChanged**: When a list view is in edit mode, all list items have a checkbox in front of them. This session variable will contain the ID and the values of all editable columns of all list items of which the checkbox state has been changed.

- **ListViewDataChanged**: This session variable will indicate whether data has been changed in the list view.

- **ListViewSelectionChanged**: This session variable will indicate whether an item has been selected in the list view.

- **SelectedReservation** (deprecated from 9.6.8 onwards): When a booking is selected, this session variable will contain the ID of the booking. Use *IDOfSelection* instead from DataMiner 9.6.8 onwards.

- **IDOfSelection**: Available from DataMiner 9.6.8 onwards. This session variable contains a list of the IDs or GUIDs of the selected items, separated by pipe characters.

- **StateOfSelection**: Available from DataMiner 9.6.5 onwards. When a booking is selected, this session variable the current state of the booking, which can be one of the following states:

  - Undefined (0)
  - Pending (1)
  - Confirmed (2)
  - Ongoing (3)
  - Ended (4)
  - Disconnected (5)
  - Interrupted (6)
  - Canceled (7)

- **ViewPort**: This session variable has to contain the time range that will be used when populating a dynamic list with bookings. Example: *5248460498427387904;5248491602427387904*.

- **YAxisResources**: When the list is configured to show bookings, you can use this session variable to apply a filter. Example: 

  ```json
  [{"Type":"custom","Background":"#FFFFFF","ItemHeight":64,"Filter":"(ReservationInstance.Name[String] notContains 'SRMExposeFlow')"}]
  ```
