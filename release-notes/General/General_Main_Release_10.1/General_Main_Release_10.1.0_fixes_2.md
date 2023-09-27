---
uid: General_Main_Release_10.1.0_fixes_2
---

# General Main Release 10.1.0 - Fixes (part 2)

#### Dashboards app - Pivot table component: Problem with 'Auto-expand rows' option \[ID_26803\]

In some cases, the pivot table component’s “Auto-expand rows” option would not work properly when exiting edit mode.

#### Jobs app: No longer possible to save jobs after removing all additionally added fields from the default job section \[ID_26805\]

When you added a number of additional fields to the default job section and then removed them again, in some cases, it would no longer be possible to save jobs.

#### Email report based on dashboard from new app was blank \[ID_26811\]

In some cases, it could occur that if an Automation script sent an email report based on a dashboard from the new Dashboards app, the PDF attached to this email was blank.

#### Dashboards app: Configuration of Group component not saved \[ID_26828\]

In the Dashboards app, it could occur that the configuration of a Group component was not saved.

#### Exception value of numeric parameter displayed incorrectly \[ID_26837\]\[ID_26889\]

If a numeric parameter was set to an exception value, it could occur that it displayed a numeric value instead of its exception value string.

#### Monitoring app: Visual Overview pages not retrieved if HTTPS was enabled \[ID_26839\]

When HTTPS was enabled on a DMA, it could occur that Visual Overview pages could not be retrieved in the Monitoring app.

#### Issues when exporting trend graph for multiple parameters to CSV with custom data set \[ID_26851\]

If a trend graph containing multiple parameters was exported to CSV with a custom data set, it could occur that the export window closed to soon, causing a problem in Cube or making it impossible to save the file. In addition, it could occur that multiple rows were created for the same timestamp.

#### Various issues in the Jobs app \[ID_26866\]

The following issues have been resolved in the Jobs app:

- The confirmation message when a job was deleted was not in line with other deletion confirmation messages.

- When a collapsed or expanded job section was deleted, it was respectively expanded or collapsed while the deletion confirmation message was displayed.

- When the pop-up window to edit a field was closed without saving the changes and then reopened, it still displayed the changes.

#### Jobs app: No error message when deleting all templates in the Load from template window & job fields could incorrectly be marked both 'Required' and 'Read only' \[ID_26868\]

When, in the *Load from template* window, you deleted all templates, up to now, no error message would be displayed, saying that there are no templates to be applied.

Also, when you configured a job field, up to now, it was possible to mark a field both *Required* and *Read only*. From now on, this will no longer be possible.

#### Service & Resource Management: Virtual function elements would remain in an 'Undefined' state \[ID_26898\]

In some cases, the element state of a virtual function element would remain “Undefined”. As a result, bookings using the resource in question could not be started.

#### Service & Resource Management: Incorrect exception was logged when opening Profiles or Resources app \[ID_26901\]

When you opened the Profiles or Resources app, in some cases, an incorrect exception would be thrown when fetching discreet values for profile parameters.

#### Dashboards app: Problems with CPE feed \[ID_26905\]

In some cases, the diagram would not show the selected value when the first field was a text field.

Also, when you opened a drop-down field, in some cases, the fields would close again, making it impossible to select a value.

#### DataMiner state saved in connection and in event cache not in sync \[ID_26928\]

In some cases, it could occur that the DataMiner state saved on the connection and in the event cache were not in sync, which could cause various issues. For example, it could be impossible to delete a ticketing resolver.

#### DataMiner Cube desktop app installation drop-down box not displayed correctly on landing page on small screen \[ID_26934\]

On the DataMiner landing page, the drop-down box that allows you to install the desktop DataMiner Cube app was not displayed correctly if the screen was too small. Since the DataMiner Cube desktop app can only be installed on PCs with a relatively large screen, on small screens this drop-down box will no longer be displayed.

#### DataMiner Cube: Text displayed incorrectly in mixed DPI environment \[ID_26937\]

If DataMiner Cube was displayed on different monitors with different DPI settings, it could occur that text was not displayed correctly in some places.

#### Incorrect information about Cube in Programs and Features window \[ID_26944\]

In the Windows *Programs and Features* window, it could occur that the version number and size of the originally installed DataMiner Cube desktop app were displayed, instead of the actual version number and size.

#### Service & Resource Management: Virtual function definition linked to protocol version used as production version could not be bound to element using production version \[ID_26966\]

If an element used the production version of a protocol, a virtual function definition with a protocol link to the version of the protocol that was used as the production version could not be bound to the element.

Note that protocol links do not support specifying "production" as the protocol version. Note also that when the protocol of an element is changed, the virtual function resource bound to that element is currently not yet changed.

#### Dashboards app: Title not updated after switch between dashboards \[ID_26969\]

When you switched between dashboards in the new Dashboards app, it could occur that the title was not updated correctly.

#### Dashboards app: No error message shown when opening a non-existing dashboard \[ID_26997\]

When you tried to open a non-existing dashboard (e.g. by using an incorrect URL), no error message would appear. Instead, an empty dashboard would be opened.

#### DataMiner Cube: Issues occurring during DELT import operations \[ID_27004\]

A number of issues that would sometimes occur during DELT import operations have now been fixed.

#### Indexing Engine: Incorrect 'Sequence contains no elements' error \[ID_27010\]

On systems running Indexing Engine, in some cases, an incorrect “Sequence contains no elements” error would regularly be added to the logs.

#### Bookings app: Hidden 'Booking state' column could no longer be set visible again \[ID_27058\]

When, in the *Bookings* app, the *Booking state* column was set hidden, in some cases, it would no longer be possible to set it visible again.

#### Dashboards app: Incorrect default indices selection in parameter feed linked to CPE feed \[ID_27116\]

If a dashboard contained a CPE feed linked to a parameter feed containing a number of indices that had to be selected by default, it could occur that changing the CPE feed selection caused this default selection to be incorrect.

#### Dashboards app: State component linked to a services feed would not immediately get updated when a service was selected \[ID_27137\]

When a feed containing services was linked to a state component, in some cases, the state component would not immediately be updated when you selected a service.

#### Dashboards app: Problem with trend statistics component \[ID_27147\]

When you dragged a table column parameter onto a trend statistics component and then also dragged table indices onto it to act as a filter, in some cases, an error message would appear, saying that no trend data was available.

#### Dashboards app: 'Delete component' button would not immediately get updated when you selected multiple components \[ID_27148\]

When you selected multiple components, the *Delete component* button at the top of the screen would incorrectly only get updated to *Delete X components* when you hovered over it.

#### Web Services API: Too many bookings retrieved when multiple subscription sets were used \[ID_27176\]

If there were subscriptions to multiple bookings in multiple subscription sets, it could occur that the API retrieved too many bookings.

#### Dashboards app: Pivot table component retrieved only first page of partial table \[ID_27178\]

In some cases, it could occur that a pivot table component only retrieved data from the first page of a partial table.

#### DataMiner Cube - Profiles app: Problem when duplicating a profile parameter \[ID_27194\]

When, in the *Profiles* app, you duplicated a profile parameter of type “discrete” and discreteType “number”, in some cases, the discreteType and the raw discrete values would not be copied correctly.

#### Dashboards app: Double scroll bars in dashboard with State component \[ID_27272\]

If a dashboard contained a State component, in some cases double scroll bars could be displayed.

#### DataMiner Cube - Trending: Problem when calculating trend predictions \[ID_27292\]

When calculating trend predictions on a more general level (e.g. daily), in some cases, the algorithm would not take into account missing values. Hence, it would incorrectly assume that a repeating pattern found on the more general level was also found on the more detailed level.

#### Dashboards app: Dashboard grid not resized \[ID_27293\]

In some cases, it could occur that the dashboard grid was not resized when necessary.

#### Dashboards app: Duplicate 'Delete component' button \[ID_27295\]

When a dashboard contained a Group component, it could occur that two *Delete component* buttons were displayed when the dashboard was in edit mode.

#### Interactive Automation scripts: Problems with the UIBlockDefinition.IsEnabled and UIBlockDefinition.InitialValue properties \[ID_27326\]

Up to now, UIBlockDefinition.IsEnabled was not applied for blocks of type “checkbox”. From now on, a block of type “checkbox” will be disabled when the UIBlockDefinition.IsEnabled property is set to False.

Also, UIBlockDefinition.InitialValue was not applied correctly for blocks of type “calendar” when the value was not a valid ISO string. From now on, the UIBlockDefinition.InitialValue property will be ignored and the datetime picker block will be constructed based on the DMAAutomationUICalendarComponent.Timestamp property, which will contain the UTC time stamp the InitialValue represents.

#### Dashboards app: Problems with the color picker \[ID_27329\]\[ID_27365\]

A number of issues have been fixed with regard to the color picker.

#### Dashboards app: Navigation pane issue after refresh in edit mode \[ID_27339\]

If you exited edit mode in the Dashboards app after refreshing while edit mode was active, all folders in the navigation pane were collapsed and the current dashboard was no longer indicated as selected.

#### Dashboards app: Minor issues with time range feed \[ID_27357\]

The following minor issues could occur with a time range feed component in a dashboard:

- In some cases, the clock icon was not displayed next to the time summary.

- It could occur that the configuration pane of the time range feed was not correctly aligned with the time summary.

#### DataMiner Cube - Profiles app: 'Modified' label would not disappear after saving \[ID_27373\]

When, in the *Profiles* app, you saved a profile definition, a profile instance or a profile parameter, in some cases, the “Modified” tag would incorrectly not disappear.

#### Dashboards: Problem when changing the theme \[ID_27398\]

When, in the Dashboards app, you changed the theme, the colors of certain components (e.g. analog clock, digital clock,...) would not be changed accordingly.

#### Problem when a QAction launched an Automation script immediately after the element had been started \[ID_27431\]

When a QAction launched an Automation script immediately after the element had been started, in some cases, an exception could be thrown.

#### DataMiner Cube: Not possible to filter tables on display value \[ID_27490\]

In the quick filter boxes for tables in DataMiner Cube, previously it was only possible to filter on the raw value of the cells, i.e. the value used by the protocol, which is not necessarily the same as the displayed value. Now filtering on the displayed value is also possible.

#### Problem when renaming DVE elements \[ID_27494\]

When you renamed a DVE element, in some cases, the element name would incorrectly not get updated.

#### Jobs app: When applying a template, job section fields of type 'User' would incorrectly not be overwritten \[ID_27495\]

When, in the Jobs app, you applied a template to a job, values in job section fields of type “User” would incorrectly not get overwritten with the values from the template.

#### Dashboards app - Image component: Image selection box would incorrectly also contain non-image files \[ID_27510\]

When, in the Dashboards app, you added an image component and opened the image selection box on its *Settings* tab, in some cases, the selection box would list all files found in the C:\\Skyline DataMiner\\Dashboard\\\_IMAGES\\ folder, including files that were not images. From now on, the image selection box will only list image files.

#### Dashboards app: Table in visual overview component not filtered correctly \[ID_27517\]

When a visual overview component was used in a Dashboards app, it could occur that a table in the visual overview was not filtered properly.

#### Dashboards app: Problem with line chart component displaying resource capacity information \[ID_27526\]

When a line chart component in a dashboard was configured to display resource capacity information, and no data was displayed for the current timespan, a problem could occur if you selected the *Use percentage based units* option in the *Settings* pane.

#### DataMiner Cube - Visual Overview: No log entry would get created when a Visio shape contained a reference to an element on a disconnected DMA \[ID_27527\]

No log entry would get created when a Visio shape displaying a chart contained a reference to an element located on a disconnected DataMiner Agent.

#### DataMiner Cube - Visual Overview: Memory leak caused by alarm shapes not getting cleaned up properly \[ID_27550\]

In some cases, alarm shapes created as part of a Children shape would not get cleaned up properly.

#### DataMiner Cube start window: Entering text in the Arguments text box could resize the UI \[ID_27559\]

When, in the DataMiner Cube start window, you edited an agent entry, in some cases, the UI could get resized incorrectly when entering text in the *Arguments* text box.

#### DataMiner Cube - Services app: Problem when trying to assign a service profile instance to a profile instance with a parameter of type 'capability' \[ID_27580\]

When you tried to assign a service profile instance to a profile instance with a parameter of type “capability” (exclusively), in some cases, an exception could be thrown.

#### Dashboards app: Line chart component would not draw the trend graph of a resource capacity \[ID_27606\]

In some cases, a line chart component would not draw the trend graph of a resource capacity.

#### Service & Resource Management: Parameters of type double in generated SRM protocols will now have their lengthtype set to 'next param' instead of 8. \[ID_27617\]

Up to now, parameters of type double in generated SRM protocols would have their rawtype set to “numeric text” and their lengthtype set to 8. As a result, if a parameter of a generated SRM protocol contained a value of more than 8 characters, that value would incorrectly be replicated to 0.

From now on, parameters of type double in generated SRM protocols will have their lengthtype set to “next param” instead.

#### Dashboards app: Problem with Auto-select all indices option for Parameter feed component \[ID_27623\]

In the Dashboards app, if the *Auto-select number of indices* option was selected for a Parameter feed component, it could occur that the *Auto-select all indices* option did not work.

#### Jobs app: Problem when no domains were configured \[ID_27635\]

When no domains had been configured, in some cases, the jobs list would incorrectly keep loading. Also, when you refreshed an empty jobs list, a “page not found” error would be displayed.

> [!NOTE]
> Up to now, when no domains were configured, a popup message would be displayed, asking you to create one. From now on, visual indication and a button will be displayed instead.

#### FileInfoManager: Problem when handling production protocols \[ID_27645\]

In some cases, FileInfoManager would handle production protocols incorrectly.

Also, Automation script IDs will now be case insensitive.

#### SLAnalytics: Problem when updating behavioral anomaly detection suggestion events \[ID_27646\]

In some cases, updates to behavioral anomaly detection suggestion events would contain an incorrect root alarm ID. As a result, a second suggestion event would be created and linked to the same change point. Also, after two hours, only the original alarm would be cleared.

#### Jobs app: Loading problem when selecting the already selected job domain in configuration mode \[ID_27651\]

When, in configuration mode, you selected the job domain that was already selected, in some cases, the loading indicator would remain visible indefinitely.

#### Interactive Automation scripts: Problem when a text box had its wantOnChange setting set to true and its value set to an empty string \[ID_27666\]

When a text box in an interactive Automation script had its wantOnChange setting set to true and its value set to an empty string, in some cases, an exception could be thrown.

#### Mobile apps: Problem with time range quick pick buttons \[ID_27676\]

In the Dashboards app and other DataMiner mobile apps, it could occur that the quick pick buttons of a time range selector did not function correctly.

#### Dashboards app: Problem when pivot table component displayed table parameters with same table index values \[ID_27687\]

In case a pivot table component of a dashboard displayed different table parameters of which the table index values were the same, it could occur that the table index was displayed instead of parameter names.

#### DataMiner Cube - Trending: Problem when exporting a trend graph to a CSV file \[ID_27708\]

When you select the *Line graph instead of block graph* option when exporting a trend graph to a CSV file, the timestamps of the average data points are put halfway between two points.

In some cases, when you exported a trend graph multiple times in a row using that line graph option, the timestamps would incorrectly keep shifting in the direction of the future.

#### DataMiner Cube - Trending: Numbers smaller than 1 could be missing their decimal separator \[ID_27717\]

In some cases, trend data numbers smaller than 1 could be missing their decimal separator.

#### Automatic incident tracking: Problem when removing the IDP location from elements with active alarms \[ID_27723\]

On a system using automatic incident tracking on which DataMiner Infrastructure Discovery Provisioning (IDP) was deployed, in some cases, when the IDP location of an element with active alarms was removed, that location would not be removed correctly. This would cause certain alarms to be grouped by an empty location.

> [!NOTE]
> From now on, IDP location grouping requires that the *Make this property available for alarm filtering* option is activated for the following element properties: IDP, Location Name, Location Building, Location Floor, Location Room, Location Aisle and Location Rack.

#### Dashboards app: Pivot table component showed an error message \[ID_27724\]

In the Dashboards app, the pivot table component would show the following error message:

```txt
Error trapped: 'Skyline.DataMiner.Web.Common.IPersistentConnectionContainerEx' does not contain a definition for 'GetElementProtocol'
```

#### Service & Resource Management: Problem when rebinding a VirtualFunctionResource \[ID_27735\]

When a VirtualFunctionResource was unbound, in some cases, it would still be processing parameter sets from its bound element. This would cause the parameters of the unbound element to no longer be in an “uninitialized” state. Instead, they would incorrectly stay set to the last received value from the bound element.

#### Interactive Automation scripts: MinWidth, MaxWidth, MinHeight and MaxHeight properties of UIBlock components would not be parsed correctly \[ID_27736\]

In some cases, the MinWidth, MaxWidth, MinHeight and MaxHeight properties of UIBlock components would not be parsed correctly.

#### Dashboards app: Problem when grouping parameter data \[ID_27755\]

When grouping parameter data in components that support parameter data grouping, in some cases, an error could be thrown when you selected either “by element” or “all together” while some of the grouped parameters were single-value parameters without an index.

#### DataMiner Cube: Problem when opening a ListView component containing bookings \[ID_27780\]

In some cases, a KeyNotFound exception could be thrown when you opened a ListView component that contained a list of bookings.

#### Problem with SLDataMiner at startup when no NICs could be found \[ID_27799\]

In some cases, an error could occur in SLDataMiner at startup when no NICs could be found.

#### Jobs app: Empty drop-down boxes when creating/editing job \[ID_27810\]

When a job was created or edited in the Jobs app, it could occur that no items were displayed in drop-down boxes.

#### SLAnalytics: Problem when opening a trend graph on a system using pattern matching \[ID_27829\]

On a system using pattern matching, in some cases, an error could occur in SLAnalytics when you opened a trend graph.

#### Dashboards app - Line chart component: Problems when retrieving trend data \[ID_27853\]

In some cases, a trend graph legend would show an error when a trend data request was interrupted, e.g. by scrolling to another page before the current page was fully loaded.

Also, when multiple trend requests were required, in some cases, those requests would be ignored when a trend data request was already in progress.

#### Service & Resource Management: When an unbound Virtual Function Resource was deleted, the replication connection was incorrectly not removed \[ID_27857\]

When an unbound Virtual Function Resource was deleted, in some cases, the replication connection would incorrectly not be removed.

#### DataMiner Cube - Profiles app: Service profiles could not be deleted when linked to a profile instance \[ID_27860\]

In some cases, it would not be possible to delete a service profile, especially when a profile instance had a link to it. In the profile instance editor, the service profile selection box now contains a “\<None>” entry. This will allow the link to the service profile instance to be severed.

Also, in some cases, the Profiles app would not load service profile objects.

#### Dashboards app - Line chart component: Trend graph incorrectly showed primary key instead of display key \[ID_27879\]

When a table parameter had a display key that was different from the primary key, up to now, the trend graph would incorrectly show the primary key. From now on, it will show the display key instead.

#### Dashboards app - Pivot table component: Problem with conditions \[ID_27897\]

When a pivot table component had conditions configured, in some cases, those conditions would incorrectly only work in conjunction with table column parameters, not with single-value parameters.

Also, a selection box problem could occur when multiple conditions were configured in the “Configure indices” section.

#### Automation: Problem when retrieving information events from all DMAs \[ID_27903\]

When, in a DataMiner System with multiple agents, information events were retrieved by an Automation script, in some cases, not all information events would be retrieved.

#### DataMiner Cube - Correlation: Number of occurrences in 'Sliding window' section could incorrectly not be changed \[ID_27909\]

When you tried to define that a correlation rule had to be triggered when a situation occurred a specific number of times in a specified period of time, in some cases, it would not be possible to change the default number of times (i.e. 1).

#### DataMiner Cube would constantly try to reconnect due to a problem that occurred while serializing alarm metadata in proactive suggestion events \[ID_27927\]

Due to a problem that occurred while serializing alarm metadata in proactive suggestion events, in some cases, DataMiner would constantly try to reconnect.

#### Dashboards app - Time range component: Default range would be used even after being overwritten afterwards \[ID_27941\]

If the default values of a time range component had been set to a custom range, in some cases, those values would incorrectly still be used after being overwritten afterwards (e.g. by means of URL arguments or another feed).

#### Jobs app: Job section fields would not be displayed in the correct order \[ID_27943\]

When editing a job, in some cases, the fields of a particular job section would not be displayed in the order in which they were defined in the job domain.

#### Dashboards app: Table component would not be rendered correctly in a PDF report \[ID_27958\]

In some cases, a table component would not be rendered correctly in a PDF report.

#### DataMiner Cube - Trending: Rounding issue when exporting a trend graph to CSV \[ID_27980\]

When you exported a trend graph to CSV with the *Line graph instead of block graph* option selected, in some cases, the timestamps would be off by a second due to a rounding error.

#### DataMiner Cube - Visual Overview: Save button no longer working in embedded Service Manager component \[ID_28003\]

In an embedded Service Manager component, in some cases, the Save button would no longer work.

#### DataMiner Cube - Alarm Console: Problem with 'unread alarms' counter \[ID_28063\]

In some cases, the number of unread alarms displayed in the header of an alarm tab would be incorrect, especially on history tabs, on filtered tabs or when e.g. masking an alarm immediately after it was set to read.

#### DataMiner Cube - Profiles app: 'Based on' selection box would be empty \[ID_28089\]

When, in the *Definitions* tab of the Profiles app, you selected a profile definition and then clicked *Add* to select another profile definition in the *Based on* selection box, in some cases, that selection box would be empty.

#### Dashboards app: Share window would incorrectly be resized when you entered a message \[ID_28093\]

When you opened a dashboard, clicked *Start sharing*, and entered a message, in some cases, the *Share* window would incorrectly be resized.

#### DataMiner Cube - Profiles app: Regular expression of a profile instance parameter would incorrectly not be checked \[ID_28094\]

In the Profiles app, it is possible to define a parameter of type text and add a regular expression that values have to match.

When such a parameter was added to a profile instance, in some cases, when its value was changed, the regular expression would incorrectly not be checked and all values would be allowed.

#### DataMiner Cube - Visual Overview: ListView filter would not reapply conditions when new items were added \[ID_28095\]

When a ListView component listing elements or services had an external filter applied, the filter would incorrectly not be reapplied when new items were added to the list.

#### Dashboards app: Problems with table component \[ID_28146\]

A number of problems have been fixed with regard to the table component.

In some cases, for example, rendering issues could occur when resizing table columns.

#### Dashboards: Problems with CPE feed \[ID_28157\]

When you selected a CPE filter, in some cases, the raw key would incorrectly be displayed for a short while.

Also, when you selected a chain filter (e.g. Region) and a value (e.g. California), and then selected another chain filter and value, in some cases, nothing would be displayed and an error would occur.

#### Ticketing app: Problem when creating a ticket \[ID_28167\]

In some cases, a null reference exception could be thrown when creating a ticket.

#### DataMiner Cube: EPM manager would incorrectly show the base table on a KPI popup \[ID_28194\]

When a field was defined on a base table while the topology cell was defined on a view table based on that base table, in some cases, a KPI popup on the field in question would incorrectly display the base table instead of the view table.

#### DataMiner Cube - Alarm Console: Problem when opening an active alarms tab containing correlation alarm details \[ID_28232\]

In some cases, an error could occur when you opened an active alarms tab that contained correlation alarm details.

#### Dashboards app: Components could not be moved in a Chromium web browser due to a spacing problem \[ID_28260\]

When using the Dashboards app in a Chromium web browser, in some cases, a lack of spacing around the components would prevent you from moving them.

#### DataMiner Cube: EPM card would not open when no topology cell was linked to the filter \[ID_28272\]

When an EPM field was defined on a table without a chain topology cell, in some cases, it would not be possible to launch an EPM card of an item in this field from the *Topology* tab in the sidebar.

#### SLAnalytics: Problem when trying to process a parameter update for a non-existing parameter \[ID_28282\]

In some case, an error could occur in SLAnalytics when trying to process a parameter update for a non-existing parameter.

#### Ticketing app: Headers would incorrectly not be cleared when switching domains \[ID_28291\]

In the Ticketing app, in some cases, headers would not be cleared when you switched domains.

#### Web Services API v0: Serialization error when using the GetActiveAlarmsFromView and GetActiveAlarmsFromElement methods \[ID_28293\]

Due to a serialization error, in some cases, the following Web Services API v0 methods would no longer work:

- GetActiveAlarmsFromView

- GetActiveAlarmsFromElement

#### Interactive Automation scripts: Equals signs not accepted in UI block values \[ID_28324\]

In some cases, equals signs (“=”) could not be used in UI block values.

#### Failover: Configuration issues \[ID_28378\]

In a Failover setup, in some cases, an error could occur when no ElasticSearch database was found.

Also, in some cases, configuration updates would be ignored after a Failover switch.

#### Assembly incorrectly configured in SLNet.exe.config file \[ID_28408\]

In the SLNet.exe.config file, an assembly was configured incorrectly.

#### Dashboards app - GQI: Problem with the query builder \[ID_28415\]

In the Dashboards app, in some cases, errors could occur when building a query.

#### Dashboards app: Problem with charts in PDF reports \[ID_28449\]

In PDF reports, the alarm top component would not show the grid lines and the generic bar charts would not position properly due to a CSS issue.

#### DataMiner Cube - Visual Overview: Booking shape timers would not get updated every second when the shape was being displayed \[ID_28453\]

In a booking shape, timers can show remaining time, elapsed time, etc. However, in some cases, those timers would not get updated every second when the shape was being displayed.

#### Deserialization exceptions during file offload \[ID_28481\]

During a file offload, in some cases, a large number of deserialization exceptions could be written to the SLDBConnection.txt log file.

#### DataMiner Cube: Problem when opening the Protocols & Templates app \[ID_28529\]

In some cases, an error could occur when you opened the Protocols & Templates app.

#### DataMiner Cube - Alarm Grouping: Problem when changing the polling IP address of an element associated with an alarm \[ID_28563\]

When the polling IP address of an element with a timeout alarm was changed, in some rare cases, the timeout alarm would incorrectly be linked to the old IP address instead of the new one. This would then lead to an incorrect grouping of alarms.

#### DataMiner Cube - Trending: Problem with percentile line \[ID_28565\]

When you added an additional trend line to an existing trend graph with one parameter, and then removing the original parameter, in some cases, the percentile line would no longer be visible.

#### Dashboards app - GQI: Problem when creating new queries due to file locking issue \[ID_28636\]

Due to a file locking issue, in some cases, it would not be possible to create new queries.

#### HTML5 apps: Problem when the SAML response from the identity provider contained line breaks \[ID_28671\]

When an HTML5 app (Dashboards, Monitoring, Job, Ticketing, etc.) received a SAML response from the identity provider, in some cases, an error could occur when that response contained line breaks.

#### Problem in SLDataMiner if Protocol.xml.lnk file linked to unavailable path \[ID_28715\]

A problem could occur in the SLDataMiner process if a protocol production version Protocol.xml.lnk file linked to a path that could not be reached.

#### DataMiner Cube - Services app: Capacity/capability value override would not be saved correct-ly \[ID_28721\]

When, in a service profile instance, you overrode the capacity of a parameter, the update would not be saved correctly when you had set the value to 0.

#### DataMiner Cube - Services app: Discard button would not be enabled after including or excluding a service profile definition parameter \[ID_28741\]

When, in the *Services* app, you included or excluded a service profile definition parameter in the *By node* tab, in some cases, the Discard button would incorrectly not be enabled.

#### DataMiner Cube - Alarm Console: Alarms in alarm tab of type 'Active alarms linked to cards' would be filtered incorrectly when opening an EPM card \[ID_28780\]

When, in your Alarm Console, you had an alarm tab of type “Active alarms linked to cards”, in some cases, when you opened an EPM card, the alarms in that alarm tab would not be filtered correctly. Also, the name of the alarm tab would not be displayed correctly.

#### Re-installation of NAS/NATS services would fail \[ID_28781\]

When the NAS and NATS services had been deleted manually, in some cases, re-installing those services would fail.

#### HTML5 apps: Problem with internal API calls when fetching data \[ID_28830\]

When working with HTML5 apps like Ticketing or Jobs, in some cases, the internal API calls ObserveTickets, ObserveJobs and ObserveBookings could throw an exception when fetching data.

#### Problem with SLDataMiner when loading protocols \[ID_28833\]

In some cases, an error could occur in the SLDataMiner process when loading protocols.

#### Locking issues in SLNet, SLASPConnection and SLDMS \[ID_29050\]

In some cases, locking issues could occur in the SLNet, SLASPConnection and SLDMS processes.
