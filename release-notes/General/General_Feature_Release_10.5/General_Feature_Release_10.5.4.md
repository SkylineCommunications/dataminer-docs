---
uid: General_Feature_Release_10.5.4
---

# General Feature Release 10.5.4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.4](xref:Cube_Feature_Release_10.5.4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.4](xref:Web_apps_Feature_Release_10.5.4).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [Elements can now be configured to run in isolation mode [ID 41757]](#elements-can-now-be-configured-to-run-in-isolation-mode-id-41757)

## New features

#### Elements can now be configured to run in isolation mode [ID 41757]

<!-- MR 10.6.0 - FR 10.5.4 -->

Up to now, the *ProcessOptions* section of the *DataMiner.xml* file allowed you to configure that an element had to run in its own SLProtocol and SLScripting processes, and in a *protocol.xml* file, the *RunInSeparateInstance* tag allowed you to do the same. However, it was only possible to configure this for all elements using a particular protocol.

From now on, the new *Run in isolation mode* feature will allow you to also configure this for one single element. For more information on how to configure this in DataMiner Cube, see [Elements can now be configured to run in isolation mode [ID 41758]](xref:Cube_Feature_Release_10.5.4#elements-can-now-be-configured-to-run-in-isolation-mode-id-41758).

As creating additional SLProtocol processes has an impact on the resource usage of a DataMiner Agent, a hard limit of 50 SLProtocol processes has been introduced. If, when an element starts, an attempt to create a new SLProtocol process fails because 50 processes are already running, the element will be hosted by an existing SLProtocol process and its matching SLScripting process, regardless of how the *Run in isolation mode* was configured.

From those 50 SLProtocol processes, 10 processes will be reserved for elements that are not running in isolation mode. This means, that only 40 elements will be able to run in isolation mode at any given time. However, the notice that will appear each time an attempt is made to start an additional element in isolation mode will mention the 50-element limit.

Reducing the number of SLProtocol processes in the *DataMiner.xml* file will reduce the number of reserved processes. However, increasing the number of SLProtocol processes to above 50 will keep the reserved number of SLProtocol processes to 50 (i.e. the maximum number of SLProtocol processes).

For example, if 15 SLProtocol processes are configured in the *DataMiner.xml* file, and 45 elements are configured to run in isolation mode, then:

- 10 SLProtocol processes will be used for elements that are not running in isolation mode,
- 35 SLProtocol processes will be used to host an element in isolation mode, and
- the remaining 5 SLProtocol processes will be used for elements running either in isolation mode or not, depending on which elements starts first.

This means, that some elements will not be able to run in isolation mode, and some SLProtocol processes will not be able to host elements that are not running in isolation mode. In each of those cases, an alarm will be generated.

In the *DataMiner.xml* file, it is possible to configure a separate SLProtocol process for every protocol that is being used. This setting will also comply with the above-mentioned hard limit of 50 SLProtocol processes. As this type of configuration is intended for testing/debugging purposes only, an alarm will be generated when such a configuration is active to avoid that this setting would remain active once the investigation is done.

See also [RunInIsolationModeConfig property added to SLNet messages ElementInfoEventMessage and LiteElementInfoEvent [ID 42247]](#runinisolationmodeconfig-property-added-to-slnet-messages-elementinfoeventmessage-and-liteelementinfoevent-id-42247)

For more information on how to configure elements to run in isolation mode in DataMiner Cube, see [Elements can now be configured to run in isolation mode [ID 41758]](xref:Cube_Feature_Release_10.5.4#elements-can-now-be-configured-to-run-in-isolation-mode-id-41758).

#### Information events of type 'script started' will no longer be generated when an Automation script is triggered by the Scheduler app [ID 41970]

<!-- MR 10.6.0 - FR 10.5.4 -->

From now on, by default, information events of type "script started" will no longer be generated when an Automation script is triggered by the Scheduler app.

In other words, when an Automation script is triggered by the Scheduler app, the SKIP_STARTED_INFO_EVENT:TRUE option will automatically be added to the `ExecuteScriptMessage`. See also [Release note 33666](xref:General_Main_Release_10.3.0_new_features_1#added-the-option-to-skip-the-script-started-information-event-id-33666).

If you do want such information events to be generated, you can add the `SkipInformationEvents` option to the *MaintenanceSettings.xml* file and set it to false:

```xml
<MaintenanceSettings xmlns="http://www.skyline.be/config/maintenancesettings">
    ...
    <SLNet>
        ...
        <SkipInformationEvents>false</SkipInformationEvents>
        ...
    </SLNet>
    ...
</MaintenanceSettings>
```

#### SLNetClientTest tool: Element process ID information [ID 42013]

<!-- MR 10.6.0 - FR 10.5.4 -->

In the *SLNetClientTest* tool, you can now retrieve live information about the mapping between elements running on a DataMiner Agent and the processes they use, including SLProtocol and SLScripting. To do so, go to *Diagnostics > DMA > Element Process ID Info*.

The information provided is similar to the information found in the *SLElementInProtocol.txt* log file. It will allow you to monitor and troubleshoot process usage in real time.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Interactive automation scripts: UI components 'Calendar' and 'Time' can now retrieve the time zone and date/time settings of the client [ID 42064]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

When UI components of type *Calendar* or *Time* are used in interactive automation scripts, up to now, the entered date and time would be formatted depending on the platform and the configured settings. From now on, when an interactive Automation script is being run, the UI components of type *Calendar* and *Time* will be able to return the time zone of the client and the time and date as entered by the user.

To allow the client to return the time zone and client time and date, on the `UIBlockDefinition`, set the `ClientTimeInfo` option to `UIClientTimeInfo.Return`. This option is intended to be used for UI components of type *Calendar* or *Time* (the latter with either `AutomationDateTimeUpDownOptions`, `AutomationDateTimeUpDownOptions` or `AutomationDateTimePickerOptions`).

The result of the ShowUI command now includes the following new methods that can be used to request the time zone and date/time settings of the client:

- `TimeZoneInfo GetClientTimeZoneInfo(string destVar)`
- `DateTimeOffset GetClientDateTime(string destVar)`

##### TimeZoneInfo GetClientTimeZoneInfo(string destVar)

This method will return the time zone of the client for the UI component with the specified *destVar*.

It will return null if the component does not exist, if `ClientTimeInfo` is not set to `UIClientTimeInfo.Return`, or if the component does not support the information. If the time zone information provided by the client cannot be deserialized into a `TimeZoneInfo` object, a `SerializationException` will be thrown.

If this time zone information has to be stored for later use, consider the following:

- Use the `ToSerializedString()` method to get a string containing all details. Later, this information can then be restored by using `TimeZoneInfo.FromSerializedString(storedInfo)`.

  > [!NOTE]
  > The time zone information that is returned might not be the most recent and could result in incorrect time interpretations.

- Use the `Id` property, which can then be restored by using `TimeZoneInfo.FindSystemTimeZoneById(storedId)`.

  > [!NOTE]
  > The ID that is returned might not be available on the DataMiner Agent that is executing the Automation script.

For more info, see [Saving and restoring time zones](https://learn.microsoft.com/en-us/dotnet/standard/datetime/saving-and-restoring-time-zones)

##### DateTimeOffset GetClientDateTime(string destVar)

This method will return the date and time as it was entered in the UI block with the specified *destVar*, in the time zone of the client (taking into account the client's UTC offset). The `DateTime` property of the returned value will contain the the date and/or time in the user's time zone.

The returned value will be `DateTimeOffset.MinValue` if the component does not exist, if `ClientTimeInfo` is not set to `UIClientTimeInfo.Return`, or if the component does not support the information.

> [!IMPORTANT]
> Components that have `ClientTimeInfo` enabled should not have components with a *destVar* that contains "_DateTimeComponentClient".

#### Service & Resource Management: Configuring the script to be executed when a reservation goes into quarantine [ID 42067]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

Up to now, when a reservation went into quarantine, the *SRM_QuarantineHandling* script would always be executed. From now on, when you create a reservation, you will be able to specify the name of the quarantine script to be executed in the `QuarantineHandlingScriptName` property.

> [!NOTE]
>
> - If the `QuarantineHandlingScriptName` property contains Null, an empty string, white space, or "SRM_QuarantineHandling", the default *SRM_QuarantineHandling* script will be executed when the reservation goes into quarantine.
> - If multiple reservations go into quarantine after a resource or reservation update, the scripts configured on the different reservations will each be executed once for the reservations in question.

#### Relational anomaly detection: New messages to add, update or remove parameter groups in the configuration file [ID 42181] [ID 42276]

<!-- MR 10.6.0 - FR 10.5.4 -->

The following messages can be used to add, update or remove a parameter group from the configuration file, or to retrieve information for a particular parameter group from that configuration file:

- `AddMADParameterGroupMessage` allows you to add a parameter group to the Relational Anomaly Detection configuration file.

  If a group with the same name already exists, no new group will be added. Instead, the existing group will be updated.

- `RemoveMADParameterGroupMessage` allows you to remove a parameter group from the Relational Anomaly Detection configuration file.

- `GetMADParameterGroupInfoMessage` allows you to retrieve all configuration information for a particular group.

> [!NOTE]
> Names of RAD parameter groups will be processed case-insensitive.

#### RunInIsolationModeConfig property added to SLNet messages ElementInfoEventMessage and LiteElementInfoEvent [ID 42247]

<!-- MR 10.6.0 - FR 10.5.4 -->

A new `RunInIsolationModeConfig` property has been added to the SLNet messages `ElementInfoEventMessage` and `LiteElementInfoEvent`. This property will allow client applications to indicate if and how an element is configured to run in isolation mode.

The property can have one of the following values:

| Value    | Description |
|----------|-------------|
| None     | The element is not running in isolation mode. |
| Dma      | In the `ProcessOptions` section of the *DataMiner.xml* file, it has been specified that all elements using the protocol in question should be running in isolation mode. |
| Protocol | In the *protocol.xml* file, the `RunInSeparateInstance` tag specifies that all elements using the protocol in question should be running in isolation mode. |
| Element  | The element has been individually configured to run in isolation mode. |

If multiple settings indicate that the element should be running in isolation mode, the `RunInIsolationModeConfig` property will be set to one of the above-mentioned values in the following order of precedence: "Protocol", "Element", "Dma".

> [!NOTE]
>
> - If, in DataMiner Cube, you specified that a particular element had to run in isolation mode, the boolean property `RunInIsolationMode` will be true. In some cases, this boolean `RunInIsolationMode` property will be false, while the above-mentioned `RunInIsolationModeConfig` property will be set to "Protocol". In that case, the element will be running in isolation mode because it was configured to do on protocol level.
> - See also [Elements can now be configured to run in isolation mode [ID 41757]](#elements-can-now-be-configured-to-run-in-isolation-mode-id-41757)

#### Relational anomaly detection: New group argument 'minimumAnomalyDuration' [ID 42283]

<!-- MR 10.6.0 - FR 10.5.4 -->

Per DataMiner Agent, the RAD parameter groups must be configured in the `C:\Skyline DataMiner\Analytics\RelationalAnomalyDetection.xml` file, which must be formatted as follows.

```xml
<?xml version="1.0" ?>
  <RelationalAnomalyDetection>
    <Group name="[GROUP_NAME]" updateModel="[true/false]" anomalyScore="[THRESHOLD]" minimumAnomalyDuration="[THRESHOLD2]">
      <Instance>[INSTANCE1]</Instance>
      <Instance>[INSTANCE2]</Instance>
      [... one <Instance> tag per parameter in the group]
    </Group>
    [... one <Group> tag per group of parameters that should be monitored by RAD]
</RelationalAnomalyDetection>
```

Each `<Group>` tag can now have an additional `minimumAnomalyDuration` argument.

This optional argument will specify the minimum duration (in minutes) that deviating behavior must persist to be considered a significant anomaly. Default value: 5

- When `minimumAnomalyDuration` is set to a value greater than 5, the deviating behavior will need to last longer before an anomaly event is triggered.
- `minimumAnomalyDuration` can be set to a non-default value, for example, to filter out noise events caused by a single, short, harmless outlying value in the data.
- If `minimumAnomalyDuration` is either not set or set to a value less than or equal to 5, an anomaly event will be generated as soon as values deviate sufficiently from the RAD model.

## Changes

### Enhancements

#### Security enhancements [ID 41425] [ID 41913] [ID 42104] [ID 42343]

<!-- 41425: MR 10.6.0 - FR 10.5.4 -->
<!-- 41913: MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->
<!-- 42104: MR 10.5.0 [CU1] - FR 10.5.4 -->
<!-- 42343: MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of security enhancements have been made.

#### Enhanced performance when updating subscriptions and when checking events against the set of active subscriptions [ID 41822]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

Because of a number of enhancements, overall performance has increased when updating subscriptions and when checking events against the set of active subscriptions.

#### Credentials library is now fully aware of all supported SNMPv3 authentication and encryption algorithms [ID 41923]

<!-- MR 10.6.0 - FR 10.5.4 -->
<!-- Reverted by RN 42136 and reinstated by RN 42153 -->

Up to now, the credentials library would only be aware of a subset of all SNMPv3 authentication and encryption algorithms.

Because of a number of enhancements, it will now be fully aware of all supported algorithms.

#### Service & Resource Management: Enhanced handling of locked files when activating or deactivating functions [ID 41978]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of enhancements have been made to the ProtocolFunctionManager with regard to the handling of locked files when activating or deactivating functions.

#### Suggestion events created by Relational anomaly detection for a group of parameters will now be grouped into a single incident [ID 41983]

<!-- MR 10.6.0 - FR 10.5.4 -->

When Relational anomaly detection (RAD) detects that a group of parameters deviates from its normal behavior, it will create a suggestion event for each of the parameters in that group. These suggestion events will now be grouped into a single incident so that it is shown on a single line in the Alarm Console.

When you clear such an incident, all its base alarms (i.e. the suggestion events created by Relational anomaly detection) will also be cleared.

#### NATS: NatsCustodianResetNatsRequest will now be blocked when the NATSForceManualConfig option is enabled [ID 42074]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

When the `NATSForceManualConfig` option is enabled in the *MaintenanceSettings.xml* file, the `NatsCustodianResetNatsRequest` message will now be blocked. Instead of performing a NATS reset, it will now return an error with the following message:

`Resetting NATS is blocked while the system is running a Manual Config. See https://aka.dataminer.services/disabling-automatic-nats-config for more information.`

> [!NOTE]
> The `NatsCustodianResetNatsRequest` message will also be blocked when BrokerGateway is being used.

#### Disabling an SLAnalytics feature will now clear all open alarms and suggestion events associated with that feature [ID 42096]

<!-- MR 10.6.0 - FR 10.5.4 -->

When, in DataMiner Cube, you go to *System Center > System settings > Analytics config*, and you explicitly disable one of the following SLAnalytics features, all open alarms and suggestion events associated with that feature will now automatically be cleared:

- Behavioral anomaly detection
- Pattern matching
- Proactive cap detection
- Relational anomaly detection

#### Relational anomaly detection: First anomaly score of a RAD group will now be calculated faster [ID 42141]

<!-- MR 10.6.0 - FR 10.5.4 -->
<!-- Not added to MR 10.6.0 -->

Because of a number of enhancements, after a RAD parameter group is configured, the first anomaly score for that group will be calculated faster than before.

#### GQI DxM: Enhanced performance when executing multiple queries simultaneously [ID 42191]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

Because of a number of enhancements, overall performance has increased when executing multiple queries simultaneously.

#### STaaS: Enhanced granularity when migrating custom data to STaaS [ID 42219]

<!-- MR 10.6.0 - FR 10.5.4 -->

When you migrate data of data type *CustomData* from either Cassandra Single or Cassandra Cluster to STaaS (using e.g. the [STaaS Migration Script package](https://catalog.dataminer.services/details/46046c45-e44c-4bff-ba6e-3d0441a96f02)), you can now indicate exactly which data you want to have migrated.

For example, if you want to migrate only the SLAnalytics data, you can now specify the *CustomData* data type as well as the *Analytics* data type.

#### Connection enhancements [ID 42233]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

A number of enhancements have been made with regard to the connections made among DataMiner Agents as well as the connections made between DataMiner Agents and client applications.

#### SLAnalytics - Pattern matching: Multivariate pattern suggestion events will now be grouped into a single incident [ID 42274]

<!-- MR 10.6.0 - FR 10.5.4 -->

When a multivariate pattern is detected in new trend data, suggestion events are generated for every instance in the linked pattern.

From now on, those suggestion events will be grouped into a single incident, which will be shown as a single line in the Alarm Console.

#### Swarming: 'Where are my elements.txt' file added to the 'C:\\Skyline DataMiner\\Elements\\' folder [ID 42314]

<!-- MR 10.6.0 - FR 10.5.4 -->

When Swarming is enabled, a file named *Where are my elements.txt* will now be present in the `C:\Skyline DataMiner\Elements\` folder.

In that file, users who wonder why this folder no longer contains any *element.xml* files will be referred to the [Swarming documentation](https://aka.dataminer.services/swarming) in [docs.dataminer.services](https://docs.dataminer.services/).

#### Relational anomaly detection is now able to process data from history set parameters [ID 42319]

<!-- MR 10.6.0 - FR 10.5.4 -->

Under certain conditions, Relational anomaly detection (RAD) is now able to detect relational anomalies on history set parameters:

- If there is at least one history set parameter in a RAD parameter group, that parameter group will only be processed when all data from all parameters in the group has been received. In other words, if a history set parameter receives data 30 minutes later than the real-time parameters, possible anomalies will only be detected after 30 minutes.

- RAD will only process data received within the last hour. If a history set parameter receives data more than an hour later than the real-time parameters, that data will be disregarded.

#### GQI DxM: Logging can now be viewed in DataMiner Cube [ID 42352]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

From now on, you can view the logging of the GQI DxM in DataMiner Cube.

Also, no new log file will be started every day anymore. From now on, a new log file will only be started as soon as the size of the existing file reaches 5 MB.

> [!NOTE]
> Currently, DataMiner Cube only allows you to view the logging of the parent process. It does not yet allow you to view the logging of the child processes (i.e. the logging of the ad hoc data sources and the operators).

#### GQI DxM: Separate log file per extension library in Extensions folder [ID 42355]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

From now on, a separate log file will be created per GQI DxM extension library in the `C:\ProgramData\Skyline Communications\DataMiner GQI\Logs\Extensions` folder.

Example:

- `C:\ProgramData\Skyline Communications\DataMiner GQI\Logs\Extensions\Library A.txt`
- `C:\ProgramData\Skyline Communications\DataMiner GQI\Logs\Extensions\Library B.txt`

The log entries added to those files will now each include the name of the extension as well as the name of the user. The log entry format will now be the following:

`[Timestamp][Level][Extension][User][SessionId][NodeId] Message`

#### SLLogCollector now collects the logging of the GQI DxM extensions from the Extensions folder [ID 42379]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

SLLogCollector will now look for GQI DxM extension logging in the following folder:

- `C:\ProgramData\Skyline Communications\DataMiner GQI\Logs\Extensions`

### Fixes

#### DataMiner Object Models: No longer possible to query DOM after initializing a Cassandra Cluster migration [ID 40993]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

After a Cassandra Cluster migration had been initialized, it would no longer be possible to query DOM.

#### Mobile Visual Overview: Problem when the same mobile visual overview was requested by multiple users of the same user group [ID 41881]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.4 -->

When multiple users of the same user group requested the same mobile visual overview, in some rare cases, a separate DataMiner Cube instance would incorrectly be created on the DataMiner Agent for each of those users, potentially causing the creation of one Cube instance to block the creation of another Cube instance.

#### Cassandra: Problem with incorrect gc_grace_seconds values [ID 41939]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

On systems with a Cassandra or Cassandra Cluster database, a number of issues have been fixed with regard to the `gc_grace_seconds` setting:

- The `gc_grace_seconds` values will no longer be updated during a DataMiner restart.
- The `gc_grace_seconds` value for trend data will now by default be set to 0.
- The `gc_grace_seconds` value for logger tables will now by default be set to 4 hours (with TTL) or to 1 day (without TTL).

#### Problem when trying to update the protocol version of an element in error [ID 41962]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When you tried to update the protocol version of an element in error via DataMiner Cube, in some rare cases, a message would incorrectly appear, stating that it was not possible to update the element.

#### Problems with SNMP managers [ID 42014]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

In the following cases, an SNMP manager configured to send SNMPv3 Inform messages would get stuck in a timeout:

- When multiple SNMP managers were sending information to the same IP address and port.
- When "time window" errors were thrown after the SNMP manager (configured with *authnopriv* or *authpriv*) had been restarted.

Also, "out of time window" errors could be thrown when an SNMP manager received SNMPv3 traps. From now on, in SNMPv3 mode, the first alarm sent by DataMiner to the SNMP manager will always be a PING alarm. This will allow an SNMP manager to clean up time table information, which will prevent "out of time window" errors from being thrown when receiving subsequent alarms.

#### Problem when deleting elements with logger tables [ID 42029]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When an element with a logger table was deleted, some items would not be removed from Cassandra and from OpenSearch/Elasticsearch:

- SLDataGateway still contained the table definitions.

- When the `databaseName` option was used, the table that had been created in a separate table schema would not be deleted.

- In case of a Cassandra Cluster, the logger table is by default stored in the `sldmadb_elementdata_<dmaid>_<elementid>_<tableid>` keyspace. When an element with a logger table was deleted, the database table would correctly be removed, but the empty keyspace would still exist.

> [!NOTE]
> When an element with a logger table is deleted, the logger table will not be deleted when it has the `customDatabaseName` or `databaseNameProtocol` option.

#### SLAnalytics: Memory leak due to an excessive number of messages being received following an alarm template update [ID 42047]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When an alarm template was updated, in some cases, the alarm focus manager could receive a excessive number of messages, causing SLAnalytics to leak memory.

#### Mobile Visual Overview: Problem with user context [ID 42061]

<!-- MR 10.6.0 [CU0] - FR 10.5.4 -->

Up to now, when no user context was needed in mobile visual overviews, an attempt would be made to reuse server-side cards among users. However, in some cases, this could cause problems, especially when handling popups or embedded visual overviews.

To make sure the user context is always correct and that it get passed correctly to popups, from now on, mobile visual overviews will always use a separate card for each user and create a new card whenever a user requests a new visual overview in a web app.

#### SLAnalytics - Behavioral anomaly detection: Problem when trying to retrieve incorrect INF values from the database [ID 42069]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

In some cases, INF (infinity) values would incorrectly get stored in the database. Attempts to retrieve those values would then result in the *Behavioral anomaly detection* feature not starting up.

#### Mobile Visual Overview: Child shapes would incorrectly remain clickable when hidden [ID 42090]

<!-- MR 10.6.0 [CU0] - FR 10.5.4 -->

When a parent shape with a conditional show/hide setting was hidden, up to now, the clickable regions of its hidden child shapes would incorrectly remain active. In other words, users would incorrectly be able to still click child shapes after they had been hidden.

#### GQI DxM: Killed child processes would not automatically start up again [ID 42091]

<!-- MR 10.6.0 - FR 10.5.4 -->
<!-- Not added to MR 10.6.0 -->

When the GQI DxM is being used, ad hoc data sources and custom operators each run in their own child process. Up to now, when such a child process was killed, it would incorrectly not automatically start up again when a query needed it. The entire GQI DxM had to be restarted.

From now on, when a child process is killed, it will automatically start up again as soon as a new query request is received that wants to use it.

#### Scheduler: Dashboard exported via an email action would incorrectly be displayed as plain text instead of HTML [ID 42117]

<!-- MR 10.6.0 - FR 10.5.4 -->

When, in the *Scheduler* app, a dashboard was exported via an email action, up to now, HTML-formatted text in the email body would incorrectly be sent as plain text, even when the *Plain text* option was not selected. From now on, when the *Plain text* option is not selected, the text in the email body will be marked as HTML, and will be parsed and displayed correctly.

#### SLAnalytics - Behavioral anomaly detection: Change points could incorrectly be labeled as a level shift [ID 42119]

<!-- MR 10.6.0 - FR 10.5.4 -->

When a trend graph seemed to increase or decrease, in some cases, change points could incorrectly be labeled as a level shift.

#### DataMiner Taskbar Utility would incorrectly show a pop-up window when made to perform a DataMiner upgrade using the command prompt [ID 42135]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When you made SLTaskbarUtility perform a DataMiner upgrade using the command prompt, up to now, a pop-up window would appear when the DataMiner Agent was not running. As pop-up windows are only expected to appear when running in interactive mode, from now on, pop-up windows will no longer appear when you make SLTaskbarUtility perform actions using the command prompt.

#### Not possible to simultaneously update multiple TTL settings [ID 42139]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

In some cases, it would not be possible to simultaneously update multiple TTL settings.

#### MessageBroker: Subscriptions that had been disposed of would incorrectly get recreated [ID 42164]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

After a MessageBroker client had disposed of a subscription and had reconnected to NATS, in some cases, the subscription would incorrectly get recreated.

#### Problem with SLAnalytics due to MessageBroker reconfiguring itself [ID 42207]

<!-- MR 10.6.0 - FR 10.5.4 -->
<!-- Not added to MR 10.6.0 -->

After a DataMiner Agent was added to or removed from a DMS, in some cases, SLAnalytics could stop working due to Message Broker reconfiguring itself.

#### Relational anomaly detection: Response of GetMADDataMessage did not contain the anomaly score and the parameter values associated with the last trend data entry [ID 42238]

<!-- MR 10.6.0 - FR 10.5.4 -->
<!-- Not added to MR 10.6.0 -->

The `GetMADDataMessage` allows you to request anomaly scores during a specified time range for a particular RAD parameter group.

However, up to now, the response would not contain the anomaly score and the parameter values associated with the last trend data entry.

#### Problem when NATS sessions were disposed [ID 42281]

<!-- MR 10.5.0 [CU1] - FR 10.5.4 -->

In some rare cases, an exception could be thrown when NATS sessions were disposed.

#### Mobile Visual Overview: Problem with SLHelper when removing mobile visual overview sessions [ID 42296]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU2] - FR 10.5.4 [CU0] -->

When mobile visual overview sessions were removed from a DataMiner Agent, in some cases, the SLHelper process could temporarily block other requests.

#### GQI DxM: Problem when executing a query using ad hoc data sources with real-time updates enabled [ID 42310]

<!-- MR 10.4.0 [CU14]/10.5.0 [CU1] - FR 10.5.4 -->

When a query using ad hoc data sources was executed with real-time updates enabled, up to now, the following message could incorrectly appear:

```txt
Operations that change non-concurrent collections must have exclusive access. A concurrent update was performed on this collection and corrupted its state. The collection's state is no longer correct.
```

#### Problem when exporting an element to a .dmimport file [ID 42320]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

In some rare cases, exporting an element to a *.dmimport* file could fail.

#### SLNetClientTest tool: Problem when trying to connect to a DataMiner Agent using external authentication via SAML [ID 42341]

<!-- MR 10.4.0 [CU13]/10.5.0 [CU1] - FR 10.5.4 -->

When, in the *SLNetClientTest* tool, you tried to connect to a DataMiner Agent using external authentication via SAML, the following error message would appear:

`Unable to load DLL 'WebView2Loader.dll': The specified module could not be found.`

The *WebView2Loader.dll* file will now been added to the DataMiner upgrade packages.

> [!WARNING]
> Always be extremely careful when using this tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Problem when performing actions involving migrated elements [ID 42400]

<!-- MR 10.6.0 - FR 10.5.4 [CU0] -->
<!-- Not added to MR 10.6.0 -->

When an element had been migrated from one DataMiner Agent to another, in some rare cases, certain actions involving that migrated element (e.g. a deletion of the element) would fail until the DataMiner Agent was restarted.

#### SLNet memory leak related to indexing logic for Cube search bar [ID 42544]

<!-- MR 10.6.0 - FR 10.5.4 [CU0] -->

In systems with many trended parameters, an SLNet memory leak could occur whenever an ElementInfoMessage was sent (e.g. when an element was restarted or edited, or when an element property was changed). This was caused by the SLNet indexing of trended parameters for the Cube search bar not being cleaned up correctly, which lead to duplicate entries being kept in the SearchManager in SLNet, consuming more and more memory.
