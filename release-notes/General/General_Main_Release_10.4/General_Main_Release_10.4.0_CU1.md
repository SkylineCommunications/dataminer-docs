---
uid: General_Main_Release_10.4.0_CU1
---

# General Main Release 10.4.0 CU1 - Preview

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Automation: Late script control requests will now be ignored [ID_38409]

<!-- MR 10.4.0 [CU1] - FR 10.4.4 -->

From now on, SLAutomation will ignore any script control request it receives for a script that is not running or not running anymore, and will add an entry in the SLAutomation.txt log file when it does so.

Examples of new log entries:

- DEBUG (5): `Handling script command 'Continue' (2) for script with ID 954.`
- ERROR (-1): `Handling command 'Continue' (2) for script with ID 954 failed with error code 2147942487.`
- ERROR (-1): `Handling command 'Continue' (2) for script with ID 954 failed because it is not interactive.`
- INFO (-1): `Handling command 'Continue' (2) for script with ID 954 failed because it is not active.`

In the latter case, no error would be returned up to now.

#### Service & Resource Management: Booking name validation now case-insensitive [ID_38556]

<!-- MR 10.4.0 [CU1] - FR 10.4.4 -->

The validation of the name of a booking is now case-insensitive. This means that when the SRM Framework checks if there are future bookings with the same name, the casing is now no longer taken into account.

#### SLAnalytics - Behavioral anomaly detection: Suggestion event generation will now be limited [ID_38674]

<!-- MR 10.4.0 [CU1] - FR 10.4.4 -->

From now on, the generation of anomaly suggestion events will be limited to 50 events per hour per type of anomaly (level shift, trend change, flatline or variance change).

> [!NOTE]
> The generation of anomaly alarm events (i.e. on parameters that have anomaly monitoring configured in the alarm template) will remain unlimited.

#### GQI: Clearer error message will now be thrown when an ad hoc data source or custom operator cannot be instantiated [ID_38686]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, when an ad hoc data source or custom operator could not be instantiated, the following exception would be thrown when an error occurred on object creation level (within the constructor):

`Error: Could not create instance of datasource when trying to use an ad hoc datasource.`

From now on, the following exception will be thrown instead:

`Error trapped: Could not create instance of datasource 'datasource ID': <exception message>.`

\* `<exception message>` being the message that was thrown within the constructor.

#### SLLogCollector will now also collect the logs of the CommunicationGateway DxM [ID_38716]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

SLLogCollector will now also collect the logs of the *CommunicationGateway* DxM.

#### Security enhancements [ID_38756]

<!-- RN 38756: MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

A number of security enhancements have been made.

### Fixes

#### Problem with file offload mechanism when main database is offline [ID_38542]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When the main database is offline, file offloads are used to store write/delete operations. In some cases, this file offload mechanism could end up in an unrecoverable state due to a threading issue.

#### Hostname of SNMP element would not get resolved after the element had gone into timeout [ID_38547]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When an element with an SNMP connection that was configured with a hostname instead of an IP address went into timeout, and during the timeout the hostname could not be resolved, the element would remain in timeout and would no longer try to resolve the hostname until it was restarted.

Also, in StreamViewer, the error messages that indicate that the hostname could not be resolved have now been made clearer. For example, in case of SNMPv3, a generic `DISCOVERY FAILED` error would appear when something went wrong while setting up a connection. From now on, the error will indicate what exactly went wrong (e.g. the engine ID could not be discovered, the user credentials were not valid, etc.).

#### SLAnalytics - Pattern matching: A match of one subpattern would incorrectly be considered a match of the entire multivariate pattern [ID_38587]

<!-- MR 10.4.0 [CU1] - FR 10.4.3 -->

When the streaming method was being used, a match detected for one subpattern of a multivariate pattern would incorrectly be considered a match of that entire multivariate pattern.

Although the suggestion events were generated correctly, the pattern matches would not be indicated correctly on the trend graphs.

#### Problem with SLProtocol when calculating the length of a serial response [ID_38591]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

In some cases, SLProtocol could stop working due to an `Access violation reading location` error being thrown while calculating the length of a serial response.

#### GQI: Problem when sorting DOM instances when the column by which you sorted contained null values [ID_38592]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When DOM instances were sorted, in some cases, an error could be thrown when the column by which you sorted contained null values.

#### SLAnalytics - Automatic incident tracking: Problem when updating alarm groups [ID_38629]

<!-- MR 10.3.0 [CU13] / 10.4.0 [CU1] - FR 10.4.4 -->

Each time the focus score of an alarm is updated, incident tracking has to update its alarm groups. In some cases, incident tracking would incorrectly update its groups twice, causing the groups to be set to an undefined state.

#### Service & Resource Management: Booking corrupted after SRM_QuarantineHandling retrieved incorrect version of the booking [ID_38646]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, it could occur that the script *SRM_QuarantineHandling* retrieved a previous version of a booking instead of the latest, quarantined version, which could cause subsequent updates to corrupt the booking object. To prevent this, *SRM_QuarantineHandling* will now be called after a booking is saved.

#### SLAnalytics - Behavioral anomaly detection: Problem when updating the anomaly configuration for a DVE element [ID_38661]

<!-- MR 10.4.0 [CU1] - FR 10.4.4 -->

When you had updated the anomaly configuration for a DVE element, SLAnalytics would not process the changes correctly, causing incorrect behavioral anomaly alarms to be generated.

#### DataMiner upgrade: Some folders would not get cleaned up when performing an upgrade [ID_38672]

<!-- MR 10.4.0 [CU1] - FR 10.4.4 -->

Up to now, the following folders would incorrectly not get cleaned up when performing a DataMiner upgrade:

- `C:\Skyline DataMiner\Webpages\API\bin`
- `C:\Skyline DataMiner\Webpages\Maps\bin`

#### Errors would be thrown at DataMiner startup when production protocols had an information template assigned [ID_38683]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

At DataMiner startup, in some cases, errors could incorrectly be thrown when at least one production protocol had an information template assigned.

#### SLAnalytics: Problem when processing an element with an invalid alarm template [ID_38724]

<!-- MR 10.4.0 [CU1] - FR 10.4.4 -->

In some cases, SLAnalytics could stop working while processing an element with an invalid alarm template.

#### DataMiner Maps: KML layers would incorrectly always be displayed first in the legend [ID_38746]

<!-- MR 10.3.0 [CU12] / 10.4.0 [CU1] - FR 10.4.4 -->

When using either Google Maps or OpenStreetMap, KML layers would incorrectly always be displayed first in the layer legend, regardless of the order in which they were specified in the map configuration file.

From now on, the legend will always show the layers in the order in which they were specified in the map configuration file.
