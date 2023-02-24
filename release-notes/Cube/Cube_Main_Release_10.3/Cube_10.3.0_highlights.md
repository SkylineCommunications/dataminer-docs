---
uid: Cube_Main_Release_10.3.0_highlights
---

# DataMiner Cube Main Release 10.3.0 – Highlights

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

## Highlights

#### Trending: New'Custom' button allows you to specify a custom X-axis range [ID_31705]

<!-- MR 10.3.0 - FR 10.2.1 -->

At the top of a trend graph, a new “Custom” button has been added next to the existing “Last 24 hours”, “Last week” and “Last month” buttons.

When you click this new button, you will be able to specify a custom X-axis range.

#### Visual Overview: Text wrapping and trimming [ID_32440]

<!-- MR 10.3.0 - FR 10.2.3 -->

In shapes linked to an object, it is now possible to change the text wrapping and trimming.

To do so, add a shape data field of type TextStyle, and set its value to “TextWrapping=...” and/or “TextTrimming=...” (separated by a pipe character).

| Shape data field | Value |
|--|--|
| TextStyle | TextWrapping=NoWrap/Wrap/WrapWithOverflow\|TextTrimming=CharacterEllipsis/WordEllipsis/None |

##### TextWrapping options

- **NoWrap**: The text will not wrap onto a new line, unless one was explicitly configured with a line break. Text that exceeds the bounds of the shape width and/or height will not be shown.

- **Wrap**: The text will automatically be wrapped onto new lines when the width of the shape is exceeded. The text past the boundaries of the shape height will not be shown.

- **WrapWithOverflow**: The text will be shown as before (default option).

##### TextTrimming options

- **CharacterEllipsis**: The text will be cut off a bit earlier than when TextTrimming is set to “None”, and “...” will be added to indicate that the text is longer than what fits in the shape.

- **WordEllipsis**: The text will be cut off at the nearest full word, and “...” will be added to indicate that the text is longer than what fits in the shape.

- **None**: The text will be cut off when necessary (default option).

> [!NOTE]
> Setting TextTrimming to either “CharacterEllipsis” or “WordEllipsis” will have no effect when TextWrapping is set to its default value (i.e. “WrapWithOverflow”).

#### Visual Overview - Edit in Visio: New options 'Add theming' and 'Add pretty hover' [ID_32660]

<!-- MR 10.3.0 - FR 10.2.5 -->

When, in DataMiner Cube, you right-click a visual overview and select “Edit in Visio”, an advanced edit panel will appear. When no shape is selected, you can now click an ellipsis button (“...”) in the top-right corner of the panel. This will open a menu with the following options.

- Add theming: If you click this option, the following theme options will be added to the page-level “Options” data field:

  *#000000=ThemeForeground\|#FF0000=ThemeAccentColor\|#FFFFFF=ThemeBackground*

- Add pretty hover: If you click this option, the following option will be added to the page-level “Options” data field:

  *HoverType=Geometry*

> [!NOTE]
> If no page-level “Options” data field exists, one will be created.

#### Services app: Service definition type [ID_32667]

<!-- MR 10.3.0 - FR 10.2.4 -->

When configuring a service definition, you now have to specify its type:

- SRM (default type)

- Skyline Process Automation

- Custom Process Automation

In Visual Overview, this type can be visualized by means of a \[ServiceDefinition:...\] placeholder. See the following example, in which xxx should be replaced by a service definition GUID.

```txt
[ServiceDefinition:xxx,Type]
```

> [!NOTE]
> It is not allowed to duplicate service definitions of type “Skyline Process Automation”. Therefore, the *Duplicate* option will not be available when you right-click a service definition of that type.

#### Visual Overview: Configuring a shape to set a duration in a session variable \[ID_32716\]

<!-- MR 10.3.0 - FR 10.2.4 -->

You can now configure a shape to set a duration of type TimeSpan in a session variable.

To do so, add the following shape data fields to the shape:

- a shape data field of type **SetVar**, of which the value is set to the name of the session variable, and

- a shape data field of type **SetVarOptions**, of which the value is set to “Control=Duration”, followed by the necessary options. For a list of possible options, see below.

| Shape data field | Value |
|--|--|
| SetVar | \<name of session variable> |
| SetVarOptions | Control=Duration\|\<option>\|\<option>\|... |

##### Options

Next to “Control=Duration”, you can specify the following options (separated by pipe characters).

| Option | Description |
|--|--|
| ShowInfinity=true/false | When this option is set to true, next to the duration selector, a checkbox is displayed that can be used to set the duration to infinity, which will replace the value of the session variable with TimeSpan.MaxValue. Default: False. |
| Minimum= | The minimum duration. Default: 1 minute. |
| Maximum= | The maximum duration. Default: 1 week. |

##### Setting the initial value of the duration in the session variable

Use a page-level InitVar field to set the initial value of the duration in the session variable.

If you set the initial value to “Infinity”, the value in the session variable will be replaced by TimeSpan.MaxValue. If the *ShowInfinity* option is set to true, a selected infinity checkbox will be displayed next to the duration selector.

> [!NOTE]
> Using an InitVar or SetVar field, it is possible to set a duration that is outside of the specified minimum/maximum range.

##### Specifying a duration

When specifying the minimum duration, the maximum duration and the InitVar value, you can use the following units:

| Unit | Description | Example |
|--|--|--|
| No unit | If no unit is specified, then the number in question will be considered a number of days. | 1 |
| s | seconds | 1s |
| m | minutes | 1m |
| h | hours | 1h |
| d | days | 1d |
| mo | months (1 month = 30 days) | 1mo |
| y | years (1 year = 365 days) | 1y |

#### Alarm Console - Automatic incident tracking: Manually add/remove alarms to/from alarm groups, move alarms from one alarm group to another, and rename alarm groups \[ID_32729\] \[ID_32819\] \[ID_32875\] \[ID_32914\] \[ID_32940\] \[ID_32957\] \[ID_33027\] \[ID_33036\] \[ID_33130\] \[ID_33212\]

<!-- MR 10.3.0 - FR 10.2.5
RN 33036/33130/33212: MR 10.3.0 - FR 10.2.6 -->

When, in the Alarm Console, you enable the “Automatic incident tracking” option, from now on, you will be able to manually add/remove alarms to/from alarm groups and to rename alarm groups.

- When you right-click an alarm that is not part of any alarm group, you will be able to click the “Add to incident” option. If you do so, a window will appear, asking you

  - to create a new incident (i.e. a new alarm group) and add the alarm to it, or

  - to add the alarm to an existing alarm group.

- When you right-click an alarm that is already part of an alarm group, you will be able to click the “Remove from incident” option. If you do so, the alarm will be removed from the alarm group of which it was a part.

- When you right-click an alarm that is part of an alarm group, you will be able to click the “Move to another incident” option. If you do so, a pop-up window will appear, asking you to either create a new incident or select another, existing incident.

- By default, automatically created alarm groups are named “View group:X” and manually created alarm groups are named “User defined group”. To rename an alarm group, click the pencil icon next to the name and enter a new name.

> [!NOTE]
>
> - From the moment a user manually adds or removes an alarm to or from an alarm group or renames an alarm group, that group will no longer be updated automatically.
> - Manually created incidents (alarm groups) will have their alarm focus score set to 0.
> - When Cube is connected to a DataMiner Agent that does not yet support manually creating, updating and renaming incidents (alarm groups), the menu commands to manipulate alarm groups will not be available.
> - See also [Alarm Console: Manually creating incident alarms even when “Automatic incident tracking” is disabled \[ID_33000\]](xref:Cube_Main_Release_10.3.0_other_features_changes#alarm-console-manually-creating-incident-alarms-even-when-automatic-incident-tracking-is-disabled-id_33000)

#### Trending - Behavioral anomaly detection: New type of change point 'flatline' [ID_32839] [ID_32856] [ID_32950] [ID_32993] [ID_33559] [ID_33957]

<!-- MR 10.3.0 - FR 10.2.5
RN 32993: MR 10.3.0 - FR 10.2.6
RN 33559: MR 10.3.0 - FR 10.2.8
RN 33957: MR 10.3.0 - FR 10.2.10 -->

The DataMiner Analytics software can detect a number of changes in the behavior of a trend, also known as “change points”. From now on, it will also be able to detect change points of type “flatline”. A flatline is detected when a fluctuating value suddenly remains constant.

A change point of type flatline will be labeled anomalous when no flatline change point of approximately the same length or longer was recently detected in the trend of the parameter in question.

A running estimate will be kept of how long the parameter typically remains constant. If this estimate exceeds 1 hour, no change points of type “flatline” will be detected. Else, a change point of type “flatline” will be detected if the parameter value was not constant in the last hour but is constant again for more than 3 times the running estimate.

Whenever an anomalous flatline is detected, a “suggestion event” is generated. You can view these suggestion events by creating a suggestion event tab in the Alarm Console.

A new flatline trend icon will be used to indicate when a parameter has flatlined.

> [!NOTE]
> Flatline change points can also be detected for history set parameters that are set nearly in real time, i.e. parameters of which the incoming changes never have a delay larger than 10 minutes.
> Flatline events will be cleared as soon as the flatline ends.

#### Visual Overview: ServiceManager component functionality expanded to support Process Automation UI \[ID_33187\]

<!-- MR 10.3.0 - FR 10.2.6
See also: Enhancements – Fix was moved to 10.2.0 CU3 by RN 33188 -->

To make it possible to show an overview of Process Automation service definitions in Visual Overview and filter these, the functionality of the *ServiceManager* component has been expanded.

##### interface=definitions component option

When you embed the Services module in Visio using the shape data field *Component* with the value *ServiceManager*, in the *ComponentOptions* shape data field, you can now use the option *interface=definitions* to only show the *Definitions* > *Recent* tab of the Services module. All existing options and variables have been made compatible with this option.

##### Filter shape data

If you use the *interface=definitions* component option described above, you can now also combine a *Filter* shape data field with the *ServiceManager* component. This allows you to filter the service definitions in the list, in the same way as in a *ListView* component. The following properties are supported for the filter:

- Name (String)

- Description (String)

- IsTemplate (Boolean)

- ID (GUID)

- CreatedBy (String)

- CreatedAt (DateTime)

- LastModifiedBy (String)

- LastModified (DateTime)

- NodeFunctionIDs (List\<Guid>)

- Properties (IDictionary\<string, dynamic>)

- ServiceDefinitionType (Int): This is an enum with the following possible values:

  - 0 = Default (representing the type "SRM" in Cube)

  - 1 = ProcessAutomation (representing the type "Skyline Process Automation" in Cube)

  - 2 = CustomProcessAutomation (representing the type "Custom Process Automation" in Cube)

Examples:

- This filter will only show service definitions of type "Skyline Process Automation" or "Custom Process Automation":

  | Shape data field | Value |
  |--|--|
  | Filter | ServiceDefinition.ServiceDefinitionType\[Int32\] == 1 \|\| ServiceDefinition.ServiceDefinitionType\[Int32\] == 2 |

- This filter will only show service definitions with the property *Virtual Platform* set to VPA:

  | Shape data field | Value |
  |--|--|
  | Filter | ServiceDefinition.Properties."Virtual Platform" == "VPA" |

##### New HideAddButton and HideDeleteButton component options

The following options can now also be specified in the *ComponentOptions* shape data field for a *ServiceManager* component:

- **HideAddButton=**: If this option is set to "true", no options to add a service definition will be displayed.

- **HideDeleteButton=**: If this option is set to "true", no options to delete a service definition will be displayed.

#### Desktop app - Start window: New 'HTTP or HTTPS' setting [ID_33289]

<!-- MR 10.3.0 - FR 10.2.6 -->

Up to now, when a DataMiner Agent had been added to the start window of the DataMiner Cube desktop app at a time when only HTTP was available, Cube would no longer switch to HTTPS when that protocol became available and HTTP got blocked.

When you add a DataMiner Agent to the start window, in the Advanced settings, you can now set the *Transport* setting to either “HTTPS only” or “HTTP or HTTPS”. If you choose the latter option, Cube will use HTTP by default. When HTTP is not available, it will try to use HTTPS instead. From that point onwards, the transport setting will automatically be switched to “HTTPS only”, so HTTPS will be used for all following sessions.

> [!NOTE]
> If a DataMiner Agent is configured to use only HTTPS, Cube will not fall back to HTTP, even when you have chosen the “HTTP or HTTPS” option.

#### Visual Overview: Adding a 'Refresh' and/or a 'Sort' button to a table control [ID_33346]

<!-- MR 10.3.0 - FR 10.2.6 -->

When using a shape of type *ParameterControls* to visualize a table in a Visio drawing, you can now add a *Refresh* button and/or a *Sort* button to that shape.

Example of how to add both a *Refresh* button and a *Sort* button:

1. Create three shapes and group them:

   - the first shape will contain the table,

   - the second shape will contain the *Refresh* button, and

   - the third shape will contain the *Sort* button.

1. Add the following shape data field to the shape that has to contain the table:

   | Shape data field | Value |
   |--|--|
   | ParameterControlOptions | Table |

1. Add the following shape data field to the shape that has to contain the Refresh button:

   | Shape data field | Value |
   |--|--|
   | ParameterControlOptions | Refresh |

1. Add the following shape data field to the shape that has to contain the Sort button:

   | Shape data field | Value |
   |--|--|
   | ParameterControlOptions | Sort  |

1. Add the following shape data fields to the group:

   | Shape data field | Value |
   |--|--|
   | Element | Element ID or element name |
   | ParameterControl | ID of the table parameter  |

> [!NOTE]
> The *Refresh* button and the *Sort* button will only be displayed when necessary.

#### Alarm Console: Updating incidents using the side panel \[ID_33436\]\[ID_33450\]

<!-- MR 10.3.0 - FR 10.2.7 -->

In the Alarm Console, it is now possible to edit incidents (i.e. alarm groups) using the side panel.

When you open the side panel and select an incident, a *Drag-and-drop editing* button will appear. Clicking that button will freeze both the side panel and the alarm tab and will allow you to

- add alarms to the incident by dragging them from the Alarm Console onto the side panel, and

- remove alarms from the incident by clicking the “X” next to the base alarm.

When you are finished editing the incident, click *Apply* to apply your changes and unfreeze the side panel.

> [!NOTE]
> Instead of opening the side panel and clicking the *Drag-and-drop editing* button, you can also right-click an incident and select *Edit incident*. This will open the side panel (if it is not open yet) and enable the “drag and drop” mode.

#### Tab layout: Closing a card tab by clicking it with the middle mouse button \[ID_33883\]

<!-- MR 10.3.0 - FR 10.2.9 -->

When the card layout is set to “tab layout”, you can now close a card tab by clicking it with the middle mouse button.

#### Password box with strength indicator and peek button \[ID_33937\]

<!-- MR 10.3.0 - FR 10.2.9 -->

Password boxes in Cube will now indicate the password strength (common, very weak, weak, good, strong, very strong) based on a scoring algorithm and a dictionary of default and well-known passwords. They will also have a peek button that allows you to temporarily reveal the password you have entered.

These new password boxes can be found in the following locations:

- Cube login screen (peek only)
- Data Display: parameters of type password (e.g. the password box of a Microsoft Platform element)
- Edit port settings of an SNMPv3 element
- System Center \> Agents \> Add
- System Center \> Database
- System Center \> Users/groups \> Add new user... (peek only)
- System Center \> System Settings \> Credentials Library
- System Center \> System Settings \> LDAP
- Interactive Automation scripts (UIBlock of type PasswordBox)

> [!NOTE]
>
> - If a value received from the server has been automatically entered in a password box, the strength indicator and peek button will not be available until you enter a completely new password.
> - If the value received from the server is a fixed 8-asterisk-long placeholder instead of an actual password, you will not be able to modify it. You will be forced to replace the entire value.

#### New 'Light' theme & new links in the Apps list \[ID_33944\]

<!-- MR 10.3.0 - FR 10.2.9 -->

A new theme has been added to DataMiner Cube: “Light”.

Also, the Apps list now contains links to the Catalog, the Admin app, and custom web apps.

#### Trending: Light bulb icon now indicates that related parameters have been found [ID_34432]

<!-- MR 10.3.0 - FR 10.2.12 -->

In the top-right corner of a trend graph, next to the full-screen button, a light bulb icon will now appear when DataMiner finds parameters that are related to the parameters shown in the trend graph. Clicking this light bulb icon will allow you to add one or more of those related parameters to the trend graph you are viewing.

Relationships between parameters are found by studying the changes in the behavior of a trend (also known as change points). These relationships are then stored in a model managed by a DataMiner Extension Module named *ModelHost*. When you open a trend graph, DataMiner Cube will check the parameter relationship model, retrieve from it all parameters related to those shown in the trend graph, and list the ten most important ones when you click the light bulb icon.

> [!NOTE]
>
> - This light bulb feature will only work on cloud-connected DataMiner Agents that have the *ModelHost* DxM installed and that have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads).
> - Relationship models are calculated once per week. When this feature is activated, it can take up to a week before the first results are visible.
> - Currently, the ModelHost DxM is not yet available.
