---
uid: General_Main_Release_10.5.0_CU18
---

# General Main Release 10.5.0 CU18 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

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
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU18](xref:Cube_Main_Release_10.5.0_CU18).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU18](xref:Web_apps_Main_Release_10.5.0_CU18).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Enhancements

#### Security enhancements [ID 45646]

<!-- 45646: MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

A number of security enhancements have been made.

#### APIGateway: gRPC connections that go through the Azure Cloud Relay service will now buffer event messages [ID 45671]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

From now on, gRPC connections that go through the Azure Cloud Relay service will buffer event messages until the client confirms they have been received.

This will allow those connections to survive a temporary outage of the Azure Cloud Relay service, for example when restarting or deploying a new version.

#### ConfigureIIS.bat script will now ensure a dedicated Application Pool for the API application [ID 45842]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

The *ConfigureIIS.bat* script will now ensure a dedicated Application Pool for the API application. This will avoid needless restarts of the API when files running under the same DefaultAppPool would change inside WebPages.

This new application pool is called *DataMiner WebAPI AppPool*. it is solely intended to serve as pool for the web API, and will not recycle periodically.

### Fixes

#### Problem with SLPort when sending a large message over a WebSocket connection [ID 45625]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, when a large message (e.g., a message with a size of 400 KB) was sent over a WebSocket connection, in some cases, an internal buffer issue could cause the SLPort process to stop unexpectedly.

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

#### Smart-serial client connection state incorrectly shown as undefined [ID 45931]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, when an element with a smart-serial connection acted as a client, in some cases, the *Connection State* column in the *Communication Info* table on the *General parameters* page would incorrectly show `Undefined`.

From now on, that column will correctly show the actual connection state, e.g., `Connected`.

#### Problem with SLDataMiner when SLWatchdog requested element statistics while an element was being stopped [ID 45945]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In some rare cases, SLDataMiner could stop unexpectedly when SLWatchdog requested statistics about the number of active elements while an element was being stopped.

#### SLSNMPManager process could stop working unexpectedly when it received a malformed SNMP packet [ID 45993]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, the SLSNMPManager process could stop working unexpectedly when, while using SNMP++, it received a malformed SNMP packet containing an integer type with length zero.

#### Invalid matrix 'columntypes' definition could cause SLProtocol to stop unexpectedly [ID 46011]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, when a matrix parameter had fewer `columntypes` defined in its options than there were dimensions, `SLProtocol` could stop unexpectedly when `protocol.SendToDisplay` was called on that matrix parameter.

From now on, missing matrix outputs that are not covered by `columntypes` will be handled correctly.
