---
uid: Embedding_a_Resource_Manager_component
---

# Embedding a Resource Manager component

For DMAs with a Resource Manager license, it is possible to embed a Resource Manager component in Visual Overview, which will allow users to get a timeline overview of which bookings have been made.

> [!NOTE]
> In order to see this component in Visual Overview, you need to have a Resource Manager license or IDP license, as well as the user permission *Modules* > *Resources* > *UI Available* (or in earlier versions of DataMiner: *Modules* > *Resource Manager* > *Reservations* > *Timeline UI available*).

In this section:

- [Configuring the shape data fields of the timeline component](#configuring-the-shape-data-fields-of-the-timeline-component)

- [Adding session variable controls for a Resource Manager component](#adding-session-variable-controls-for-a-resource-manager-component)

- [Making shapes display information about objects selected on the timeline](#making-shapes-display-information-about-objects-selected-on-the-timeline)

- [Specifying custom actions in a Resource Manager component](#specifying-custom-actions-in-a-resource-manager-component)

- [Configuring command controls for a Resource Manager component](#configuring-command-controls-for-a-resource-manager-component)

- [Customizing the color of booking blocks](#customizing-the-color-of-booking-blocks)

## Configuring the shape data fields of the timeline component

When you have created the shape that should display the Resource Manager timeline, add a shape data field of type **Component** to it, and set its value to “*Reservations*” or “*Bookings*”.

In addition, you can specify options using various other shape data fields, such as **ComponentOptions**. Different ComponentOptions can be combined with pipe characters. The following options are available:

| Shape data field | Value                                                                       | Description                                                                                                                                                                                                                                                                                                                                                                                       |
|------------------|-----------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ComponentOptions | SessionVariablePrefix=\[prefix\] | When you specify this option, a unique prefix is assigned to the session variable names. This can be used in order to avoid any conflicts.<br> For example, if you specify the value “*SessionVariablePrefix=RM*”, the session variable YaxisResources becomes RMYaxisResources. |
| ComponentOptions | DefaultBandHeight=                                                          | Sets the default height of the timeline bands.<br> This value has to be an integer greater than 10, e.g. *DefaultBandHeight=100*.<br> Any height specified using a JSON object in a *YaxisResources* session variable will override this value. See [YAxisResources](#yaxisresources).                                                  |
| ComponentOptions | EnableFollowMode                                                            | Activates the follow mode. This will make the timeline move along with the current time.                                                                                                                                                                                                                                                                                                          |
| ComponentOptions | AutoReEnableFollowModeTimeout=                                              | Sets the number of seconds after which the follow mode will be reactivated each time a user jumps to another time range.<br> This value has to be an integer greater than 0, e.g. *AutoReEnableFollowModeTimeout=5*                                                                                                                                                    |
| ComponentOptions | UseCommandsForCustomActions                                                 | Available from DataMiner 9.5.6 onwards. Allows the timeline to be used in conjunction with command control shapes to select an action mode. See [Configuring command controls for a Resource Manager component](#configuring-command-controls-for-a-resource-manager-component).                                                                                                                  |
| ComponentActions | \[{...json...}\]                                                            | Custom actions, specified with JSON objects. Available from DataMiner 9.5.4 onwards. For more information, see [Specifying custom actions in a Resource Manager component](#specifying-custom-actions-in-a-resource-manager-component).                                                                                                                                                           |
| Options          | CardVariable                                                                | This option can be used to specify that the session variables mentioned in the other shape data fields are card variables, not page variables. It is also possible to configure a different session variable scope, as specified in [Indicating the scope of the variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable#indicating-the-scope-of-the-variable).                  |

Please note the following regarding this component:

- The **ComponentOptions** shape data field can also be configured to store properties of Resource Manager objects in variables. See [Making shapes display information about objects selected on the timeline](#making-shapes-display-information-about-objects-selected-on-the-timeline).

- The options related to variables can help avoid conflicts between variables when multiple cards are open. Otherwise, if you click a session variable shape on one card, this could have an effect on other cards.

- The appearance of bands on the timeline can be customized using the *YaxisResources* session variable. See [YAxisResources](#yaxisresources).

- The color of booking blocks can be customized using properties of the bookings. See [Customizing the color of booking blocks](#customizing-the-color-of-booking-blocks).

- If a *ListView* component with source *Reservations* or *Bookings* is used together with an embedded Resource Manager component, selecting an item in the list will select the corresponding block on the Resource Manager timeline and vice versa. See [Creating a list view](xref:Creating_a_list_view).

## Adding session variable controls for a Resource Manager component

When you have linked a shape to a Resource Manager timeline, you can add shapes that update session variables to the Visio drawing, in order to make it possible for users to determine what is displayed on the timeline.

> [!TIP]
> See also:
> [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)

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

To turn separate shapes into navigation controls, use the session variable *Navigate* on those shapes.

| Shape data field | Value                                | Action                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
|------------------|--------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SetVar           | Navigate:now                         | Zoom in on a period from 3 hours ago to 3 hours from now.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| SetVar           | Navigate:now(before X;after Y)       | Zoom in to a time frame around the current time: from X hours earlier until Y hours later<br> Supported from DataMiner 9.6.12 onwards.<br> For example: <br> -  To show a time frame starting 1 hour earlier and ending 9 hours later: <br>*\[sep::=\]Navigate=now(before 01:00:00;after 09:00:00)*<br> -  To show a time frame starting one day earlier and ending 3 months later:<br>*\[sep::=\]Navigate=now(before 1.00:00:00; after 90.00:00:00)*             |
| SetVar           | Navigate:yesterday                   | Zoom in on yesterday (midnight to midnight).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| SetVar           | Navigate:yesterday(before X;after Y) | Zoom in to a time frame around noon yesterday: from X hours earlier until Y hours later.<br> Supported from DataMiner 9.6.12 onwards.<br> For example: <br> -  To show a time frame starting 6 hours earlier and ending 6 hours later: <br>*\[sep::=\]Navigate=yesterday(before 06:00:00;after 06:00:00)*<br> -  To show a time frame starting one day earlier and ending 3 months later:<br>*\[sep::=\]Navigate=yesterday(before 1.00:00:00; after 90.00:00:00)* |
| SetVar           | Navigate:today                       | Zoom in on today (midnight to midnight).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| SetVar           | Navigate:today(before X;after Y)     | Zoom in to a time frame around noon today: from X time earlier until Y time later.<br> Supported from DataMiner 9.6.12 onwards.<br> For example: <br> -  To show a time frame starting 6 hours earlier and ending 6 hours later: <br>*\[sep::=\]Navigate=today(before 06:00:00;after 06:00:00)*<br> -  To show a time frame starting one day earlier and ending 3 months later:<br>*\[sep::=\]Navigate=today(before 1.00:00:00; after 90.00:00:00)*               |
| SetVar           | Navigate:tomorrow                    | Zoom in on tomorrow (midnight to midnight).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| SetVar           | Navigate:tomorrow(before X;after Y)  | Zoom in to a time frame around noon tomorrow: from X hours earlier until Y hours later.<br> Supported from DataMiner 9.6.12 onwards.<br> For example: <br> -  To show a time frame starting 6 hours earlier and ending 6 hours later: <br>*\[sep::=\]Navigate=tomorrow(before 06:00:00;after 06:00:00)*<br> -  To show a time frame starting one day earlier and ending 3 months later:<br>*\[sep::=\]Navigate=tomorrow(before 1.00:00:00; after 90.00:00:00)*    |
| SetVar           | Navigate:pan+hour                    | Slide 1 hour/day/week/month to the right, without changing the zoom factor.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| SetVar           | Navigate:pan+day                     |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:pan+week                    |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:pan+month                   |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:pan-hour                    | Slide 1 hour/day/week/month to the left, without changing the zoom factor.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| SetVar           | Navigate:pan-day                     |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:pan-week                    |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:pan-month                   |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:zoom+hour                   | Change the zoom factor to the indicated duration, centered around the current DataMiner time.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| SetVar           | Navigate:zoom+day                    |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:zoom+week                   |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:zoom+month                  |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:zoom-hour                   |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:zoom-day                    |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:zoom-week                   |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:zoom-month                  |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
| SetVar           | Navigate:yyyy-mm-dd hh:mm:ss         | Zoom in on a period of 24 hours, centered on the specified time.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |

> [!NOTE]
> - After a particular action has been performed, the session variable *Navigate* will be cleared. That way, it can be set again to perform another action. You can, for example, keep clicking a “pan+day” button to slide to the right.
> - The last of the above-mentioned *Navigate* options will often be used together with a shape data field of type *SetVarOptions* set to “Control=DateTime”, which will turn the shape into a date picker. See [Creating a DateTime control](xref:Adding_options_to_a_session_variable_control#creating-a-datetime-control).
> - From DataMiner 10.0.0 \[CU14\]/10.1.0 \[CU3\]/10.1.6 onwards, it is possible to load a specific time slot immediately when a user navigates to the page. To do so, use the **InitVar** shape data on page level instead of the SetVar shape data mentioned above.

### ResourcesInSelectedReservation

When a booking block is selected, this session variable will contain a comma-separated list of resource GUIDs.

Available from DataMiner 9.6.3 onwards.

### TimerangeOfSelectedReservation

When a booking block is selected, this session variable will contain the start-stop time range of the booking, inflated by 10%. Values in this session variable will be serialized, e.g. “5248098399646517511;5248392353962787511”.

Available from DataMiner 9.6.3 onwards.

### Viewport

When you pan or zoom in on the timeline, this session variable will contain the time range that is visible on the screen. From DataMiner 10.0.0 \[CU14\]/10.1.0 \[CU3\]/10.1.6 onwards, this session variable can also be used to zoom to a specific time range as soon as the component is loaded.

When this session variable is set by an external source, the timeline component will be updated to show the new time range.

The value can be set in serialized form (e.g. “5248098399646517511;5248392353962787511”) or using a “start;stop” format. In the latter case, start and stop must be timestamps that can be parsed by DateTime (e.g. “2017-09-17T09:42:01.9129607Z;2018-08-23T15:05:53.5399607Z” in ISO 8601 format, or “17/09/2017 9:42:01;23/08/2018 15:05:53” in local format).

Available from DataMiner 9.6.3 onwards.

> [!NOTE]
> - Prior to DataMiner 9.6.11, the scope of this session variable is always global. From DataMiner 9.6.11 onwards, the card, page and workspace scope are also supported.
> - If both *Viewport* and *Navigate* are used, the *Navigate* variable will be processed after the *Viewport* variable.

### YAxisResources

To allow users to specify what is displayed on the Y-axis, use the session variable *YaxisResources*.

- You can specify a comma-separated list of pools and/or individual resources. Use names or GUIDs.

    Use the *ALL* keyword if you want to clear the filter and display all known resources. However, note that this is not advisable on large systems with many resources and bookings, as it may have a negative impact on performance.

    | Shape data field | Value                                                                                             | Description                                                                                                                                                                                                                                                          |
    |--------------------|---------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | SetVar             | YaxisResources:Pool=Antennas,IRDs,Encoders                                                        | Creates a band for each resource in each of the specified pools. Pools can be specified either with their name or their GUID and are comma-separated.                                                                                                                |
    | SetVar             | YaxisResources:Pool={863D1545-C7B7-4D3F-BFB8-BC8EF3B15859},{B7E038EC-96DE-4EF4-8485-AD2C1C8EACCD} |                                                                                                                                                                                                                                                                      |
    | SetVar             | YaxisResources:Resource=R1,R2,R3                                                                  | Creates a band for each specified resource. Resources can be specified either with their name or their GUID and are comma-separated. From DataMiner 9.6.7 onwards, it is also possible to specify the DMA ID/Element ID for resources that are linked to an element. |
    | SetVar             | YaxisResources:ALL                                                                                | Creates a band for each resource in the system. Not recommended when there are many resources. <br> If only *YaxisResources* is specified without any additional configuration, this will have the same effect.                       |

- To specify custom bands on the timeline, from DataMiner 9.5.3 onwards, you can use the following configuration for the *YaxisResources* session variable:

    | Shape data field | Value                           |
    |--------------------|---------------------------------|
    | SetVar             | YaxisResources:\[{...json...}\] |

    The JSON object for the custom bands can be configured as follows:

    | Property    | Type       | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
    |---------------|------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Name          | string     | The name displayed on the Y-axis                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
    | Type          | “custom"   | Specifies the type of band. Currently, only “custom” is supported.                                                                                                                                                                                                                                                                                                                                                                                                                                      |
    | Background    | Color      | The background color for the band.                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
    | Height        | GridLength | The height of the band, either relative (e.g. *3\**), absolute (e.g. *200*) or *auto*. When empty, a default absolute height of 64 pixels is used. Not applicable when *ItemHeight* is filled in.                                                                                                                                                                           |
    | MinimumHeight | integer    | The absolute minimum height, in case Height is relative or *ItemHeight* is used.                                                                                                                                                                                                                                                                                                                                                                                         |
    | ItemHeight    | integer    | The fixed height of blocks on this band. If this is specified, the Height property is ignored. If there are a specific number of concurrent blocks, the band height will be that number multiplied by the specified *ItemHeight*. If necessary, a vertical scrollbar will appear.                                                                                                                                                                                        |
    | Filter        | string     | A filter that determines which blocks are displayed in this band. This field supports single filters and combination filters using an AND or OR operator. Most booking fields are supported, including booking properties, which should be specified using the exposer *ReservationInstance.Properties*. However, it is not possible to filter on the service definition name or on datetime fields. Also, for fields of type integer, only exact matches are supported. |

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
    > You can use the “Minify/Compact” function at https://jsonformatter.org/ to remove all whitespace and newlines from a JSON string before copying it to a Visio shape data item.

## Making shapes display information about objects selected on the timeline

To have shapes display information about an object selected on the timeline, the following session variables can be configured:

| Shape data field | Value                         | Comment                                                                                                                                                                                                                                                                                                                                                                                                                            |
|------------------|-------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Variable         | SelectedOccurrence            | Available from DataMiner 9.5.4 onwards. Used in case there are recurring bookings                                                                                                                                                                                                                                                                                                                                                  |
| Variable         | SelectedPool                  | From DataMiner 10.2.1/10.3.0 onwards, when you select a resource band, this variable is filled in with the first pool of the selected resource.                                                                                                                                                                                                                                                  |
| Variable         | SelectedReservation           |                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| Variable         | SelectedResource              | From DataMiner 10.2.1/10.3.0 onwards, this variable is filled in when you select a resource band.                                                                                                                                                                                                                                                                                                |
| Variable         | SelectedSession               |                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| Variable         | SelectedReservationDefinition | Available from DataMiner 9.5.7 onwards. If the selected block is a booking instance linked to a particular booking definition, this variable will be filled in with the GUID of that definition.                                                                                                                                                                                                                                   |
| Variable         | SelectedTimeRange             | Available from DataMiner 10.2.1/10.3.0 onwards. The value of this variable can be set in serialized form (e.g. “5248098399646517511;5248392353962787511”) or using a “start;stop” format. In the latter case, start and stop must be timestamps that can be parsed by datetime (e.g. “2017-09-17T09:42:01.9129607Z;2018-08-23T15:05:53.5399607Z” in ISO 8601 format, or “17/09/2017 9:42:01;23/08/2018 15:05:53” in local format). |

Alternatively, you can also make shapes display properties of the *SelectedReservation*, *SelectedSession*, *SelectedResource*, *SelectedOccurrence* or *SelectedPool*. To do so, the properties must be stored in a variable, which is then displayed by a shape.

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

If a **ComponentActions** shape data field has been added to the *Reservations* or *Bookings* shape, this shape data field can be configured to contain JSON objects with the following properties:

| Property | Type                                   | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
|----------|----------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Name     | string                                 | The text displayed in the context menu item.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| Type     | {"script", "set"}                      | The type of action to be executed:<br> -  script: run an automation script<br> -  set: perform a parameter set                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| Execute  | string                                 | The action to be executed.<br> The same syntax is used as for Visio shapes:<br> -  *Script:ScriptName\|Dummies\|Parameters\|Memories\|Tooltip\|Options*<br> -  *Set\|DmaID/ElementID\|ParameterID:TableRowKey\|NewValue\|Options*<br> Inside this string, the following placeholders can be used:<br> -  *\[StartTime\]*: The timestamp of the start of the selected range.<br> -  *\[StopTime\]*: The timestamp of the end of the selected range. |
| Level    | { "global", "band",<br>"reservation" } | The context in which the action is available:<br> -  *global*: On an empty part of the timeline.<br> -  *band*: On the name in the Y-axis of a horizontal band.<br> -  *reservation*: On a booking block.                                                                                                                                                                                                                                                                                                                                    |

> [!NOTE]
> From DataMiner 9.5.14 onwards, it is possible to omit trailing pipe characters when specifying the Automation script. For example, instead of specifying “Script:MyScript\|\|\|\|\|”, you can simply specify “Script:MyScript”.

Example of a JSON string with three custom actions:

```txt
[
    { "Name": "Action1", "Level": "global, "Type": "script","Execute":"script:CreateReservation||START=[StartTime];STOP=[StopTime]|||" },
    { "Name": "Action2", "Level": "band", "Type": "script","Execute": "script:RemoveAll||BAND=[BandName]|||" },
    { "Name": "Action3", "Level": "block", "Type": "set","Execute": "set|34/5|1004:7|Off|" }
]
```

> [!NOTE]
> You can use the “Minify/Compact” function at https://jsonformatter.org/ to remove all whitespace and newlines from a JSON string before copying it to a Visio shape data item.

## Configuring command controls for a Resource Manager component

If *ComponentActions* shape data are defined on a Resource Manager component in Visio, the selection behavior of the bookings timeline is different from the default behavior: instead of zooming in on the selected range, the component shows a context menu that allows the user to select one of the available actions.

However, from DataMiner 9.5.6 onwards, it is possible to use this component in conjunction with command control shapes, so that users can select a particular “mode” to determine which action is executed when they select a range on the timeline.

This is configured as follows:

1. Add the following shape data fields to the component shape:

    | Shape data     | Value                                                                                                                                                                                                                                           |
    |------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Component        | Name of the Visio component: *Reservations* or *Bookings*.                                                                                                                                |
    | ComponentActions | Custom actions, specified with JSON objects. See [Specifying custom actions in a Resource Manager component](#specifying-custom-actions-in-a-resource-manager-component).                                                                       |
    | ComponentOptions | *UseCommandsForCustomActions*                                                                                                                                                                                        |
    | CommandPrefix    | Optional prefix added to the command name (in the shape containing the command, see below) in case multiple identical commands have to be configured for different instances of the same component (e.g. “*One\_*”). |

    > [!TIP]
    > See also:
    > [Embedding a Resource Manager component](#embedding-a-resource-manager-component)

2. Add the following shape data fields to the command control shape:

    | Shape data     | Value                                                                                                                                                                                                        |
    |------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Command          | Name of the command to be executed when the shape is clicked (optionally preceded by the command prefix): *SetCustomActionMode*.                                                  |
    | CommandParameter | The name of the action, as configured in the *ComponentActions* field. If no action name is specified here, the default zoom action will be selected with this command shape. |
    | Scope            | The scope of the command: *Page*                                                                                                                                                  |

For example, a bookings timeline can be configured as follows:

| Shape data field | Value                                                                                                                                                                                                                                                                                                                       |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Component        | Reservations                                                                                                                                                                                                                                                                                                                |
| ComponentActions | \[{ "Name": "Action1", "Execute": "script:a\|b\|c\|d\|e", "Type": "AutomationScript", "Level": "global" },{ "Name": "Action2", "Execute": "script:a\|b\|c\|d\|e", "Type": "AutomationScript", "Level": "global" },{ "Name": "Action3", "Execute": "script:a\|b\|c\|d\|e", "Type": "AutomationScript", "Level": "global" }\] |
| ComponentOptions | UseCommandsForCustomActions                                                                                                                                                                                                                                                                                                 |
| CommandPrefix    | CMD\_                                                                                                                                                                                                                                                                                                                       |

In that case, you can for instance define the following command control shapes:

- To apply the default zoom action when selecting the timeline:

    | Shape data field | Value                   |
    |--------------------|-------------------------|
    | Command            | CMD_SetCustomActionMode |
    | CommandParameter   |                        |
    | Scope              | Page                    |

- To apply action 1 when selecting the timeline:

    | Shape data field | Value                   |
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

    - Case-insensitive. Code must start with a hash tag and can only contain hexadecimal values.

    - 3-digit, 6-digit and 8-digit formats are supported (8-digit format can contain an alpha value).

    - Examples: *#0F0*, *#00FF00* and *#FF00FF00*

- Using (A)RGB Integer Functional Notation

    - 3 integer values separated by commas. Can be preceded by a fourth integer value (i.e. an alpha value). Each of these values must be between 0 and 255.

    - Template: “R,G,B” or “A,R,G,B” - A (alpha), R (red), G (green), B (blue)

    - Example: *141,89,0,184*

> [!NOTE]
> If the API is used to update the color of a booking, ideally the ResourceManagerHelper calls *UpdateReservationInstanceProperties*(…) and *SafelyUpdateReservationInstanceProperties* (…) should be used. These assure the best performance when booking properties are updated and prevent possible issues when a booking is updated multiple times during its runtime.
>
