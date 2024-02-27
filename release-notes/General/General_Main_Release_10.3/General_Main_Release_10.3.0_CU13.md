---
uid: General_Main_Release_10.3.0_CU13
---

# General Main Release 10.3.0 CU13 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Circular correlation rules will now be blocked [ID_38301]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

A correlation rule will now be blocked when it was triggered due to a correlated alarm that depends on an alarm created by the rule in question.

> [!NOTE]
> ​This feature only works when the correlation rule and all alarms in question reside on the same DataMiner Agent.

#### Enhanced performance when applying a table filter subscription containing wildcards and when applying a partial table cell subscription [ID_38555]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Because of a number of enhancements, overall performance has increased

- when applying an initial table filter subscription containing wildcards that needs to be handled by the SLElement process, and
- when applying a subscription of a partial table cell.

#### GQI: Clearer error message will now be thrown when an ad hoc data source or custom operator cannot be instantiated [ID_38686]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, when an ad hoc data source or custom operator could not be instantiated, the following exception would be thrown when an error occurred on object creation level (within the constructor):

`Error: Could not create instance of datasource when trying to use an ad hoc datasource.`

From now on, the following exception will be thrown instead:

`Error trapped: Could not create instance of datasource 'datasource ID': <exception message>.`

\* `<exception message>` being the message that was thrown within the constructor.

#### SLLogCollector will now also collect the logs of the CommunicationGateway DxM [ID_38716]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

SLLogCollector will now also collect the logs of the *CommunicationGateway* DxM.

#### Security enhancements [ID_38756]

<!-- RN 38756: MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

A number of security enhancements have been made.

#### SLProtocol will no longer forward all changes to standalone parameters to SLElement [ID_38785]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, SLProtocol would forward all changes to standalone parameters to SLElement, even when this was not strictly necessary. From now on, SLProtocol will only forward changes to standalone parameters to SLElement when the latter requires them.

Also, when an SNMP parameter used a wildcard as OID, up to now, SLProtocol would forward the value of that wildcard to SLElement, which would then pass it on to the SLSNMPManager process. From now on, SLProtocol will forward those wildcard values directly to SLSNMPManager.

### Fixes

#### Problem when a redundancy group was set to an undefined state [ID_38401]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When a redundancy group was set to an undefined state, a large number of empty connectivity contexts would be inserted into the *Connectivity* section of the *redundancy.xml* file. As a result, the correct connectivity contexts would be overwritten, causing the redundancy group to be stuck in the undefined state.

#### Problem with file offload mechanism when main database is offline [ID_38542]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When the main database is offline, file offloads are used to store write/delete operations. In some cases, this file offload mechanism could end up in an unrecoverable state due to a threading issue.

#### Hostname of SNMP element would not get resolved after the element had gone into timeout [ID_38547]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When an element with an SNMP connection that was configured with a hostname instead of an IP address went into timeout, and during the timeout the hostname could not be resolved, the element would remain in timeout and would no longer try to resolve the hostname until it was restarted.

Also, in StreamViewer, the error messages that indicate that the hostname could not be resolved have now been made clearer. For example, in case of SNMPv3, a generic `DISCOVERY FAILED` error would appear when something went wrong while setting up a connection. From now on, the error will indicate what exactly went wrong (e.g. the engine ID could not be discovered, the user credentials were not valid, etc.).

#### Problem with SLProtocol when calculating the length of a serial response [ID_38591]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

In some cases, SLProtocol could stop working due to an `Access violation reading location` error being thrown while calculating the length of a serial response.

#### GQI: Problem when sorting DOM instances when the column by which you sorted contained null values [ID_38592]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When DOM instances were sorted, in some cases, an error could be thrown when the column by which you sorted contained null values.

#### Problem when a DataMiner Cube client tried to connect using gRPC [ID_38606]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When a DataMiner Cube client tried to connect to a DataMiner Agent using gRPC, in some rare cases, a disconnect could occur with the following error:

`Some messages have probably gone lost. Waiting for X while X+20 already entered.`

#### SLAnalytics - Automatic incident tracking: Problem when updating alarm groups [ID_38629]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Each time the focus score of an alarm is updated, incident tracking has to update its alarm groups. In some cases, incident tracking would incorrectly update its groups twice, causing the groups to be set to an undefined state.

#### Service & Resource Management: Booking corrupted after SRM_QuarantineHandling retrieved incorrect version of the booking [ID_38646]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, it could occur that the script *SRM_QuarantineHandling* retrieved a previous version of a booking instead of the latest, quarantined version, which could cause subsequent updates to corrupt the booking object. To prevent this, *SRM_QuarantineHandling* will now be called after a booking is saved.

#### Errors would be thrown at DataMiner startup when production protocols had an information template assigned [ID_38683]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

At DataMiner startup, in some cases, errors could incorrectly be thrown when at least one production protocol had an information template assigned.

#### Paused element set back to the active state would no longer receive any alarm updates [ID_38744]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When a paused element was set back to the "started" state, it would no longer receive any alarm updates until it was restarted.

#### DataMiner Maps: KML layers would incorrectly always be displayed first in the legend [ID_38746]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When using either Google Maps or OpenStreetMap, KML layers would incorrectly always be displayed first in the layer legend, regardless of the order in which they were specified in the map configuration file.

From now on, the legend will always show the layers in the order in which they were specified in the map configuration file.

#### Failover: Memory leak when invoking PowerShell scripts [ID_38763]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

On Failover systems using a shared hostname, SLNet regularly executes PowerShell scripts. However, invoking those scripts would cause a memory leak. To prevent this, each PowerShell script will now be run in a separate process, which will be terminated at the end of the script.

#### Automation: Problem when sending an email to a user or group [ID_38844]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When an Automation script sent an email to a user or a user group using an *Email* action, in some cases, an error could be thrown.

#### Problem with SLProtocol when it took longer than 15 minutes to execute a poll group [ID_38858]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

When an element used SNMP or HTTP communication, a notification would only be sent to SLWatchdog when a poll group finished executing. As a result, when it took longer than 15 minutes to execute a poll group, an SLProtocol run-time error alarm would be generated and subsequently cleared when the poll group finished.

In order to avoid such run-time error alarms from being generated, a check will now be performed when a response is received, and an additional notification will be sent to SLWatchdog when the first notification to SLWatchdog was sent more than one minute ago.
