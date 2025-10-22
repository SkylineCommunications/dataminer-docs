---
uid: General_Feature_Release_10.5.12
---

# General Feature Release 10.5.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.12](xref:Cube_Feature_Release_10.5.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.12](xref:Web_apps_Feature_Release_10.5.12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

- [User-defined APIs: New ResponseHeaders property [ID 43705] [ID 43960]](#user-defined-apis-new-responseheaders-property-id-43705-id-43960)

## New features

#### DataMiner upgrade: New VerifyOSVersion prerequisite will block upgrades on unsupported OS versions [ID 43356]

<!-- MR 10.6.0 - FR 10.5.12 -->

When a DataMiner upgrade is being performed, from now on, the new *VerifyOSVersion* prerequisite will check whether the DataMiner version in the upgrade package supports the version of the operating system that is installed on the DataMiner Agent. If not, the upgrade will be aborted, and the user will be asked to upgrade the operating system.

> [!NOTE]
> Microsoft no longer supports OS versions older than Windows Server 2016 or Windows 10. Hence, these versions will not pass the above-mentioned OS version check.

#### User-defined APIs: New ResponseHeaders property [ID 43705] [ID 43960]

<!-- MR 10.6.0 - FR 10.5.12 -->

In the `ResponseHeaders` property of the `ApiTriggerOutput` class, you can now specify the HTTP headers that will be added to the response.

Also, the `ApiTriggerOutput` class now allows you to override the contents of the Content-Type header, which is set to "application/json" by default.

Currently, the following headers are blocked, and will result in an error if you try to set them:

- Access-Control-Allow-Origin
- Access-Control-Allow-Credentials
- Access-Control-Expose-Headers
- Access-Control-Allow-Methods
- Access-Control-Max-Age
- Vary
- Content-Length (automatically set)
- Set-Cookie
- WWW-Authenticate
- Proxy-Authenticate
- Transfer-Encoding
- Connection
- Upgrade
- Trailer
- TE
- Via
- Server
- Date (automatically set)
- Strict-Transport-Security

The endpoint can now also return the following additional errors:

| ErrorCode | Integer value | HTTP Status Code | Description |
|-----------|---------------|------------------|-------------|
| ResponseHeadersNotAllowed | 1012 | 500 | The response header or headers you are trying to return are not allowed. |
| ResponseHeadersInvalid | 1013 | 500 | The response header or headers you are trying to return are invalid. Header names and values cannot contain whitespace, colons (":"), commas (","), or ASCII control characters. The *UserDefinableApiEndpoint* logging will contain the exact error. |

#### Automation: Engine class now exposes the public property ScriptName [ID 43840]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

From now on, the `Engine` class exposes the public property `ScriptName`.

This means that, in an Automation script, it will now be possible to retrieve the name of that script.

#### Interactive Automation scripts executed in a web app: UI version can now be set in the script [ID 43875]

<!-- MR 10.6.0 - FR 10.5.12 -->

Up to now, when you wanted an interactive Automation script executed in a web app to use the new UI version, you had to add `useNewIASInputComponents=true` to the URL of the app.

From now on, it is also possible to indicate the UI version in the script itself. To do so, set the `engine.WebUIVersion` property to one of the following values:

| Value | UI version |
|-------|------------|
| WebUIVersion.Default | Default UI version. At present, this is V1. |
| WebUIVersion.V1      | Current UI version (V1) |
| WebUIVersion.V2      | New UI version (V2)     |

Example:

```csharp
engine.WebUIVersion = WebUIVersion.V2
```

The URL parameter `useNewIASInputComponents` has priority over the UI version set in the script.

- If you use `useNewIASInputComponents=true`, the script will use the new UI version (i.e. V2), even when V1 was set in the script.
- If you use `useNewIASInputComponents=false`, the script will use the current UI version (i.e. V1), even when V2 was set in the script.

> [!IMPORTANT]
> This feature is only supported for interactive Automation scripts executed in web apps. It is not supported for interactive Automation scripts executed in DataMiner Cube.

## Changes

### Enhancements

#### SLLogCollector: Memory dumps will be taken first & new option to skip the BPA tests [ID 43588]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Each time the *SLLogCollector* tool is run, by default, it will order the *Standalone BPA Executor* tool to execute all BPA tests available in the system. From now on, a checkbox will allow you to have those BPA tests skipped.

Also, when ordered to include memory dumps, up to now, the SLLogCollector tool would first run the BPA tests and collect all logging, and would then take the memory dumps. From now on, it will take the memory dumps first.

#### Serial communication: Only TLS 1.2 or TLS 1.3 encryption will now be allowed [ID 43678]

<!-- MR 10.6.0 - FR 10.5.12 -->

Although DataMiner supports all TLS versions up to TLS 1.3, from now on, all serial communication will have to use either TLS 1.2 or TLS 1.3 encryption.

#### Relational anomaly detection: All relational anomalies will now be stored in the database [ID 43720]

<!-- MR 10.6.0 - FR 10.5.12 -->

All relational anomalies detected by the Relational Anomaly Detection (RAD) feature will be stored in the database\*.

The new `GetRelationalAnomaliesMessage` will allow you to retrieve relational anomalies detected in the past for a particular parameter during a specified time range.

*\*If you choose not to use the recommended Storage as a Service (STaaS) setup but instead choose self-managed storage, you also need to set up an OpenSearch or Elasticsearch indexing database in your DMS.*

#### Automation, Correlation, and Scheduler: All dashboard reports will now fully be generated by the Web DcM [ID 43762]

<!-- MR 10.6.0 - FR 10.5.12 -->

From now on, all dashboard reports configured in Automation, Correlation or Scheduler will fully be generated by the Web DcM. SLHelper will no longer be involved in any report generation processes.

SLHelper will also no longer convert the reports of the legacy Reporter module to PDF format. From now on, this will also be done by the Web DcM.

#### Relational anomaly detection: New API message to migrate a RAD parameter group to a specific DMA [ID 43769]

<!-- MR 10.6.0 - FR 10.5.12 -->

From now on, the new `MigrateRADParameterGroupMessage` will allow you to migrate a RAD parameter group to a specific DataMiner Agent.

This new DataMiner Agent will then be responsible for building, maintaining, and executing the anomaly detection model of the RAD parameter group in question.

> [!NOTE]
> A RAD parameter group will be migrated automatically when its parameters are hosted by elements that are swarmed from one DataMiner Agent to another. The RAD parameter group will then be migrated to the DataMiner Agent hosting the majority of its parameters.

#### DataMiner upgrade: Backend browser installation package no longer included in upgrade packages [ID 43771]

<!-- MR 10.6.0 - FR 10.5.12 -->

From now on, DataMiner upgrade packages will no longer include the Puppeteer-Sharp/Chromium browser installation package.

This backend browser, which was used by SLHelper to generate reports and to convert those reports to PDF format, is no longer needed as the new Web DcM will now generate all reports and convert them to PDF format.

#### Swarming: Clearer error message when file contents cannot be retrieved [ID 43774]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When, during a swarming operation, a file cannot be loaded, from now on, a clearer error message will be logged. The message will now include the reason of the failure, and, if the error occurred because the file was locked, the process locking the file will also be mentioned.

Also:

- If SLDataMiner is unable to load a certain file, it will shut down gracefully, and the DataMiner Agent will be stopped.
- If a process other than SLDataMiner is unable to load a certain file, then it will retry loading the file 10 times, and if, after all those retries, it is still not able to load the file, it will stop trying, and retry again when it needs to send a request to the storage module.

#### NATSMigration tool will now also check for outdated DLL files in the ProtocolScripts folder [ID 43778]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

From now on, the *NATSMigration* tool will also check for outdated DLL files in the `C:\Skyline DataMiner\ProtocolScripts` folder.

When an outdated DLL file is found, the migration will be aborted. For the migration to succeed, the user will have to remove the outdated DLL file and update the protocol in question.

#### OPC communication is End of Life [ID 43785]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

From now on, OPC communication should no longer be used in DataMiner connectors. Instead, QActions should be used, for example like in the [Generic OPC Data Access](https://catalog.dataminer.services/details/f2642ea9-9eaa-42f3-880e-816470b06a61) connector.

#### PDF reports configured in the Dashboards app can now also be sent if recipients are only specified in the CC and/or BCC fields [ID 43844]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, an PDF report configured in the Dashboards app could only be sent if recipients were specified in the *To* field.

From now on, it will also be possible to send PDF reports if recipients are only specified in the *CC* and/or *BCC* fields.

> [!NOTE]
> Currently, PDF reports configured in DataMiner Cube still require recipients to be specified in the *To* field.

#### Relational anomaly detection: New API message to retrieve all relational anomalies within a given time frame [ID 43853]

<!-- MR 10.6.0 - FR 10.5.12 -->

From now on, the new `GetAllRelationalAnomaliesMessage` will allow you to retrieve all relational anomalies within a given time frame, regardless of the RAD parameter group or parameter they were detected on.

> [!NOTE]
> This message will only return anomalies detected on parameters to which the user has access.

#### BPA test 'Cube CRL Freeze': Enhanced performance [ID 43854]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Because of a number of enhancements, overall performance of the the *Cube CRL Freeze* BPA test has increased.

This BPA test will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

#### DxMs upgraded [ID 43866] [ID 43950] [ID 43961]

<!-- RN 43866: MR 10.6.0 - FR 10.5.12 -->
<!-- RN 43950: MR 10.6.0 - FR 10.5.12 -->
<!-- RN 43961: MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner CloudGateway 2.17.14
- DataMiner DataAPI 1.4.0
- DataMiner Orchestrator 1.8.0

The CloudGateway DxM and the DataAPI DxM will only be upgraded when an older version is found on the DataMiner Agent. If no older version is found, they will not be installed.

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

#### SLDMS: Broadcast event DMS_INVALIDATE_HOSTING_AGENT_CACHE has been removed [ID 43896]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when the SLDMS process had updated its local hosting agent cache information about an element, service, or redundancy group, it would publish a DMS_INVALIDATE_HOSTING_AGENT_CACHE request across the cluster so that other agents could also update this information.

This redundant broadcast event has now been removed.

#### Alarms of type 'Notice' will now be generated when SLDataGateway queues no longer seem to decrease [ID 43909]

<!-- MR 10.6.0 - FR 10.5.12 -->

In some rare cases, SLDataGateway queues no longer seemed to decrease.

When this should happen in the future, an alarm of type "Notice" will be generated to make sure system administrators can act accordingly in order to prevent data loss.

#### BPA test 'DataMiner Agent Minimum Requirements': Updated requirements [ID 43913]

<!-- MR 10.6.0 - FR 10.5.12 -->

In the BPA test *DataMiner Agent Minimum Requirements*, the following minimum hardware requirements have been updated:

| Hardware                 | Former requirement | New requirement |
|--------------------------|---------|---------|
| System memory            | 32 GB   | 16 GB   |
| Size of main disk (C:\\) | 300 GB  | 128 GB  |

#### DataMiner upgrade: Enhanced warning when an upgrade package cannot be found [ID 43916]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when a DataMiner upgrade package could not be found, the following warning message would appear:

*"WARNING! Upgrade ID [guid] no longer exists"*

This message has now been replaced by the following one:

*"WARNING! Upgrade package with ID [guid] no longer exists"*

#### NATSMigration tool will now log clearer HTTP errors when it is not able to connect to BrokerGateway [ID 43931]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When the *NATSMigration* tool is not able to connect to BrokerGateway, it will now add clearer HTTP errors to the error log.

#### Relational anomaly detection: New API message to retrieve the model fit score of a RAD parameter subgroup [ID 43934]

<!-- MR 10.6.0 - FR 10.5.12 -->

From now on, the new `GetRADSubgroupModelFitMessage` will allow you to retrieve the model fit score of a RAD parameter subgroup.

The model fit score, ranging from 0 to 1, indicates how well the relational behavior of a subgroup is captured by the shared model trained across multiple subgroups:

- Higher scores suggest that the subgroup's behavior aligns well with the shared model.
- Lower scores indicate that the subgroup's behavior deviates from the patterns learned by the shared model.

The model fit score is derived from the evolution of anomaly scores over time for the subgroup in question. In general, subgroups with consistently high anomaly scores tend to have lower model fit scores, reflecting poor alignment with the shared relational model.

#### Time-scoped relation learning: Exceptions will now be thrown when sending a GetTimeScopedRelationsMessage with incorrect arguments [ID 43963]

<!-- MR 10.6.0 - FR 10.5.12 -->

When a client application retrieves information about time-scoped related parameters using the `GetTimeScopedRelationsMessage`, from now on, exceptions will be thrown when that message is sent with incorrect arguments (e.g. a non-existing parameter ID, an invalid time range, etc.).

### Fixes

#### Parameter or DCF information would become unavailable to remotely hosted elements after a DataMiner connection had been re-established [ID 43765]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

After a DataMiner connection had been re-established (due to e.g. a network issue, a failover switch, etc.), in some rare cases, an issue could occur that would cause parameter or DCF information to be unavailable to remotely hosted elements.

#### Alerter would incorrectly require .NET Framework 2.0 [ID 43787]

<!-- MR 10.6.0 - FR 10.5.12 -->

When you tried to install Alerter, in some cases, a warning message would appear, saying that Microsoft .NET Framework 2.0 needed to be installed first.

From now on, when you try to install Alerter, it will check whether Microsoft .NET Framework 4.6.2 is installed.

#### Cleared alarms would incorrectly not be shown when using the history slider in DataMiner Cube [ID 43810]

<!-- MR 10.6.0 - FR 10.5.12 -->

On systems with a Cassandra cluster database in combination with an OpenSearch indexing database, cleared alarms would incorrectly not be shown when using the history slider in DataMiner Cube.

#### 'Failed to wait for Parameter Notification queue to handle remaining events' exception after a DataMiner startup [ID 43818]

<!-- MR 10.6.0 - FR 10.5.12 -->
<!-- Not added in MR 10.6.0 -->

After a DataMiner startup, in some cases, the following exception could appear in the Alarm Console, especially on large, heavily loaded systems:

`Unexpected Exception [Failed to wait for Parameter Notification queue to handle remaining events]: DmaConnections`

#### MessageBroker client could get stuck while trying to fetch information from BrokerGateway [ID 43832]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When, on systems using the BrokerGateway-managed NATS solution, BrokerGateway is not running the local DataMiner Agent, the MessageBroker client could get stuck while trying to fetch information from BrokerGateway.

#### SLNet would wait too long before closing a connection [ID 43851]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In some rare cases, SLNet would incorrectly wait for 2 hours before closing a connection. As a result, SLNet and SLDataMiner would keep a large number of unused connections in memory for too long.

#### Events would be generated with incorrect hosting agent information [ID 43862]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When elements were swarmed or migrated via a DELT package, in some cases, events would not be generated with the correct hosting agent information.

#### Swarming: Specific elements could not be swarmed to a specific DMA until that DMA had been restarted [ID 43883]

<!-- MR 10.6.0 - FR 10.5.12 -->
<!-- Not added in MR 10.6.0 -->

In some rare cases, it would incorrectly not be possible for specific elements to be swarmed to a specific DataMiner Agent until that Agent had been restarted.

#### BrokerGateway would incorrectly be allowed to make automatic changes to the appsettings.runtime.json file when HasManualConfig was set to true [ID 43893]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When BrokerGateway could not find any local IP address in the `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json` configuration file, up to now, it would incorrectly add a local IP address to that file, even when the `HasManualConfig` setting was set to true.

From now on, when the `HasManualConfig` setting is set to true, BrokerGateway will not be allowed to make any automatic changes to the `appsettings.runtime.json` configuration file.

#### Timeout of queries against a Cassandra database was set incorrectly [ID 43912]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

The timeout of queries against a Cassandra database was set incorrectly. This timeout has now been set to 10 minutes.

#### Problem with temporary deadlocks in SLNet while DataMiner Agents were connecting or reconnecting [ID 43936]

<!-- MR 10.6.0 - FR 10.5.12 -->
<!-- Not added in MR 10.6.0 -->

Up to now, a temporary deadlock could occur in SLNet while DataMiner Agents were connecting or reconnecting to each other.

In some cases, this could lead to "thread problem" alarms appearing and then clearing later on.

#### Visual Overview in web apps: Cube running as a service within SLHelper would not load the common server settings from ClientSettings.json [ID 43941]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when DataMiner Cube was running as a service within the SLHelper process, it would not load the common server settings from `C:\Skyline DataMiner\users\ClientSettings.json` when it is unable to retrieve its own user settings.

From now on, regardless of whether DataMiner Cube can retrieve its own user settings, it will load the common server settings from `C:\Skyline DataMiner\users\ClientSettings.json`.

#### Notices regarding incorrect baseline values would no longer be generated when an element was started after being swarmed or migrated [ID 43970]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When an element that had been swarmed or migrated by means of a DELT package was started up, up to now, the following notices would no longer be generated when incorrect baseline values were found:

- `The fixed value (%g) is invalid. It is lower than nominal value (%g), and in the higher range. This value will not be used for alarm creation.`
- `The fixed value (%g) is invalid. It is higher than nominal value (%g), and in the lower range. This value will not be used for alarm creation.`

These notices will now be generated again.
