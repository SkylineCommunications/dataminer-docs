---
uid: General_Main_Release_10.2.0_CU22
---

# General Main Release 10.2.0 CU22 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_37641]

<!-- 37641: MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

A number of security enhancements have been made.

#### DataMiner Cube - Visual Overview: Enhanced service chain behavior [ID_37645]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

A number of UI enhancements have been made with regard to service chain behavior in visual overviews.

Up to now, in some cases, service chains could get redrawn too often, or shapes would not get redrawn when a service chain was updated. Also, context menus of shapes would not always close when those shapes were updated and context menus would incorrectly show the *Display connectivity* command twice.

#### DataMiner Cube - Spectrum analysis: Zooming inside a spectrum window [ID_37668]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

It is now possible to zoom inside a spectrum window:

- To zoom horizontally, scroll up and down. This has the same effect as altering the frequency span.
- To zoom vertically, scroll up and down while pressing the CTRL key. This has the same effect as altering the amplitude scale.

When you stop scrolling, the new zoom dimensions will be set on the spectrum analyzer device and the screen will be updated with the new data.

> [!IMPORTANT]
>
> - It is only possible to zoom horizontally if the spectrum protocol includes the *Start frequency*, *Stop frequency* and *Frequency span* parameters.
> - It is only possible to zoom vertically if the spectrum protocol includes the *Amplitude scale* parameter.

#### DataMiner Cube - Spectrum Analysis: Buttons in 'Reference lines' panel, 'Thresholds' panel and 'Measurement Points' panel have been restyled [ID_37752]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In the *View* tab of a spectrum card, the buttons in the *Reference lines* panel and the *Thresholds* panel as well as the delete buttons in the *Measurement Points* panel have been restyled to match the buttons in the *Markers* panel.

#### Enhanced performance when locking or unlocking inputs and output of matrices in client applications [ID_37755]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

Because of a number of enhancements, overall performance has increased when locking or unlocking inputs and output of matrices in client applications.

#### DataMiner Cube - Visual Overview: Enhanced performance when opening a visual overview with a large amount of shapes that link to a webpage [ID_37799]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

Because of a number of enhancements, overall performance has increased when opening a visual overview with a large amount of shapes that link to a webpage.

#### DataMiner Cube - Spectrum Analysis: Editing the X-axis and Y-axis labels [ID_37821]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In a spectrum view, it is now possible to modify the center frequency and reference level.

To modify the center frequency:

1. Click the pencil icon next to the center frequency X-axis label.
1. Use the up/down buttons to change the center frequency.
1. Click *Confirm* or press ENTER.

To modify the reference level:

1. Click the pencil icon next to the reference level Y-axis label.
1. Use the up/down buttons to change the reference level.
1. Click *Confirm* or press ENTER.

> [!NOTE]
> To change the unit of either the center frequency or the reference level, go to the settings menu on the right.

#### Protocols: Buffer for SNMP responses now has a dynamic size [ID_37824]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

Up to now, when an SNMP response was received, a buffer with a fixed size of 10240 characters was used to translate the response to the requested format (e.g. OctetStringUTF8). When the response was larger that 10240 characters, it was cut off.

From now on, the buffer will have a dynamic size. This allow larger responses to be processed, and will also make sure that less memory has to be reserved when smaller responses are received.

#### DataMiner Cube - Trending: Relation learning light bulb enhancements [ID_37834]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

The checks run to decide whether to show the relation learning light bulb in the top-right corner of a trend graph window have been optimized.

Also, this light bulb can now have the following states, which will indicate why it is not yet showing any results:

| State | Description |
|-------|-------------|
| Checking requirements | The light bulb is still checking whether all requirements are met. |
| Loading               | The light bulb is fetching the relations. |

> [!NOTE]
> The following prerequisites are now optional instead of mandatory:
>
> - *DataMiner CloudFeed* version 1.1.0 or higher
> - *Allow performance and usage data offload* option

#### DataMiner Cube - Alarm Console: New alarm tab showing current suggestion events now has the 'Automatically remove cleared alarms' option enabled by default [ID_37855]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When you add a new alarm tab showing the current suggestion events, that tab will now have the *Automatically remove cleared alarms* option enabled by default.

This means that suggestion events will automatically disappear from the tab approximately 2 hours after they have been detected.

#### DataMiner Cube: Optimization of memory handling when closing cards [ID_37858]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

Overall memory handling when closing cards has been optimized.

#### DataMiner Cube - Settings: Default values of trend graph action settings have been changed [ID_37867]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In the *Settings* window, the default values of the following trend graph action settings have been changed:

| Setting | New default value |
|---------|-------------------|
| Right mouse button action on graph         | Select |
| Hotkey + left mouse button action on graph | Zoom   |

#### DataMiner Cube - Protocols & Templates: Clicking Help will now open the protocol's help page on 'DataMiner Connector Documentation' [ID_37873]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When, in the *Protocols & Templates* app, you right-click a protocol in the *Protocols* list and select *Help*, a new browser window will now open, showing the protocol's help page on [DataMiner Connector Documentation](https://docs.dataminer.services/connector/index.html).

> [!NOTE]
> That same help page will appear when, in an element card, you open the hamburger menu and select *Help*.

#### DataMiner Cube - Service templates: Scrollbar added inside every tab of a service template card [ID_37882]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

A number of enhancements have been made to the service template card, one of which is a scrollbar added inside every tab.

#### DataMiner Cube - Desktop application: New command-line argument 'UseInitialArgumentsAfterDisconnect' [ID_37888]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

You can now start the DataMiner Cube desktop application with the new command-line argument *UseInitialArgumentsAfterDisconnect=true*.

This argument will make sure that all other arguments you specified when you started the application will again be applied when Cube has to reconnect for some reason.

#### DataMiner Cube - Alarm templates: Enhanced selection box in 'Anomaly alarm settings' window [ID_37899]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

The selection box at the top of the *Anomaly alarm settings* window has now been made wider in order to better accommodate content in languages other than English.

#### DataMiner Cube: Legacy Reports, Dashboards and Annotations modules are now end-of-life and will be disabled by default [ID_37935]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

As from DataMiner versions 10.1.10/10.2.0, the *LegacyReportsAndDashboards* and/or *LegacyAnnotations* soft-launch options allowed you to enable or disable the legacy *Reports*, *Dashboards* and *Annotations* modules. By default, they were enabled.

Now, the above-mentioned soft-launch options will be disabled by default, causing the legacy *Reports*, *Dashboards* and *Annotations* modules to be hidden. If you want to continue using these modules, which are now considered end-of-life, you will have to explicitly enable the soft-launch options.

In DataMiner Cube, all buttons related to these modules will now by default also be hidden.

#### DataMiner Cube - Spectrum analysis: Zero span mode [ID_37946]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

Spectrum windows now support zero span mode.

To enter zero span mode, set the frequency span to 0. The X axis will then change from a frequency axis to a time axis, and all frequency-related features will be disabled.

In zero span mode, the sweeptime parameter is used to indicate the time on the X axis:

- Left: 0
- Right: Sweeptime

#### DataMiner Cube - Alarm Console: All alarms tabs listing suggestion events now have the 'Automatically remove cleared alarms' option enabled by default [ID_38034]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

From now on, all alarm tabs listing suggestion events will behave like alarm tabs listing active alarms, i.e. the *Automatically remove cleared alarms* option will be enabled by default, except for alarm tabs listing historical alarms or information events.

#### DataMiner Cube - Search: Request to initialize client indexing will only be sent when the user has AdminTools permission [ID_38090]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in *System Center > Search & Indexing*, the *Enable search indexing on the client* option was enabled, up to now, DataMiner Cube would send a message to the DataMiner Agent requesting to initialize client indexing, regardless of whether or not the user had *Admin tools* permission (*Modules > System configuration > Tools*). When the user had not been granted this permission, an `Exception occurred while receiving search options` error would be logged.

From now on, before it sends the message in question to the DataMiner Agent, DataMiner Cube will first check whether the user has *Admin tools* permission. If not, it will not send the message.

#### DataMiner Cube - Alarm Console: Enhanced performance when loading history alarms of a view, a service or an element dragged onto the Alarm Console [ID_38141]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

Up to now, when you dragged a view, a service or an element onto the Alarm Console, and indicated that you wanted history alarms of that view, service or element to be loaded, it could take a long time for those alarms to get loaded.

Because of a number of enhancements, overall performance has increased when loading the history alarms of a view, a service or an element dragged onto the Alarm Console.

> [!NOTE]
> When indicating that an alarm tab should list history alarms, it is no longer possible to select the *Show masked alarms* option. From now on, all masked alarms will automatically be included when history alarms are loaded.

#### DataMiner Cube - System Center: 'Install Indexing Engine' button removed [ID_38145]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

Up to now, you could go to *System Center > Search & Indexing* and click *Install Indexing Engine* to install an Elasticsearch database on a DataMiner Agent to which Cube was connected. This button has now been removed.

Elasticsearch is only supported up to version 6.8, which is no longer supported by Elastic. We recommend using OpenSearch instead, ideally with a dedicated clustered storage setup. Using storage per DMA with OpenSearch is also possible; in that case you will first need to install an OpenSearch database (ideally on a separate Linux server), and then connect your DMS to the OpenSearch database.

#### DataMiner Cube - Data Display: Enhanced performance when loading partial tables [ID_38155]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

Because of a number of enhancements, overall performance has increased when loading partial tables in DataMiner Cube.

#### DataMiner Cube - System Center: Database setting "CloudStorage" renamed to "STaaS" [ID_38325]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

In the *Database* section of *System Center*, up to now, when a DataMiner Agent was configured to use Storage as a Service (STaaS), the *Database* setting was set to "CloudStorage". This "CloudStorage" value has now been renamed to "STaaS".

Also, when *Database* is set to "STaaS", the *Configuration* and *Maintenance* sections will no longer be visible in both the *General* and *Offload* tabs, and the *Cassandra preparation/migration* button will be hidden.

### Fixes

#### DataMiner Cube: Problem when adding up [Start Time:] placeholders [ID_37661]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

When the [Sum:] placeholder was used to add [Start Time:] placeholders, in some cases, the sum would not be correct.

From now on, when configuring [Start Time:] placeholders that will be used in Sum operations, a format will have to be specified.

See also: [Linking a shape to a booking](xref:Linking_a_shape_to_a_booking)

#### DataMiner Cube: A number of Automation issues have been fixed [ID_37674]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

A number of issues have been fixed with regard to Automation:

- When, in the Automation app, you opened a script in an undocked card, it would not be possible to edit the name of the script.
- A *nullreference* exception could be thrown when an Automation script was deleted.
- Cube could leak memory each time you opened an Automation script in a new card.

#### DataMiner Cube - Protocols & Templates: Function definitions would not be listed when you activated a functions file [ID_37754]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When, in the *Protocols & Templates* app, you activated a functions file, the activated function definitions would incorrectly not be listed. For this list to be displayed, you had to close the *Protocols & Templates* app and re-opened it again.

#### DataMiner Cube - Visual Overview: Placeholder containing '[Elapsed Time]' would not be updated when the elapsed time had changed [ID_37756]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When the placeholder `[Elapsed Time]` was used inside another placeholder (e.g. `[Subtract:[Elapsed Time],[PreRoll]]`), the entire placeholder (e.g. `[Subtract:[Elapsed Time],[PreRoll]]`) would not be updated when the elapsed time had changed.

#### DataMiner Cube - Pattern matching: Memory leak [ID_37771]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

DataMiner Cube could start leaking memory when you opened trend graphs with pattern matching.

#### SLAnalytics: Problem when the alarm repository was not available at startup [ID_37782]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In some cases, an error could occur in SLAnalytics when it was not able to connect to the alarm repository at startup.

#### DataMiner Cube - Data Display: Problem when hovering over lite parameter controls in Skyline Black theme [ID_37814]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When DataMiner Cube was using the *Skyline Black* theme, lite parameter controls would become unreadable when you hovered over them.

#### Entire SNMPv3 response would be discarded when one or more cells contained 'no such instance' [ID_37815]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When a table was polled via SNMPv3 and the response included a cell that contained *no such instance*, the table would not get populated with the values that were received. Instead, the entire result set would be discarded.

#### DataMiner Cube - Visual Overview: URLs that did not link to a DataMiner web apps would incorrectly get a connection ticket [ID_37822]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When the URL specified in a shape data item of type *Link* did not link to a DataMiner web app, but contained a keyword that could be interpreted as a keyword of a DataMiner web app, a connection ticket would incorrectly be added to that URL.

#### DataMiner Cube could leak memory leak when a card in tab layout was closed before it had fully been loaded [ID_37857] [ID_38021]

<!-- RN 37857: MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->
<!-- RN 38021: MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

When a card in tab layout was closed before it had fully been loaded, DataMiner Cube could leak memory due to list boxes not being cleared from memory.

#### DataMiner Cube - Visual Overview: Problem when a parameter value changed while executing an Automation script [ID_37854]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in a visual overview, a parameter value changed while executing an Automation script, an exception would be thrown.

#### DataMiner Cube - System Center: Term 'Client independent updates' replaced by 'Server independent client updates' [ID_37926]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In the *System settings > Manage client versions* section of *System Center*, the term *client independent updates* has been replaced by *server independent client updates*.

#### DataMiner Cube: Problem when right-clicking after selecting a large number of elements and/or services in a view card [ID_37981]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

When, in a view card, you selected a large number of elements and/or services and then right-clicked, in some cases, Cube could become unresponsive.

#### DataMiner Cube - Automation: Save button would incorrectly not be enabled after renaming an Automation script [ID_37987]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

When you had renamed an Automation script, in some rare cases, the *Save* button would incorrectly not be enabled. As a result, it was not possible to save the change.

#### DataMiner Cube - Correlation: Problem with 'Dynamic' option in 'Send email' action [ID_37995]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

When configuring a Correlation rule, you can make that rule send an email by adding a *Send email* action to it.

In some cases, when you opened a *Send email* action, it would incorrectly not be possible to select the *Dynamic* option to indicate that the elements that triggered the Correlation rule have to be included.

#### DataMiner Cube - Visual Overview: Problem with user permissions when right-clicking a visual overview linked to a service [ID_38018]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in DataMiner Cube, you right-clicked inside a visual overview linked to a service, the context menu would incorrectly allow you to edit the visual overview when you had permission to edit services in general but no permission to edit that specific service.

From now on, when you right-click inside a visual overview linked to a service, the context menu will only allow you to edit the visual overview when you have permission to edit that specific service (on top of the permission to edit services in general and the permission to access and edit visual overviews).

#### DataMiner Cube: Memory leaks when opening/closing alarm cards and 'Alarm Console' or 'Cube sides' section of the 'Settings' window [ID_38054]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

DataMiner Cube would leak memory each time you opened and closed an alarm card and each time you opened and closed the *Alarm Console* section or the *Cube sides* section in the user settings tab of the *Settings* window.

#### DataMiner Cube: Memory leak in About window [ID_38055]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

DataMiner Cube would leak memory each time you opened the *About* window.

#### DataMiner Cube - System Center: Memory leak in Update Center window [ID_38056]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

DataMiner Cube would leak memory each time you opened the *Update Center* window.

#### DataMiner Cube: Memory leak in Alarm Console [ID_38057]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

The Alarm Console would leak memory each time you opened an active alarms tab.

#### DataMiner Cube - System Center: 'Clean up unused' tool would incorrectly consider custom Visio files assigned to elements as unused [ID_38061]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

In *System Center*, you can clean up unused Visio files. However, up to now, this *Clean up unused Visio files* tool would incorrectly consider custom Visio files assigned to elements as unused.

#### DataMiner Cube - Visual Overview: Exception values of numeric parameters would be displayed incorrectly when the DynamicUnits soft-launch option was enabled [ID_38083]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When the *DynamicUnits* soft-launch option was enabled, exception values of numeric parameters would be displayed incorrectly.

#### DataMiner Cube could become unresponsive when event messages were being sent [ID_38115]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

In some rare cases, DataMiner Cube could become unresponsive when event messages were being sent.

#### DataMiner Cube would leak memory when you closed a card or when you closed an alarm tab containing correlated alarms [ID_38127]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

DataMiner Cube would leak memory

- when you closed an alarm tab containing correlated alarms, or
- when you closed a card (e.g. an element card) after navigating to it by clicking *Previous* on another card.

#### DataMiner Cube - Visual Overview: Unexpected behavior when locale was set to Turkish [ID_38140]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When the locale of the client machine was set to Turkish, visual overviews could manifest unexpected behavior due to names of shape data items being transformed incorrectly. These transformations will now be done culture independently.

#### DataMiner Cube: Problem after logging out and in repeatedly [ID_38171]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When you logged out and in repeatedly, an exception could be thrown, causing Cube to become unresponsive.

#### DataMiner Cube: No longer allowed to create properties with a name that consists of whitespace characters only [ID_38209]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Up to now, DataMiner Cube would incorrectly allow you to create properties of which the name consisted of whitespace characters only. From now on, this is no longer allowed.

#### DataMiner Cube would incorrect show 'Could not connect to the DataMiner Agent' instead of 'This Dataminer Agent is not running' [ID_38212]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When Cube connected to a DataMiner Agent that had APIGateway running as a process but did not have SLNet running, it would incorrectly show a `Could not connect to the DataMiner Agent` error instead of `This Dataminer Agent is not running`.

#### DataMiner Cube - Correlation app: Problem when loading read-only connectivity chains in the connectivity editor [ID_38252]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in the Correlation app, you opened the connectivity editor and loaded the read-only chains (e.g. connectivity chains automatically generated by service templates), Cube would throw an exception when it found duplicate items in those chains. From now on, when Cube finds duplicate items in connectivity chains, it will add a log entry.

#### DataMiner Cube would incorrectly still show the 'Add to dashboard...' menu option when the 'LegacyReportsAndDashboards' soft-launch option was disabled [ID_38258]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When the *LegacyReportsAndDashboards* soft-launch option was disabled, DataMiner Cube will incorrectly still show the *Add to dashboard...* menu option when you right-clicked a parameter, an element or a service.

#### DataMiner Cube - Visual overview: Problem when VdxPage data item and View data item of a shape were set by the same SetVar shape [ID_38321]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When a shape had both a *VdxPage* data field and a *View* data field in which the Visio page name as well as the view name were card variables set by the same *SetVar* shape, in some rare cases, the Visio page name would not be applied correctly, causing the incorrect page being displayed.

#### DataMiner Cube - Alarm Console: Alarms grouped by time, root time, creation time or root creation time could be grouped incorrectly [ID_38329]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in the Alarm Console, alarms were grouped by time, root time, creation time or root creation time, they could be grouped incorrectly.

#### DataMiner Cube - System center: Description of 'Log file size' setting was incorrect [ID_38330]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

In System Center, you can go to *System settings > Logging* to change the log file size.

Up to now, the description of this setting mentioned that the setting applied to the DataMiner Agent to which you were connected. It will now mention that the setting applies to the entire DataMiner System.

#### DataMiner Cube: Problem when opening a service card of which the default page was set to 'Reports' [ID_38380]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

When you opened a service card of which the default page was set to *Reports*, an error could occur, causing DataMiner Cube to become unresponsive.
