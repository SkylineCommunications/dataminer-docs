---
uid: General_Feature_Release_10.6.10_CU1
---

# General Feature Release 10.6.10 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.10](xref:Cube_Feature_Release_10.6.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.10](xref:Web_apps_Feature_Release_10.6.10).
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

## Important changes

The following changes may have an impact on your system, so please make sure to check these before you upgrade:

- [DataMiner key vault [ID 44075] [ID 44349] [ID 44350] [ID 44351] [ID 44352] [ID 44353] [ID 44354] [ID 44701] [ID 44702] [ID 44911] [ID 46047] [ID 46061]](xref:General_Feature_Release_10.6.10#dataminer-key-vault-id-44075-id-44349-id-44350-id-44351-id-44352-id-44353-id-44354-id-44701-id-44702-id-44911-id-46047-id-46061)
- [Load, save, and delete actions for services have been rerouted from SLXml to the StorageModule DcM [ID 46134]](xref:General_Feature_Release_10.6.10#load-save-and-delete-actions-for-services-have-been-rerouted-from-slxml-to-the-storagemodule-dcm-id-46134)

## Changes

### Fixes

#### DataMiner services could fail to load during DataMiner startup [ID 46773]

<!-- MR 10.7.0 - FR 10.6.10 [CU1] -->
<!-- Not added to MR 10.7.0 - Introduced by RNs 46061 and 46134 -->

Since DataMiner Feature Release 10.6.10, in some cases, DataMiner services could fail to load during DataMiner startup.
