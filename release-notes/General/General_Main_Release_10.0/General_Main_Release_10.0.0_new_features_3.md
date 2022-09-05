---
uid: General_Main_Release_10.0.0_new_features_3
---

# General Main Release 10.0.0 - New features (part 3)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> From DataMiner 10.0.0/10.0.2 onwards, DataMiner Service & Resource Management also requires DataMiner Indexing.

### DMS Cube (Visual Overview)

#### Visual Overview: Option to embed Chromium browser \[ID_18501\]

If a shape in Visio is linked to a web page, it is now possible to add an option in order to display the page using the Chromium browser. To do so, add the following shape data:

| Shape data field | Value     |
|------------------|-----------|
| Options          | UseChrome |

#### Visual Overview: Highlighting connections based on the source and target of the connection \[ID_19511\]\[ID_21428\]

From now on, it is possible to configure a highlight style that is only applied if the path comes from a certain source and (optionally) goes to a certain destination.

To do so, add the following fields in the **Options** shape data field next to the *HighlightStyle* option, using a pipe character (“\|”) as a separator:

- **HighlightTarget=SourceDestination**: This option must be added to indicate that the type of highlighting to be used is source-to-destination highlighting.

- **Source:\<x>**: This option must be added to indicate where the highlighted path should start.

  \<x> can take the following values:

  - *Element=*\[Element name or DMA ID/Element ID of the source element\]
  - *Protocol=*\[Protocol name of the source element (not including the version)\]
  - *Tag=*\[tag name\]

  To use the “Tag” option, a shape elsewhere in the drawing will need to be configured with the shape data **Tag**, of which the value is set to the tag name.

- **Destination:\<y>**: This is an optional field that can be added to indicate where the highlighted path should end. The highlighted path will then only include shapes and lines that run towards this destination.

  \<y> is configured in the same manner as \<x>, allowing the same three kinds of values.

- **Priority:\<z>**: This optional field allows you to give a highlight style priority over another style.

  \<z> is a number indicating the priority of the style. This way, multiple of these source-to-destination highlight styles can be defined with different priorities. If this field is not defined, the style will get the lowest priority.

- **Direction=Forwards/Backwards/Both**: This optional field allows you to specify the direction in which has to be crawled through the DCF network. Default direction: Forwards.

  - Using *Direction=Backwards* together with *Source:Tag=MySource* will highlight all paths that lead to the *MySource* shape.
  - Using *Direction=Forwards* will highlight all paths starting from the source shape.

Examples:

```txt
HighlightStyle|HighlightTarget=SourceDestination|Source:Element=231/88|Priority=3
```

```txt
HighlightStyle|HighlightTarget=SourceDestination|Source:Protocol=MyDCFProtocol|Destination:Tag=Antenna|Priority=2
```

```txt
HighlightStyle|HighlightTarget=SourceDestination|Source:Tag=MySource|Direction=Backwards
```

#### Visual Overview: Device discovery shape \[ID_19646\]

It is now possible to configure a shape in Visio so that it launches the Device Discovery app when it is clicked in Cube. To do so, add the following shape data to a shape linked to a view:

| Shape data field | Value            |
|------------------|------------------|
| Execute          | Device discovery |

Example:

| Shape data field | Value            |
|------------------|------------------|
| View             | MyView           |
| Execute          | Device discovery |

#### Visual Overview: New option to automatically close a VdxPage popup/window after executing the main action \[ID_19689\]

It is now possible to have a VdxPage popup/window close itself automatically after the main action has been executed. To do so, add a data field of type “Options” to a shape displayed inside the VdxPage popup/window and set its value to “ClosePage”.

| Shape data field | Value     |
|------------------|-----------|
| Options          | ClosePage |

The difference between this new “ClosePage” option and the “AutoClosePopup” option is that the former is set on a shape inside the VdxPage popup/window, while the latter is set on the shape opening the popup/window.

#### Visual Overview: Embedded Resource Manager timeline component has three new session variables \[ID_19996\]\[ID_23047\]

When you embed a Resource Manager timeline component in a Visio drawing, you can now use the following additional session variables:

- **ResourcesInSelectedReservation**

  When you select a booking block, this session variable will contain a comma-separated list of resource GUIDs.

- **TimerangeOfSelectedReservation**

  When you select a booking block, this session variable will contain the start-stop time range of the booking, inflated by 10%.

  Note that values in this session variable will be serialized. Example: “5248098399646517511;5248392353962787511”

- **Viewport**

  When you pan or zoom in the timeline, this session variable will contain the time range that is visible on the screen.

  When this session variable is set by an external source, the timeline component will be updated to show the new time range. The value can be set in serialized form (e.g. “5248098399646517511;5248392353962787511”) or using a “start;stop” format. In the latter case, start and stop must be timestamps that can be parsed by DateTime (e.g. “2017-09-17T09:42:01.9129607Z;2018-08-23T15:05:53.5399607Z” in ISO 8601 format, or “17/09/2017 9:42:01;23/08/2018 15:05:53” in local format).

> [!NOTE]
>
> - Using the above-mentioned session variables, you can link two timeline components in a master-detail relation.
> - The Viewport session variable can be set on Cube level, card level, page level and workspace level.

#### Visual Overview: 'Edit in Visio' enhancements \[ID_20361\]\[ID_22394\]

When, in DataMiner Cube, you right-click a visual overview and select *Edit in Visio*, the Visio file in question will be opened in Microsoft Visio. In Visio, a new set of add-ins is now available to manage DataMiner-related data.

##### Advanced Editing

The *Advanced Editing* panel is an improved shape data editor. If the panel is not visible, go to the *Add-ins* menu, and click the *Advanced editing* button.

When you click the page background, this panel will list the page data items currently linked to the page. When you click a shape, this panel will list the shape data items currently linked to the shape you clicked.

- To add a data item to either the page or the selected shape, click *Add page data* or *Add shape data* and select a data item from the list. That data item will then be added to the list of data items linked to the page or shape. Now, click inside the value box of the new data item and enter a value.

  When, in a value, you want to add a placeholder (i.e. a dynamic part), then type a square bracket (“\[“), select the placeholder from the list, and press TAB.

  > [!NOTE]
  > Apart from the value of a data item, you can also change the name of a data item. If, however, you change a name to one that is unknown to DataMiner or to one that is already in the list, it will be highlighted.

- To remove a data item from either the page or the selected shape, click the black cross on the right of the item.

#### Visual Overview: Shapes turned into a tab control showing Visio file pages now also support different tab control styles \[ID_20507\]

Shapes turned into a tab control that displays specific pages of a Visio file now also support the new tab control style introduced in DataMiner version 9.5.14.

To use this style, add the “TabControlStyle=2” option to the *Options* shape data item.

Example:

| Shape data field | Value             |
|------------------|-------------------|
| VdxPage          | Page1\|Page2      |
| Options          | TabControlStyle=2 |

#### Visual Overview: Reservation shape \[ID_20517\]\[ID_22075\]

It is now possible to link a shape to a booking, used in the Service & Resource Management suite.

To do so, specify a *Reservation* shape data field and set it to one of the following values:

- The GUID of the booking

- A dynamic placeholder, e.g. \[pagevar:SelectedReservation\]

- A service name, service ID or placeholder referring to a service, e.g. \[this service\]. In that case, the *ReservationID* property of the service will be used.

The following placeholders can be used in the text displayed on the *Reservation* shape:

| Placeholder | Description |
|-------------|-------------|
| \[Name\] | Will be replaced by the name of the booking linked to the shape. |
| \[Status\] | Will be replaced by the value of the *Status* property of the booking linked to the shape. |
| \[Start Time:format=\<format>\] | Will be replaced by the start time of the booking, converted to the DataMiner time. Optionally, a colon (":") can be added within the placeholder, followed by the format in which the start time should be displayed. By default, this is the standard month format, followed by a space and the standard short time format. For other possible formats, refer to the note below. |
| \[End Time:format=\<format>\] | Will be replaced by the end time of the booking, converted to the DataMiner time. This placeholder supports the same optional format configuration as the *\[Start Time\]* placeholder. |
| \[Elapsed Time:format=\<format>,default=\<defaultValue>\] | Will be replaced by the amount of time that has passed since the booking started running. Optionally, a colon (“:”) can be added within the placeholder, followed by the time format and a default value. By default, the format is "\[x days\] hh:mm:ss", where the number of days is only displayed if it is 1 or more, and the local language is used. For other possible formats, refer to the note below. This placeholder is replaced by the default value when the booking is not running. If no default value is specified and the booking is not running, nothing is displayed. |
| \[Time until start:format=\<format>,default=\<defaultValue>\] | Will be replaced by the amount of time that still has to pass until the booking starts. This placeholder supports the same options as the *\[Elapsed Time\]* placeholder. The placeholder is replaced by the default value when the current time is later than the booking start time. If no default value is specified in that case, nothing is displayed. |
| \[Remaining time:format=\<format>,default\<defaultValue>\] | Will be replaced by the amount of time remaining until the booking ends. This placeholder supports the same options as the *\[Elapsed Time\]* placeholder. The placeholder is replaced by the default value if the booking is not currently running. If no default value is specified in that case, nothing is displayed. |
| \[Time since end:format=\<format>,default=\<defaultValue>\] | Will be replaced by the amount of time that has passed since the end of the booking. This placeholder supports the same options as the *\[Elapsed Time\]* placeholder. The placeholder is replaced by the default value if the current time is earlier than the booking end time. If no default value is specified in that case, nothing is displayed. |

> [!NOTE]
>
> - If a parent shape has *Reservation* shape data that resolves to a booking, and a child shape has placeholders that could potentially resolve to the value of a booking property, then you can prevent the child shape from being linked to the parent shape's booking by adding an *Options* shape data field to the child shape and set its value to “AllowInheritance=False”.
> - For more information on possible date and time formats, refer to:
>   - <https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings>
>   - <https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings>

#### Visual Overview: New context menu item to copy text to clipboard + new option to customize context menu \[ID_20539\]\[ID_21715\]

If a shape in Visual Overview displays text, a new context menu item is now available for the shape that will allow users to easily copy the text to the clipboard.

In addition, it is now also possible to configure a custom context menu for a specific shape in Visio. To do so, add the *ContextMenu* shape data. For now, the only supported action for this context menu is to copy the shape text, even if the shape is part of a disabled group shape. For this, the following value needs to be specified:

| Shape data field | Value                         |
|------------------|-------------------------------|
| ContextMenu      | MenuItem:Action=CopyShapeText |

Optionally, to make sure that this action is also executed when a user left-clicks on the shape, instead of only when the user right-clicks, you can also add IsDefaultAction=True:

| Shape data field | Value                                              |
|------------------|----------------------------------------------------|
| ContextMenu      | MenuItem:Action=CopyShapeText,IsDefaultAction=True |

#### Visual Overview: Using a protocol name in a shape condition \[ID_20646\]

It is now possible to use a protocol name in a shape condition. This allows shapes to be shown or hidden based on the protocol of an element.

If, for example, a shape has the following shape data, it will be shown only when the element named “MyElement” has a protocol named “MyProtocolName”.

| Shape data field | Value                                                |
|------------------|------------------------------------------------------|
| Show             | \<A>-A\|Element:MyElement\|Protocol\|=MyProtocolName |

#### Visual Overview: New 'ListView' component [ID_20649] [ID_21203] [ID_21752] [ID_21686] [ID_21886] [ID_21929] [ID_21931] [ID_22795]

Up to now, when you wanted to turn a shape into a list box control, you had to add two shape data items to that shape: one of type "SetVar" and one of type "SetVarOptions". In the first, you had to specify a list of fixes values or refer to a table parameter containing a number of values, and in the second, you had to specify "Control=ListBox", followed by a number of options if necessary.

In a Visio file linked to either an element or a view, you can now add a list box control by adding a shape with the following shape data items:

| Shape data field |Value |
|------------|------------|
| Component | ListView |
| ComponentOptions | List of options, separated by pipe characters. For an overview of all possible component options, see below. |
| Columns | The list of columns that have to be displayed (in JSON format). If you do not specify this shape data field or leave it empty, all columns will be displayed.<br>Example:<br>*{"Name": "SetVar visioshape columnfilters","Version": 1,"Columns": [{"ColumnKey": "AlarmIcon","Position": 1,"PredefinedWidth": 50, "HorizontalAlignment":"center" },{"ColumnKey": "Name", "Position": 2,"PredefinedWidth": 200, },{"ColumnKey": "ID", "Position": 3,"PredefinedWidth": 80, }]}* |
| Source | The type of items to be shown in the list:<br>- *Elements*<br>- *Services*<br>- *Reservations*/*Bookings* |
| Filter | If you set *Source* to *Elements* or *Services*, then *Filter* can contain a view filter to make the list view only show items from one specific view:<br>- View=\<ViewID\> (with fallback to view name if you specified a number that is used as a name)<br>- ViewName=\<ViewName\> (with fallback to view ID if you specified a number)<br>It is also possible to apply a filter based on the service name. The filter should contain the exposer "Service.Name" and the operator "not Contains" or "contains". The filter can be combined with a view filter, using a pipe ("\|") character as separator. For example: *View=\[var:ViewFilter\]\|Service.Name notContains '1'\|Service.Name notContains 'copy'*<br>If you set *Source* to *Reservations* or *Bookings*, then *Filter* can contain a booking filter based on any field or property.<br>Examples:<br>- *ReservationInstance.Name\[string\]== 'Encoder 2'*<br>- *ReservationInstance.Name\[string\] contains 'Enc'*<br>- *ReservationInstance.Status\[Int32\] == 3*<br>- *ReservationInstance.End\[DateTime\] \>01/22/2019 11:17:32*<br>- *ReservationInstance.Properties.Class\[String\] == 'Silver'*<br>Note:<br>- Both View and ViewName filters will fall back to the root view if the specified view cannot be found.<br>- Instead of specifying a fixed view ID or view name, you can also specify a session variable that contains a view ID or a view name. Example: *View=\[var:mySelectedView\]* |

##### Component options

List of options that can be entered in the *ComponentOptions* data item:

| Component option | Description |
|--------|----------------|
| DisableInUseItems=true/false | When a list view is in edit mode, all list items have a checkbox in front of them. If you set the "Disable-InUseItems" option to "true", the checkboxes that should not be accessible will be shown as disabled. Default: false |
| EditMode=true/false | This option can be used to enable or disable the list view’s edit mode. If set to "true", checkboxes will appear in front of every row. |
| Recursive | This option can be used to link a list view to another list view. If, for example, a ListView component lists the services, and two other ListView components list the source and destination resources available and in use for the services in the first ListView component, then the "recursive" option will allow the source and destination resource ListView components to link to the service ListView component, supporting any type of service hierarchy. |
| SessionVariablePrefix=\[prefix\] | When you specify this option, a unique prefix is assigned to the session variable names. This option allows you to avoid having multiple ListView components using the exact same session variables. |
| StartTime=<br>EndTime= | If the list view is configured to list bookings, then you can use these options to specify a time range.<br>Example: MM/DD/YYYY HH:MM:SS<br>Default settings:<br>- StartTime = NOW - 1 day<br>- EndTime = NOW + 2 days<br>Note: SetVar controls of type DateTime will automatically return a date/time in the correct format.<br> For more information, see: <https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings> |

> [!NOTE]
> Contrary to the above-mentioned options, the “MultipleValueSep” option must be specified in a shape data item of type “SetVarOptions”.

##### Session variables

List of session variables that can be used in conjunction with this *ListView* component:

| Session variable | Contents |
|------------------|----------------------|
| DynamicList_CheckedItems | When a list view is in edit mode, all list items have a checkbox in front of them.<br>This session variable will contain the ID and the values of all editable columns of all list items of which the checkbox is selected. |
| FilterMode | In situations with multiple linked ListView components, set the FilterMode variable to "true" if you want a second, linked ListView to be filtered based on the item selected in the first ListView. Default: false. |
| ListViewCheckingChanged | When a list view is in edit mode, all list items have a checkbox in front of them.<br>This session variable will contain the ID and the values of all editable columns of all list items of which the checkbox state has been changed. |
| ListViewDataChanged | This session variable will indicate whether data has been changed in the list view. |
| ListViewSelectionChanged | This session variable will indicate whether an item has been selected in the list view. |
| IDOfSelection | This session variable contains a list of IDs or GUIDs of the selected items, separated by pipe characters. |
| StateOfSelection | When a booking is selected, this session variable will contain the current state of the booking:<br>- Undefined (0)<br>- Pending (1)<br>- Confirmed (2)<br>- Ongoing (3)<br>- Ended (4)<br>- Disconnected (5)<br>- Interrupted (6)<br>- Canceled (7) |
| ViewPort | This session variable has to contain the time range that will be used when populating a dynamic list with bookings. |

##### Using the component in Cube

In DataMiner Cube, right-clicking the header of the *ListView* component will allow users to change the alignment of a column, change a column name and modify which columns are displayed. It is also possible to save and load a column configuration.

These options are also available in the *Services* tab of the Services app, which uses a similar kind of component. For more information on the different options, see [Services app: New 'Services' tab \[ID_20459\]\[ID_20962\]\[ID_21203\]\[ID_23460\]\[ID_23785\]](xref:General_Main_Release_10.0.0_new_features_5#services-app-new-services-tab-id_20459id_20962id_21203id_23460id_23785).

#### Visual Overview: Embedding the Bookings app as a component \[ID_20812\]\[ID_21686\]

It is now possible to embed the *Bookings* app in a Visio shape.

To do so, add a shape data item of type *Source*, and set its value to “*Reservations*”.

| Shape data field | Value        |
|------------------|--------------|
| Source           | Reservations |

- A filter can be applied using the YAxisResources session variable.

    Example: \[{"Type":"custom","Background":"#FFFFFF","ItemHeight":64,"Filter":"(ReservationInstance.Name\[String\]  notContains 'SRMExposeFlow')"}\]

- A time range can be applied using the Viewport session variable.

    Example: 5248460498427387904;5248491602427387904

#### Visual Overview: Cropped images now supported \[ID_21019\]

Visual Overview now supports images that were cropped in Microsoft Visio.

#### Visual Overview - Trend component: Top/bottom X & wildcard result limitation \[ID_21035\]

The trend component has two new features.

##### Top/bottom X functionality

When configuring a trend component, it is now possible to specify that it should only show the top/bottom X current values of a particular parameter.

In the “Sort” shape data field, you can add the following for every parameter specified in the “Parameters” shape data field: \[SortOrder\],limit:X (where SortOrder is either ASC or DESC, and X is the number of values to be shown).

See the following example:

| Shape data field  | Value                      |
|-------------------|----------------------------|
| Component         | Trending                   |
| Parameters        | 520/3:270:\*\|520/3:203:\* |
| ParametersOptions | ShowLegend:true            |
| Sort              | ASC,limit:2\|DESC,limit:1  |

> [!NOTE]
> The trend component will show an information bar only if the number of values found for a particular parameter exceeds the default limit (i.e. 10). It will not show an information bar if the number of values found for a particular parameter exceeds a limit that was explicitly specified in the “Sort” data field.

##### Limiting wildcard results

When configuring a trend component, it is now possible to limit the number of parameters that match the wildcard expression specified in the “Parameters” shape data field. Previously, the number of returned parameters had a fixed limit of 10.

In the “ParametersOptions” shape data field, you can add the following for every parameter specified in the “Parameters” shape data field: Limit:X (where X is the number of values to be shown).

See the following example:

| Shape data field  | Value        |
|-------------------|--------------|
| Component         | Trending     |
| Parameters        | 520/3:207:\* |
| ParametersOptions | Limit:2      |

> [!NOTE]
> The trend component will show an information bar only if the number of parameter found for at least one of the wildcard expressions exceeds the default limit (i.e. 10). It will not show an information bar if the number of parameters found for at least one of the wildcard expressions exceeds a limit that was explicitly specified in the “ParametersOptions” data field.

#### Service & Resource Management - Visual Overview: Shape inheritance for Reservation shapes and support for placeholders containing booking properties \[ID_21391\]

It is now possible to use placeholders containing custom booking properties in the text on a Visio shape.

In addition, shape inheritance has been added for *Reservation* shapes. This means that if a parent shape has *Reservation* shape data and a child shape is linked to this same booking, for instance because of shape text placeholders or *Info* shape data, the child shape will be considered a Reservation shape linked to the same booking.

#### Visual Overview: Condition to check the number of quarantined bookings \[ID_21598\]

In Visio, it is now possible to apply conditional shape manipulations depending on the number of bookings that have been quarantined in the system. Quarantined bookings are bookings that they have automatically returned to a pending state by the DMA.

To do so, for shape data fields such as Hide, Show, Highlight, etc., specify a condition like the following example:

```txt
<A>-A|Reservations|NumberOfQuarantinedReservations|>1
```

#### Visual Overview: A shape linked to an alarm can now list the impacted services of that alarm \[ID_21657\]

If a shape is linked to an alarm, it is now possible to have the list of impacted services displayed on that shape.

To do so, add a shape data field of type “Info”, and set its value to “Services”. See the example below.

Make sure the text of the shape contains an asterisk ('\*'). At run-time, this asterisk will then be replaced with the names of all impacted services.

Example:

| Shape data field | Value       |
|------------------|-------------|
| Alarm            | 111/273/350 |
| Info             | Services    |

#### Visual Overview: Dynamic placeholder '\[Param:\]' can now retrieve all values of a column parameter \[ID_21781\]

The dynamic placeholder “\[Param:\]” can now retrieve all values of a column parameter. Up to now, specifying a column parameter in a “\[Param:\]” placeholder would result in a “Not Initialized” error.

To have a “\[Param:\]” placeholder retrieve all values of a column parameter, specify the ID of that column parameter in the placeholder.

In the following example, all values of column parameter 110 are retrieved and displayed as “One\|Two\|Three”.

| Shape data field | Value                                                |
|------------------|------------------------------------------------------|
| Tooltip          | Summary of parameter 110 is: \[Param:MyElement,110\] |

If you want a custom separator instead of the default separator (“\|”), then you can specify that custom separator in a shape data item of type “Options”. See the example below.

| Shape data field | Value              |
|------------------|--------------------|
| Options          | MultipleValueSep=; |

#### Visual Overview: YaxisResources session variable now allows DMA ID/Element ID configuration \[ID_21832\]

When a *Reservations* or *Bookings* component is embedded in Visio, the resources on the Y-axis of the timeline can be specified using the session variable *YAxisResources*. When this session variable is used to refer to specific resources, this can now also be done by referring to the DMA ID and element ID of resources linked to an element, using the syntax "*YaxisResources:Resource=**DMA ID/Element ID*". For example:

| Shape data field | Value                          |
|------------------|--------------------------------|
| SetVar           | YaxisResources:Resource=34/101 |

#### Visual Overview: Displaying or using the current DataMiner time in a shape \[ID_21866\]

It is now possible to have a shape display the current DataMiner time or to use that time in shape data items.

To do so, add the following dynamic placeholder to either the shape text or a shape data item:

- \[DataMinerTime\]

By default, the current DataMiner time will be displayed in the regional date/time format. If you want that time to be displayed in another format, then specify the format inside the placeholder. See the following example:

- \[DataMinerTime:Format=HH:mm:ss\]

> [!NOTE]
> The time shown by this dynamic placeholder will be refreshed every second.

#### Visual Overview: Calculating datetime and timespan values using dynamic placeholders \[ID_21911\]

The existing \[Sum:...\] placeholder and the new \[Subtract:...\] placeholder can now be used to calculate datetime and timespan values.

Also, the new \[Reservation:...\] placeholder can be used to retrieve the start or the end of an existing booking.

##### \[Subtract:...\]

Use this new dynamic placeholder to calculate datetime and timespan values by subtracting one or more values from a specified value. See the following examples.

- Calculating a timespan by subtracting one datetime value from another:

    \[Subtract:14/02/1989 22:22:22,12/01/1989 11:10:9\]

- Calculating a timespan by subtracting a datetime value and two timespan values from a datetime value:

    \[Subtract:14/02/1989 22:22:22,12/01/1989 11:10:9,00:01:00,00:00:05\]

- Calculating a datetime value by subtracting a timespan from a datetime value:

    \[Subtract:14/02/1989 22:22:22,00:02:00\]

- Calculating a timespan by subtracting one timespan from another:

    \[Subtract:23:33:15,00:03:15\]

By default, datetime and timespan values will be displayed in the regional date/time format. If you want such a value to be displayed in another format, then specify the format inside the placeholder. See the following example: \[Subtract:23:33:15,00:03:15\|Format=HH:mm\]

##### \[Sum:...\]

Similar to the \[Subtract:...\] placeholder above, this existing dynamic placeholder can now also be used to calculate datetime and timespan values by adding one or more values to a specified value.

##### \[Reservation:...,Start/End\]

Use the new \[Reservation:...\] placeholder to retrieve the start or the end of an existing booking.

See the following example: \[Reservation:\<ReservationGuid>,Start\]

As this \[Reservation:...\] placeholder produces a datetime value, it can also be used inside a \[Sum:...\] or \[Subtract:...\] placeholder.

#### Visual Overview: Shape data fields of type 'Parameters' now also accept element names, \[this element\] placeholders and keys containing forward slashes \[ID_21976\]

When configuring a trend component or a parameter chart, up to now, the shape data field of type *Parameters* had to contain a value with the following syntax:

```txt
DmaID:ElementID:ParameterID[:TableRowFilter]|...|...
```

In a value like the one found above, from now on, it is also allowed to use element names, \[this element\] placeholders and keys containing forward slashes (e.g. dmaID/elementID).

#### Visual Overview: Possibility to link page to multiple CPE chains and/or fields \[ID_22107\]

Previously, a Visio page could only be linked to one particular chain and field of a CPE Manager element. Now it is possible to link a page to several chains and/or fields.

To do so, in the *Chain* and *Field* shape data, specify the different chains and fields using pipe characters as separators. For each combination of a chain and field value from the shape data, the page will be displayed.

For example:

| Shape data field | Value                              |
|------------------|------------------------------------|
| Chain            | olt (limited)\|cmts topology\|maps |
| Field            | OLT\|CMC                           |

With the configuration of the example above, the page will be visible for the *OLT* and *CMC* field when the user navigates in the *OLT (limited)*, *CMTS topology* or *maps* chain.

> [!NOTE]
> If the *Field* shape data ends in a pipe character, the page will also be displayed when no field is selected.

#### Visual Overview: New dynamic placeholder \[Resource:...\] \[ID_22157\]

From now on, the \[Resource:...\] placeholder can be used to retrieve a property of a resource, which can be the name of the resource, the ID of the element linked to the resource, or a custom property.

For this purpose, the following syntax must be used:

\[Resource:*\<GUID>*,*\<property>*\]

This syntax consists of the following components:

- The GUID of the resource.

- The property to be retrieved, which can be specified as follows:

    | Property                                            | Value returned                                                                                                                                                               |
    |-------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | FullElementID                                         | The ID of the element linked to the resource in the format DmaID/ElementID. This can for instance be used to link to an actual element in Element shape data.                |
    | Name                                                  | The name of the resource.                                                                                                                                                    |
    | Property=*\<propName>* | The value of a custom property of the resource. The name of that custom property must be specified in *\<propName>*, e.g. Property=State. |

#### Visual Overview: Displaying or using the DataMiner time in UTC or local time in a shape \[ID_22252\]

It is now possible to have a shape display the current DataMiner time in either UTC time or local time, and to use those times in shape data items.

To do so, add the following dynamic placeholders to either the shape text or a shape data item:

- \[UTCTime\]
- \[LocalTime\]

By default, those times will be displayed in the regional date/time format. If you want a time to be displayed in another format, then specify the format inside the placeholder. See the following example:

- \[UTCTime:Format=HH:mm:ss\]

> [!NOTE]
> The times shown by these dynamic placeholders will be refreshed every second.

#### Visual Overview: Comprehensive set of Visio stencils now shipped with DataMiner \[ID_22643\]

DataMiner is now shipped with a comprehensive set of Visio stencils, which will automatically be downloaded to the client computer when you open Microsoft Visio from within DataMiner Cube. In Microsoft Visio, these stencils can be found under *More Shapes \> DataMiner*.

Using the new DataMiner stencils will considerably speed up the design of visually attractive Visio drawings. Not in the least because the stencils contain macros that automatically fill in the necessary shape data when you add shapes to a drawing. Only group-level shape data has to be filled in manually.

> [!NOTE]
>
> - In Microsoft Visio, open the *Visio options* window, go to *Advanced \> General*, and make sure the *Enable Automation events* option is selected.
> - Shape data used by the macros to fill in child-level shape data is always preceded by an underscore character.

#### Visual Overview: Parameter cache can now be used by shapes linked to a table column value and by \[param:\] placeholders that retrieve a table column value \[ID_22900\]

In the global user settings in DataMiner Cube (*C:\\Skyline DataMiner\\Users\\ClientSettings.json*), it is possible to configure that certain table parameters have to be cached. This cache can now also be used for:

- a shape that is linked to a table column value, and
- a \[param:\] placeholder that retrieves a table column value.

> [!NOTE]
>
> - For this to work, you only have to configure in the *ClientSettings.json* file that the table in question needs to be cached on the client. No changes have to be made to the Visio file.
> - Table indices containing wildcards are not yet supported.

#### Visual Overview: Linking to an element or partial element in a service by passing the service context in the element shape \[ID_23319\]

Up to now, it was possible to link to partial elements in a service context if the parent shape or the Visio file had a service context. In other words, when using child shapes or when the Visio file was linked to a service.

From now on, it will also be possible to set the service context by explicitly specifying a service in the *ServiceContext* shape data field of the element shape. The shape data of the element will then be resolved based on the name, ID or alias of the element, but in the context of the service you specified in the ServiceContext field.

| Shape data field | Value                                                             |
|------------------|-------------------------------------------------------------------|
| ServiceContext   | *Name, ID or alias of the service* |

#### Visual Overview: Navigation to data pages via shapes \[ID_23386\]

You can now configure a shape in Visio so that it can be used to navigate to any page of an element, service or view. Previously, this was only possible for visual overview pages, but now you can also configure a shape to navigate to data pages.

To do so:

1. Link the shape to the DataMiner object with the page you want to navigate to. For example, for an element, add the *Element* shape data field and specify the DMA ID/element ID as its value.

2. Add the following shape data to the shape:

    | Shape data field | Value                                                                                                                                                                                                                                                                                                                                                                                     |
    |--------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Page               | “*data*” or “*d*” for a data page or “*visual*” or “*v*” for a visual page, followed by a colon and the name of the page. To link to a subpage, add a forward slash and the name of the subpage. For example: *data:performance/Task Manager* |

#### Visual Overview: Bookings component and ListView component on same Visio page are now automatically synchronized \[ID_23715\]

On a Visio page containing both a Bookings component showing a timeline and a ListView component listing bookings, selecting a booking in one component will now automatically cause the same booking to be selected in the other component.

#### Visual Overview: New options for VdxPage pop-up windows \[ID_23734\]

When a shape is configured to display a page of the Visio drawing in a normal, undocked window using a VdxPage data shape field set to “\<Pagename>\|Window”, two new options can now be specified in a LinkOptions data shape field.

| Shape data field | Value                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| VdxPage          | *\<PageName>*\|Window                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| LinkOptions      | WindowStyle=*\<Style>*<br> \<Style> can be:<br> - SingleBorderWindow: A window with a single border<br> - ThreeDBorderWindow: A window with a 3-D border<br> - ToolWindow (default): A fixed-size tool window without minimize/maximize buttons<br> KeepOnTop=*\<true/false>*<br> - When set to true, the window will always appear in front of the window from which it was launched (default: false) |

#### Visual Overview: New \[Event:...\] placeholder \[ID_23834\]

By specifying an \[Event:...\] placeholder in a shape data field or a page data field, it is now possible to have an action triggered when a particular event occurs. During the event, the \[Event:...\] placeholder will be replaced by the value of the argument specified in the placeholder.

Syntax of the placeholder: \[Event:*\<EventName>*,*\<ArgumentName>*\]

At present, only one Router Control event can be specified:

- EventName: IOClicked

- Possible arguments:

    | Name               | Description                                                                           |
    |--------------------|---------------------------------------------------------------------------------------|
    | Label              | The label of the input or output that was clicked.                                    |
    | Index              | The index of the input or output that was clicked.                                    |
    | DCF interface ID   | The ID of the DCF interface that is linked to the input or output that was clicked.   |
    | DCF interface name | The name of the DCF interface that is linked to the input or output that was clicked. |

Example: \[Event:IOClicked,Label\]

> [!NOTE]
>
> - If you specify multiple \[Event:...\] placeholders in a shape data field or a page data field, only one action will be triggered when that event occurs.
> - It is advised not to insert \[Event:...\] placeholders into other dynamic parts or placeholders.

#### Visual Overview: New option to collapse empty rows and columns in the connectivity chain of a service instance \[ID_23941\]

By adding a data field of type ‘ServiceInstance’ to a shape, it is possible to have the connectivity chain of a service instance drawn automatically in Visual Overview.

When configuring such a shape, from now on, you can use the *CollapseEmptyRowsAndColumns* option to automatically collapse all empty rows and columns in the connectivity chain.

Example:

| Shape data field | Value                            |
|------------------|----------------------------------|
| ServiceInstance  | \[this service\]                 |
| Options          | CollapseEmptyRowsAndColumns=True |

#### Visual Overview: New icons added to DataMiner stencils \[ID_25024\]

The following additional icons are now available in the DataMiner stencils:

- PTP -BC
- PTP-TC
- PTP-Slave
- PTP-GrandMaster
