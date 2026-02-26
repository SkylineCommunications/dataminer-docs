---
uid: General_Feature_Release_10.6.3_CU1
---

# General Feature Release 10.6.3 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version:
>
> - Make sure **version 14.44.35211.0** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation. The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
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

## Changes

### Fixes

#### SLNet will no longer take into account the log level before sending a log entry to SLLog [ID 44868]

<!-- MR 10.5.0 [CU12] / 10.6.0 [CU0] - FR 10.6.3 [CU1] -->

In DataMiner Main Release 10.5.0 CU12, Main Release 10.6.0, and Feature Release 10.6.3, a change was made to make sure SLNet would only send a log entry to SLLog if the log level dictates that the entry should be logged.

This change has now been reverted as it caused SLNet to leak handles whenever a user authenticated using SAML and a new SLHelper process was started.
