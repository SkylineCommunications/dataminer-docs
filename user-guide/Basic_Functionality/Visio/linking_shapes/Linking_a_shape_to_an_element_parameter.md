---
uid: Linking_a_shape_to_an_element_parameter
---

# Linking a shape to an element parameter

When you have linked a shape to an element using a shape data field of type **Element**, you can use an additional shape data field of type **Parameter** to link that shape to a particular parameter of that element.

> [!NOTE]
> - When you have linked a shape to an enhanced service using a shape data field of type **Element**, you can use an additional shape data field of type **Parameter** to link that shape to a particular parameter of the service.
> - If you link a shape to a spectrum analyzer parameter, by default, the shape will be turned into a **spectrum analyzer thumbnail**.
> - In a Visio file linked to a protocol, a shape linked to a parameter will always be shown, even if that parameter has no value. A shape linked to a parameter will only be hidden if a show/hide condition dictates that it should be hidden.

## Basic shape data field configuration

Add a shape data field of type **Parameter** to the shape.

- For a **simple parameter** or **matrix parameter**, set the value of the shape data field to:

  ```txt
  ParameterID|Options
  ```

  For information on the possible options, refer to [Options for shapes linked to parameters](#options-for-shapes-linked-to-parameters). It is also possible not to specify any options.

- For a **table parameter**, set the value of the shape data field to:

  ```txt
  ParameterID:TableRowKey|Options
  ```

  Regarding this configuration:

  - Table rows can be referenced either by primary key or by display key.

  - TableRowKey can contain wildcards (“\*” or ”?”) and/or placeholders.

  - For information on the possible options, refer to [Options for shapes linked to parameters](#options-for-shapes-linked-to-parameters). It is also possible not to specify any options.

  - When using a variable table row, replace the colon by a comma.

    When specifying a fixed table row, you have to separate the parameter ID and the table row by means of a colon (”:”). However, when specifying a table row containing a wildcard or when specifying a table row by means of a \[param\] or \[property\] placeholder, use a comma (”,”) as separator instead.

    Examples:

    ```txt
    302:5
    302,sl*
    302,[param:456]
    302,[property:MySpecialProperty]
    ```

- For a **spectrum analyzer parameter**, set the value of the shape data field to:

  ```txt
  ParameterID|MonitorRef|ScriptVariable|MeasurementPointID|PresetName|SpectrumOptions
  ```

  > [!NOTE]
  > It is also possible to embed a full Spectrum Analysis component in Visio. See [Embedding a Spectrum Analysis component](xref:Embedding_a_Spectrum_Analysis_component)

  Regarding this configuration:

  - A shape linked to a spectrum analyzer parameter will by default be turned into a spectrum analyzer thumbnail. However, it is possible to configure an option to prevent this, so that the shape only serves as a link to the spectrum analyzer. See [Keeping a shape from turning into a spectrum thumbnail](#keeping-a-shape-from-turning-into-a-spectrum-thumbnail).

  - *MonitorRef* can be either the monitor name or the monitor ID. The monitor name can contain \* and ? wildcards. In that case, the first matching monitor for the element will be used.

  - *ScriptVariable* refers to a variable of type trace that is used in the script of the specified monitor.

  - If the monitor specifies only a single measurement point, the measurement point ID can be set to -1. The required measurement point will then be selected automatically.

  - In Cube, the spectrum thumbnail can only display one reference trace from the preset.

  - Only public presets can be used. Note that up to DataMiner 9.0.3, the suffix “(public)” must be added. From DataMiner 9.0.4/9.0.0 CU7 onwards, this suffix is no longer required.

  - For information on the spectrum options, refer to [SpectrumOptions](#spectrumoptions).

  - When referring to a spectrum analyzer parameter, you can use variable placeholders. For example:

    ```txt
    64001|[property:MONITOR_ID]|trace_[property:CIRCUIT_ID]|-1||DisplayTime
    64001|[Var:monitor]|[Var:buffer]|-1|Carrier CSG_200_000000001037 - NIT_06_R L Rx (public)|DisplayTime
    ```

  - From DataMiner 10.2.0/10.1.8 onwards, you can have the spectrum thumbnail show the trace from a specific moment in the past, based on the recorded trending for a parameter in a spectrum monitor. To do so, as the parameter ID, specify the ID of the spectrum monitor trace parameter (which is always in the range 50000 - 59999). You can find this ID in the file *SpectrumMonitors.xml* in the folder *C:\\Skyline DataMiner*. Then configure the **HistoryMode** shape data in the same manner as to display the history alarm state of a parameter. See [Linking a shape to a history alarm](xref:Linking_a_shape_to_a_history_alarm).

    > [!NOTE]
    > The trended trace record from right before the specified time will be displayed. For this purpose, the trended traces are queried with the following steps until a trace record is found, or the maximum search extent has been reached: 1 hour – 3 hours – 12 hours – 24 hours – 48 hours (maximum).

## Showing the parameter value in shape text

The value of the parameter will appear on the shape only if you add shape text that contains a “\*” character. This character will then be replaced by the current value of the parameter.

To add text to a shape, just double-click the shape, and enter the text.

> [!NOTE]
> If the shape text contains a “\*” character, this character will not be replaced by the current parameter value if a dynamic behavior option like SHOW, HIDE, ROTATE, FLIPX, or FLIPY has been added to the shape data field of type **Parameter**. A shape linked to a parameter can either display the parameter value or behave dynamically based on that same parameter value.

## Placeholders in the shape text

Within the text in the shape, which is added by double-clicking the shape in Visio, certain placeholders can be used to display information about the parameter.

### Placeholder for parameter description

To make a shape display the parameter description of a parameter it is linked to, use the following placeholder in the shape text. You can combine this with other shape text, for instance with the parameter value as described above.

```txt
[ParameterDescription]
```

> [!NOTE]
> For table parameters, the display index is added to the parameter description, similar to the way such parameters are displayed in the Alarm Console.

### Placeholder for parameter baseline value

To make a shape display the normalized value of a parameter it is linked to, use the following placeholder in the shape text:

```txt
[NormalizedValue]
```

## Retrieving and showing the value of a table parameter using a subscription filter

When there are two related tables, and you link a shape to a column parameter of the first table, you can make the shape display the value of a particular row of this column parameter, depending on the value in the linked row of the other table. This is done by specifying a subscription filter on the second table.

This can be done in two ways, depending on the version of DataMiner you are using.

- From DataMiner 9.5.1 onwards:

  In addition to specifying the **Element** and **Parameter** shape data fields to link the shape to the first table parameter, also specify a **Subscriptionfilter** shape data field, with the value “*value=*\[PID\]*==*\[filter value\]”.

  For example, in the configuration below, the column parameters 1005 and 2002 are located in two related tables. The dynamic placeholder in the data field of type *Parameter* will be replaced by the value in column 1005 on the row of which the value in the linked row in column 2002 matches the condition specified in the subscription filter. This value will then be displayed on the shape.

  | Shape data field | Value               |
  |--------------------|---------------------|
  | Element            | 1/1                 |
  | Parameter          | \[param:1/1,1005,\] |
  | SubscriptionFilter | value=2002 == 1     |

- From DataMiner 9.5.2 onwards:

  When you use the configuration with the *\[param:\]* placeholder illustrated above, it can occur that the placeholder is resolved to an integer that equals the ID of a parameter, so that a subscription is made on that parameter, which can lead to a different parameter value being shown. As such, as an alternative, you can use a similar configuration that does not use this placeholder, and makes use of a **ParameterSubscriptionFilter** shape data field instead of a **SubscriptionFilter** shape data field. For example:

  | Shape data field          | Value          |
  |-----------------------------|----------------|
  | Element                     | 1/1            |
  | Parameter                   | 101            |
  | ParameterSubscriptionFilter | value=202 == 1 |

  > [!NOTE]
  > As an alternative way to keep a shape from incorrectly subscribing to a parameter if the first of these configurations is used, you can also add an Options shape data field and set it to *DisableParameterSubscription*.

> [!TIP]
> See also: [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax)

## Displaying history values for parameters

From DataMiner 10.1.10/10.2.0 onwards, it is possible to make an element shape in Visual Overview show the parameter values for a specific point in the past. This time and date can optionally be selected using another Visual Overview component.

To retrieve the value, DataMiner will use the trend record stored for the selected time. To know whether real-time or average trending should be retrieved, the latest trending configuration will be taken into consideration. If both types of trending are available, by default real-time trending will be used.

Configure the shape data as follows:

1. Add a shape data field of type **HistoryMode** to the element shape or page, depending on whether you want to show only this shape in history mode, or all element shapes on the page.

1. Set the value of the shape data field as follows:

   ```txt
   State=[On/Off]|TimeStamp=[datetime value]|Options
   ```

   Refer to the table below for the value syntax:

   | Value | Explanation |
   |-------|-------------|
   | State | Can be "On" or "Off". On means history mode is active, Off means the current parameter values are shown instead. You can use a placeholder to change this value dynamically. |
   | TimeStamp | The date and time for which the parameter value should be displayed. You can use a placeholder to change this value dynamically. |
   | NoDataValue= | This option allows you to specify the text that should be displayed in case no trending is available. If this option is not specified, the default value “N/A” is displayed. |
   | TrendDataType | This option allows you to determine which kind of trend data should be used, if available: *Realtime* (default), *Average* or *RealtimeAndAverage*. |
   | AverageTrendDataIndication | This option allows you to specify a prefix to the parameter value in case it represents an average value. By default, no prefix is shown. |

   For example:

   | Shape data field | Value |
   |------------------|-------|
   | HistoryMode      | State=On\|TimeStamp=\[var:myTime\]\|NoDataValue=\<No data available>\|Average\|AverageTrendDataIndication=\[AVG\] |

1. If you want to use a **SetVar** shape to set the history mode date and time, use the *SetVarOptions* shape data on that shape, and set the value to *Control= DateTime*. Optionally, you can also add *DateTimeCulture=* followed by *Current* or *Invariant*. The latter is the default value.

   For example:

   | Shape data field | Value                                     |
   |--------------------|-------------------------------------------|
   | SetVar             | myTime                                    |
   | SetVarOptions      | Control=DateTime\|DateTimeCulture=Current |

    > [!TIP]
    > See also: [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)

> [!NOTE]
>
> - To make element shapes display the average value, minimum value, or maximum value of a parameter they are linked to, you can use the placeholders `[average value]`, `[minimum value]`, and `[maximum value]` in the shape text. These placeholders will only show values for history parameter values based on average trend data.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[Linking > Objects]* page > *History mode* toggle button.

## Options for shapes linked to parameters

In shapes linked to parameters, several options can be specified within the **Parameter** shape data field:

- [Making a parameter shape show the parameter alarm state](#making-a-parameter-shape-show-the-parameter-alarm-state)

- [Making a parameter subshape show an element’s alarm color](#making-a-parameter-subshape-show-an-elements-alarm-color)

- [Conditional shape manipulation actions](#conditional-shape-manipulation-actions)

- [SpectrumOptions](#spectrumoptions)

However, there are also options that should be specified in a separate **Options** shape data field:

- [Keeping a shape from turning into a spectrum thumbnail](#keeping-a-shape-from-turning-into-a-spectrum-thumbnail)

- [Showing a parameter value for non-initialized parameters](#showing-a-parameter-value-for-non-initialized-parameters)

- [Customizing the way a parameter value is displayed](#customizing-the-way-a-parameter-value-is-displayed)

- [Ensuring the shape text value is not cleared upon a subscription change](#ensuring-the-shape-text-value-is-not-cleared-upon-a-subscription-change)

### Making a parameter shape show the parameter alarm state

In the value of the **Parameter** shape data field, add the “*\|ALARM*” option. The shape will take the color of the parameter’s current alarm state.

> [!NOTE]
> If you do not specify this “\|ALARM” option, the shape will take the color of the element’s current alarm state.

### Making a parameter subshape show an element’s alarm color

If, in a shape linked to an element, you want to have a subshape that has the current alarm color of the element, add a shape data field of type **Parameter** to the subshape and set its value to “*\*\|ALARM*”. That way, the subshape will show the worst alarm state of all parameters of that element, which is equal to the alarm state of the element.

### Conditional shape manipulation actions

Conditional shape manipulation actions can be specified within the value of the **Parameter** shape data field. See [Basic conditional shape manipulation actions](xref:Basic_conditional_shape_manipulation_actions).

### SpectrumOptions

If the value refers to a spectrum analyzer parameter, you can use the following spectrum options in the **Parameter** shape data field (referred to as “SpectrumOptions” in [Basic shape data field configuration](#basic-shape-data-field-configuration)), separated by semicolons (“;”).

| Option            | Description                                         |
|-------------------|-----------------------------------------------------|
| DisplayLabels     | Displays the X/Y-axis labels on the spectrum image. |
| DisplayMarkers    | Displays the markers from the selected preset.      |
| DisplayThresholds | Displays the thresholds from the selected preset.   |
| DisplayTime       | Displays the time of the spectrum trace.            |

> [!NOTE]
> If the Visio file is displayed using the Monitoring & Control app, the *DisplayMarkers* and *DisplayThresholds* options are only available from DataMiner 9.6.1 onwards.

### Keeping a shape from turning into a spectrum thumbnail

When a shape is linked to a spectrum analyzer parameter, as described above, by default a spectrum thumbnail is displayed. However, it is possible to keep this image from being displayed, so that the shape is only used as a link to the spectrum analyzer.

To do so, add a shape data field of type **Options** to the shape, and set its value to “*LinkingOnly*”.

| Shape Data field | Value |
|------------------|-------|
| Parameter        | ParameterID\|MonitorRef\|BufferName\|MeasurementPointID\|PresetName\|SpectrumOptions |
| Options          | LinkingOnly |

### Showing a parameter value for non-initialized parameters

In shapes that display a parameter value, you can have empty, non-initialized parameter values replaced by custom text.

To do so, add a shape data field of type **Options** to the shape displaying a parameter value, and set its value to “*EmptyValue=*”, followed by the text to be displayed.

```txt
EmptyValue=Value to be displayed
```

### Customizing the way a parameter value is displayed

From DataMiner 9.5.13 onwards, the following options can be used (separated by a pipe character) to customize how a parameter value is displayed on a shape linked to a parameter:

| Options    | Description |
|------------|-------------|
| Decimals=X | Replace X by the desired decimal count of the parameter value. For example, if you specify *Decimals=2*, two digits will be displayed to the right of the decimal point. |
| Hideunit   | If this option is specified, the unit of measure of the parameter value will not be displayed. |

For example:

| Shape data field | Value                |
|------------------|----------------------|
| Element          | 123/25               |
| Parameter        | 401                  |
| Options          | Decimals=3\|HideUnit |

### Ensuring the shape text value is not cleared upon a subscription change

From DataMiner 10.1.0 \[CU1\]/10.1.4 onwards, when a dynamic part of a **Parameter** shape data field changes, the value from the previous parameter subscription is cleared from the shape text. A new value will only be filled in if the ID of the parameter is valid and a new subscription is made. As such, if the ID of the parameter shape data is not a valid number, the value will remain cleared.

However, it is possible to revert to legacy behavior, where the old value continues to be displayed. To do so, add the following option:

| Shape data field | Value                                |
|------------------|--------------------------------------|
| Options          | ClearValueOnSubscriptionChange=False |

## Examples of shapes linked to parameters

```txt
350
```

The shape is linked to parameter 350 of the element specified in the shape data field of type **Element**.

```txt
350|HIDE;<6
```

The shape is linked to parameter 350 of the element specified in the shape data field of type **Element**. The extra “HIDE” option will make the shape disappear if the value of the parameter drops below 6.

```txt
350|HIDE;=[Property:MyHideProp]
```

The shape is linked to parameter 350 of the element specified in the shape data field of type **Element**. The extra “HIDE” option will make the shape disappear if the value of the parameter is equal to the value of the element property named “MyHideProp”.
