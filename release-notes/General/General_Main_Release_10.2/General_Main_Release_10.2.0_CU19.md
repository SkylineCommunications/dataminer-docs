---
uid: General_Main_Release_10.2.0_CU19
---

# General Main Release 10.2.0 CU19

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Service & Resource Management: ProfileInstances with 'IsValueCopy' set to true will be assigned a TTL of 1 year [ID 31189]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

For each ProfileInstance, an `isValueCopy` property can be set:

- When set to false, the ProfileInstance will be added to a primary index.
- When set to true, the ProfileInstance will be added to a secondary index and will be assigned a TTL of 1 year (see note below).

From now on, it will no longer be allowed to change the `IsValueCopy` property of a ProfileInstance from true to false or vice versa. If such an attempt is made, a *ProfileManagerError* will be returned in the trace data with reason *ProfileInstanceChangedType*.

Also, in DataMiner Cube, the *By value/By reference* toggle button has now been removed from the *Profiles* App. Profile instances created using Cube will now always be created *by reference*.

> [!NOTE]
> When the `isValueCopy` property of a ProfileInstance is set to true, it will only be assigned a TTL of 1 year when that ProfileInstance is stored in Elasticsearch.

#### Improved handling of smart baseline parameter sets [ID 36997]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

The handling of smart baseline parameter sets in SLNet has improved in cases where a protocol is configured to receive a nominal value for a column parameter (using the Protocol.Params.Param.Alarm type attribute), and the column value to be set is of the "retrieved" type, as configured in the ColumnOption type of the parameter to be set (i.e. the alarm tag `<Alarm Type="absolute:2,3">` is defined for the column parameter, and the ColumnOption type of the parameter is "retrieved"). In those cases, the parameter sets are now done in sets of at most 5000 at once, which will greatly improve performance when setting smart baselines for large tables.

In addition, a write parameter is no longer needed in this scenario. Previously, if there was no write parameter, it was not possible to update the stored baseline value. Now if a write parameter is present, it will be used to set the values in case of single parameter sets.

#### Automatic cleanup of C:\\Skyline DataMiner\\Upgrades\\Packages folder [ID 37033]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

After each DataMiner upgrade, up to now, the DataMiner upgrade package would be kept indefinitely in the `C:\Skyline DataMiner\Upgrades\Packages` folder.

From now on, after each DataMiner upgrade or DataMiner startup, this folder will be cleaned up.

- When a DataMiner upgrade was successful, only the `progress.log` file for that particular upgrade will be kept.
- When a DataMiner upgrade failed, apart from the `progress.log` file, the [prerequisite checks](xref:Preparing_to_upgrade_a_DataMiner_Agent#prerequisite-checks) will also be kept for debugging purposes.

#### Security enhancements [ID 37064] [ID 37094]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

A number of security enhancements have been made.

#### SLReset: Generation of NATS credentials will now also be logged in SLFactoryReset.txt [ID 37071]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the factory reset tool *SLReset.exe* was run, up to now, the generation of the NATS credentials would only be logged to the console. From now on, an entry will also be added to the *SLFactoryReset.txt* log file.

#### 'No Notifications might be sent' notice will now be logged in the SLSNMPAgent.txt log file [ID 37188]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you connected to a DataMiner Agent, up to now, the Alarm Console would often show the following notice:

`No Notifications might be sent (Email or Sms). Init Notifications: No e-mail address found to use as sender. Defaulting to notifications@example.com`

This notice will now be logged in the *SLSNMPAgent.txt* log file instead.

### Fixes

#### Dashboards app: Problem with trend components in PDF reports [ID 36331]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU4] - FR 10.3.7 -->

In a PDF report of a dashboard, in some cases, trend components would collide with other components.

#### DataMiner upgrade failed because prerequisites check incorrectly marked Agent as failed [ID 36776]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some cases, it could occur that the prerequisites check that is performed at the start of a DataMiner upgrade incorrectly marked an Agent as failed, which caused the upgrade to fail.

#### Connection timed out while waiting for upgrade package upload to all DMAs [ID 36866]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

At the start of a DataMiner upgrade in a cluster, first the upload of the upgrade package cascades through the cluster: the package is uploaded to the DMA the client is connected to, then it is forwarded to the other DMAs in the cluster, and if one of these is a Failover pair, the online DMA in turn forwards the package to the offline DMA. The upload is only considered complete when the first DMA has uploaded the package and received confirmation from all other DMAs.

However, when the upload happened too slowly, it could occur that the connection timed out. Now, as long as the upgrade is progressing, the upload will not time out.

#### Dashboards app/Low-Code Apps: Error when data source contained cells with NaN value [ID 36923]

<!-- MR 10.2.0 [CU19]/MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when a data source contained cells with the value "NaN", an error message was shown in the Dashboards app or Low-Code Apps.

This has been fixed. The display value will remain "NaN", but the raw value will now be null.

#### Issues related to NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES (336) notifications sent to SLDataMiner [ID 36973]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

A number of issues related to NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES (336) notifications sent to SLDataMiner have been resolved:

- Up to now, these notifications were only able to handle one column at a time. Now they can handle multiple columns.
- A small memory leak could occur when a NT_FILL_ARRAY_WITH_COLUMN_ONLY_UPDATES notification was sent to SLDataMiner with invalid data.
- If the user sending such a notification did not have sufficient rights on the element, or if the element was locked by another user, this did not cause this notification to fail. Now it will fail. This same issue has also been resolved for the NT_DELETE_ROW (156), NT_ADD_ROW (149), and NT_ADD_ROW_RETURN_KEY (240) notifications.

#### DataMiner Cube: Spectrum monitoring element no longer showed all spectrum monitor parameters [ID 37009]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you create a spectrum monitor, you can configure custom parameters. These parameters are in fact variables from the spectrum scripts, that are given more user-friendly names.

Normally, when you open a spectrum monitor element, you should be able to view all custom spectrum monitor parameters that have their *Displayed on element card* setting enabled. However, due to an issue, those parameters would no longer all be listed.

#### NATS configuration inconsistent in Failover setup after reconfiguring NATS [ID 37023]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.9 [CU1] -->

Up to now, the offline DMA in a Failover pair built its NATS configuration by fetching the nodes from the online DMA. In case the online DMA could not communicate with the rest of the cluster, this caused the offline DMA to also mark all other DMAs as unreachable. This meant that when NATS was reconfigured, even when the offline DMA was actually able to reach them, these "unreachable" DMAs were excluded from its routes. Moreover, as the offline DMA cannot generate alarms, there would be no notification of this until it was switched to online.

This will now be prevented. The offline DMA will now collect all nodes locally when setting up its NATS configuration instead of fetching them from the online DMA.

#### Dashboards app: Height of 'Data used in Dashboard' section would not be reduced when you deleted multiple components at once [ID 37032]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.9 -->

When, while in edit mode, you deleted multiple components at once, the *Data used in Dashboard* section of the edit pane would not be updated correctly. The data would be removed, but the height of the section would incorrectly not be reduced.

#### Spectrum Analysis: Preset tab loading indefinitely if no presets defined [ID 37043]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

If no preset was available for a particular spectrum element, it could occur that the *Preset* tab for the spectrum element kept loading indefinitely.

#### Dashboards app & Low-Code Apps: Line & area chart component could get stuck in a loading state [ID 37044]

<!-- MR 10.2.0 [CU19] - FR TBD -->

In some cases, a line & area chart component could get stuck in a loading state without showing any possible error messages.

#### Dashboards app/Low-Code Apps: Visual glitch when closing component menu [ID 37058]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the menu of a component in a dashboard or low-code app was closed by moving the mouse pointer out of it at the bottom center, a visual glitch could occur where the menu appeared to rapidly open and close.

#### Dashboards app/Low-Code Apps - Line chart component: Viewport would change upon receiving data [ID 37065]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When a line chart component received new data, it would incorrectly recalculate its viewport.

#### SLReset: Problem due to NATS being re-installed before cleaning up the 'C:\\Skyline DataMiner' folder [ID 37072]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you perform a factory reset by running *SLReset.exe*, NATS will automatically be re-installed.

Up to now, SLReset would re-install NATS **before** it cleaned up the `C:\Skyline DataMiner` folder. As, in some cases, this could cause unexpected behavior, SLReset will now re-install NATS **after** the file cleanup.

#### Failover: NATS servers would incorrectly use the virtual IP address of a Failover setup to establish the route to the online agent [ID 37073]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.9 [CU2] -->

When the NATS server builds the route connections to the agents in a Failover setup, in some cases, when establishing the route to the online agent, it used the virtual IP address of the Failover setup instead of the primary address of the online agent.

From now on, *NATS Custodian* will check whether the routes list contains any virtual IP addresses. If so, it will replace each virtual IP address with the correct primary address of the online agent when performing the NATS configuration checks. However, it will not restart NATS.

#### Cassandra Cluster Migrator tool would incorrectly not migrate any logger tables [ID 37083]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

The Cassandra Cluster Migrator tool would incorrectly not migrate any logger tables.

#### Monitoring app: Filtered combo box control not shown correctly in Visual Overview [ID 37107]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In the Monitoring app, it could occur that Visual Overview parameter control shapes configured to show a filtered combo box control (i.e. with *SetVarOptions* set to *Control=FilterComboBox*) were not displayed correctly.

#### Low-Code Apps: Time range component overlay not fully displayed [ID 37118]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you click a time range component in a low-code app, an overlay is displayed where you can select a time range. In some cases, it could occur that part of this overlay could not be displayed.

#### Problem when running queries against Elasticsearch [ID 37138]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some rare cases, queries run against an Elasticsearch database would get stuck, causing SLDataGateway to throw exceptions and Elasticsearch to not return any results.

#### Protocols: Length parameter in a response would not be set to the correct value [ID 37172]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some cases, the length parameter in a response would not be set to the the correct value.

#### Service & Resource Management: Booking status would be set to 'Ended' too soon [ID 37176]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In some cases, events scheduled to run at the end of a booking would not be run because the status of the booking was set to "Ended" too soon.

From now on, the status of a booking will only be set to "Ended" once all events have been run.

#### Low-Code Apps: Editing a published app with an existing draft would incorrectly create a new draft [ID 37194]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when you edited a published app that had a draft, a new draft would incorrectly be created. From now on, when you edit an app that has a draft, that existing draft will be opened.

#### Problem when updating the NATS server [ID 37305]

<!-- 10.2.0 [CU19]/MR 10.3.0 [CU7] - FR 10.3.10 [CU0] -->

In some cases, when updating the NATS server, an error could occur while replacing the *nats-streaming-server.exe* file.
