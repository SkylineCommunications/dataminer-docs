---
uid: General_Feature_Release_10.6.2_CU1
---

# General Feature Release 10.6.2 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
>   - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
>   - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)
>
> - Make sure all DataMiner Agents in the cluster have been **migrated to the BrokerGateway-managed NATS solution**. For detailed information, see [Migrating to BrokerGateway](xref:BrokerGateway_Migration). See also: [DataMiner Systems will now use the BrokerGateway-managed NATS solution by default [ID 43856] [ID 43861] [ID 44035] [ID 44050] [ID 44062]](xref:General_Feature_Release_10.6.1#dataminer-systems-will-now-use-the-brokergateway-managed-nats-solution-by-default-id-43856-id-43861-id-44035-id-44050-id-44062)
>
> - Make sure the Microsoft **.NET 10** hosting bundle is installed (download the latest Hosting Bundle under ASP.NET Core Runtime from [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)). See also: [DataMiner upgrade: New prerequisite will check whether .NET 10 is installed](xref:General_Feature_Release_10.6.1#dataminer-upgrade-new-prerequisite-will-check-whether-net-10-is-installed-id-44121).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.2](xref:Cube_Feature_Release_10.6.2).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.2](xref:Web_apps_Feature_Release_10.6.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Changes

### Fixes

#### Calls that check whether the connection between client and DMA is still alive would incorrectly be blocked when 10 simultaneous calls were being processed [ID 44456]

<!-- MR 10.5.0 [CU12] - FR 10.6.2 [CU1] -->

When 10 simultaneous calls between a client application (e.g. DataMiner Cube) and a DataMiner Agent were being processed, up to now, any additional call would be blocked, including calls that check whether the connection between client and DMA was still alive. As a result, the client application would disconnect.

From now on, even when 10 simultaneous calls between a client application (e.g. DataMiner Cube) and a DataMiner Agent are being processed, calls that check whether the connection between client and DMA is still alive will never be blocked.

#### SLDataGateway issue caused by OpenSearch health monitoring [ID 44647]

<!-- MR 10.5.0 [CU11] - FR 10.6.2 [CU1] -->

After an upgrade to DataMiner 10.6.2 [CU0], it could occur that SLSearchHealth.txt reported issues with the health monitor, and SLDataGateway could crash at startup. The changes that introduced this issue, i.e. [OpenSearch: Enhanced health monitoring [ID 43951]](xref:General_Feature_Release_10.6.2#opensearch-enhanced-health-monitoring-id-43951), have been reverted.
