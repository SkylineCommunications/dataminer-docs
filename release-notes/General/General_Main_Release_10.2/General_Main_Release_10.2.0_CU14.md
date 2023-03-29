---
uid: General_Main_Release_10.2.0_CU14
---

# General Main Release 10.2.0 CU14 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade will not be performed if NATS is not installed and running [ID_33304]

<!-- MR 10.3.0 - FR 10.2.7 -->
<!-- Also added to MR 10.2.0 [CU14] -->

When you launch a DataMiner upgrade, from now on, the upgrade process will not be allowed to start if NATS is not installed and running.

> [!NOTE]
> This check will be skipped if the current DataMiner version is older than version 10.1.0.

#### DataMiner Cube: Database TTL settings will now be limited to 10 years [ID_35533]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

From now on, DataMiner Cube will no longer accept database TTL settings that exceed 10 years.

#### Alarms generated when a database goes in offload mode will now have severity 'Notice' instead of 'Critical' [ID_35749]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a database went in offload mode, up to now, an alarm with severity *Critical* was generated. From now on, an alarm of severity *Notice* will be generated instead.

#### Monitoring app: Elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab [ID_35781]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In the *Monitoring* app, from now on, elements, services and views opened by clicking a Visio shape will open in the same tab instead of a new tab.

#### GQI data sources that require an Elasticsearch database will now use GetInfoMessage(InfoType.Database) to check whether Elasticsearch is available [ID_35907]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, GQI data sources that require an Elasticsearch database used the `DatabaseStateRequest<ElasticsearchState>` message to check whether Elasticsearch was available. From now on, they will use the `GetInfoMessage(InfoType.Database)` message instead.

#### Web apps: Enhanced error handling when executing an interactive Automation script by clicking a DOM button [ID_35909]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Overall error handling has been improved when executing an interactive Automation script by clicking a DOM button in a web app.

#### Improved error handling when elements go into an error state [ID_35944]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When an element goes into an error state after an attempt to activate it failed, from now on, no more calls to SLProtocol, SLElement or SLSpectrum will be made for that element.

Also, when an element that generates DVE child elements or virtual functions goes into an error state, from now on, the generated DVE child elements or virtual functions will also go into an error state. However, in order to avoid too many alarms to be generated, only one alarm (for the main element) will be generated.

The following issues have also been fixed:

- When a DVE parent element in an error state on DataMiner startup was activated, its DVE child elements or virtual functions would not be properly loaded.

- When a DVE parent element was started, the method that has to make sure that ElementInfo and ElementData are in sync would incorrectly not check all child elements.

### Fixes

#### SLLogCollector: Problem when collecting multiple memory dumps with the 'Now and when memory increases with X Mb' option [ID_35617]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When the *SLLogCollector* tool had to collect memory dumps of multiple processes with the *Now and when memory increases with X Mb* option, it would incorrectly only collect the memory dump of the first process that reached the specified Mb limit.

From now on, it will collect at least the "now" dump for each of the selected processes.

#### NATS would incorrectly be re-installed when a WMI query error occurred while the NATS installer was being run at DMA startup [ID_35647]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When the NATS installer was being run at DMA startup, in some cases, due to an issue with a WMI query, NATS could incorrectly be re-installed, even though NATS and NAS were already running.

From now on, the execution of the NATS installer at DMA startup will be skipped when NATS is already running. Also, if an error occurs when running a WMI query during the execution of the NATS installer, a message saying that the re-installation has failed will be added to the *SLUMSEndpointManager.txt* log file.

> [!NOTE]
> When an error occurs while running a WMI query, and no NATS/NAS service is running, NATS will not be installed automatically. A manual installation of NATS will be needed.

#### Existing masked alarms would incorrectly affect the overall alarm severity of an element [ID_35678]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Existing masked alarms would incorrectly affect the overall alarm severity of an element.

#### Dashboards app: Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns [ID_35702]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

Sticky component menus would no longer be fully visible after you had changed the number of dashboard columns.

#### SLElement could leak memory when updating alarm templates containing conditions [ID_35728]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.4 -->

In some cases, SLElement could leak memory when updating alarm templates containing conditions.

#### Memory leak in SLAnalytics [ID_35758]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU1] - FR 10.3.4 -->

In some cases, SLAnalytics kept on waiting on a database call, which eventually led to the process leaking memory.

#### SLProtocol would interpret signed numbers incorrectly [ID_35796]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

SLProtocol would interpret signed numbers incorrectly, causing parameters to display incorrect values.

#### Dashboards app & Low-code apps: Duplicated component would not have the size as the original [ID_35804]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When you duplicated a component, the size of the duplicate would incorrectly be limited to 30 rows. From now on, when you duplicate a component, the duplicate will have the same size as the original.

#### Dashboards app: A table component could appear to be empty when you rapidly switched between visualizations [ID_35831]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, a table component could appear to be empty when you rapidly switched between visualizations.

Also, an error could be thrown when you tried to add an invalid query to a component.

#### DataMiner Maps: Markers could disappear when a layer was enabled or disabled [ID_35838]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In some cases, markers could disappear when a layer was enabled or disabled.

#### DataMiner Cube - Alarm Console: It could take a long time for an active alarms tab to load on a system with a large number of masked alarms [ID_35843]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Due to a caching issue, on a system with a large number of masked alarms, it could take a long time for an active alarms tab to load.

#### DataMiner Cube - Alarm Console: Base alarm updates would not be shown when the active alarms tab was filtered [ID_35845]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In a filtered active alarms tab, in some cases, a base alarm will match the filter while the correlated alarm will not. In that case, the base alarm will be shown while the correlated alarm will not.

However, up to now, when a base alarm was updated, the update would not be reflected in the Alarm Console until the filter was removed.

#### Business Intelligence: At SLA startup, the active alarms would no longer be in sync with the actual alarms affecting the SLA [ID_35862]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

At SLA startup, in some cases, the active alarms would no longer be in sync with the actual alarms affecting the SLA.

Also, a number of other minor fixes with regard to SLA management have been implemented.

#### Dashboards app & Low-code apps - GQI components: Problems when a GQI request failed [ID_35904]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a GQI request failed, some GQI components would show either an unrelated error or no error at all, while other GQI components would show a correct error but incorrect data.

#### Web apps: Login button would incorrectly be disabled on Edge and Chrome [ID_35906]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Up to now, in some cases, the login button would incorrectly be disabled when you opened a web app in Microsoft Edge or Google Chrome.

#### Dashboards app & Low-code apps - Clock components: Clock time would not update when set to server time [ID_35912]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When a clock component (analog or digital) was set to use server time, the clock time would not update.

#### DataMiner Cube - Visual Overview: [ServiceDefinitionFilter] placeholder would incorrectly not be resolved when used in a table row filter [ID_35923]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When, in a shape data field of type *ParameterControlOptions*, you had specified a table row filter that included a `[ServiceDefinitionFilter]` placeholder (e.g. "TableRowFilter:101=[ServiceDefinitionFilter]"), that placeholder would incorrectly not be resolved, causing the linked table control to be empty when filtered.

#### DataMiner Cube - Spectrum analysis: Problem when opening a spectrum element with an empty username [ID_35927]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

An error could occur when you tried to open a spectrum element of which the username was set to NULL.

Also, an exception could be thrown when you tried to copy spectrum settings to the Windows clipboard.

#### DataMiner Cube - Surveyor: Dragging multiple items from a view card onto a view in the Surveyor did not work as expected [ID_35955]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Dragging several elements or services from a view card onto a view in the Surveyor did not work as expected.

From now on, when you drag several elements or services from a view card onto a view in the Surveyor

- **the items in that view will be moved** to the view in Surveyor, and
- **the items in any of its sub-views will be copied** to the view in the Surveyor.

If you want to the items in the view to be **copied** to the view in the Surveyor instead of moved, keep the CTRL key pressed while dragging them.
