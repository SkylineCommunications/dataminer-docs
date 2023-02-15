---
uid: Embedding_a_Resource_Manager_component
---

# Embedding a Resource Manager component

For DMAs with a Resource Manager license, it is possible to embed a Resource Manager component in Visual Overview, which will allow users to get a timeline overview of which bookings have been made.

> [!NOTE]
> In order to see this component in Visual Overview, you need to have a Resource Manager license or IDP license, as well as the user permission [Modules > Resources > UI Available](xref:DataMiner_user_permissions#modules--resources--ui-available) (or in earlier versions of DataMiner: [Modules > Resource Manager > Reservations > UI available](xref:DataMiner_user_permissions#modules--resource-manager--reservations--ui-available)).

## Configuring the shape data fields of the timeline component

When you have created the shape that should display the Resource Manager timeline, add a shape data field of type **Component** to it, and set its value to “*Reservations*” or “*Bookings*”.

In addition, you can specify options using various other shape data fields, such as **ComponentOptions**. Different ComponentOptions can be combined with pipe characters. The following options are available:

| Shape data field | Value | Description |
|--|--|--|
| ComponentOptions | SessionVariablePrefix=\[prefix\] | When you specify this option, a unique prefix is assigned to the session variable names. This can be used in order to avoid any conflicts. For example, if you specify the value “*SessionVariablePrefix=RM*”, the session variable YaxisResources becomes RMYaxisResources. |
| ComponentOptions | DefaultBandHeight= | Sets the default height of the timeline bands. This value has to be an integer greater than 10, e.g. *DefaultBandHeight=100*. Any height specified using a JSON object in a *YaxisResources* session variable will override this value. See [YAxisResources](#yaxisresources). |
| ComponentOptions | EnableFollowMode | Activates the follow mode. This will make the timeline move along with the current time. When you navigate away from the line that represents now while follow mode is enabled, follow mode will temporarily be paused. As soon as you navigate back in view of the line that represents now, follow mode will be activated again. |
| ComponentOptions | AutoReEnableFollowModeTimeout= | Sets the number of seconds after which the follow mode will be reactivated each time a user jumps to another time range. This value has to be an integer greater than 0, e.g. *AutoReEnableFollowModeTimeout=5* |
| ComponentOptions | UseCommandsForCustomActions | Available from DataMiner 9.5.6 onwards. Allows the timeline to be used in conjunction with command control shapes to select an action mode. See [Configuring command controls for a Resource Manager component](#configuring-command-controls-for-a-resource-manager-component). |
| ComponentActions | \[{...json...}\] | Custom actions, specified with JSON objects. Available from DataMiner 9.5.4 onwards. For more information, see [Specifying custom actions in a Resource Manager component](#specifying-custom-actions-in-a-resource-manager-component). |
| Options | CardVariable | This option can be used to specify that the session variables mentioned in the other shape data fields are card variables, not page variables. It is also possible to configure a different session variable scope, as specified in [Indicating the scope of the variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable#indicating-the-scope-of-the-variable). |

Please note the following regarding this component:

- The **ComponentOptions** shape data field can also be configured to store properties of Resource Manager objects in variables. See [Making shapes display information about objects selected on the timeline](#making-shapes-display-information-about-objects-selected-on-the-timeline).

- The options related to variables can help avoid conflicts between variables when multiple cards are open. Otherwise, if you click a session variable shape on one card, this could have an effect on other cards.

- The appearance of bands on the timeline can be customized using the *YaxisResources* session variable. See [YAxisResources](#yaxisresources).

- The color of booking blocks can be customized using properties of the bookings. See [Customizing the color of booking blocks](#customizing-the-color-of-booking-blocks).

- If a *ListView* component with source *Reservations* or *Bookings* is used together with an embedded Resource Manager component, selecting an item in the list will select the corresponding block on the Resource Manager timeline and vice versa. See [Creating a list view](xref:Creating_a_list_view).

## Adding session variable controls for a Resource Manager component

When you have linked a shape to a Resource Manager timeline, you can add shapes that update session variables to the Visio drawing, in order to make it possible for users to determine what is displayed on the timeline.

> [!TIP]
> See also: [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)

The following session variables can be used specifically for a Resource Manager component:

- [ReservationsFilter](#reservationsfilter)

- [Navigate](#navigate)

- [ResourcesInSelectedReservation](#resourcesinselectedreservation)

- [TimerangeOfSelectedReservation](#timerangeofselectedreservation)

- [Viewport](#viewport)

- [YAxisResources](#yaxisresources)

### ReservationsFilter

To allow users to specify which booking blocks are displayed on the resource bands, use the session variable *ReservationsFilter*.

If, for example, you specify the value indicated in the first row of the table below, only the blocks that use the resource named “Antenna 2” will be shown in addition to the one of the resource band.

Use the *ALL* keyword if you want to clear the filter and display all bookings. However, note that this is not advisable on large systems with many resources and bookings, as it may have a negative impact on performance.

| Shape data field | Value                                 |
|------------------|---------------------------------------|
| SetVar           | ReservationsFilter:Resource=Antenna 2 |
| SetVar           | ReservationsFilter:ALL                |

### Navigate

To turn separate shapes into navigation controls, use the session variable *Navigate* in the **SetVar** shape data field on those shapes.

> [!NOTE]
>
> - After a particular action has been performed, the session variable *Navigate* will be cleared. That way, it can be set again to perform another action. You can, for example, keep clicking a “pan+day” button to slide to the right.
> - From DataMiner 10.0.0 \[CU14\]/10.1.0 \[CU3\]/10.1.6 onwards, it is possible to load a specific time slot immediately when a user navigates to the page. To do so, use the **InitVar** shape data on page level instead of the SetVar shape data mentioned above.

The following *Navigate* values are supported in the **SetVar** shape data field:

- **Navigate:now**

  Zooms in on a period from 3 hours ago to 3 hours from now.

- **Navigate:now(before X;after Y)**

  Supported from DataMiner 9.6.12 onwards. Zooms to a time frame around the current time: from X hours earlier until Y hours later.

  For example:

  - To show a time frame starting 1 hour earlier and ending 9 hours later:

    ```txt
    [sep::=]Navigate=now(before 01:00:00;after 09:00:00)
    ```

  - To show a time frame starting one day earlier and ending 3 months later:

    ```txt
    [sep::=]Navigate=now(before 1.00:00:00; after 90.00:00:00)
    ```

- **Navigate:yesterday**

  Zooms in on yesterday (midnight to midnight).

- **Navigate:yesterday(before X;after Y)**

  Supported from DataMiner 9.6.12 onwards. Zooms to a time frame around noon yesterday: from X hours earlier until Y hours later.

  For example:

  - To show a time frame starting 6 hours earlier and ending 6 hours later:

    ```txt
    [sep::=]Navigate=yesterday(before 06:00:00;after 06:00:00)
    ```

  - To show a time frame starting one day earlier and ending 3 months later:

    ```txt  
    [sep::=\Navigate=yesterday(before 1.00:00:00; after 90.00:00:00)
    ```

- **Navigate:today**

  Zooms in on today (midnight to midnight).

- **Navigate:today(before X;after Y)**

  Supported from DataMiner 9.6.12 onwards. Zooms to a time frame around noon today: from X time earlier until Y time later.

  For example:

  - To show a time frame starting 6 hours earlier and ending 6 hours later:

    ```txt
    [sep::=]Navigate=today(before 06:00:00;after 06:00:00)
    ```

  - To show a time frame starting one day earlier and ending 3 months later:

    ```txt
    [sep::=]Navigate=today(before 1.00:00:00; after 90.00:00:00)
    ```

- **Navigate:tomorrow**

  Zooms in on tomorrow (midnight to midnight).

- **Navigate:tomorrow(before X;after Y)**

  Supported from DataMiner 9.6.12 onwards. Zooms to a time frame around noon tomorrow: from X hours earlier until Y hours later.
  
  For example:

  - To show a time frame starting 6 hours earlier and ending 6 hours later:

    ```txt
    [sep::=]Navigate=tomorrow(before 06:00:00;after 06:00:00)
    ```

  - To show a time frame starting one day earlier and ending 3 months later:

    ```txt
    [sep::=]Navigate=tomorrow(before 1.00:00:00; after 90.00:00:00)
    ```

- **Navigate:pan+hour**
  
  Slides 1 hour to the right, without changing the zoom factor.

- **Navigate:pan+day**

  Slides 1 day to the right, without changing the zoom factor.

- **Navigate:pan+week**

  Slides 1 week to the right, without changing the zoom factor.

- **Navigate:pan+month**

  Slides 1 month to the right, without changing the zoom factor.

- **Navigate:pan-hour**

  Slides 1 hour to the left, without changing the zoom factor.

- **Navigate:pan-day**

  Slides 1 day to the left, without changing the zoom factor.

- **Navigate:pan-week**

  Slides 1 week to the left, without changing the zoom factor.

- **Navigate:pan-month**

  Slides 1 month to the left, without changing the zoom factor.

- **Navigate:zoom+hour**

  Changes the zoom factor with one additional hour, centering around the current DataMiner time.

- **Navigate:zoom+day**

  Changes the zoom factor with one additional day, centering around the current DataMiner time.

- **Navigate:zoom+week**

  Changes the zoom factor with one additional week, centering around the current DataMiner time.

- **Navigate:zoom+month**

  Changes the zoom factor with one additional month, centering around the current DataMiner time.

- **Navigate:zoom-hour**

  Changes the zoom factor to one hour less, centering around the current DataMiner time.

- **Navigate:zoom-day**

  Changes the zoom factor to one day less, centering around the current DataMiner time.

- **Navigate:zoom-week**

  Changes the zoom factor to one week less, centering around the current DataMiner time.

- **Navigate:zoom-month**

  Changes the zoom factor to one month less, centering around the current DataMiner time.

- **Navigate:yyyy-mm-dd hh:mm:ss**

  Zooms in on a period of 24 hours, centered on the specified time. This option is often used together with a shape data field of type *SetVarOptions* set to “Control=DateTime”, which will turn the shape into a date picker. See [Creating a DateTime control](xref:Adding_options_to_a_session_variable_control#creating-a-datetime-control).

### ResourcesInSelectedReservation

When a booking block is selected, this session variable will contain a comma-separated list of resource GUIDs.

Available from DataMiner 9.6.3 onwards.

### TimerangeOfSelectedReservation

When a booking block is selected, this session variable will contain the start-stop time range of the booking, inflated by 10%. Values in this session variable will be serialized, e.g. “5248098399646517511;5248392353962787511”.

Available from DataMiner 9.6.3 onwards.

### Viewport

When you pan or zoom in on the timeline, this session variable will contain the time range that is visible on the screen. From DataMiner 10.0.0 \[CU14\]/10.1.0 \[CU3\]/10.1.6 onwards, this session variable can also be used to zoom to a specific time range as soon as the component is loaded.

When this session variable is set by an external source, the timeline component will be updated to show the new time range.

The value can be set in serialized form (e.g. “5248098399646517511;5248392353962787511”) or using a “start;stop” format. In the latter case, start and stop must be timestamps that can be parsed by DateTime (e.g. “2017-09-17T09:42:01.9129607Z;2018-08-23T15:05:53.5399607Z” in ISO 8601 format, or “2017-08-07 9:42:01;2017-08-10 15:05:53” in UTC format "yyyy-mm-dd hh:mm:ss").

Available from DataMiner 9.6.3 onwards.

> [!NOTE]
>
> - Prior to DataMiner 9.6.11, the scope of this session variable is always global. From DataMiner 9.6.11 onwards, the card, page and workspace scope are also supported.
> - If both *Viewport* and *Navigate* are used, the *Navigate* variable will be processed after the *Viewport* variable.

### YAxisResources

To allow users to specify what is displayed on the Y-axis, use the session variable *YaxisResources* in the **SetVar** shape data field.

#### Passing pools and/or resources to the YAxisResources session variable

You can specify a comma-separated list of pools and/or individual resources. Use names or GUIDs.

From DataMiner 9.6.7 onwards, you can also specify the DMA ID/Element ID for resources that are linked to an element. Use the *ALL* keyword if you want to clear the filter and display all known resources. However, note that this is not advisable on large systems with many resources and bookings, as it may have a negative impact on performance.

Example values for the **SetVar** shape data field:

- *YaxisResources:Pool=Antennas,IRDs,Encoders*

  Creates a band for each resource in each of the specified pools. In this case the pools are specified by their names (comma-separated).

- *YaxisResources:Pool={863D1545-C7B7-4D3F-BFB8-BC8EF3B15859},{B7E038EC-96DE-4EF4-8485-AD2C1C8EACCD}*
  
  Creates a band for each resource in each of the specified pools, similar to the previous example. In this case the pools are specified by their GUIDs (comma-separated).

- *YaxisResources:Resource=R1,R2,R3*

  Creates a band for each specified resource. In this case, the resources are specified by their names, but you can also specify them by GUID or by DMA ID/element ID if they are linked to an element (from DataMiner 9.6.7 onwards). Either way, the resources should be separated by commas.

- *YaxisResources:ALL*

  Creates a band for each resource in the system. This is not recommended when there are many resources. If only *YaxisResources* is specified without any additional configuration, this will have the same effect.

#### Passing elements, services, views, or exposers to the YAxisResources session variable

From DataMiner 10.2.8/10.3.0 onwards, you can pass elements, services, or views to the YAxisResources session variable in order to show the corresponding resource bands.

##### Passing elements

You can pass elements by name or by ID as a string of comma-separated values.

In case an element is configured as an element reference in a resource, as a main DVE element in a function resource, or as the element corresponding with a virtual function resource, the corresponding resource will be shown.

In the following example, three elements are passed: an element with the name "MyElement", the element to which the Visio drawing is linked, and the element with ID 123/456:

`YAxisResources:Element=MyElement,[this element],123/456`

> [!NOTE]
> The corresponding resource bands are not updated automatically in case there is a change to the configuration of the elements.

##### Passing services

You can pass services by name or by ID as a string of comma-separated values.

The resources of the bookings linked to the services will be shown.

In the following example, three services are passed: a service with the name "MyService", the service to which the Visio drawing is linked, and the service with ID 123/456:

`YAxisResources:Service=MyService,[this service],123/456`

To also show resources for contributing bookings, in the **ComponentOptions** shape data field of the Resource Manager component, specify *Recursive=True*.

> [!NOTE]
> The resource band will be updated in real time, based on the linked booking. This means that when you add or remove resources in a booking, you will immediately see the effect on the timeline.

##### Passing views

You can pass views by name or by ID as a string of comma-separated values.

When you pass a view, for any elements in that view that are configured as an element reference in a resource, as a main DVE element in a function resource, or as the element corresponding with a virtual function resource, the corresponding resources will be shown.

In the following example, three views are passed: a view with the name "MyView", the view to which the Visio drawing is linked, and the view with ID 123:

`YAxisResources:View=MyView,[this view],123`

To also show resources for elements in child views, in the **ComponentOptions** shape data field of the Resource Manager component, specify *Recursive=True*.

> [!NOTE]
> The corresponding resource bands are not updated automatically in case there is a change to the configuration of the elements.

##### Passing exposers

From DataMiner 10.3.1/10.4.0 onwards, you can pass resource exposers as a filter by object ID, by using the "filter" option. You can use this to show the corresponding resource bands on the timeline.

> [!TIP]
> See also: [YAxisResource session variable examples](xref:YAxisResource_Shape_Data_Examples#passing-exposers-with-a-filter)

> [!NOTE]
> We recommend using a filter that results in less than 100 resources to avoid a possible delay while loading the bands.

You can also have a profile parameter name converted to the ID of the found object, using the format [ProfileParameter:xxx,ID], where "xxx" is replaced with the name of the capacity/capability profile parameter.

The profile parameter keys should be represented with the **number format**. For example:

- Default: d248b04f-2253-41c6-a92a-e12768fe2b20
- Number: d248b04f225341c6a92ae12768fe2b20

Do **not** use braces or parentheses. For example:

- {d248b04f-2253-41c6-a92a-e12768fe2b20}
- (d248b04f-2253-41c6-a92a-e12768fe2b20)

> [!NOTE]
> The server-side filter is case sensitive with regard to profile parameter keys.

> [!TIP]
> See also:
>
> - [YAxisResource session variable examples](xref:YAxisResource_Shape_Data_Examples#passing-exposers-with-a-filter-and-converter)
> - [Microsoft's Guid.ToString Method](https://learn.microsoft.com/en-us/dotnet/api/system.guid.tostring?view=netframework-4.8)

#### Specifying custom bands on the timeline

To specify custom bands on the timeline, from DataMiner 9.5.3 onwards, you can use the following configuration for the *YaxisResources* session variable:

| Shape data field | Value                           |
|--------------------|---------------------------------|
| InitVar            | `[sep::^]YaxisResources^[{*...json...*}, {*...json...*}, ...]` |

or

| Shape data field | Value                           |
|--------------------|---------------------------------|
| SetVar             | `[sep::§]YaxisResources§[{*...json...*}, {*...json...*}, ...]` |

> [!NOTE]
> Using `[sep::§]` is strongly recommended in order to avoid parsing problems. See [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters).

The JSON object for the custom bands can be configured with the following properties:

- **Name**: String. The name displayed on the Y-axis.

- **Type**: Specifies the type of band. Currently, only "custom" is supported.

- **Background**: Color. The background color for the band.

- **Height**: GridLength. The height of the band, either relative (e.g. *3\**), absolute (e.g. *200*) or *auto*. When empty, a default absolute height of 64 pixels is used. Not applicable when *ItemHeight* is filled in.

- **MinimumHeight**: Integer. The absolute minimum height, in case Height is relative or *ItemHeight* is used.

- **ItemHeight**: Integer. The fixed height of blocks on this band. If this is specified, the Height property is ignored. If there are a specific number of concurrent blocks, the band height will be that number multiplied by the specified *ItemHeight*. If necessary, a vertical scrollbar will appear.

- **Filter**: String. A filter that determines which blocks are displayed in this band. This field supports single filters and combination filters using an "AND" or "OR" operator. Most booking fields are supported, including booking properties, which should be specified using the exposer *ReservationInstance.Properties*. However, it is not possible to filter on the service definition name or on datetime fields. Also, for fields of type integer, only exact matches are supported.

Examples:

```txt
[
    {
        "type": "custom",
        "name": "Gold",
        "height": "2*",
        "background": "#FFFF00",
        "filter": "ReservationInstance.Properties.Class[String] == 'Gold'"
    },
    {
        "type": "custom",
        "name": "Silver",
        "height": "3*",
        "background": "#EEEEEE",
        "filter": "ReservationInstance.Properties.Class[String] == 'Silver'"
    }
]
```

```txt
[
    {
        "Type": "custom",
        "Name": "All",
        "Background": "##ADC9CA",
        "Height": "*",
        "ItemHeight":"45"
        "filter": "(ReservationInstance.Properties.Area[String] contains 'AJA') OR (ReservationInstance.Properties.Area[String] contains 'AJE')"
    },
]
```

> [!NOTE]
> You can use the “Minify/Compact” function at <https://jsonformatter.org/> to remove all whitespace and newlines from a JSON string before copying it to a Visio shape data item.

## Making shapes display information about objects selected on the timeline

To have shapes display information about an object selected on the timeline, the following session variables can be configured in the **Variable** shape data field:

- **SelectedOccurrence**: Available from DataMiner 9.5.4 onwards. Used in case there are recurring bookings.

- **SelectedPool**: From DataMiner 10.2.1/10.3.0 onwards, when you select a resource band, this variable is filled in with the first pool of the selected resource.

  > [!NOTE]
  > From DataMiner 10.2.10/10.3.0 onwards, the *SelectedPool* session variable will contain the GUIDs of all pools of the selected resource(s), separated by commas.

- **SelectedReservation**

- **SelectedResource**: From DataMiner 10.2.1/10.3.0 onwards, this variable is filled in when you select a resource band.

  > [!NOTE]
  > From DataMiner 10.2.7/10.3.0 onwards, users can select multiple bands by keeping the Ctrl key pressed when selecting different bands, or by keeping the Shift key pressed when selecting the first and last of several consecutive bands that need to be selected. In that case, the *SelectedResource* session variable will contain the GUIDs of all selected resources, separated by commas.

- **SelectedSession**

- **SelectedReservationDefinition**: Available from DataMiner 9.5.7 onwards. If the selected block is a booking instance linked to a particular booking definition, this variable will be filled in with the GUID of that definition.

- **SelectedTimeRange**: Available from DataMiner 10.2.1/10.3.0 onwards. The value of this variable can be set in serialized form (e.g. “5248098399646517511;5248392353962787511”) or using a “start;stop” format. In the latter case, start and stop must be timestamps that can be parsed by datetime (e.g. “2017-09-17T09:42:01.9129607Z;2018-08-23T15:05:53.5399607Z” in ISO 8601 format, or “17/09/2017 9:42:01;23/08/2018 15:05:53” in local format).

  > [!NOTE]
  > Prior to DataMiner 10.3.0/10.2.3, when a resource item is selected, the *SelectedTimeRange* session variable is cleared. From DataMiner 10.2.3 to 10.2.7, it is only cleared when the time range selection shown in the timeline area is changed. From DataMiner 10.3.0/10.2.8 onwards, the session variable is cleared when the selection is cleared.

Alternatively, you can also make shapes display properties of the *SelectedReservation*, *SelectedSession*, *SelectedResource*, *SelectedOccurrence* or *SelectedPool*. For this purpose, the properties must be stored in a variable, which is then displayed by a shape.

To have properties of Resource Manager objects stored in a variable:

- Configure the following value in the **ComponentOptions** shape data field of the Resource Manager timeline shape, depending on the type of variable you want to store the property in. To configure more than one variable, separate the configuration for each of them with pipe characters.

  | Type of variable | Value                                                  |
  |--------------------|--------------------------------------------------------|
  | Session variable   | setvar:\[VariableName\]=SelectedX.\[PropertyName\]     |
  | Card variable      | setcardvar:\[VariableName\]=SelectedX.\[PropertyName\] |
  | Page variable      | setpagevar:\[VariableName\]=SelectedX.\[PropertyName\] |

  Example:

  ```txt
  setvar:MyVar1=SelectedResource.Chain|setcardvar:MyVar2=SelectedPool.DeviceType|...
  ```

  > [!NOTE]
  > To avoid issues with the configuration, it is best not to mix card variables and page variables in the variable controls, but to use either one or the other.

- Configure a shape to display the variable. See [Making a shape display the current value of a variable](xref:Making_a_shape_display_the_current_value_of_a_variable).

## Specifying custom actions in a Resource Manager component

If a **ComponentActions** shape data field has been added to the *Reservations* or *Bookings* shape, you can execute custom actions on the timeline via a context menu. From DataMiner 10.2.8/10.3.0 onwards, this context menu is shown when you right-click the timeline. Prior to DataMiner 10.2.8/10.3.0, this context menu is displayed as soon as you make a selection on the timeline.

The **ComponentActions** shape data field should contain a JSON object with the following properties:

- **Name**: String. The text displayed in the context menu item.

- **Type**: Can be "script" or "set". Determines the type of action to be executed:

  - *script*: Run an Automation script.

  - *set*: Perform a parameter set.

  > [!NOTE]
  > The following legacy type naming is also supported:
  >
  > - *ias*, *automation*, or *automationscript*, instead of *script*
  > - *parameter* or *parameterset*, instead of *set*
  >
  > However, we recommend that you do not use this legacy type naming.

- **Execute**: String. The action to be executed. The same syntax is used as for Visio shapes:

  - *Script:ScriptName\|Dummies\|Parameters\|Memories\|Tooltip\|Options*

  - *Set\|DmaID/ElementID\|ParameterID:TableRowKey\|NewValue\|Options*

  > [!NOTE]
  > From DataMiner 9.5.14 onwards, it is possible to omit trailing pipe characters when you specify the Automation script. For example, instead of specifying “Script:MyScript\|\|\|\|\|”, you can simply specify “Script:MyScript”.

  Within this string, the following placeholders can be used:

  - *\[StartTime\]*: The timestamp of the start of the selected range.

  - *\[StopTime\]*: The timestamp of the end of the selected range.

- **Level**: Can be "global" or "reservation". Determines where the action is available:

  - *global*: On an empty part of the timeline.

  - *reservation*: On a booking block.

  > [!NOTE]
  > The following legacy level naming is also supported:
  >
  > - *general*, instead of *global*
  > - *block*, instead of *reservation*
  >
  > However, we recommend that you do not use this legacy level naming.

Example of a JSON string with custom actions:

```txt
[
    { "Name": "Action1", "Level": "global, "Type": "script","Execute":"script:CreateReservation||START=[StartTime];STOP=[StopTime]|||" },
    { "Name": "Action2", "Level": "reservation", "Type": "set","Execute": "set|34/5|1004:7|Off|" }
]
```

> [!NOTE]
> You can use the “Minify/Compact” function at <https://jsonformatter.org/> to remove all whitespace and newlines from a JSON string before copying it to a Visio shape data item.

## Configuring command controls for a Resource Manager component

From DataMiner 9.5.6 onwards, it is possible to use a Resource Manager component in conjunction with command control shapes, so that users can select a particular “mode” to determine which action is executed when they select a range on the timeline.

If this configuration is used, the selection behavior of the booking timeline is different from the default behavior: if the user first selects a command shape and then selects a timeline range, the corresponding command is immediately executed. If no command shape is selected first, the component will zoom in on the selected range.

You can configure this as follows:

1. Add the following shape data fields to the component shape:

    | Shape data     | Value    |
    |----------------|----------|
    | Component      | Name of the Visio component: *Reservations* or *Bookings*. |
    | ComponentActions | Custom actions, specified with JSON objects. See [Specifying custom actions in a Resource Manager component](#specifying-custom-actions-in-a-resource-manager-component). |
    | ComponentOptions | *UseCommandsForCustomActions* |
    | CommandPrefix    | Optional prefix added to the command name (in the shape containing the command, see below) in case multiple identical commands have to be configured for different instances of the same component (e.g. “*One\_*”). |

1. Add the following shape data fields to the command control shape:

    | Shape data     | Value      |
    |----------------|------------|
    | Command        | Name of the command to be executed (optionally preceded by the command prefix): *SetCustomActionMode*. |
    | CommandParameter | The name of the action, as configured in the *ComponentActions* field. If no action name is specified here, the default zoom action will be selected with this command shape. |
    | Scope          | The scope of the command: *Page* |

For example, a bookings timeline can be configured as follows:

| Shape data field | Value   |
|------------------|---------|
| Component        | Reservations   |
| ComponentActions | \[{ "Name": "Action1", "Execute": "script:a\|b\|c\|d\|e", "Type": "AutomationScript", "Level": "global" },{ "Name": "Action2", "Execute": "script:a\|b\|c\|d\|e", "Type": "AutomationScript", "Level": "global" },{ "Name": "Action3", "Execute": "script:a\|b\|c\|d\|e", "Type": "AutomationScript", "Level": "global" }\] |
| ComponentOptions | UseCommandsForCustomActions  |
| CommandPrefix    | CMD\_    |

In that case, you can for instance define the following command control shapes:

- To apply the default zoom action when selecting the timeline:

    | Shape data field   | Value                   |
    |--------------------|-------------------------|
    | Command            | CMD_SetCustomActionMode |
    | CommandParameter   |                         |
    | Scope              | Page                    |

- To apply action 1 when selecting the timeline:

    | Shape data field   | Value                   |
    |--------------------|-------------------------|
    | Command            | CMD_SetCustomActionMode |
    | CommandParameter   | Action1                 |
    | Scope              | Page                    |

## Customizing the color of booking blocks

The color of a timeline booking block can be customized with the following properties of the booking:

- From DataMiner 10.0.0/10.0.2 onwards:

    | Property               | Description                        |
    |--------------------------|------------------------------------|
    | VisualForeground         | The default foreground color       |
    | VisualBackground         | The default background color       |
    | VisualBorder             | The default border color           |
    | VisualSelectedForeground | The foreground color when selected |
    | VisualSelectedBackground | The background color when selected |
    | VisualSelectedBorder     | The border color when selected     |

- Prior to DataMiner 10.0.0/10.0.2:

    | Property                | Description                        |
    |---------------------------|------------------------------------|
    | Visual.Foreground         | The default foreground color       |
    | Visual.Background         | The default background color       |
    | Visual.Border             | The default border color           |
    | Visual.SelectedForeground | The foreground color when selected |
    | Visual.SelectedBackground | The background color when selected |
    | Visual.SelectedBorder     | The border color when selected     |

The value of these properties can be defined as follows:

- As a pre-defined color:

  - Case-insensitive.

  - List of supported color names: <https://msdn.microsoft.com/en-us/library/system.windows.media.colors.aspx>

  - Example: *Green*

- In (A)RGB hexadecimal format:

  - Case-insensitive. Code must start with a hashtag and can only contain hexadecimal values.

  - 3-digit, 6-digit and 8-digit formats are supported (8-digit format can contain an alpha value).

  - Examples: *#0F0*, *#00FF00* and *#FF00FF00*

- Using (A)RGB Integer Functional Notation

  - 3 integer values separated by commas. Can be preceded by a fourth integer value (i.e. an alpha value). Each of these values must be between 0 and 255.

  - Template: “R,G,B” or “A,R,G,B” - A (alpha), R (red), G (green), B (blue)

  - Example: *141,89,0,184*

> [!NOTE]
> If the API is used to update the color of a booking, ideally the ResourceManagerHelper calls *UpdateReservationInstanceProperties*(…) and *SafelyUpdateReservationInstanceProperties* (…) should be used. These assure the best performance when booking properties are updated and prevent possible issues when a booking is updated multiple times during its runtime.
>
