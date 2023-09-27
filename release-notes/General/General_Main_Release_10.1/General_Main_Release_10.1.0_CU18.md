---
uid: General_Main_Release_10.1.0_CU18
---

# General Main Release 10.1.0 CU18

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

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

#### DVE function protocol version of active functions will now be deleted when the main DVE protocol version is deleted [ID_33834]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When a version of a DVE protocol with function DVE protocols is deleted from the system while functions are active, from now on, the function DVE protocol versions associated with those active functions will also be removed from the system.

#### Alarm Console: Time of history sets will now always be converted to the local time zone [ID_33849]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

From now on, the time of history sets will always be converted to the local time zone.

#### SLLogCollector: Enhanced processing of SLProtocol memory dumps [ID_33932]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, SLLogCollector is now better able to collect SLProtocol memory dumps, especially in cases where there is no reference to an element.

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

### Fixes

#### SLAnalytics - Pattern matching: No 'suggestion event' type alarm would be triggered in case of DVE elements [ID_32671]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.5 -->

From DataMiner 10.0.13 onwards, you can activate alarm monitoring of trend patterns, so that a "suggestion event" type alarm is triggered whenever a specific pattern is detected. In case of dynamic virtual elements, in some cases, no "suggestion event" type alarm would be triggered.

#### SLLogCollector would become unresponsive when the name of the process or the path where the files had to be stored contained spaces [ID_33493]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

While collecting log information, SLLogCollector would become unresponsive when the name of the process or the path where the collected files had to be stored contained spaces.

#### Trending: Creation, update and deletion of a trend pattern would not be communicated to the other DataMiner Agents in the DMS [ID_33624]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU5] - Feature Release Version 10.2.8 -->

When you created, updated or deleted a tag, up to now, this would incorrectly not be communicated to the other DataMiner Agents in the DMS.

#### Monitoring app: Trend graph of table column parameter not displayed when table row index contained forward slash [ID_33661]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 -->

In the Monitoring app, the trend graph of a table column parameter would not be displayed when the table row index contained a forward slash.

#### SLProtocol would leak memory leak each time a parameter of a replicated element was updated [ID_33745]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

SLProtocol would leak memory each time a parameter of a replicated element was updated.

#### Problem with SLElement when resolving foreign keys took a long time and the the element debug log level was equal to or higher than 1 [ID_33826]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When the element debug log level was equal to or higher than 1, an error could occur in SLElement when resolving foreign keys took a long time.

#### Element card - REPORTS page: Masking and unmasking not shown correctly in the different graphs [ID_33832]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

On the REPORTS page of an element card, masking and unmasking (i.e. state changes to "masked" and "unmasked") would not be shown correctly in the different graphs.

#### Alarm Console would incorrectly keep loading while the tickets linked to the alarms were being loaded [ID_33847]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you open DataMiner Cube, it will load the alarms and try to link the existing tickets to them so it can show the ticket information in the Alarm Console.

While this process was ongoing, in some rare cases, the Alarm Console would incorrectly keep on loading.

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

#### Connected DMA removed from cluster instead of selected DMA in System Center [ID_34035]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In System Center, when you clicked the *Leave cluster* button on the *Agents* page, this removed the DMA you were connected to from the cluster instead of the selected DMA.

#### Problem with SLSNMPManager when an SNMP Get or Set was put on the queue while the element in question was being stopped [ID_34038]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In some rare cases, an error could occur in the SLSNMPManager process due to an SNMP Get or Set having been put on the queue while the element in question was being stopped.

#### EPM: Incorrect alarm color shown for EPM shapes in Visual Overview [ID_34039]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Up to now, to resolve the monitoring state of EPM shapes displayed in Visual Overview, the source table of the EPM front end was used, which could cause an incorrect alarm color to be shown for such shapes. Now, the source table of the back end is used instead, as this is the table the monitoring is applied to.

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

#### No alarms shown with alarm filter on property value filtering the alarms before they entered Cube [ID_34090]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If an alarm filter that filtered on a property value was used to filter the alarms before they entered Cube, it could occur that no alarms were shown, even if there were alarms matching the filter.

#### Visual Overview: Non-linked shape without LinkOptions shape data field not displayed [ID_34102]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

If a shape was not linked to a DataMiner object and did not have a *LinkOptions* shape data field, it could occur that the shape was not displayed in Visual Overview.

#### Navigation issue in visual overview with several tab pages and shapes linked to EPM object [ID_34122]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

In a visual overview with several tab pages and shapes linked to an EPM object, if you clicked a shape that opened an EPM object, then clicked the Back button, and then clicked a shape to navigate to another tab page in the same visual overview, this did not work.

#### 'Clear all' button not available for EPM topology chain [ID_34133]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you make a selection in an EPM topology chain, a *Clear all* button becomes available, which allows you to clear the selection again. However, in some cases, this button disappeared again. This was specifically the case when you opened a card of a certain level in the chain, closed this card, and then opened another card from the chain, other than the previous card.

#### Problem in SLElement when updating table with parameters used in advanced naming [ID_34135]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version TBD -->

When a table was updated that contained parameters used in advanced naming, a problem could occur in SLElement.

#### DataMiner Cube: Workspace with EPM view card showed incorrect page when loaded [ID_34163]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

When you loaded a workspace containing the card of a view linked to EPM, it could occur that the card did not show the page saved in the workspace but instead the default "Visual" page.

#### Problem in SLElement when element was dynamically included in service multiple times with partially included parameter set [ID_34185]

<!-- Main Release Version 10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.8 [CU2] -->

When an element was dynamically included in a service multiple times with a partially included parameter set, a problem could occur in SLElement while parsing the information received from SLDataMiner.

#### SNMP polling issues in case protocol contained wildcards in parameter OIDs [ID_34343]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU18]/10.2.0 [CU6] - Feature Release Version 10.2.9 [CU1] -->

In some specific cases, wildcards in the parameter OIDs in a protocol caused polling to return no data. This only occurred when a parameter with a wildcard OID referred to another parameter that was not displayed.
