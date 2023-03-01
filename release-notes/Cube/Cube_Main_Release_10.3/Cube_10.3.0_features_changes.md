---
uid: Cube_Main_Release_10.3.0_other_features_changes
---

# DataMiner Cube Main Release 10.3.0 – Other new features & changes

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

## Other new features

#### Visual Overview: Shape data fields of type 'ParametersSummary' can now also handle subscription filters specified in the index part of a parameter section \[ID_31609\]

<!-- MR 10.3.0 - FR 10.2.1 -->

The value of a ParametersSummary shape data field has to consist of a number of delimited sections:

```txt
Operation|Param1|Param2|...|ParamZ|Actions
```

Each parameter section in the value above has to be configured as follows:

```txt
Element:Parameter:Index
```

From now on, the “Index” part of a parameter section can also contain a subscription filter:

```txt
Filter=<subscriptionFilter>
```

This subscription filter can be any filter that can be passed to a parameter change subscription (e.g. “VALUE=\<pid> == \<value>”, “fullFilter=(...)”, etc.).

> [!NOTE]
> Up to now, when the index part of a parameter section contained a wildcard, no results would be returned whenever cells were set to “not initialized”. From now on, cells set to “not initialized” will be skipped.

#### Trending: New 'Fixed interval' option when exporting average trend data \[ID_31699\]

<!-- MR 10.3.0 - FR 10.2.2 -->

When you export average trend data, selecting the new *Fixed interval* option will make sure that the data points are equally distributed and that gaps smaller than a time slot (e.g. 5 minutes) are ignored.

> [!NOTE]
>
> - The “fixed interval” option can only be used when exporting average trend data for double, number or analog parameters.
> - When you select the *Fixed interval* option, the *Exclude gaps* option will automatically be selected and disabled to indicate that the latter option is included in the former.
> - When you select the *Line graph* option, from now on, that option will no longer add intermediary data points. Those will now by default be added when you select the *Fixed interval* option.

#### DataMiner Cube: Start window will now detect a HTTP(S) redirection and will ask the user to confirm that redirection \[ID_31726\]

<!-- MR 10.3.0 - FR 10.2.1 -->

When, in the start window of the DataMiner Cube desktop app, you try to connect to a DataMiner Agent with a redirection on HTTP(S) level, you will now be asked to confirm the redirection.

#### Visual Overview - Embedded Resource Manager component: New and updated session variables \[ID_31770\] \[ID_32394\]

<!-- RN 31770: MR 10.3.0 - FR 10.2.1
RN 32394: MR 10.3.0 - FR 10.2.3 -->

The following changes have been made with regard to session variables that can be used in embedded Resource Manager components.

##### New variable 'SelectedTimeRange'

When you select a time range, that range will be stored in the SelectedTimeRange variable.

The value can be set in serialized form (e.g. “5248098399646517511;5248392353962787511”) or using a “start;stop” format. In the latter case, start and stop must be timestamps that can be parsed by DateTime (e.g. “2017-09-17T09:42:01.9129607Z;2018-08-23T15:05:53.5399607Z” in ISO 8601 format, or “17/09/2017 9:42:01;23/08/2018 15:05:53” in local format).

This variable will be cleared whenever you select another time range in the timeline.

##### Updated variable 'SelectedResource'

The SelectedResource variable will now also be filled in when you select a resource band.

Note that, when you select a resource band, the SelectedPool variable will contain the first pool of the selected resource.

##### Problem with 'SelectedReservation' variables

When you select a booking, the following variables are filled in:

- SelectedReservation
- SelectedReservationDefinition
- ResourcesInSelectedReservation
- TimerangeOfSelectedReservation

However, up to now, when the current booking selection was cleared, those variables would incorrectly not get cleared.

#### Visual Overview: Specifying a remote debugging port for Chromium and Edge browser engines [ID_31792]

<!-- MR 10.3.0 - FR 10.2.4 -->

Embedded Chromium and Edge browser engines allow external tooling to inspect and manipulate their web browser.

When starting DataMiner Cube, from now on, you can pass a remote debugging port for both Chromium and Edge engines by specifying the following command line options:

- ChromeRemoteDebuggingPort=7001
- EdgeRemoteDebuggingPort=7002

Note that the port number must be between 1024 and 65535.

#### Alarm templates - Information events: Support for wildcard values [ID_31872] [ID_32106]

<!-- MR 10.3.0 - FR 10.2.2 -->

In the alarm template editor, you can indicate that an information event should be generated when a certain parameter reaches a certain value. To do so, you select the *Info* option and enter a value in the text box or, in case of a discreet parameter, select a value in the selection box.

From now on, for parameters of type string or double, it is also possible to enter values that contain a wildcard (\* or ?).

#### Visual Overview: Resource placeholder can now be used to check whether a resource is in use [ID_32203]

<!-- MR 10.3.0 - FR 10.2.3 -->

The \[Resource:...\] placeholder can be used to retrieve a property of a resource. From now on, it can also be used to check whether a resource is being used by any bookings. To do so, use the following syntax.

```txt
[Resource:<GUID>,InUse]
```

> [!NOTE]
> Currently, this check will only be performed when the visual overview is opened or when the GUID or the resource itself is changed.

See also: [New 'IN USE' info tag to be used in element shapes linked to resources \[ID_32393\]](#new-in-use-info-tag-to-be-used-in-element-shapes-linked-to-resources-id_32393)

#### Visual Overview: Linking a shape to an alarm filter with a System Name or System Type filter context [ID_32252] [ID_32548]

<!-- RN 32252: MR 10.3.0 - FR 10.2.3
RN 32548: MR 10.3.0 - FR 10.2.4 -->

When you link a shape to an alarm filter, you can specify a filter context. Up to now, it was possible to filter on element, service or view. Now, it is also possible to filter on EPM system name or system type using the following syntax:

```txt
FilterContext=SystemName=X
FilterContext=SystemType=X
```

If you specify a filter context like the one above, the shape will be linked to the alarms of which the “System Name” or “System Type” property is set to “X”. This will allow you, for example, to show the alarm statistics of an EPM object or to create a new alarm tab by clicking the shape in question.

> [!NOTE]
> It is also possible to specify a filter context in which both system name and system type are combined. To do so, use the following syntax:
>
> *FilterContext=SystemName=X;SystemType=Y*
>
> If you specify a filter context like the one above, the shape will be linked to the alarms of which the “System Name” is set to “X” and “System Type” is set to “Y”.

#### Visual Overview: Use of dynamic units now depends on value of DynamicUnits soft-launch option [ID_32256]

<!-- MR 10.3.0 - FR 10.2.3 -->

Up to now, when configuring a parameter shape, it was possible to enable to use of dynamic units (i.e. units that can be converted to other units according to rules configured in the protocol) by adding “DynamicUnits=true” in an Options data field. From now on, when you do not specify this option in a parameter shape, whether or not that shape will use dynamic unit will depend on the value of the DynamicUnits soft-launch option.

> [!NOTE]
> The DynamicUnits=true/false option can now be used to override the value of the DynamicUnits soft-launch option. For example, if the DynamicUnits soft-launch option is set to true, you can configure a parameter shape to not use dynamic units by adding "DynamicUnits=False" to its Options data field.
>
> For more information on soft-launch options, see [Soft-launch options](xref:SoftLaunchOptions).

#### New 'IN USE' info tag to be used in element shapes linked to resources [ID_32393]

<!-- MR 10.3.0 - FR 10.2.3 -->

Shapes that are linked to an element can automatically be linked to corresponding resources by adding “UseResource=True” in a shape data field of type Options.

From now on, in shapes linked to resources, you can specify “IN USE” in a shape data field of type Info. That way, the shape will indicate whether the linked resource is in use. However, note that for this feature to work, the shape text has to contain a “\*” character.

Alternatively, you can also use “\[In use\]” in any dynamic part specified in either a shape data field or the shape text.

See also: [Visual Overview: Resource placeholder can now be used to check whether a resource is in use \[ID_32203\]](#visual-overview-resource-placeholder-can-now-be-used-to-check-whether-a-resource-is-in-use-id_32203)

#### Visual Overview: Shapes that cannot be clicked and had their text trimmed will show a tooltip with the full shape text [ID_32463]

<!-- MR 10.3.0 - FR 10.2.4 -->

Shapes that cannot be clicked and had their text trimmed by means of a “TextTrimming” option in a shape data field of type TextStyle will now automatically show a tooltip with the full, untrimmed shape text.

#### New setting to enable the cache of the Chromium browser engine [ID_32534]

<!-- MR 10.3.0 - FR 10.2.4 -->

In the *Computer \> Advanced* section of the *Settings* app, you can now use the *Enable browser cache* setting to enable the cache of the Chromium browser engine.

Enabling this cache has the following advantages:

- Certain web applications will load faster.
- SAML authentication can provide a better single sign-on experience.

> [!CAUTION]
> This feature involves a potential security risk. If multiple DataMiner users share the same Windows account on a particular computer, they will also share the same browser cache and, as a consequence, the same authentication on third-party websites.

#### Trending: Refresh rate of trend graphs can now be configured [ID_32715]

<!-- MR 10.3.0 - FR 10.2.4 -->

Up to now, open trend graphs were automatically refreshed every 2 minutes. From now on, you can specify a custom refresh rate (5 seconds to 5 minutes) in the *Update interval* setting, located in the *User \> Trending* section of the *Settings* app.

Default: 2 minutes

> [!NOTE]
>
> - Changing this refresh rate can have a minor effect on overall performance, especially when opening trend graphs with more than 10 parameters.
> - If you change the *Update interval* setting, then open trend graphs need to be closed and re-opened if you want them to use the new interval.

#### Visual Overview: Passing Interactive Automation script output to session variables [ID_32874]

<!-- MR 10.3.0 - FR 10.2.6 -->

Similar to regular Automation scripts, interactive Automation scripts are now also able to pass their output to session variables in Visual Overview.

> [!NOTE]
> When configuring the Execute shape, it is recommended to specify both the NoConfirmation option and the CloseWhenFinished option in the value of the Execute data field.

#### Visual Overview - Resource Manager component: Enhancements with regard to selecting bookings in the timeline [ID_32938]

<!-- MR 10.3.0 - FR 10.2.6 -->

A number of enhancements have been made with regard to selecting bookings in the timeline area of an embedded Resource Manager component.

- When you select a booking, the corresponding resource band and all occurrences of that booking will be selected.
- When you unselect a booking, the corresponding resource band and all occurrences of that booking will also be unselected.
- The reservation variable and the resource variable will always contain the booking and the resource selected in the timeline.
- When you remove a resource band, the corresponding resource variable will be cleared.

#### DataMiner Cube - Alarm Console: Users can now manually create incidents even when 'Automatic incident tracking' is disabled in System Center [ID_32990] [ID_33354]

<!-- MR 10.3.0 - FR 10.2.7 -->

From now on, users will be able to manually create incidents even when “Automatic incident tracking” is disabled in System Center.

#### Visual Overview: Resource usage now updated in real time [ID_33001] [ID_33156] [ID_33497]

<!-- MR 10.3.0 - FR 10.2.6 -->

From now on, resource usage will be updated in real time. This means that “\[Resource:\<GUID>,InUse\]” placeholders and Info data fields of type “IN USE” will now be updated without having to close and re-open cards.

Also, from now on, “\[Resource:\<GUID>,InUse\]” placeholders and Info data fields of type “IN USE” can be used in any element shape, provided it has “UseResource=True” in a shape data field of type Options.

#### Alarm Console: Additional actions to be performed on incidents [ID_33056]

<!-- MR 10.3.0 - FR 10.2.6 -->

From now on, when you right-click an incident (alarm group), you will be able to perform the following additional actions:

- Take ownership
- Release ownership
- Force release ownership
- Add a comment

If you right-click a manually created incident, you will also be able to select *Clear alarm*. When you clear a manually created incident, the alarm group will be cleared and all the base alarms will again be added to the Alarm Console.

#### Alarm templates - Anomaly detection: Configuring alarms for flatline changes [ID_33123] [ID_33139] [ID_33171]

<!-- MR 10.3.0 - FR 10.2.6 -->

From DataMiner 10.0.3 onwards, you can configure an alarm template so that alarms are generated instead of suggestion events when anomalies are detected for specific parameters. From now on, you can also enable this for flatline changes.

1. Click the cogwheel button in the top-right corner of the alarm template editor.
1. Select the option *Advanced configuration of anomaly detection*. Four extra columns will be displayed in the template editor.
1. In the *Flatline monitor* column, click the toggle button to enable or disable alarms for flatline changes.

#### Alarm Console: Second-generation hyperlinks of type 'openview', 'openservice', 'openelement' and 'openparameter' now support '\[PROPERTY:\]' keywords [ID_33166]

<!-- MR 10.3.0 - FR 10.2.7 -->

Up to now, it was only possible to use “\[PROPERTY:\]” keywords in second-generation hyperlinks of type “url”, “execute” and “script”. From now on, these keywords can also be used in second-generation hyperlinks of type “openview”, “openservice”, “openelement” and “openparameter”.

For example, a hyperlink of type “openelement” could contain the following content:

```txt
[PROPERTY:ALARM:Booking Manager Element ID]
```

> [!NOTE]
>
> - If you want to use a view property, a service property or an element property in a hyperlink, then you must enable its “Make this property available for alarm filtering” setting in DataMiner Cube.
> - If you want to use a view property on an alarm of an element that has been added to multiple views, the property that will be used in the hyperlink will be the property of the view with the lowest ID that contains the element.

#### DataMiner Cube: Start window enhancements [ID_33219]

<!-- MR 10.3.0 - FR 10.2.6 -->

A number of enhancements have been made to the start window of the DataMiner Cube desktop app:

- Settings menu (cogwheel icon in bottom-right corner)

  - New *About* box with version information.

  - All menu items now have icons in front of them.

- When you right-click an agent,

  - you can now click *Open in browser* to connect to that agent using a browser version of Cube, and

  - all context menu items now have icons in front of them.

- When agents/clusters are arranged in named groups, the context menu of the DataMiner Cube system tray icon will now contain submenus per named group.

- The message that is displayed after a start window update will no longer show any technical information.

#### Trending - Behavioral anomaly detection: Enhanced analysis of anomalous change points [ID_33281] [ID_34376]

<!-- MR 10.3.0 - FR 10.2.11 -->

When you enable alarm monitoring for a specific type of anomaly in an alarm template, an automatic anomaly significance check is performed. This check has now been enhanced.

Per trended parameter, the anomaly significance check will filter out behavioral changes that cannot be considered anomalous with respect to the history of behavioral changes of the parameter in question. Behavioral changes similar to changes that have occurred regularly or frequently in the historical behavior of a parameter will not be labelled anomalous and will therefore not cause an alarm to be generated when anomaly monitoring is enabled for the parameter and anomaly type in question.

#### Data Display: Context menu of URL parameters now contains copy commands [ID_33321]

<!-- MR 10.3.0 - FR 10.2.6 -->

In Data Display, the context menu of a URL parameter will now contain the following copy commands:

- Copy ‘\<URL>’: Copies the URL to the Windows Clipboard.

- Copy value to editor: Copies the URL to the write parameter edit box.

  > [!NOTE]
  > This command will only be available when there is a write parameter.

#### Alarm Console: A comment will now be added to an manually created incident when created or updated [ID_33387]

<!-- MR 10.3.0 - FR 10.2.7 -->

When users manually create an incident, change the display value of a manually created incident or add or remove base alarms to or from a manually created incident, from now on, a comment will be added to the incident (Created, Base alarm added, Base alarm removed, Value changed by \<user name> @ \<time>).

#### Visual Overview - Resource Manager component: Passing elements, services or views using the YAxisResources variable [ID_33402]

<!-- MR 10.3.0 - FR 10.2.8 -->

From now on, you can pass elements, services, or views to the YAxisResources session variable in order to show the corresponding resource bands.

##### Passing elements

You can pass elements by name or by ID as a string of comma-separated values.

In case an element is configured as an element reference in a resource, as a main DVE element in a function resource, or as the element corresponding with a virtual function resource, the corresponding resource will be shown.

In the following example, three elements are passed: an element with the name "MyElement", the element to which the Visio drawing is linked, and the element with ID 123/456:

```txt
YAxisResources:Element=MyElement,[this element],123/456
```

The corresponding resource bands are not updated automatically in case there is a change to the configuration of the elements.

##### Passing services

You can pass services by name or by ID as a string of comma-separated values.

The resources of the bookings linked to the services will be shown.

In the following example, three services are passed: a service with the name “MyService”, the service to which the Visio drawing is linked, and the service with ID 123/456:

```txt
YAxisResources:Service=MyService,[this service],123/456
```

To also show resources for contributing bookings, in the ComponentOptions shape data field of the Resource Manager component, specify Recursive=True.

The resource band will be updated in real time, based on the linked booking. This means that when you add or remove resources in a booking, you will immediately see the effect on the timeline.

##### Passing views

You can pass views by name or by ID as a string of comma-separated values.

When you pass a view, for any elements in that view that are configured as an element reference in a resource, as a main DVE element in a function resource, or as the element corresponding with a virtual function resource, the corresponding resources will be shown.

In the following example, three views are passed: a view with the name "MyView", the view to which the Visio drawing is linked, and the view with ID 123:

```txt
YAxisResources:View=MyView,[this view],123
```

To also show resources for elements in child views, in the ComponentOptions shape data field of the Resource Manager component, specify Recursive=True.

The corresponding resource bands are not updated automatically in case there is a change to the configuration of the elements.

#### Failover: Current Failover DMA status will now automatically be refreshed every minute [ID_33426]

<!-- MR 10.3.0 - FR 10.2.8 -->

In the *Failover Config* window as well as the *Status* dialog box, the current Failover DMA status will now automatically be refreshed every minute.

#### Visual Overview - Service Manager component: Filtering on FunctionDefinitionType [ID_33466]

<!-- MR 10.3.0 - FR 10.2.7 -->

When you embed a Service Manager component in Visual Overview, it is now possible to apply a filter that will make the function tree only list functions with specific FunctionDefinitionType fields.

To do so, add a FunctionTypes option to the ComponentOptions shape data field.

| Shape data field | Value |
|--|--|
| Component | ServiceManager |
| ComponentOptions | FunctionTypes=\[comma-separated list of values\]<br> Possible values:<br> - Undefined (i.e. NULL value)<br> - UserTask<br> -  ScriptTask<br> - ResourceTask<br> - Gateway<br> - NoneStartEvent<br> - TimeStartEvent<br> - EndEvent |

> [!NOTE]
>
> - The FunctionTypes option
>   - only works in conjunction with the options Interface=definition or Interface=definitions.
>   - can be used in combination with the HideChildFunctions option.
>   - can be set dynamically using session variables.
> - The filter will be cleared when no FunctionTypes option is specified or when the FunctionTypes option is set to an empty list of values.
> - Parent functions that do not match the filter but have child functions that match the filter will be displayed in the function tree to allow you to navigate to one of the child functions.

#### Visual Overview - Resource Manager component: Selecting multiple resource bands in the timeline [ID_33536]

<!-- MR 10.3.0 - FR 10.2.8 -->

In the timeline of an embedded Resource Manager component, it is now possible to select multiple resource bands.

To select more than one resource band, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive resource bands, click the first one and then click the last one while holding down the SHIFT key.

When you select more than one resource band, the SelectedResource session variable will contain the GUIDs of all selected resources, separated by commas.

#### Visual Overview - Resource Manager component: Enhanced way of selecting a time range [ID_33580]

<!-- MR 10.3.0 - FR 10.2.8 -->

In the timeline, the context menu will no longer open automatically after selecting a time range by means of drag-and-drop. Instead, it will now only open when you right-click.

This change in behavior will now allow you to trigger a script by clicking an action button instead of selecting an option in the context menu of the timeline. In other words, you will now be able to proceed as follows:

1. Select a resource band.
1. Select a time range.
1. Click an action button.

The SelectedTimeRange variable will now be cleared when the time selection is cleared (i.e. when it is no longer visible/available). Up to now, this variable would only be cleared when the selection was changed.

#### System Center - Agents: BPA Details window now has a Copy button that copies the list of errors to the Windows clipboard [ID_33638]

<!-- MR 10.3.0 - FR 10.2.8 -->

When, in the *BPA* tab of the *Agents* section, you see a BPA test that returned errors during its last run, you can click “...” to open a *Details* window listing those errors.

At the bottom of this *Details* window, you can now find a *Copy* button that allows you to copy the list of errors to the Windows clipboard.

#### Visual Overview: \[this reservationID\] placeholder [ID_33669]

<!-- MR 10.3.0 - FR 10.2.8 -->

In shape data or shape text of shapes linked to a booking (e.g. dynamically generated shapes that represent bookings), you can now use a \[this reservationID\] placeholder to retrieve the GUID of the booking.

See the following examples:

`[Resource:[reservation:[this reservationID],ResourceID|NodeID=18|],Name]`

`[reservation:[this reservationID],Property=Monitoring]`

#### Alarm Console - Incident tracking: Some types of alarms can now be manually added to incidents even when they do not contain any focus data [ID_33771] [ID_33803]

<!-- MR 10.3.0 - FR 10.2.9 -->

Up to now, alarms that did not contain any focus information were not allowed to be the base alarm of an incident. From now on, alarms that do not contain any focus data can be manually added to an incident, provided they are not one of the following types of alarms:

- correlation alarms
- clearable alarms
- information events
- suggestion events
- other incidents

#### Trending: Prediction type selection has now moved to the context menu [ID_33861]

<!-- MR 10.3.0 - FR 10.2.9 -->

In a trend graph, up to now, a drop-down list in the top-right corner allowed you to select one of the available trend prediction types or “Auto”. This drop-down list has now been removed. Instead, you can now right-click the graph and select one of the available trend prediction types or “Auto” from the context menu.

#### Browser callbacks can now open EPM objects via SystemName or SystemType [ID_33963]

<!-- MR 10.3.0 - FR 10.2.9 -->

When an embedded web page is displayed in Cube, it is possible to make a callback from the web page into Cube and, for example, open an element, service, view or CPE card.

The existing JavaScript web browser callbacks for browser shapes in Visual Overview have now been extended to allow opening an EPM card in Cube via an object’s SystemName or SystemType using the following method:

```txt
NavigateCPEByName(string systemType, string systemName);
```

Example in HTML:

```html
<a href='javascript:window.external.NavigateCPEByName("Region","California");'>Open Region California</a>
```

#### Automation app: Casing of a script name can now be changed [ID_33988]

<!-- MR 10.3.0 - FR 10.2.9 -->

In the Automation app, it is now possible to change the casing of a script name.

Also, if you change the casing of a script name that was selected, it will remain selected.

#### Visual Overview - Conditional shape manipulation: Using statistics in the condition when the shape is linked to an EPM object [ID_34026]

<!-- MR 10.3.0 - FR 10.2.9 -->

When applying conditional shape manipulation actions to a shape, up to now, it was only possible to use statistics in the condition if the shape was linked to an element, a service or a view. From now on, you can also use statistics in the condition when the shape is linked to an EPM object.

Example in which both the SystemName and the SystemType are linked:

```txt
<A>-A|SystemType= Cable;SystemName=SF Cable1|#TotalAlarms|>0
```

Supported statistics:

- #TotalAlarms
- #CriticalAlarms
- #MajorAlarms
- #MinorAlarms
- #WarningAlarms
- #NormalAlarms
- #TimeoutAlarms
- #NoticeAlarms
- #ErrorAlarms

Supported operators:

- =
- !=
- \>
- \>=
- \<
- \<=

#### Visual Overview: Retrieving the contributing booking ID of a resource [ID_34306]

<!-- MR 10.3.0 - FR 10.2.11 -->

In Visual Overview, it is now possible to retrieve the contributing booking ID of a resource.

- By specifying the *ContributingBooking* property in the `[Resource:]` placeholder.

    Example: `[Resource:[pagevar:IDOfSelection], ContributingBooking]`

- By specifying the following in a shape that is linked to an element and that has "UseResource=true" set in its *Options* shape data field.

    - A shape data field of type *Info* set to "Contributing Booking" and an asterisk character ("*") in the shape text:

        Example:
        
        | Shape data field | Value |
        |------------------|-------|
        | Element | [pagevar:idofselection] |
        | Options | UseResource=truee |
        | Info | Contributing Booking |

        and the shape text set to `Contributing booking: *`

        ***OR***

    - A `[Contributing Booking]` placeholder in the shape text:

        Example:
        
        | Shape data field | Value |
        |------------------|-------|
        | Element | [pagevar:idofselection] |
        | Options | UseResource=truee |

        and the shape text set to `Contributing booking: [Contributing Booking]`

#### Visual Overview: Shape data items of type 'NavigatePage' can now have values that include dynamic placeholders [ID_34442]

<!-- MR 10.3.0 - FR 10.2.11 -->

Shape data items of type *NavigatePage* can now have values that include dynamic placeholders referring to session variables, parameters, etc.

#### Visual Overview: New OverridePageName option [ID_34476]

<!-- MR 10.3.0 - FR 10.2.11 -->

From now on, you can override a Visio page name by specifying an "OverridePageName=*NewPageName*" option in a page-level shape data field of type *Options*. When you do so, the page in question will be handled as if its name were *NewPageName*.

> [!NOTE]
>
> - Always use the actual page name when referring to a particular page in options like e.g. *VdxPage*, *NavigatePage*, *InlineVdx*, etc. Using a page override when referring to a page will not work.
> - This feature allows you to define duplicate page names. When you do so, take into account that components that display Visio page names may then also display those duplicate page names.
> - Visio files used in web apps do not support the OverridePageName option.

#### Visual Overview: Shape data items of type 'ParametersSummary' can now have values that include dynamic placeholders referring to session variables [ID_34483]

<!-- MR 10.3.0 - FR 10.2.11 -->

Shape data items of type *ParametersSummary* can now have values that include dynamic placeholders referring to session variables.

#### Visual Overview - ListView component : Custom property columns 'Reservation.Start' and 'Reservation.End' can now be configured to convert date/time values to the time zone specified in the navigation panel of the bookings timeline [ID_34512]

<!-- MR 10.3.0 - FR 10.2.12 -->

Up to now, when you added the custom property columns *Reservation.Start* and *Reservation.End* to a ListView component configured to list bookings, the UTC date/time values in those columns would always be converted to the time zone of the DataMiner Agent. From now on, if you set the type of those columns to "Date InvariantCulture", the date/time values in those columns will be converted to the time zone specified in the navigation panel of the bookings timeline.

#### Server-side search: New option 'includeAllCustomProperties' [ID_34541]

<!-- MR 10.3.0 - FR 10.2.12 -->

In the *MaintenanceSettings.xml* file, you can configure the DataMiner Cube server-side search engine by specifying one or more search options in the *SLNet.SearchOptions* element.

If you specify the new *includeAllCustomProperties* option, the server-side search engine will now search the values of all custom properties. Up to now, the search engine would by default only search the values of the custom properties that were displayed in the Surveyor.

For more information on the available search options, see [Setting the indexing options for the server-side search](xref:Setting_the_indexing_options_for_the_server-side_search).

Also, from now on, DataMiner Cube will call the server-side search engine when you enter a numeric search string like "1234". Up to now, when you entered a numeric search string, DataMiner Cube would perform a client-side search that would only return views of which the ID matched the search string.

#### System Center - Database: Address specified in the 'DB server' field of a database of type 'Cassandra' or 'CassandraCluster' can now include a custom port [ID_34590]

<!-- MR 10.3.0 - FR 10.3.3 -->

When, in the *Database* section of *System Center*, you are configuring a database of type "Cassandra" or "CassandraCluster", you can now specify an address with a custom port in the *DB server* field.

If you specify a hostname or IP address without a port, DataMiner will fall back to the default Cassandra port 9042.

Examples:

- localhost (Will be resolved to localhost:9042)
- 10.5.100.1:5555

#### Resources app: 'Resources' tab and 'Occupancy' tab can now be filtered [ID_34973]

<!-- MR 10.3.0 - FR 10.3.2 -->

In the *Resources* app, resource pools will now have a filter box that allow you to filter both the *Resources* tab and the *Occupancy* tab on resource name.

- When you enter text in the filter box, a list with suggestions will appear.
- When you select another resource pool while text is present in the filter box, the *Resources* tab and the *Occupancy* tab of that newly selected resource pool will automatically be filtered.
- When an item in either the *Resources* tab or the *Occupancy* tab gets updated while a filter is applied, that item will only be shown if it matches the filter after the update.
- To clear the filter box, you can either delete the text in the filter box or click the *Clear* button.

## Changes

### Enhancements

#### Desktop app: Enhanced host detection [ID_31829]

<!-- MR 10.3.0 - FR 10.2.2 -->

In the DataMiner Cube desktop app, a number of enhancements have been made with regard to host detection.

#### Desktop app start window now has a look and feel that is identical to that of the other Cube apps [ID_32161]

<!-- MR 10.3.0 - FR 10.2.3 -->

The start window of the DataMiner Cube desktop app has now been adapted so that its overall look and feel is identical to that of the other Cube apps.

#### Desktop app - Start window: Performance enhancements [ID_33384]

<!-- MR 10.3.0 - FR 10.2.7 -->

Because of a number of enhancements, overall performance has increased when opening the start window of the DataMiner Cube desktop app from the system tray icon.

#### Alarm Console: Pencil icon now identical to that used in Data Display tables [ID_33442]

<!-- MR 10.3.0 - FR 10.2.7 -->

The pencil icon used in the Alarm Console is now identical to that used in Data Display tables.

#### Alarm Console: 'Add to incident' menu option no longer available when right-clicking alarms that cannot be added to an incident [ID_33591]

<!-- MR 10.3.0 - FR 10.2.8 -->

From now on, the “Add to incident” menu option will no longer be available when you right-click an alarm that cannot be added to an incident:

- Active alarms with severity “normal” (i.e. clearable alarms that have not been cleared yet)
- Alarms with a source other “DataMiner System” (e.g. correlation alarms)
- Alarms associated with DataMiner itself
- Notices, errors, information events and suggestion events

#### Start window enhancements [ID_34033]

<!-- MR 10.3.0 - FR 10.2.9 -->

A number of enhancements have been made to the DataMiner Cube start window:

- When you hover over a cluster tile, a tooltip will now appear, showing the cluster name, the cluster alias, the hostname of the agent and the last-known server version (if any). The latter will be updated when you connect to the cluster in question and when an update occurs in the background.

    > [!NOTE]
    > Cluster tiles will no longer display the hostname of the agent if it is identical to the cluster alias.

- When using the search box to filter the tiles, the last-known server version will now also be checked. This will allow users to search for clusters with a specific server version.

- When you check for updates (by clicking the cogwheel icon in the bottom-right corner and selecting *Check for updates*), the last-known server version will now be taken into account to avoid having to contact every configured cluster. If a DataMiner Agent has been upgraded since the last background update, the new client version will be downloaded from the agent the first time you connect to it or from the cloud during the next background update (if that version is newer that the current version).

    > [!NOTE]
    >
    > - If you hold the SHIFT key when clicking *Check for updates*, a full update will start. Depending on the number of clusters in your configuration, this can take some time.
    > - An update triggered by the *Update DataMiner Cube_ [userID]* task in Windows Task Scheduler will always be a full update.

- When the start window application is downloaded from a DataMiner Agent, the cluster is automatically configured. Up to now, if it was possible to reach the agent via HTTPS within 2 seconds, the cluster was configured as "HTTPS only". However, in some cases, 2 seconds was too short, resulting in HTTPS agents being configured as "HTTP or HTTPS". From now on, the start window application will wait up to 5 seconds.

- When you add a new cluster, it will now always be added to the group containing the currently selected cluster.
- The maximum size of the daily log file has been increased from 1 MB to 100 MB.

#### Resources app: Deleting a function resource that was used by a canceled booking [ID_34159] [ID_34186]

<!-- MR 10.3.0 - FR 10.2.10 -->

From now on, it will be possible to delete a function resource that was used by a canceled booking.

#### Trending: Enhanced performance when requesting real-time trend data [ID_34171]

<!-- MR 10.3.0 - FR 10.2.10 -->

On systems that store real-time trend data for more than a week, from now on, DataMiner Cube will no longer request all available real-time trend data at once. Instead, it will request data for the past week and only request more data when needed.

#### Visual Overview: Enhanced performance when drawing connection lines [ID_34409]

<!-- MR 10.3.0 - FR 10.2.11 -->

Because of a number of enhancements, overall performance has increased when drawing connection lines on a visual overview.

#### Alarm Console: Enhanced clearing of behavioral anomaly alarms [ID_34427]

<!-- MR 10.3.0 - FR 10.2.11 -->

Suggestion events and alarm events will now automatically be cleared sooner than 2 hours after their creation or last update when a new behavioral change is detected that ends the previous anomalous behavioral change.

For example, when an alarm was created for an anomalous level increase at 1 PM, and a behavioral change point is detected at 2 PM when the level drops again, then the alarm created at 1 PM will be closed at 2 PM.

#### Trending - Behavioral anomaly detection: Suggestion events will only be created for the most significant changes [ID_34513]

<!-- MR 10.3.0 - FR 10.2.11 -->

Prior to DataMiner 10.2.11/10.3.0, suggestion events are created for all anomalous behavioral changes that do not have alarm monitoring enabled. From DataMiner 10.2.11/10.3.0 onwards, they are only created for the most significant changes. There is also a maximum of 500 suggestion events related to behavioral anomaly detection at the same time.

#### Trending - Behavioral anomaly detection: Enhanced updating of anomaly alarms after alarm template changes [ID_34543]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, anomaly alarms will now be updated even more quickly after an alarm template change.

For example, if the monitoring of a certain type of anomaly (flatline, level shift, variance, trend) stops because of an alarm template change, every open alarm for that type of anomaly will now be cleared.

Changes that might result in anomaly alarms of a certain type being cleared:

- Assigning a new alarm template that does not monitor this type of anomaly.

- Removing an alarm template, causing this type of anomaly to no longer be monitored.

- Editing an alarm template in such a way that this type of anomaly is no longer monitored.

- Changing the template filter so that it is no longer applicable to the parameter in question.

> [!NOTE]
> When an alarm template that had already been assigned to an element earlier is changed in such a way that monitoring of a certain type of anomaly is started, or when it is replaced by another alarm template that causes the monitoring of a certain type of anomaly to start, then every open suggestion event for that type of anomaly associated with the element in question will be promoted to an alarm event.

#### Automation: No more 'Abort' buttons in dialog boxes of interactive Automation scripts [ID_34559]

<!-- MR 10.3.0 - FR 10.2.12 -->

In dialog boxes of an interactive Automation script, up to now, you were able to abort the script by clicking the *Abort* button. From now on, this button will no longer be available. Instead, you can now do the following to abort a script when a dialog box has the focus:

- close the dialog box by clicking the *X* in the top-right corner, or

- press ALT+F4.

> [!IMPORTANT]
> When an interactive Automation script was launched from a web app, then you will have to press ESC instead of ALT+F4 to close a dialog box and abort the script. Pressing ALT+F4 would close the browser, not just the dialog box.

#### System Center: Link to online help now points to cloud connection help on <https://docs.dataminer.services/> [ID_34683]

<!-- MR 10.3.0 - FR 10.2.12 -->

On the *Cloud* page of *System Center*, the *online help* hyperlink now points to the [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) page on <https://docs.dataminer.services/>.

#### Alarm Console: When grouped, incident alarms will now appear in the group of the highest severity found among the base alarms [ID_34754]

<!-- MR 10.3.0 - FR 10.2.12 -->

When you open an alarm tab that contains incident alarms, the icons in front of those incident alarms show the highest severity found among the base alarms and the severity column shows "suggestion".

Up to now, when you grouped/sorted the alarms in the alarm tab by severity, the incident alarms would all appear in the "suggestion" group. From now on, they will instead appear in the group of the highest severity found among the base alarms.

Also, in case of incident alarms, the alarm duration indicator will now show the highest severity found among the base alarms.

#### Tab layout: Click the tab header with the middle mouse button to quickly close a tab [ID_34791]

<!-- MR 10.3.0 - FR 10.3.3 -->

When using the tab layout, up to now, you could quickly close a tab by clicking inside it with the middle mouse button. From now on, to quickly close a tab, instead of clicking inside the tab, you will have to click the tab header with the middle mouse button.

#### Bookings module: Navigation panel has been improved and renamed to 'settings' panel [ID_34840]

<!-- MR 10.3.0 - FR 10.3.1 Also see Fixes for bug fix section-->

The *Navigation* panel has been improved and renamed to *Settings* panel.

#### Alarm Console: A notice will now appear when resources are being migrated from XML to Elasticsearch [ID_34845]

<!-- MR 10.3.0 - FR 10.3.1 -->

When resources are being migrated from XML to Elasticsearch, a `Busy migrating resources to the Elasticsearch database.` notice will now be displayed in the Alarm console. Also, information events will be generated when a migration was started, was canceled or finished. In the latter case, the information event will indicate whether the migration finished with or without errors.

When you start a resource migration in the *SLNetClientTest* tool (by selecting *Advanced > Migration > Resources XML to Elastic > Start Migration*), all ongoing bookings and bookings that are scheduled to start or stop in the next hour will be listed in a table (which can be sorted by clicking the table headers). As the Resource Manager is stopped while a migration is in progress, it is possible that bookings will not be started or stopped during a migration.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### DataMiner Cube will now immediately be aware of any changes as to the availability of Cassandra or Elasticsearch [ID_35209]

<!-- MR 10.3.0 - FR 10.3.3 -->

Up to now, Cube would only check at startup whether Cassandra or Elasticsearch were available. From now on, it will immediately be aware of any changes as to the availability of Cassandra or Elasticsearch.

#### EPM: Data retrieved from the collector that was displayed as a table with a single row will now be displayed as single parameters [ID_35371]

<!-- MR 10.3.0 - FR 10.3.3 -->

In an EPM card, in some cases, data retrieved from the collector was displayed as a table with a single row, which often had the system name as primary key.

From now on, data retrieved from the collector that used to be displayed as a table with a single row will now be displayed as single parameters (one for every column).

### Fixes

#### Visual Overview: Problem when navigating inside EPM cards [ID_32288]

<!-- MR 10.3.0 - FR 10.2.3 -->

When working inside an EPM card, in some cases, it would no longer be possible to navigate to a data page or a subpage.

#### Visual Overview: Card buttons in an EPM card would no longer work when the Topology sidebar was selected [ID_32372]

<!-- MR 10.3.0 - FR 10.2.3 -->

When an EPM card was opened from a visual overview, and the Topology tab was selected in the sidebar, a number of buttons inside that EPM card would no longer work.

#### Properties not shown in the Surveyor [ID_32429]

<!-- MR 10.3.0 - FR 10.2.3 -->

In some cases, properties with the “Display this property in the Surveyor” option enabled would incorrectly not be displayed in the Surveyor.

From now on, when you create a new property and enable its “Display this property in the Surveyor” option, it will immediately show up in the Surveyor, and when you enable that option for an existing property, the property will show up in the Surveyor the first time its value is updated or the next time the user logs in.

When users enable the option for an existing property, a tooltip will now inform them that the value will only appear after logging off and logging in again.

#### Alarm templates: Anomaly detection alarms would incorrectly disappear after a DataMiner restart [ID_33278]

<!-- MR 10.3.0 - FR 10.2.6 -->

From DataMiner 10.0.3 onwards, you can configure an alarm template so that alarms are generated instead of suggestion events when anomalies are detected for specific parameters.

Up to now, these anomaly detection alarms would incorrectly disappear from the Alarm Console after a DataMiner restart.

#### Desktop app: Problem when creating a new group in the start window [ID_33300]

<!-- MR 10.3.0 - FR 10.2.6 -->

In some rare cases, an error could occur when you created a new group in the start window of the DataMiner Cube desktop app.

Also, the name of a group could get lost when you deleted the first agent/cluster in that group.

#### Visual Overview: Session variables of Resource Manager component would incorrectly be set to NULL when cleared [ID_33527]

<!-- MR 10.3.0 - FR 10.2.7 -->

When the following session variables of an embedded Resource Manager component were cleared, up to now, they would incorrectly be set to NULL. From now on, they will be set to an empty value instead.

- ResourcesInSelectedReservation
- SelectedOccurrence
- SelectedPool
- SelectedReservation
- SelectedReservationDefinition
- SelectedResource
- SelectedSession
- TimerangeOfSelectedReservation

#### Resources app: Empty Occupancy tab [ID_33540]

<!-- MR 10.3.0 - FR 10.2.8 -->

The first time you clicked the *Occupancy* tab after opening the *Resources* app, in some rare cases, that tab would incorrectly be empty.

#### Profiles app: Selected list items not visible on the UI would incorrectly not be validated after being edited [ID_33753]

<!-- MR 10.3.0 - FR 10.2.9 -->

When, in the Profiles app, you edited a profile definition, a profile instance, a profile parameter or a service definition, the change would incorrectly not be validated if the item in question was not visible in the list.

#### Profiles app: No validation errors were displayed when no discrete values had been added yet for a profile parameter of type discrete [ID_33756]

<!-- MR 10.3.0 - FR 10.2.9 -->

When an error occurred while configuring a profile parameter of type “discrete”, up to now, that error would not be displayed on the UI when no discrete values had been added yet.

#### Resources app: Warning messages were incorrectly shown in the footer when resource manager configuration requests returned error trace data [ID_33780]

<!-- MR 10.3.0 - FR 10.2.9 -->

When you open the *Resources* app, a warning will be shown in the footer when error trace data was found when fetching resource manager data from the server. Up to now, such a warning would incorrectly also be shown when resource manager configuration requests returned error trace data.

#### Resources app: Updating a session variable in a Resource Manager component would incorrectly cause that same session variable to be updated in the Occupancy tab of the Resources app [ID_33800]

<!-- MR 10.3.0 - FR 10.2.9 -->

When a session variable (e.g. YAxisResources) was updated in an embedded Resource Manager component, in some cases, that same session variable would also incorrectly be updated in the *Occupancy* tab of the Resources app.

#### Problem with validation of properties and actions in service definitions [ID_34023]

<!-- MR 10.3.0 - FR 10.2.9 -->

When properties or actions of a service definition were configured, it could occur that validation did not happen correctly so that an incorrect configuration could be saved, resulting in exceptions in the server logging and problems in Cube.

The validation will now ensure that no empty names or property names that are incompatible with Elasticsearch can be saved. If there is an error in a service definition, the *Modified* label will change color. Hovering the mouse pointer over the entry with the label will show the first error in the service definition.

#### Clicking the 'Close' button of one of multiple open error message boxes would incorrectly always close the last box that had been opened [ID_34173]

<!-- MR 10.3.0 - FR 10.2.10 -->

When multiple error messages boxes were being displayed, clicking the *Close* button on any of those boxes would incorrectly always close the last box that had been opened. All other boxes would stay open and could only be closed by clicking the X in the top-right corner.

#### Alarm Console: Problem when clearing alarm groups [ID_34196]

<!-- MR 10.3.0 - FR 10.2.10 -->

Alarm groups would not get cleared automatically when the *AutoClear* option was set to false.

Also, in some cases, after clearing an alarm group, a clearable version of that alarm group would incorrectly remain visible in the Alarm Console, even when the *AutoClear* option was set to true.

#### Service & Resource Management: Problem when Cube tried to retrieve SRM-related data to which the user did not have access [ID_34397]

<!-- MR 10.3.0 - FR 10.3.2 -->

Up to now, an exception could be thrown when DataMiner Cube tried to retrieve SRM-related data to which the user did not have access.

From now on, when DataMiner Cube tries to retrieve SRM-related data to which the user does not have access, a message box will appear, asking the user to contact the system administrator. Also, each time this type of message box is displayed, an entry of type "warning" will be added to the Cube logging (`User X could not read object Y because the user does not have permission flag Z`).

Overview of the read permissions needed to retrieve SRM-related data:

| SRM-related data | Read permission                    |
|------------------|------------------------------------|
| Bookings         | Bookings > UI available            |
| Functions        | Functions> UI available            |
| Profiles         | Profiles > UI available            |
| Resources        | Resources> UI available            |
| Service profiles | Services > Profiles > UI available |
| Services         | Services > UI available            |

> [!NOTE]
> Often, users will need a combination of the above-mentioned read permission for Cube to be able to retrieve the necessary SRM-related data.

#### Visual Overview: Problem when loading a DCF signal path [ID_34630]

<!-- MR 10.3.0 - FR 10.2.12 -->

When a visual overview was configured to display a DCF signal path, in some cases, that signal path would not load.

Also, in some cases, elements with an index in a service would incorrectly not show connection lines.

#### Trending - Pattern matching: Not all detected pattern occurrences would be indicated when you opened a trend graph [ID_34671]

<!-- MR 10.3.0 - FR 10.2.12 -->

When you opened a trend graph that contained patterns matching existing tags, in some cases, not all detected occurrences of those patterns would initially be indicated. Only after zooming out would all detected patterns be properly indicated.

#### Bookings module: Columns of type 'Date' would not get updated when you changed the time zone [ID_34840]

<!-- MR 10.3.0 - FR 10.3.1 Also see Enhancements-->

When, in the *Navigation* panel of the *Bookings* app, you selected another time zone, columns of type `Date` would incorrectly not get updated.

#### Trending - Pattern matching: Trend graph would no longer show the matches for the displayed parameter after editing a tag [ID_34870]

<!-- MR 10.3.0 - FR 10.3.1 -->

When you edited the properties of a tag (e.g. name, description, etc.), the trend graph would no longer show the pattern matches for the parameter that is currently displayed in the graph. Instead, it would incorrectly show the pattern matches for the parameter for which the tag was defined.

#### Trending: Problem when exporting a trend graph containing average trend data [ID_35290]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you exported a trend graph containing average trend data to CSV, in some cases, the exported data would be parsed incorrectly.

#### DataMiner Cube - Visual Overview: Problem when filtering bookings in a ListView component [ID_35430]

<!-- MR 10.3.0 - FR 10.3.3 -->

When, in Visual Overview, a filter was applied to a *ListView* component that listed bookings, no account would be taken of bookings added after the filter had been applied. As a result, in some cases, the *ListView* component would list bookings that did not match the filter.

#### Visual Overview: Certain context menu commands would incorrectly be disabled [ID_35484]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you right-clicked a shape, certain context menu commands would incorrectly be disabled.

#### Newly created users would be assigned an invalid full name, description and password when Cube was configured to connect using gRPC [ID_35493]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you had configured DataMiner Cube to connect using gRPC (by specifying `type=GRPCConnection` in the *ConnectionSettings.txt* file), newly created users would be assigned an invalid full name, description and password.

#### EPM cards: Collector pages would not be loaded [ID_35523]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you opened an EPM card, in some cases, the collector pages would not be loaded, especially on systems without backend.

From now on, the collector pages will be loaded even when the EPM environment does not include a backend. This will particularly be useful for testing purposes.

#### Trending: Light bulb icon in trend component no longer overlapping [ID_35536]

<!-- MR 10.3.0 - FR 10.3.3 -->

In some cases, the light bulb icon in the top-right corner of a trend graph would incorrectly overlap the full screen or zoom range buttons.

#### Trending - Parameter relationships: Display keys of suggested parameters would not be correct [ID_35548]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you open a trend graph, a light bulb icon will appear in the top-right corner when DataMiner finds parameters that are related to the parameters shown in the graph. When you click that icon, you get a list of the ten most important parameters, which you can then add to the graph. However, in some cases, the display keys of those listed parameters would not be correct.

#### Trending - Parameter relationships: The same parameter could be added multiple times to the graph when you clicked it repeatedly [ID_35561]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you open a trend graph, a light bulb icon will appear in the top-right corner when DataMiner finds parameters that are related to the parameters shown in the graph. When you click that icon, you get a list of the ten most important parameters, which you can then add to the graph. However, in some cases, when you clicked one of those suggested parameter multiple times, it would incorrectly be added multiple times to the graph.
