---
uid: General_Main_Release_10.2.0_CU6
---

# General Main Release 10.2.0 CU6

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SAML authentication: Azure Active Directory B2C now also supported as identity provider ID_32714]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.6 -->

For external authentication using SAML, DataMiner now also supports Azure Active Directory B2C as an identity provider.

Also, when creating a DataMiner user, using an email address as user name is now mandatory.

> [!NOTE]
> If, in DataMiner.xml, the default user name of an identity provider is not a valid email address, you can optionally add a \<PreferredLoginClaim> element that refers to a claim that contains a valid email address.

#### Cassandra Cluster Migrator: Enhanced resilience of the migration process [ID_33467] [ID_33621] [ID_33727]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

The migration process will now be executed partition by partition. This greatly enhances the overall resilience of that process.

When the source database is a Cassandra database, at the end of a migration process, the Migrator tool will now automatically retry to migrate the partitions that could not be migrated the first time. Moreover, when you manually restart a migration with failed partitions, only those failed partitions will be included in the new migration attempt. The migration will no longer have to be redone from scratch.

Also, additional fail-safes have been built in to cope with situations where the target Cassandra database cannot be reached.

#### NATS: Enhancements to the NATS configuration [ID_33558] [ID_33931]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

A number of enhancements have been made to the NATS configuration:

- STAN clustering has been removed.

- New NATSForceManualConfig option to disable the automatic reset timer in NATSCustodian.

  Disabling the timer can be done in one of the following ways:

  - Set the SLNet option **NATSForceManualConfig** to true in the SLNetClientTest tool (default = false).
  - Set the **SLNet.NATSForceManualConfig** tag to true in *MaintenanceSettings.xml*.

  > [!NOTE]
  >
  > - Changing this option in the SLNetClientTest tool can be done at run-time. The change will be applied immediately.
  > - Forcing manual configuration will disable the automatic NATS configuration on the DataMiner System. It will then be up to the user to either manually configure a NATS cluster or manually call NatsCustodianResetNatsMessage when changes are made to the DMS.

- On DataMiner startup, NAS and NATS will now automatically be started if they are not running.

Also, the nats-streaming-server binary has been updated to v0.24.6. However, note that it will not be updated automatically via upgrade actions. It will only be installed during fresh NATS installations or when reinstalling NATS via SLEndpointTool_Console. The previous version (v0.22.0) and the new version (v0.24.6) version are compatible and are able to communicate with each other.

#### Dashboards app: Enhanced 'loading' indication when state component linked to a GQI query receives an update [ID_33640]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

Up to now, each time a state component linked to a GQI query received an update, a *loading* indication would be displayed over the entire component. From now on, when such a component receives an update, a more subtle loader bar will be displayed instead.

Also, when a query error occur, from now on, the actual error will be displayed instead of "No data".

#### GQI: Enhanced performance when running a GQI query with a filter applied to it [ID_33664]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

Because of a number of enhancements, overall performance has improved when running a GQI query with a filter applied to it.

#### Serial connections: Hostname resolution enhancements [ID_33702]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a serial connection was configured with a hostname instead of an IP address, up to now, the hostname would be resolved when the port was initialized. When the hostname suddenly pointed to a different IP address, an element restart or a dynamic IP address change was needed for the serial connection to be aware of that change.

This has now been changed:

- In case of a TCP-oriented serial connection (serial SSL/TLS, SSH and serial TCP), the hostname will be resolved upon every connect.
- In case of a UDP-oriented serial connection (serial UDP), the hostname will be resolved prior to every send.

#### Web apps now also support parameter comments configured in Param.Message elements [ID_33784]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When configuring a parameter in a protocol, you can add a `<Message>` element containing a comment to be displayed in a confirmation box when users change that parameter on the user interface. Up to now, this `<Message>` element was only supported by DataMiner Cube. It is now also supported by web applications like Monitoring and Dashboards.

#### SLPort: Order of parameters in an HTTP session request will be identical to that in the protocol [ID_33796]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In an HTTP session request, the order of the parameters will now always be identical to that in the protocol.

#### Failover: Enhanced performance of SLNet when communicating via NATS [ID_33807]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

On Failover systems, because of a number of enhancements, overall performance of SLNet has increased when communicating via NATS.

#### DVE function protocol version of active functions will now be deleted when the main DVE protocol version is deleted [ID_33834]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a version of a DVE protocol with function DVE protocols is deleted from the system while functions are active, from now on, the function DVE protocol versions associated with those active functions will also be removed from the system.

#### Dashboards app: Parameter tables can now expose index values & Edit panel now allows selecting a specific protocol version [ID_33841]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, a parameter table was only able to expose indices as part of a parameter value. From now on, a parameter table will also be able to expose indices as separate values.

Also, the edit panel will now allow users to select a specific protocol version.

#### Alarm Console: Time of history sets will now always be converted to the local time zone [ID_33849]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

From now on, the time of history sets will always be converted to the local time zone.

#### Alarm Console - Proactive cap detection: Reduction of false positive matches [ID_33871]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When trend data is often getting close to the low or high value of a data range, this data range value will no longer be considered as a critical data boundary. This will reduce the number of false positive matches.

#### GQI: Table columns of type decimal can now also be used when filtering or aggregating data [ID_33927]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Table columns of type "decimal" can now also be used when filtering or aggregating data.

#### SLLogCollector: Enhanced processing of SLProtocol memory dumps [ID_33932]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, SLLogCollector is now better able to collect SLProtocol memory dumps, especially in cases where there is no reference to an element.

#### SLSNMPManager: Enhanced performance [ID_33940]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance of the SLSNMPManager process has improved.

#### New BPA test 'Verify Cloud DxM Version' [ID_33956]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 [CU0] -->

This new BPA test checks if the minimum required version is installed for all DxMs in the system.

It is available from DataMiner 10.2.8 and 10.2.0 [CU6] onwards. You can run it in System Center (on the *Agents > BPA* tab), and it also runs automatically when you upgrade to 10.2.0 [CU6]/10.2.8 or higher.

For more information, see [Verify Cloud DxM Version](xref:BPA_Verify_Cloud_DxM_Version).

#### Enhanced error handling in case QActions fail due to a problem with SLScripting [ID_34010]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an error occurs in SLScripting, from now on, a new SLScripting instance will be started and all QActions will be reloaded.

#### Alarm Console: A run-time error will now appear when the Resource Manager failed to initialize [ID_34024]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

From now on, the following run-time error will appear in the Alarm Console when the Resource Manager failed to initialized.

```txt
An unexpected exception has occurred while initializing Resource Manager. Please check the SLResourceManager logging for more information.
```

#### Parameter changes will now only be pushed from SLProtocol to SLElement when needed [ID_34047]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, parameter changes would always be pushed from SLProtocol to SLElement. From now, those changes will only be pushed from SLProtocol to SLElement when needed.

#### Size of the WebSocket messages sent from SLPort to SLProtocol will now be limited to 1024 packets [ID_34049]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 [CU1] -->

In order to prevent SLPort from running out of memory, from now on, the size of the WebSocket messages sent from SLPort to SLProtocol will be limited to 1024 packets.

#### GQI: Properties marked as 'read only' will now also be available [ID_34052]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When creating GQI queries, custom view, element, service and alarm properties that are marked as "read only" will now also be available.

#### Web apps: Enhanced performance when retrieving booking information [ID_34072]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance has increased when retrieving booking information in the Dashboards app and in Low-Code Apps.

#### Dashboards app: Enhanced performance when editing a dashboard containing GQI queries [ID_34096]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in the Dashboards app, you switched to edit mode, all columns of all GQI queries on the dashboard in question would be retrieved. From now, only when you open a specific query on the dashboard you are editing will the columns of that specific query be retrieved.

#### DataMiner upgrade: On two-node setups, the VerifyClusterPorts prerequisite will only check the ports of the NATS node that is being used by DataMiner [ID_34240]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 [CU0] -->

During an upgrade of a two-node setup (e.g. 2 single DMAs or one Failover pair), from now on, the *VerifyClusterPorts* prerequisite will only check the ports of the NATS node that is being used by DataMiner.

### Fixes

#### SLAnalytics - Pattern matching: No 'suggestion event' type alarm would be triggered in case of DVE elements [ID_32671]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.5 -->

From DataMiner 10.0.13 onwards, you can activate alarm monitoring of trend patterns, so that a "suggestion event" type alarm is triggered whenever a specific pattern is detected. In case of dynamic virtual elements, in some cases, no "suggestion event" type alarm would be triggered.

#### SLLogCollector would become unresponsive when the name of the process or the path where the files had to be stored contained spaces [ID_33493]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

While collecting log information, SLLogCollector would become unresponsive when the name of the process or the path where the collected files had to be stored contained spaces.

#### GQI: Datetime values in retrieved booking information would incorrectly not be converted to UTC time [ID_33607]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

When a GQI query retrieved booking information, the datetime values would incorrectly not be converted to UTC time.

#### Monitoring app: Trend graph of table column parameter not displayed when table row index contained forward slash [ID_33661]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 -->

In the Monitoring app, the trend graph of a table column parameter would not be displayed when the table row index contained a forward slash.

#### Dashboards app: No longer possible to select a built-in theme as default theme [ID_33665]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

In the Dashboards app, it would no longer be possible to select a built-in dashboard theme as default theme.

#### SLProtocol would leak memory leak each time a parameter of a replicated element was updated [ID_33745]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

SLProtocol would leak memory each time a parameter of a replicated element was updated.

#### Web services API would incorrectly no longer clear a number of its caches when the connection was lost [ID_33764]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When the connection was lost, the web services API would incorrectly no longer clear a number of its caches.

#### Service & Resource Management: Child DVE element would not get activated when the main DVE element was in an error state [ID_33787]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you tried to create a booking with a child DVE element linked to a main DVE element in an error state, the child DVE element would not automatically be activated, causing the booking to fail. Moreover, SLNet would not try to activate this child DVE element, causing subsequent bookings needing that same child DVE element to also fail, even if the main element had already recovered from the error state in the meantime.

#### GQI: Columns of type 'decimal' would incorrectly not be treated as columns of type 'numeric' [ID_33792]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Columns of type "decimal" would incorrectly be treated as columns of type "string" instead of columns of type "numeric".

#### Dashboards app: Options displayed in component headers would not be readable when a dark theme was applied [ID_33805]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

When a dark theme was applied, options displayed in the header of certain dashboard components (e.g. “Export to CSV”) would not be readable.

#### Dynamic virtual elements: Problem when processing table columns containing foreign keys [ID_33810]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a table contained multiple foreign keys, invalid foreign key values referring to non-existing rows could prevent those rows from being exported to DVE child elements. This would cause alarms, trend information, subscriptions, etc. to not get updated for specific DVE elements and/or virtual functions.

#### Web apps: Visio files would not get rendered correctly [ID_33812]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, Visio files would not get rendered correctly in web apps (e.g. Dashboards).

#### Cassandra Cluster Migrator tool: Problem when migrating a large amount of data [ID_33821]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

When the Cassandra Cluster Migrator tool was migrating a large amount of data, in some cases, an out of memory exception could be thrown.

#### Problem with SLElement when resolving foreign keys took a long time and the the element debug log level was equal to or higher than 1 [ID_33826]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When the element debug log level was equal to or higher than 1, an error could occur in SLElement when resolving foreign keys took a long time.

#### Dashboards app - Visual Overview component: Loading bar at the top of the component instead of large loading message on top of the component [ID_33829]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.8 -->

When a Visual Overview component was loading, up to now, a large loading message was displayed on top of the component. From now on, when a Visual Overview component is loading, a loading bar will appear at the top of the component instead.

#### Element card - REPORTS page: Masking and unmasking not shown correctly in the different graphs [ID_33832]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

On the REPORTS page of an element card, masking and unmasking (i.e. state changes to "masked" and "unmasked") would not be shown correctly in the different graphs.

#### Alarm Console would incorrectly keep loading while the tickets linked to the alarms were being loaded [ID_33847]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you open DataMiner Cube, it will load the alarms and try to link the existing tickets to them so it can show the ticket information in the Alarm Console.

While this process was ongoing, in some rare cases, the Alarm Console would incorrectly keep on loading.

#### Dashboards app - Service definition component: Function nodes not displaying number of Process Automation tokens in queue or in progress [ID_33848]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a Process Automation definition was added to a *Service definition* component, the function nodes would not display the number of tokens currently in queue or in progress.

#### SNMPv3 credentials would incorrectly be checked when replicating an element with SNMPv3 connections [ID_33859]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you replicated an element with SNMPv3 connections, the SNMPv3 credentials of that element would incorrectly be checked. As a result, alarms like the following one would appear in the Alarm Console:

```txt
Load Element Failed: Error parsing SNMPv3 password for element: <element name>
```

#### Alarm Console: Problem when loading [ID_33860]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an exception could be thrown while the Alarm Console was loading.

#### Alarm Console: Cube could become unresponsive when a large number of alarms were being added and removed in an alarm tab of type 'sliding window' [ID_33870]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in an alarm tab of type "sliding window", a large number of alarms were being added and removed, in some cases, DataMiner Cube could become unresponsive.

#### System Center: Element counter on Agents > Status tab would not be set to 0 when removing all elements from a DMA [ID_33885]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you go to *System Center > Agents > Status*, the *Elements* column shows you how many elements are being hosted by each agent in the DMS.

When, on a particular agent, you removed all elements, the number of elements of that agent would incorrectly not be set to 0. Instead, it would be set to the last-known number of elements on that agent before the element were removed.

#### SLProtocol could leak memory when the NT_UPDATE_PORTS_XML command was sent [ID_33891]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, the SLProtocol process could leak memory when the NT_UPDATE_PORTS_XML command was sent.

#### Certain types of alarms could affect and degrade an SLA [ID_33899]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an alarm of one the following types was generated, in some cases, that alarm could affect and degrade an SLA or be added to the list of active alarms for that SLA (i.e. enhanced service):

- Information Event
- Suggestion Event
- Error Alarm
- Notice Alarm

#### SLSNMPManager: StackOverflow exception while trying to resolve the next Request ID [ID_33901]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, SLSNMPManager could throw a StackOverflow exception while trying to resolve the next Request ID.

#### Spectrum analysis: Recording icon would no longer be displayed while making a spectrum recording [ID_33904]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

While making a spectrum recording, in some cases, the recording icon would no longer be displayed.

#### Visual Overview: Wait cursor would still be displayed after the scripts had already finished [ID_33911]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in Visual Overview, you clicked a shape that executed two Automation scripts, the cursor would incorrectly still be displayed as a wait cursor after the two scripts had already finished.

#### Spectrum analysis: Issues when playing a spectrum recording [ID_33918]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a spectrum recording was being played, the following issues could occur:

- The *Forward* and *Backward* buttons would not work after starting and pausing the recording.
- When you adapted the speed of the recording, the new speed would incorrectly only be applied to the next frame and not to the current frame.
- When the recording was being played, the slider could incorrectly not be used.

#### Problems when exporting tables with an IncludedPids option or with a ClientSideRowFilter [ID_33934]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, tables that had the *IncludedPids* option defined would have their data exported to a CSV file incorrectly.

Also, when a table to which a ClientSideRowFilter was applied was exported to a CSV file, up to now, that filter would not be taken into account.

#### Spectrum analysis: Maximum, minimum and average trace would disappear after skipping backward when playing a spectrum recording [ID_33942]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you play a spectrum recording, you can pause the playback and use controls to skip forward or backward. In some cases, after skipping backward, the maximum, minimum and average trace would incorrectly disappear.

#### Alarm Console: Column list not shown when hovering over the 'Add/Remove column' menu command [ID_33967]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you right-clicked a column header in an alarm tab and hovered over the *Add/Remove column* command, in some cases, the column list would incorrectly not be shown if, previously, you had right-clicked the header of the focus column or a header of an action column.

#### Data Display : Update of parameter unit would not be reflected in the UI when the element card was open [ID_34007]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an element card was open on the DATA page, and a parameter on that page had its unit changed (e.g. via an Automation script), that change would incorrectly not be reflected in the UI. To see the new unit, you had to close the element card and re-open it.

#### An alarm property with a name identical to that of an element, service of view property would incorrectly get duplicated when the element with that alarm property was restarted [ID_34021]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you created an alarm property with a name identical to an existing property of an element, service or view, that alarm property would incorrectly be duplicated each time the element with that alarm property was restarted.

> [!NOTE]
> When upgrading to v10.2.0 [CU6] or v10.2.9, an upgrade action will check the *PropertyConfiguration.xml* file for any issues with duplicate properties and correct them.

#### DataMiner upgrade: Upgrade action 'DeletePreRN28047CustomDataTemplates' would fail when Elasticsearch required authentication [ID_34029]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

During a DataMiner upgrade, the upgrade action *DeletePreRN28047CustomDataTemplates* would fail when Elasticsearch required authentication.

#### Connected DMA removed from cluster instead of selected DMA in System Center [ID_34035]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In System Center, when you clicked the *Leave cluster* button on the *Agents* page, this removed the DMA you were connected to from the cluster instead of the selected DMA.

#### Problem with SLSNMPManager when an SNMP Get or Set was put on the queue while the element in question was being stopped [ID_34038]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, an error could occur in the SLSNMPManager process due to an SNMP Get or Set having been put on the queue while the element in question was being stopped.

#### EPM: Incorrect alarm color shown for EPM shapes in Visual Overview [ID_34039]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, to resolve the monitoring state of EPM shapes displayed in Visual Overview, the source table of the EPM front end was used, which could cause an incorrect alarm color to be shown for such shapes. Now, the source table of the back end is used instead, as this is the table the monitoring is applied to.

#### GQI: No longer possible to select another row after collapsing a group containing a selected row [ID_34042]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When, in a GQI table, you collapsed a group that contained a selected row, it was no longer possible to select another row.

#### GQI: Problem when filtering or aggregating data by custom properties [ID_34058]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, it would no longer be possible to build a GQI query that filtered or aggregated data by custom properties.

#### Incorrect instance alarm level after restart and for view tables [ID_34063]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Since DataMiner 10.1.8 (RN [30044](xref:General_Feature_Release_10.1.8#instancealarmlevel-would-not-fall-back-to-cellactualalarmlevel-when-there-was-bubble-up-information-but-no-instance-information-id_30044)), it could occur that the instance alarm level for a table row did not bubble up correctly, causing alarms for view tables to be displayed incorrectly (e.g. in an EPM environment). This could also occur for tables with an alarm where no saved data was present.

#### Potential minor memory leak in SLProtocol if fixed parameter had length of zero [ID_34064]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If a fixed parameter had a length of zero, a minor memory leak could potentially occur in SLProtocol. Though it is unlikely that this could ever happen, as a fixed parameter usually contains data, this issue will now be prevented.

#### Logger tables not deleted when stopped element was deleted [ID_34067]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a stopped element was deleted, logger tables associated with that element would incorrectly not be deleted if created with `options="database"`.

#### Scheduled task corrupted after it was edited [ID_34084]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When an existing scheduled task that was configured to be executed multiple times per day was edited, it could occur that the task was corrupted and could no longer be executed.

#### GQI: Regex filter on empty cell not working correctly [ID_34088]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a filter with a regular expression was applied to an empty cell of a GQI query, it could occur that this did not work correctly. This issue only occurred for custom columns of a DOM instance and for custom data sources.

#### No alarms shown with alarm filter on property value filtering the alarms before they entered Cube [ID_34090]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If an alarm filter that filtered on a property value was used to filter the alarms before they entered Cube, it could occur that no alarms were shown, even if there were alarms matching the filter.

#### GQI queries: Problem when removing a query used as 'start from' query [ID_34093]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an exception could be thrown when removing a query that was used as "start from" query by another query.

From now on, when you try to remove a query that is used as "start from" query, a confirmation box will appear, asking you to confirm the removal of that query.

#### DataMiner Cube: Spectrum recording icon not shown while recording [ID_34097]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a spectrum recording is started, an icon should be shown to the right below the trace to indicate that a recording is being created. However, when the mouse pointer was moved outside the trace area, it could occur that this icon was no longer shown.

#### Visual overview in dashboard or low-code app showed error while fetching its initial data [ID_34100]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a visual overview was embedded in a dashboard or low-code app, it could occur that it showed the error "Could not retrieve Visual Overview information." while fetching its initial data.

#### Visual Overview: Non-linked shape without LinkOptions shape data field not displayed [ID_34102]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If a shape was not linked to a DataMiner object and did not have a *LinkOptions* shape data field, it could occur that the shape was not displayed in Visual Overview.

#### GQI queries: Problem in web APIs when opening session for query with node requiring soft-launch feature [ID_34109]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In the Dashboards app or in a low-code app, when you tried to open a session for a GQI query containing a node that required a soft-launch feature, a problem could occur in the web APIs. Now an error will be shown in such a case instead.

#### GQI queries: Component data not displayed correctly [ID_34118]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a component in a dashboard or low-code app showed a GQI query, it could occur that queries and query keys were not in sync, and that data was still being fetched even though the component seemed to be fully loaded. This could for example cause connections to be missing in a node-edge graph.

#### Navigation issue in visual overview with several tab pages and shapes linked to EPM object [ID_34122]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In a visual overview with several tab pages and shapes linked to an EPM object, if you clicked a shape that opened an EPM object, then clicked the Back button, and then clicked a shape to navigate to another tab page in the same visual overview, this did not work.

#### Dashboards app - GQI: Query columns would incorrectly not get highlighted when clicking the filter icon [ID_34127]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version TBD -->

When you clicked the filter icon of a table component, the query filter's column data would incorrectly not get highlighted in the *Feeds* data set.

#### 'Clear all' button not available for EPM topology chain [ID_34133]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you make a selection in an EPM topology chain, a *Clear all* button becomes available, which allows you to clear the selection again. However, in some cases, this button disappeared again. This was specifically the case when you opened a card of a certain level in the chain, closed this card, and then opened another card from the chain, other than the previous card.

#### Problem in SLElement when updating table with parameters used in advanced naming [ID_34135]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version TBD -->

When a table was updated that contained parameters used in advanced naming, a problem could occur in SLElement.

#### GQI queries: Unhandled exception kept other errors from being displayed [ID_34137]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some cases, an unhandled exception in the GQI visualization could keep other errors from being displayed in the UI.

#### DataMiner Cube: Workspace with EPM view card showed incorrect page when loaded [ID_34163]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you loaded a workspace containing the card of a view linked to EPM, it could occur that the card did not show the page saved in the workspace but instead the default "Visual" page.

#### Problem in SLElement when element was dynamically included in service multiple times with partially included parameter set [ID_34185]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 [CU2] -->

When an element was dynamically included in a service multiple times with a partially included parameter set, a problem could occur in SLElement while parsing the information received from SLDataMiner.

#### GQI: Requesting property values would incorrectly only return values cached on the local DataMiner Agent [ID_34253]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 [CU0] -->

When a GQI query requested property values by means of a GetPropertyValueMessage, some values could be missing as SLNet would only return values that were cached on the local DataMiner Agent. From now on, when a GQI query requests property values, the request will be sent to all running agents in the cluster.

#### SPI framework: Run-time errors could occur in SLDataMiner when tracking user actions [ID_34259]

<!-- Main Release Version 10.2.0 [CU6] - Feature Release Version 10.2.9 [CU0] -->

Due to a problem with the SPI framework, in some cases, run-time errors could occur in SLDataMiner when tracking user actions.

#### SNMP polling issues in case protocol contained wildcards in parameter OIDs [ID_34343]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 [CU1] -->

In some specific cases, wildcards in the parameter OIDs in a protocol caused polling to return no data. This only occurred when a parameter with a wildcard OID referred to another parameter that was not displayed.
