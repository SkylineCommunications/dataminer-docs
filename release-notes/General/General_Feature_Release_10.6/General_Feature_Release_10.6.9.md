---
uid: General_Feature_Release_10.6.9
---

# General Feature Release 10.6.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.9](xref:Cube_Feature_Release_10.6.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.9](xref:Web_apps_Feature_Release_10.6.9).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Prerequisites

Before you upgrade to this DataMiner version:

- Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.

  The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):

  - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
  - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

- Make sure all DataMiner Agents in the cluster have been migrated to the BrokerGateway-managed NATS solution.

  For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration).

  See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)

## Highlights

*No highlights have been selected yet.*

## New features

#### Credentials at rest [ID 44075] [ID 44352] [ID 44701] [ID 44702] [ID 44911]

<!-- MR 10.7.0 - FR 10.6.9 -->

From now on, credential secrets are stored as authenticated ciphertext (AES-256-CBC with HMAC-SHA-256) instead of in the legacy *Library.xml* file. The encryption material is held in a per-node `encryptors.bin` file under `%CommonApplicationData%\Skyline Communications\DataMiner StorageModule\Encryption\`, wrapped with the Windows [Data Protection API (DPAPI)](https://learn.microsoft.com/en-us/dotnet/standard/security/how-to-use-data-protection) under *LocalMachine* scope.

Because DPAPI binds the encryption keys to the host that produced them, restoring a DataMiner Agent on a different machine requires a **DMS backup password**. When this password has been configured, a full DataMiner backup contains a passphrase-wrapped envelope (`backup_encryptors.bin`) that is sealed with PBKDF2-HMAC-SHA-256 (100,000 iterations, 32-byte salt) and AES-256-CBC with HMAC-SHA-256, so that the encryption material can travel between hosts without exposing the keys in plain text. For more information, see [Backing up a DataMiner Agent](xref:Backing_up_a_DataMiner_Agent) and [Restoring a DMA using the DataMiner Taskbar Utility](xref:Restoring_a_DMA_using_the_DataMiner_Taskbar_Utility).

> [!IMPORTANT]
> Store the DMS backup password securely outside DataMiner (for example, in a password manager). If it is lost, encrypted credentials in any backup taken with that password can no longer be recovered on a clean host. In a multi-node cluster, a peer DataMiner Agent can re-synchronize the encryption material to a restored node, but this should not be relied upon as a substitute for a properly configured DMS backup password.

<!-- See also Cube RNs [ID 45704] [ID 45997] -->

#### Automation: Added support for running scripts in separate SLAutomation.ScriptRunner processes by SolutionId [ID 45557]

<!-- MR 10.7.0 - FR 10.6.9 -->

To help prevent DLL version conflicts between solutions, scripts can now run their C# code in separate `SLAutomation.ScriptRunner` child processes grouped by the script's `SolutionId` tag.

When a script has a `SolutionId`, DataMiner will create a runner process for that `SolutionId` (or reuse an existing one), and execute the script code in that process instead of the main `SLAutomation` process.

When you update a script that uses `SolutionId`, you can send an `InvalidateScriptRunnerMessage` to force creation of a new runner process on the next execution, ensuring the latest DLLs are loaded. A maximum of 10 runner processes can exist at the same time per `SolutionId`, and 50 runner processes in total.

Runner processes are automatically stopped after they have been idle for one hour. In the *SLNetClientTest* tool, you can view the current runners via *Advanced* > *Automation...* > *Script Runners Overview*.

## Changes

### Enhancements

#### Security enhancements [ID 45582] [ID 45646]

<!-- 45582: MR 10.7.0 - FR 10.6.9 -->
<!-- 45646: MR 10.5.0 [CU18] - FR 10.6.9 -->

A number of security enhancements have been made.

#### 'DataMiner Agent Minimum Requirements' BPA test: Enhanced time server check on hybrid clusters [ID 45661]

<!-- MR 10.7.0 - FR 10.6.9 -->

When the 'DataMiner Agent Minimum Requirements' BPA test checked the time server settings on hybrid clusters (i.e., clusters that include DaaS Agents as well as self-managed Agents), the existing checks were too strict. DaaS Agents always use VM Time as time server, whereas self-managed Agents typically use the local domain controller as time server.

From now on, the BPA test will compare the server times of all Agents in the cluster:

- If the server times differ from 1 to 5 seconds, this will be flagged as a warning.
- If the server times differ more than 5 seconds, this will be flagged as an issue.

#### APIGateway: gRPC connections that go through the Azure Cloud Relay service will now buffer event messages [ID 45671]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

From now on, gRPC connections that go through the Azure Cloud Relay service will buffer event messages until the client confirms they have been received.

This will allow those connections to survive a temporary outage of the Azure Cloud Relay service, for example when restarting or deploying a new version.

#### SLLogCollector: Extra logging and progress updates while files are being archived [ID 45650]

<!-- MR 10.7.0 - FR 10.6.9 -->

In some cases, SLLogCollector can get stuck while archiving files.

To improve visibility during archiving, SLLogCollector will now log which file is currently being archived and update the busy message with the number of files copied so far.

#### Automation: Improved save logic for automation scripts [ID 45836]

<!-- MR 10.7.0 - FR 10.6.9 -->

A number of enhancements have been made to the save logic of automation scripts:

- A per-script execution reference is now kept, so deletion of an in-use script DLL is deferred until all script executions have ended.
- When a script is updated while another instance is still running, a new DLL is created as before, while the old DLL is kept until the running instance finishes.
- Local save logic no longer deletes DLL files that were triggered by its own file-change event.
- A newly saved script now waits until its (re)compilation is complete before it is executed.

#### ConfigureIIS.bat script will now ensure a dedicated Application Pool for the API application [ID 45842]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

The *ConfigureIIS.bat* script will now ensure a dedicated Application Pool for the API application. This will avoid needless restarts of the API when files running under the same DefaultAppPool would change inside WebPages.

This new application pool is called *DataMiner WebAPI AppPool*. it is solely intended to serve as pool for the web API, and will not recycle periodically.

#### CloudFeed DxM has been upgraded to Microsoft .NET 10 [ID 45849]

<!-- MR 10.7.0 - FR 10.6.9 -->

The CloudFeed DxM has been upgraded to Microsoft .NET 10.

#### SLLogCollector will now automatically be configured to include a memory dump of SLPort and SLSNMPManager when a runtime error was detected in SLProtocol [ID 45865]

<!-- MR 10.7.0 - FR 10.6.9 -->

From now on, when you open the SLLogCollector tool, the tool will automatically be configured to include a memory dump of the SLPort and SLSNMPManager processes when a runtime error was detected in SLProtocol.

#### DOM: `FilterElement<T>` select extensions moved to the `Skyline.DataMiner.Net.Apps.ManagerStore.Select` namespace [ID 45902]

<!-- MR 10.6.0 [CU6] - FR 10.6.9 -->

When you use the DOM helper method `Read(IQuery<DomInstance>, SelectedFields<DomInstance>)` for a select read, you can pass either an `IQuery<T>` object or a `FilterElement<T>` object.

Up to now, the extension method that allowed `FilterElement<T>` to be passed was located in the `Skyline.DataMiner.Net.Messages` namespace, which is often not imported in scripts. As a result, this could lead to confusing syntax errors where the filter appeared to be incorrectly converted to an `IQuery`.

Equivalent extension methods have now been added in the `Skyline.DataMiner.Net.Apps.ManagerStore.Select` namespace, which also contains `SelectedFields<T>`. The old extension methods have been converted to regular static methods so that already compiled code remains compatible with newer `SLNetTypes` versions.

#### DxMs upgraded [ID 45944]

<!-- RN 45944: MR 10.7.0 - FR 10.6.9 -->

The following DataMiner Extension Modules (DxMs), which are included in the DataMiner upgrade package, have been upgraded to the indicated versions:

- DataMiner DataAPI 1.4.6

For detailed information about the changes included in those versions, refer to the [DxM release notes](xref:DxM_RNs_index).

### Fixes

#### Problem when multiple Agents in a DMS synchronized with Azure Entra simultaneously [ID 44546]

<!-- MR 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, when multiple Agents in a DMS synchronized with Azure Entra simultaneously, in some cases, data could get corrupted due to simultaneous requests being launched to the Entra API from one of those Agents. As a result, users and/or groups could get lost.

#### Problem with SLPort when sending a large message over a WebSocket connection [ID 45625]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, when a large message (e.g., a message with a size of 400 KB) was sent over a WebSocket connection, in some cases, an internal buffer issue could cause the SLPort process to stop unexpectedly.

#### Automation: Problem with dependency order when recompiling script libraries [ID 45673]

<!-- MR 10.7.0 - FR 10.6.9 -->

Up to now, when a script library was updated, the dependency order was always assumed to be correct. However, in cases where libraries were loaded in a different order, a library could be recompiled before one of its dependencies.

For example, when Library A depended on Library B, and Library B was recompiled after Library A, then Library A would remain linked to an older version of Library B. This would cause an issue when, after the DataMiner Agent was restarted, the outdated DLLs were removed. Library A would then reference a DLL file that no longer existed.

From now on, the recompilation flow will ensure that libraries are recompiled in the correct dependency order, preventing references to outdated dependency versions.

#### Protocol object outside of QAction run would incorrectly not be notified when the element was stopped [ID 45749]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When an `SLProtocol` or `SLProtocolExt` object that was passed as argument in the `QAction` method had been stored and reused when the QAction was already finished, up to now, this object would not be notified when the element was stopped.

This could lead to issues. For example, when a separate thread that was running in SLScripting when the element was stopped made calls on the `SLProtocol` object, the SLScripting process could crash as the connection with the SLProtocol process was no longer valid.

Also, calling `protocol.IsActive` would incorrectly indicate that the element was still active.

#### Problem when using the 'Get parameter table by alias' data source against a STaaS database [ID 45766]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

The *Get parameter table by alias* data source retrieves a parameter table from the indexing database using the specified alias.

Up to now, this data source would only check whether the DataMiner System included an indexing database. It would not check the type of the database. As it currently only supports Elasticsearch and OpenSearch, up to now, exceptions would be thrown when it was used to retrieve data from a STaaS database.

From now on, the *Get parameter table by alias* data source will only be available when the DataMiner System includes an indexing database of type Elasticsearch or OpenSearch.

#### Automatic alarm grouping: Memory leak caused by alarm duplication on element restart [ID 45831]

<!-- MR 10.6.0 [CU6] - FR 10.6.9 -->

When an element was frequently stopped and restarted, up to now, alarms would accumulate as duplicates in the internal alarm grouping counters, causing a memory leak in the SLAnalytics process. Alarms would incorrectly not be removed from the element's alarm counter when the element stopped, and were re-added as new entries each time the element restarted.

From now on, alarms will be properly removed from the element alarm counter when an element stops. An additional safeguard has also been added to prevent duplicate alarm entries from being inserted into the counter if the same alarm tree already exists.

#### Problem occurring while SL\* services were being shut down would prevent DataMiner from starting up again [ID 45839]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, while the SL* services were being shut down, in some cases, an access violation crash could occur.

As a result, DataMiner could fail to start up again.

#### Reconnecting a WMI connection could cause the SLProtocol process to stop unexpectedly [ID 45851]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, in some cases, reconnecting a WMI connection could cause the `SLProtocol` process to stop unexpectedly.

In addition, opening StreamViewer would incorrectly show all items in the tree structure as `Undefined`.

From now on, reconnecting a WMI connection will no longer cause `SLProtocol` to stop unexpectedly, and StreamViewer will correctly show the group and action executing the WMI query.

#### Problem with SLProtocol when a queued QAction finished after an element had been stopped [ID 45882]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, when an element was stopped while queued QActions were still running, in some cases, one of those QActions could finish after `SLProtocol` had already cleaned up its internal objects.

As a result, when that QAction thread then tried to update element metrics, it would attempt to access an object that had already been deleted, causing the `SLProtocol` process to crash.

#### When DataMiner was stopped, the SLAnalytics process could get stuck while being stopped [ID 45910]

<!-- MR 10.7.0 - FR 10.6.9 -->

When the DataMiner software was stopped, in some cases, the SLAnalytics process could get stuck while being stopped.

#### Smart-serial client connection state incorrectly shown as undefined [ID 45931]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, when an element with a smart-serial connection acted as a client, in some cases, the *Connection State* column in the *Communication Info* table on the *General parameters* page would incorrectly show `Undefined`.

From now on, that column will correctly show the actual connection state, e.g., `Connected`.

#### StorageModule DxM would fail to start because of a WebSocket issue [ID 45933]

<!-- MR 10.7.0 - FR 10.6.9 -->

Because of a WebSocket issue, in some rare cases, the StorageModule DxM would fail to start. As a result, DataMiner would not be able to start up.

#### STaaS: Page size would incorrectly be ignored when retrieving DOM instances from a STaaS database [ID 45952]

<!-- MR 10.7.0 - FR 10.6.9 -->
<!-- Not added to MR 10.7.0 -->

When DOM instances were retrieved from a STaaS database, up to now, the page size would incorrectly be ignored.

#### SLSNMPManager process could stop working unexpectedly when it received a malformed SNMP packet [ID 45993]

<!-- MR 10.7.0 - FR 10.6.9 -->

Up to now, the SLSNMPManager process could stop working unexpectedly when, while using SNMP++, it received a malformed SNMP packet containing an integer type with length zero.
