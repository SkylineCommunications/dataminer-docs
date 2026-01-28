---
uid: General_Feature_Release_10.6.3
---

# General Feature Release 10.6.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)
>
> - Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution. For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).
>
>   See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.3](xref:Cube_Feature_Release_10.6.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.3](xref:Web_apps_Feature_Release_10.6.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### DataMiner Object Models: Instance-level security [ID 44233]

<!-- MR 10.6.0 - FR 10.6.3 -->

On top of [DataMiner Object Models: Definition-level security [ID 43380] [ID 43589]](xref:General_Feature_Release_10.5.10#dataminer-object-models-definition-level-security-id-43380-id-43589), which allows you to grant user groups access to all DOM instances of a DOM definition, it is now also possible to allow user groups access to an individual DOM instance based on whether that DOM instance contains at least one of a specified set of values for a specified FieldDescriptor.

For example, the user group *London employees* will only be able to read the "Job" instances where the *Assigned office* field (i.e. a `DomInstanceFieldDescriptor`) contains the ID of the DOM instance for the London office.

##### Limitations

This instance-level security filtering is applied in the database, which can contain DOM definitions with millions of DOM instances.

However, there are a number of limitations:

- You can only define a maximum of 10 values per FieldDescriptor.

- For a particular DOM definition, you can only specify one condition per user group.

- When a user is a member of multiple user groups, and several of those groups have conditions for a certain DOM definition, then the condition of the user group that comes first (alphabetically) will be used.

  It is recommended that you avoid these situations by defining and using the user groups in such a way that there are no overlaps.

  > [!NOTE]
  > If users are a member of a user group with full definition-level access, this definition-level access will take precedence over any limited access of other groups they are a member of.

- When reading DOM instances, the filter is only allowed to search within one specific DOM definition. If it searches across multiple DOM definitions, and the user does not have full definition-level access to all of those definitions, the request will fail, even if the user is a member of a user group that has conditional access. If the request fails, the following error message will be thrown: `Make sure the user has full access to all queried DOM definitions`.

- Ideally, the filter should not contain more than 100 OR clauses.

##### Defining the conditional access

To configure that a user group has limited access, you can add a `FieldValueReference` to the `GroupLink` class.

A `FieldValueReference` contains the following data objects:

- DomDefinitionId (Guid): The ID of the DOM definition
- FieldDescriptorId (Guid): The ID of the FieldDescriptor
- List of allowed FieldDescriptor values (to be set via the corresponding constructor)

Currently supported FieldDescriptors:

| FieldDescriptor | Descriptor Type | Referenced Value Collection Type |
|---------|---------|---------|
| DomInstanceFieldDescriptor      | `Guid` OR `List<Guid>` | `List<Guid>` |
| DomInstanceValueFieldDescriptor | `Guid` OR `List<Guid>` | `List<Guid>` |
| GenericEnumFieldDescriptor      | `GenericEnum<int>` OR `List<GenericEnum<int>>`       | `List<int>`    |
| GenericEnumFieldDescriptor      | `GenericEnum<string>` OR `List<GenericEnum<string>>` | `List<string>` |

The `FieldValueReference` class also has a number of methods that can be used to retrieve the (number of) referenced values:

- `GetValuesCount()`: Returns the number of referenced values.
- `GetValuesType()`: Returns an enum value of `FieldValueReferenceTypes` that represents whether the `FieldValueReference` in question contains a list of Guid, string, or int values.
- `GetValues<T>`: Returns the actual values. To this method, you have to pass the correct type as returned by the `GetValuesType()` method.

When `FieldValueReference` values are saved in the `ModuleSettings`, the following validation checks will be executed:

- Check if there are any IDs that are equal to Guid.Empty. If empty IDs are detected, a `DomManagerSettingsErrorData` error will be returned with reason `DomSecurityFieldValueReferenceHasInvalidIds`.
- Check if the list of values is not empty. If the list is empty, a `DomManagerSettingsErrorData` error will be returned with reason `DomSecurityFieldValueReferenceHasNoValues`.
- Check if the list of values does not contain more than 10 items. If the list contains more than 10 items, a `DomManagerSettingsErrorData` error will be returned with reason `DomSecurityFieldValueReferenceHasTooManyValues`.

In all errors listed above, the `ErrorData` properties `GroupName` and `DomDefinitionId` can be used to find out which references are invalid. The third error also contains a `Limit` property that contains the max number of values (i.e. 10).

#### SLNet subscription logging [ID 44361]

<!-- MR 10.7.0 - FR 10.6.3 -->

In the *SLNetClientTest* tool, you can now specify that all SLNet subscription events have to be logged in the *SLSubscriptionLog.txt* log file.

To activate SLNet subscription event logging, do the following:

1. Open the *SLNetClientTest* tool, and connect to the DataMiner Agent.

1. Open the *Advanced* menu, and select *Options* > *SLNet options*.

1. Open the *Option values for* selection box, and select "SubscriptionLogOptions".

   You will see a list of all DMAs in the cluster. For each of those DMAs, the list will show whether the selected option is active, and what options are set.

1. In the *Value* column, right-click the value you want to edit, and select *Edit value*.

1. In the edit box, add or update the necessary options, and click *OK*. For a list of available options, see below.

##### Event type and cache key filtering

The entries in the *SLSubscriptionLog.txt* log file can be filtered by event type (e.g. *ParameterChangeEventMessage*) and/or cache key (e.g. DataMinerID/ElementID/ParameterID). To do so, you have to provide a value with a *filter=* prefix. If you want to provide multiple values, they have to be separated by a semicolon (";").

Options for filtering by event type:

| Option | Event type |
|--------|------------|
| element   | *ElementInfoEventMessage*     |
| alarm     |  *AlarmEventMessage*          |
| dma       | *DataMinerExtendedStateEvent* |
| parameter | *ParameterChangeEventMessage* |
| alarmfocusevent      | *Skyline.DataMiner.Analytics.AlarmFocus.AlarmFocusEvent*  |
| radgroupinfoevent    | *Skyline.DataMiner.Analytics.Rad.RadGroupInfoEvent*       |
| stateiconchangeevent | *Skyline.DataMiner.Analytics.Arrows.StateIconChangeEvent* |

Apart from the above-mentioned options, you can also use any other message type from the *Skyline.DataMiner.Net.Messages* namespace.

Formats for filtering by cache key:

- HostingDataMinerID/DataMinerID/ElementID/ParameterID
- DataMinerID
- DataMinerID/ElementID
- DataMinerID/ElementID/ParameterID

These filtering options are saved in the `<SLNet>` section of the *MaintenanceSettings.xml* file, in an element named `<SubscriptionLogOptions>`. The contents of this element are not synchronized across the DMAs in the cluster.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Changes

### Enhancements

#### New parameter caches for client apps [ID 43945]

<!-- MR 10.7.0 - FR 10.6.3 -->

Two new parameter caches are now available for client apps (e.g. DataMiner Cube):

- ProtocolParameters (linked to GetProtocolParameter on the client connection)
- ElementProtocolParameters (linked to GetElementProtocolParameter on the client connection)

Both caches are added on the connection object, and have the ability to cache in memory (for the current session) and on disk (for a next session).

#### Enhanced visibility on SLNet connection issues [ID 44069]

<!-- MR 10.7.0 - FR 10.6.3 -->

Visibility on SLNet connection issues has been enhanced:

- When a dashboard cannot be loaded because a DataMiner Agent is offline, an appropriate error message will now appear in that dashboard.

- A new log file named *SLNetConnectionsMonitor.txt* will now keep a historic record of all SLNet connection states.

#### SLNet will now take into account the log level before sending a log entry to SLLog [ID 44314]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, SLNet would incorrectly send all log entries directly to SLLog, including entries of which the log level dictated that they should not be added to a log file.

From now on, SLNet will only send a log entry to SLLog if the log level dictates that the entry should be logged. As a result, overall performance will increase when adding entries to log files.

#### An error will now be logged if the response to an SNMP Get request cannot be mapped [ID 44329]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

If the response to an *SNMP Get* request cannot be mapped, from now on, an error will be logged in the log file of the element in question and in the *SLErrorsInProtocol.txt* file.

#### Factory reset tool: Actions that stop and stop DcMs and DxMs will now have a 15-minute timeout [ID 44387]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

The factory reset tool *SLReset.exe* can be used by an administrator to fully reset a DataMiner Agent to its default state from immediately after installation.

One of the actions performed by this tool when resetting a DMA is stopping and starting the DcMs and DxMs. Up to now, the DcMs and DxMs would be stopped and started without any timeout. From now on, the stop and start actions will have a 15-minute timeout.

Also, if an exception would be thrown during a stop action, a kill command will be executed instead.

#### DataMiner backup: 'Ticketing Gateway Configuration' removed from the list of backup options [ID 44401]

<!-- MR 10.7.0 - FR 10.6.3 -->

As the Ticketing app is End of Life as of DataMiner 10.6.x, *Ticketing Gateway Configuration* has now been removed from the list of backup options.

#### Ticketing app End of Life [ID 44417]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

DataMiner Ticketing has been declared End of Life. As a result, all server code related to Ticketing has been removed.

#### Security Advisory BPA test: Enhancements [ID 44444] [ID 44477]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Up to now, the *Local admin hygiene* test would verify whether the local admin account was disabled and whether there were not too many local administrator accounts. From now on, this test will no longer be performed as the recommendations in the [hardening guide](https://aka.dataminer.services/HardeningGuide) have been updated.

Also, the following issues have now been fixed:

- The *gRPC* test will now properly take the default configuration into account. Up to now, this test would assume gRPC was disabled when not configured. From DataMiner feature release 10.5.10, gRPC is enabled by default, causing the test to report a false positive.

- On systems where the `enableLegacyV0Interface` flag is not set in the *web.config* file, the test that verifies whether the v0 web API is disabled would incorrectly assume that the v0 web API was enabled. From now on, when the `enableLegacyV0Interface` flag is not set in the *web.config* file, the v0 web API will be considered disabled.

#### APIGateway now has a dedicated log file [ID 44469]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, APIGateway would send its log entries to the Microsoft Event Viewer. Now, a dedicated APIGateway log file has been added in `C:\ProgramData\Skyline Communications\DataMiner APIGateway\Logs`.

- When the current log file reaches its maximum size of 5 MB, a new log file will be started. Up to 2 files will be kept.
- The configuration of the log file can be adjusted using an `appsettings.custom.json` file. Copy the contents of the `appsettings.json` file to the `appsettings.custom.json` file, and change the necessary values.

#### SLAnalytics: Enhanced resilience during startup [ID 44476]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Because of a number of enhancements, from now on, SLAnalytics will be more resilient when starting up.

From now on, when an issue occurs during startup, in most cases, SLAnalytics will add an entry describing the issue to the SLAnalytics log file, and will keep on working.

#### BPA test 'Cube CRL Freeze': Enhanced performance [ID 44479]

<!-- RN 44479: MR 10.4.0 [CU21] / 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->

Because of a number of enhancements, overall performance of the the *Cube CRL Freeze* BPA test has increased.

This BPA test will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

#### Interactive Automation scripts launched from web apps: UI components Time and Calendar can now all display seconds [ID 44487]

<!-- MR 10.6.0 - FR 10.6.3 -->

Up to now, in interactive Automation scripts launched from web apps, only the `UIBlockType.Time` component with `AutomationTimeUpDownOptions` had the ability to show seconds. From now on, all the following `UIBlockType.Time` components, as well as the `UIBlockType.Calendar` component, will also have that ability. Their option classes will now all have a `ShowSeconds` property, which will be set to false by default.

- `UIBlockType.Time` with `AutomationDateTimePickerOptions`
- `UIBlockType.Time` with `AutomationDateTimeUpDownOptions`
- `UIBlockType.Time` with `AutomationTimePickerOptions`
- `UIBlockType.Calendar` with `AutomationCalendarOptions`

#### GQI: Domain user name will now be included in the OnInitInputArgs of a GQI extension [ID 44509]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, for a GQI extension (i.e. an ad hoc data source or a custom operator) to be able to retrieve the username of the user who launched the query, an additional connection had to be set up, which could cause overall performance of the extension to decrease.

From now on, the `OnInitInputArgs` will include a `Session` object that will contains the domain user name of the user who launched the query.

#### SLNet messages GetLiteElementInfo, GetLiteServiceInfo, and GetLiteRedundancyGroupInfo now support filtering by HostingAgentID [ID 44537]

<!-- MR 10.6.0 - FR 10.6.3 -->

The following SLNet messages, which can be used to retrieve information about elements, services, and redundancy groups, now also support filtering by HostingAgentID. This allows you to e.g. retrieve a list of all elements that are being hosted on a particular DataMiner Agent.

- GetLiteElementInfo
- GetLiteRedundancyGroupInfo
- GetLiteServiceInfo

#### Migrating booking data from Cassandra Single to indexing database is no longer supported [ID 44550]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 -->
<!-- Not added to MR 10.5.0 [CU12] -->

From now on, it will no longer be possible to migrate booking data from a Cassandra database per DMA to an indexing database.

Up to now, in DataMiner Cube, the *Migrate booking data to Indexing Engine*, found in *System Center > Search & Indexing*, allowed you to migrate older booking data (i.e. from prior to DataMiner 10.0) stored in a Cassandra database per DMA to the indexing database. From now on, when Cube is connected to a DMA running DataMiner 10.6.0 [CU0]/10.6.3 or newer, this option will no longer be available.

### Fixes

#### Numeric cell would incorrectly not be cleared when its exception value was set to 0 [ID 44356]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When a numeric cell had its exception value set to 0, up to now, it would incorrectly not be possible to clear that cell by setting its value to null or by using the `protocol.clear` property. When an attempt was made to clear the cell or to set its value to null, the cell would incorrectly show its exception value instead of the word "Uninitialized".

Also, in some cases, an exception would be displayed even when it had a type other than the parameter for which it had been defined. For example, an exception value of type string defined for a parameter of type double.

For more information, see [Exceptions element](xref:Protocol.Params.Param.Interprete.Exceptions). The `Exceptions` tag should only be used to intercept values of the same `Interprete.Type` as that of your parameter. If you want to intercept values of another type, then you should use the `Protocol.Params.Param.Interprete.Others` tag instead.

#### MessageBroker: Problem with hostnames and FQDNs containing a certain combination of dashes and characters [ID 44433]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

Up to now, hostnames and FQDNs in the *MessageBrokerConfig.json* file would incorrectly be considered invalid when they contained a certain combination of dashes and characters.

Examples of hostnames that were incorrectly considered invalid:

- Hostnames that start with one letter or number, followed by a dash. E.g. `a-agent`, `h-hostname`, etc.
- Full IPv6 addresses like `[2001:0db8:85a3:0000:0000:8a2e:0370:7334]`
- Shortened IPv6 addresses like `[::1]`

#### DaaS: Short-lived alarms without operational impact would appear immediately after the 'My DataMiner Agent' element had been created [ID 44440]

<!-- MR 10.6.0 - FR 10.6.3 -->

On a newly created DaaS system, up to now, short-lived alarms without operational impact could appear immediately after the *My DataMiner Agent* element had been created.

In the alarm template of the *My DataMiner Agent* element, hysteresis has now been tweaked to prevent such alarms from appearing on newly created DaaS systems.

#### Calls that check whether the connection between client and DMA is still alive would incorrectly be blocked when 10 simultaneous calls were being processed [ID 44456]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When 10 simultaneous calls between a client application (e.g. DataMiner Cube) and a DataMiner Agent were being processed, up to now, any additional call would be blocked, including calls that check whether the connection between client and DMA was still alive. As a result, the client application would disconnect.

From now on, even when 10 simultaneous calls between a client application (e.g. DataMiner Cube) and a DataMiner Agent are being processed, calls that check whether the connection between client and DMA is still alive will never be blocked.

#### GQI: Problem with Timer callbacks could cause SLHelper to stop working [ID 44458]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

In some cases, exceptions could be thrown in the callback of System.Threading.Timer, causing the SLHelper process to stop working.

See also: [GQI DxM: Problem with Timer callbacks could cause the GQI DxM to stop working [ID 44460]](xref:Web_apps_Feature_Release_10.6.3#gqi-dxm-problem-with-timer-callbacks-could-cause-the-gqi-dxm-to-stop-working-id-44460)

#### Event message would return the object twice in case of two subscriptions to the same object [ID 44486]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When, on the same connection, there were two subscriptions to the same object, in some cases, that object would incorrectly be returned twice in the event message.

#### SLA would degrade after an element had been restarted [ID 44490]

<!-- MR 10.5.0 [CU12] - FR 10.6.3 -->

When an element was restarted, and that element had alarms with service impact that were being tracked by an SLA, in some cases, the SLA would degrade when one of those alarms no longer affected the SLA.
