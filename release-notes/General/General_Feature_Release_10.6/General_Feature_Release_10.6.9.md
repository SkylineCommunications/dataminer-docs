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

*No new features have been added yet.*

## Changes

### Enhancements

#### Security enhancements [ID 45582]

<!-- 45582: MR 10.7.0 - FR 10.6.9 -->

A number of security enhancements have been made.

#### DataAPI: Enhanced handling of element creations failing because another element with the same name already exists [ID 45643]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When DataAPI creates an element, in some cases, the element is not immediately fully synchronized in DataMiner. Subsequent requests then detect that an element with the same name already exists and fail, even though DataAPI itself created that element.

To determine whether DataAPI created an element, the request must confirm that it is genuinely the same element. Up to now, when a name collision occurred, the request would simply fail with no way to identify its own recently created element.

From now on, DataAPI will verify whether the existing element is one it created earlier by matching and tracking both the identifier and the type (i.e., the protocol). When both match, the request is allowed to proceed. If not, it is treated as a conflict and will be rejected.

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

#### When DataMiner was stopped, the SLAnalytics process could get stuck while being stopped [ID 45910]

<!-- MR 10.7.0 - FR 10.6.9 -->

When the DataMiner software was stopped, in some cases, the SLAnalytics process could get stuck while being stopped.
