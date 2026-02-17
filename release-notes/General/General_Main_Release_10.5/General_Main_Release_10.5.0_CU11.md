---
uid: General_Main_Release_10.5.0_CU11
---

# General Main Release 10.5.0 CU11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> Before you upgrade to this DataMiner version:
>
> - Make sure the Microsoft **.NET 10** hosting bundle is installed (download the latest Hosting Bundle under ASP.NET Core Runtime from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)). See also: [DataMiner upgrade: New prerequisite will check whether .NET 10 is installed](xref:General_Main_Release_10.5.0_CU10#dataminer-upgrade-new-prerequisite-will-check-whether-net-10-is-installed-id-44121).
> - Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU11](xref:Cube_Main_Release_10.5.0_CU11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU11](xref:Web_apps_Main_Release_10.5.0_CU11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner upgrade: New upgrade action will register DataMiner exe files with Windows Error Reporting [ID 39440]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

During a DataMiner upgrade, from now on, a new upgrade action will register all DataMiner SL\*.exe and "DataMiner \*.exe" files with Windows Error Reporting (WER). This will make sure that, each time a DataMiner process crashes for whatever reason, a full crash dump is created in `C:\Skyline DataMiner\Logging\CrashDump\wer\<ExeName>`. These WER crash dumps will allow Skyline to thoroughly investigate any issue that might occur.

> [!NOTE]
>
> - Each time a crash dump is created for a particular process, any existing crash dumps for the same process will be automatically deleted. Per DataMiner process, only the most recent crash dump will be kept.
> - Although the entire `C:\Skyline DataMiner\Logging\CrashDump\wer\` folder will be cleared during a DataMiner upgrade, DataMiner will not manage it. Removing crash dumps from this folder will not require a DataMiner restart.
> - Currently, WER crash dumps are not included in SLLogCollector packages, and CDMR is not aware of them.

#### Security enhancements [ID 43789]

<!-- 43789: MR 10.5.0 [CU11] - FR 10.6.2 -->

A number of security enhancements have been made.

#### Elasticsearch/OpenSearch: Enhanced history alarm filtering on service ID or service name [ID 44192]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When, on a system with a Cassandra Cluster database, history alarms are filtered on service ID or service name, up to now, that filter would not be translated correctly to Elasticsearch or OpenSearch. From now on, that filter will be translated correctly. As a result, overall performance will increase when applying the filter in question to large datasets.

Also, filtering on alarm properties or interfaces using wildcards or regular expression has now been made case insensitive.

#### Enhanced performance when upgrading DxMs [ID 44210] [ID 44211]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Because of a number of enhancements, overall performance has increased when the following DxMs are upgraded during a DataMiner upgrade:

- BrokerGateway
- StorageModule

#### SLLogCollector packages will now also include time zone info, domain info, IP addresses of NICs, Web.config files, IIS configuration, and HTTP service state [ID 44223]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

SLLogCollector packages will now also include the following information:

- Time zone info, which will be stored in the following file:

  ```text
  /Windows/powershell.exe Get-TimeZone_.txt
  ```

- Windows domain info, which will be stored in the following files:

  ```text
  /Windows/nltest.exe _dclist_.txt
  /Windows/nltest.exe _domain_trusts.txt
  /Windows/nltest.exe _dsgetdc_.txt
  ```

- The IP addresses of all network adapters, which will be stored in the following files:

  ```text
  /Network Information/NetworkInterface_GetAllNetworkInterfaces.txt
  /Network Information/powershell.exe [System.Net.Dns]_GetHostname().txt
  ```

- All `Web.config` files found in `C:\Skyline DataMiner\WebPages` and all its subfolders.

- The entire IIS configuration.

- A snapshot of the HTTP service state (Request Queue View), which will be stored in the following file:

  `/Network Information/netsh.exe http show servicestate view=requestq verbose=no.txt`

#### SLSNMPManager: Enhanced performance of the SNMP++ library [ID 44372]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Because of a number of enhancements, overall performance of the SNMP++ library has increased, especially when polling large SNMP tables.

### Fixes

#### Problem when a connector was deleted immediately after it had been uploaded [IID 44083]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When a connector was deleted immediately after it had been uploaded, in some rare cases, events triggered by the connector upload would still be adding references to the SLNet cache while the events triggered by the connector deletion were already trying to remove those references. This would lead to the SLNet cache incorrectly containing references to connectors that no longer existed on disk.

#### Not possible to export elements with logger tables on systems with Cassandra Cluster and OpenSearch [ID 44105]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

On a system with Cassandra Cluster and OpenSearch, up to now, it would incorrectly not be possible to export elements with logger tables.

A `Cassandra.InvalidQuery` exception with message "No keyspace has been specified" would be thrown and logged.

> [!NOTE]
> On a system with Cassandra Cluster and OpenSearch, it is currently not yet possible to export SLAs.

#### Problem when generating a default MessageBrokerConfig.json file [ID 44155]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When neither an *SLCloud.xml* file nor a *MessageBrokerConfig.json* file could not be found on a DataMiner Agent, up to now, any process using MessageBroker would fail to generate a default *MessageBrokerConfig.json* file. As a result, it would not be possible to connect to NATS.

From now on, when neither a *SLCloud.xml* file nor a *MessageBrokerConfig.json* file can be found, a default *MessageBrokerConfig.json* file will be generated.

#### Elements hosted on another DMA and under the root view would not be visible if you did not have full access to the root view [ID 44170]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

In client applications like DataMiner Cube, up to now, elements hosted on a DMA other than the one you were connected to would incorrectly not be visible in the Surveyor if they were directly under the root view and if you did not have full access to that root view.

#### Uploading certain protocol versions would cause elements to no longer be able to execute QActions [ID 44172]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

After you had uploaded a protocol with a version that was identical to the prefix of the version of a protocol that was already in use (e.g., a new protocol with version 1.0.0.1 versus an existing protocol with version 1.0.0.1_DEV), up to now, elements using the existing protocol (e.g., with version 1.0.0.1_DEV) would incorrectly no longer be able to execute QActions.

#### Problem with SLElement when loading elements that included matrix parameters [ID 44188]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

In some cases, SLElement could stop working when loading elements that included matrix parameters.

#### Problem when importing a .dmimport package containing elements that use a production version of a connector [ID 44189]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When you imported a *.dmimport* package containing an element that used a production version of a connector for which a different version was set as production version on the target agent, up to now, the connector version set as production version in the *.dmimport* package would incorrectly always be set as new production version on the target agent.

From now on, the system will always ask what you want it to do:

- Make the connector version in the *.dmimport* package the new production version on the target agent, and allow the imported element to still use the production version.

OR

- Leave the production version untouched on the target agent, and update the imported element so that it no longer uses the production version but the referenced version instead.

#### BrokerGateway: Issues related to certificates [ID 44195]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Up to now, in some cases, issues related to certificates could cause `TLS handshake error: remote error: tls: bad certificate` errors to be added to the NATS log file and `Could not connect to the local NATS endpoint on '<IP>'. Please make sure that the nats service is running without issues.` notice alarms to be generated.

From now on, in order to prevent any issues related to certificates, in the following cases, the certificate authority will be either added or updated in the certificate store:

- When adding an agent to the cluster.
- When removing an agent from the cluster.
- When calling NATSRepair.
- When migrating to BrokerGateway.
- When no certificate authorities can be found during BrokerGateway startup.

#### STaaS: Problem when migrating or importing elements with logger tables [ID 44196]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

On systems using STaaS, when an element with logger tables had been migrated from one DMA to another, up to now, that element would no longer start up after it was migrated back to its original DMA.

Also, on system using STaaS, up to now, when importing a DELT package containing elements with logger tables, the logger table data would not be imported correctly.

#### Problem when retrieving historic alarms with a filter on the value of a discrete parameter [ID 44221]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When historic alarms were retrieved with a filter on the value of a discrete parameter, up to now, no alarms would be returned.

This was due to the parameter value being incorrectly translated to a numeric value.

#### No retries would incorrectly be attempted when retrieving DMS configuration info failed [ID 44240]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When a client application connects to a DataMiner System, it retrieves the configuration info of that DataMiner System.

Up to now, when retrieving that info failed, no retries would incorrectly be attempted. From now on, a retry will be attempted every 10 seconds.

#### Problem when trying to create, update, or delete users or user groups [ID 44245]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Because of file locking issues, in some cases, errors could occur when trying to create, update, or delete users or user groups.

#### Crowd: HTTP response codes would incorrectly be ignored [ID 44254]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When DataMiner was configured to import users and groups from a Crowd server, SLDataMiner would incorrectly disregard HTTP result codes while parsing a response during the hourly LDAP synchronization. This could lead to users being removed from their groups until the next successful synchronization, causing them to be unable to log in to DataMiner.

#### BrokerGateway: getnatsconnectiondetails calls would slow down whenever an IP address listed in appsettings.runtime.json could not be reached [ID 44287]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Up to now, whenever an IP address listed in BrokerGateway's `appsettings.runtime.json` file could not be reached, `getnatsconnectiondetails` calls would slow down for all MessageBroker clients, causing DataMiner to not start up as it would not be able to contact the StorageModule DcM fast enough.

#### Problem when calling NotifyDataMiner NT_ELEMENT_STARTUP_COMPLETE for an element while that element was being renamed [ID 44288]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When a QAction called NotifyDataMiner `NT_ELEMENT_STARTUP_COMPLETE` for its own element while that element was being renamed, up to now, a deadlock would occur, causing a runtime error.

#### Problem with SLDataMiner when a version of a DVE connector was set to production version [ID 44308]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

When a version of a DVE connector was set to production version, in some cases, a fatal error could occur in SLDataMiner.

#### A history set parameter with a constant value would not properly update its new timestamp [ID 44318]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

Up to now, a history set parameter with a constant value would not properly update its new timestamp when a set parameter was triggered with a more recent timestamp.

#### Service impact of exported DVE parameter or DCF interface state of DVE element were incorrect when monitored parameters of the DVE element were polled but not saved [ID 44341]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

After a DataMiner restart or an element restart, in some cases, the service impact of an exported parameter or the DCF interface state of a DVE element would be incorrect when the monitored parameters of the DVE element in question were polled but not saved, especially when those monitored parameters were associated with active alarms.

#### Protocols - PortSettings: DefaultValue and Disabled child elements of SkipCertificateVerification element would not be read if the connection was not the primary connection [ID 44343]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

In the `<PortSettings>` element of an HTTP connection, you can configure a `<SkipCertificateVerification>` element with child elements `<DefaultValue>` and `<Disabled>`. Up to now, both child elements would incorrectly not be read if the connection in question was not the primary connection.

#### Problem with the GQI DxM when it tried to connect to SLNet during DataMiner startup [ID 44380]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

During DataMiner startup, in some rare cases, a fatal error could occur in the GQI DxM when it tried to connect to SLNet.

#### Problem with SLDataMiner when an incomplete JSON response was received from Microsoft Entra ID [ID 44391]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 -->

In some cases, a fatal error could occur in SLDataMiner when an incomplete JSON response was received from Microsoft Entra ID while authenticating a user via SAML.

#### Failing attempt to create an alarm for an element being stopped could block the alarm thread [ID 44394]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 [CU0] -->

When an alarm cannot be created for a particular element, an attempt is made to fetch the element state for logging purposes.

Up to now, in some cases, when the element was being stopped and was flushing its data to the database, this fetch operation could block the alarm thread. As a result, no new alarms would get processed for that element until the element had stopped flushing its data.

#### Calls that check whether the connection between client and DMA is still alive would incorrectly be blocked when 10 simultaneous calls were being processed [ID 44456]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 [CU1] -->

When 10 simultaneous calls between a client application (e.g., DataMiner Cube) and a DataMiner Agent were being processed, up to now, any additional call would be blocked, including calls that check whether the connection between client and DMA was still alive. As a result, the client application would disconnect.

From now on, even when 10 simultaneous calls between a client application (e.g., DataMiner Cube) and a DataMiner Agent are being processed, calls that check whether the connection between client and DMA is still alive will never be blocked.
