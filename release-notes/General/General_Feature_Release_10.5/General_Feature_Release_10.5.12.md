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

- [User-defined APIs: New ResponseHeaders property [ID 43705]](#user-defined-apis-new-responseheaders-property-id-43705)

## New features

#### DataMiner upgrade: New VerifyOSVersion prerequisite will block upgrades on unsupported OS versions [ID 43356]

<!-- MR 10.6.0 - FR 10.5.12 -->

When a DataMiner upgrade is being performed, from now on, the new *VerifyOSVersion* prerequisite will check whether the DataMiner version in the upgrade package supports the version of the operating system that is installed on the DataMiner Agent. If not, the upgrade will be aborted, and the user will be asked to upgrade the operating system.

> [!NOTE]
> Microsoft no longer supports OS versions older than Windows Server 2016 or Windows 10. Hence, these versions will not pass the above-mentioned OS version check.

#### User-defined APIs: New ResponseHeaders property [ID 43705]

<!-- MR 10.6.0 - FR 10.5.12 -->

In the `ResponseHeaders` property of the `ApiTriggerOutput` class, you can now specify the HTTP headers that will be added to the response.

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

#### Email messages can now also be sent if recipients are only specified in the CC and/or BCC fields [ID 43844]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, an email message could only be sent if the recipients were specified in the *To* field.

From now on, it will also be possible to send email messages that only have recipients specified in the *CC* and/or *BCC* fields.

#### BPA test 'Cube CRL Freeze': Enhanced performance [ID 43854]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Because of a number of enhancements, overall performance of the the *Cube CRL Freeze* BPA test has increased.

This BPA test will identify client machines and DataMiner Agents without internet access where the DataMiner Cube application experiences a significant freeze during startup. This freeze is caused by the system attempting to verify the application's digital signatures with online Certificate Revocation Lists (CRLs).

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

### Fixes

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

<!-- MR 10.6.0 - FR 10.5.12 -->
<!-- Not added in MR 10.6.0 -->

When, on systems using the BrokerGateway-managed NATS solution, BrokerGateway is not running the local DataMiner Agent, the MessageBroker client could get stuck while trying to fetch information from BrokerGateway.

#### SLNet would wait too long before closing a connection [ID 43851]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In some rare cases, SLNet would incorrectly wait for 2 hours before closing a connection. As a result, SLNet and SLDataMiner would keep a large number of unused connections in memory for too long.

#### BrokerGateway would incorrectly be allowed to make automatic changes to the appsettings.runtime.json file when HasManualConfig was set to true [ID 43893]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When BrokerGateway could not find any local IP address in the `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json` configuration file, up to now, it would incorrectly add a local IP address to that file, even when the `HasManualConfig` setting was set to true.

From now on, when the `HasManualConfig` setting is set to true, BrokerGateway will not be allowed to make any automatic changes to the `appsettings.runtime.json` configuration file.
