---
uid: Cube_Feature_Release_10.4.2
---

# DataMiner Cube Feature Release 10.4.2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.2](xref:General_Feature_Release_10.4.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.2](xref:Web_apps_Feature_Release_10.4.2).

## Highlights

- [System Center: 'Install Indexing Engine' button removed [ID 38145]](#system-center-install-indexing-engine-button-removed-id-38145)

## Changes

### Enhancements

#### Visual Overview: Enhanced performance when opening a visual overview with a large amount of shapes that link to a webpage [ID 37799]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

Because of a number of enhancements, overall performance has increased when opening a visual overview with a large amount of shapes that link to a webpage.

#### Optimization of memory handling when closing cards [ID 37858]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU1] - FR 10.4.2 -->

Overall memory handling when closing cards has been optimized.

#### Alarm Console: All alarms tabs listing suggestion events now have the 'Automatically remove cleared alarms' option enabled by default [ID 38034]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

From now on, all alarm tabs listing suggestion events will behave like alarm tabs listing active alarms, i.e., the *Automatically remove cleared alarms* option will be enabled by default, except for alarm tabs listing historical alarms or information events.

#### Search: Request to initialize client indexing will only be sent when the user has AdminTools permission [ID 38090]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in *System Center > Search & Indexing*, the *Enable search indexing on the client* option was enabled, up to now, DataMiner Cube would send a message to the DataMiner Agent requesting to initialize client indexing, regardless of whether or not the user had *Admin tools* permission (*Modules > System configuration > Tools*). When the user had not been granted this permission, an `Exception occurred while receiving search options` error would be logged.

From now on, before it sends the message in question to the DataMiner Agent, DataMiner Cube will first check whether the user has *Admin tools* permission. If not, it will not send the message.

#### Alarm Console: Enhanced performance when loading history alarms of a view, a service or an element dragged onto the Alarm Console [ID 38141]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

Up to now, when you dragged a view, a service or an element onto the Alarm Console, and indicated that you wanted history alarms of that view, service or element to be loaded, it could take a long time for those alarms to get loaded.

Because of a number of enhancements, overall performance has increased when loading the history alarms of a view, a service or an element dragged onto the Alarm Console.

> [!NOTE]
> When indicating that an alarm tab should list history alarms, it is no longer possible to select the *Show masked alarms* option. From now on, all masked alarms will automatically be included when history alarms are loaded.

#### System Center: 'Install Indexing Engine' button removed [ID 38145]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

Up to now, you could go to *System Center > Search & Indexing* and click *Install Indexing Engine* to install an Elasticsearch database on a DataMiner Agent to which Cube was connected. This button has now been removed.

Elasticsearch is only supported up to version 6.8, which is no longer supported by Elastic. We recommend using OpenSearch instead, ideally with a dedicated clustered storage setup. Using storage per DMA with OpenSearch is also possible; in that case you will first need to install an OpenSearch database (ideally on a separate Linux server), and then connect your DMS to the OpenSearch database.

#### Data Display: Enhanced performance when loading partial tables [ID 38155]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

Because of a number of enhancements, overall performance has increased when loading partial tables in DataMiner Cube.

### Fixes

#### Problem when adding up [Start Time:] placeholders [ID 37661]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

When the [Sum:] placeholder was used to add [Start Time:] placeholders, in some cases, the sum would not be correct.

From now on, when configuring [Start Time:] placeholders that will be used in Sum operations, a format will have to be specified.

See also: [Linking a shape to a booking](xref:Linking_a_shape_to_a_booking)

#### DataMiner Cube - Visual Overview: Problem when a parameter value changed while executing an automation script [ID 37854]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in a visual overview, a parameter value changed while executing an automation script, an exception would be thrown.

#### Problem when right-clicking after selecting a large number of elements and/or services in a view card [ID 37981]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

When, in a view card, you selected a large number of elements and/or services and then right-clicked, in some cases, Cube could become unresponsive.

#### Automation: Save button would incorrectly not be enabled after renaming an automation script [ID 37987]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

When you had renamed an automation script, in some rare cases, the *Save* button would incorrectly not be enabled. As a result, it was not possible to save the change.

#### Correlation: Problem with 'Dynamic' option in 'Send email' action [ID 37995]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11] - FR 10.4.2 -->

When configuring a correlation rule, you can make that rule send an email by adding a *Send email* action to it.

In some cases, when you opened a *Send email* action, it would incorrectly not be possible to select the *Dynamic* option to indicate that the elements that triggered the correlation rule have to be included.

#### Visual Overview: Problem with user permissions when right-clicking a visual overview linked to a service [ID 38018]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in DataMiner Cube, you right-clicked inside a visual overview linked to a service, the context menu would incorrectly allow you to edit the visual overview when you had permission to edit services in general but no permission to edit that specific service.

From now on, when you right-click inside a visual overview linked to a service, the context menu will only allow you to edit the visual overview when you have permission to edit that specific service (on top of the permission to edit services in general and the permission to access and edit visual overviews).

#### DataMiner Cube could leak memory leak when a card in tab layout was closed before it had fully been loaded [ID 38021]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU1] - FR 10.4.2 -->

When a card in tab layout was closed before it had fully been loaded, DataMiner Cube could leak memory due to list boxes not being cleared from memory.

#### Memory leaks when opening/closing alarm cards and 'Alarm Console' or 'Cube sides' section of the 'Settings' window [ID 38054]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

DataMiner Cube would leak memory each time you opened and closed an alarm card and each time you opened and closed the *Alarm Console* section or the *Cube sides* section in the user settings tab of the *Settings* window.

#### Memory leak in About window [ID 38055]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

DataMiner Cube would leak memory each time you opened the *About* window.

#### System Center: Memory leak in Update Center window [ID 38056]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

DataMiner Cube would leak memory each time you opened the *Update Center* window.

#### Memory leak in Alarm Console [ID 38057]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

The Alarm Console would leak memory each time you opened an active alarms tab.

#### System Center: 'Clean up unused' tool would incorrectly consider custom Visio files assigned to elements as unused [ID 38061]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

In *System Center*, you can clean up unused Visio files. However, up to now, this *Clean up unused Visio files* tool would incorrectly consider custom Visio files assigned to elements as unused.

#### Visual Overview: Exception values of numeric parameters would be displayed incorrectly when the DynamicUnits soft-launch option was enabled [ID 38083]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When the *DynamicUnits* soft-launch option was enabled, exception values of numeric parameters would be displayed incorrectly.

#### DataMiner Cube could become unresponsive when event messages were being sent [ID 38115]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

In some rare cases, DataMiner Cube could become unresponsive when event messages were being sent.

#### DataMiner Cube would leak memory when you closed a card or when you closed an alarm tab containing correlated alarms [ID 38127]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

DataMiner Cube would leak memory

- when you closed an alarm tab containing correlated alarms, or
- when you closed a card (e.g., an element card) after navigating to it by clicking *Previous* on another card.

#### Visual Overview: Unexpected behavior when locale was set to Turkish [ID 38140]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When the locale of the client machine was set to Turkish, visual overviews could manifest unexpected behavior due to names of shape data items being transformed incorrectly. These transformations will now be done culture independently.

#### DataMiner Cube: Problem after logging out and in repeatedly [ID 38171]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When you logged out and in repeatedly, an exception could be thrown, causing Cube to become unresponsive.

#### DataMiner Cube would incorrect show 'Could not connect to the DataMiner Agent' instead of 'This Dataminer Agent is not running' [ID 38212]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When Cube connected to a DataMiner Agent that had APIGateway running as a process but did not have SLNet running, it would incorrectly show a `Could not connect to the DataMiner Agent` error instead of `This Dataminer Agent is not running`.

#### Correlation app: Problem when loading read-only connectivity chains in the connectivity editor [ID 38252]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in the Correlation app, you opened the connectivity editor and loaded the read-only chains (e.g., connectivity chains automatically generated by service templates), Cube would throw an exception when it found duplicate items in those chains. From now on, when Cube finds duplicate items in connectivity chains, it will add a log entry.

#### DataMiner Cube would incorrectly still show the 'Add to dashboard...' menu option when the 'LegacyReportsAndDashboards' soft-launch option was disabled [ID 38258]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When the *LegacyReportsAndDashboards* soft-launch option was disabled, DataMiner Cube will incorrectly still show the *Add to dashboard...* menu option when you right-clicked a parameter, an element or a service.

#### Visual overview: Problem when VdxPage data item and View data item of a shape were set by the same SetVar shape [ID 38321]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When a shape had both a *VdxPage* data field and a *View* data field in which the Visio page name as well as the view name were card variables set by the same *SetVar* shape, in some rare cases, the Visio page name would not be applied correctly, causing the incorrect page being displayed.

#### Alarm Console: Alarms grouped by time, root time, creation time or root creation time could be grouped incorrectly [ID 38329]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

When, in the Alarm Console, alarms were grouped by time, root time, creation time or root creation time, they could be grouped incorrectly.

#### System center: Description of 'Log file size' setting was incorrect [ID 38330]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 -->

In System Center, you can go to *System settings > Logging* to change the log file size.

Up to now, the description of this setting mentioned that the setting applied to the DataMiner Agent to which you were connected. It will now mention that the setting applies to the entire DataMiner System.

#### System Center: No longer possible to add additional databases when DMA was using STaaS [ID 38399]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU11] - FR 10.4.2 [CU0] -->

In *System Center*, the *Other* tab of the *Database* section allows you to configure additional databases.

Up to now, when Cube was connected to a DataMiner Agent configured to use STaaS, an error could occur when you tried to add an additional database.

#### Visual Overview: Problem with subscription filter on 'Children' shape [ID 38537]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU11]/10.4.0 [CU0] - FR 10.4.2 [CU0] -->

When a subscription filter was configured on a *Children* shape, it would not get parsed correctly, causing the filter to malfunction.
