---
uid: General_Feature_Release_10.6.12
description: "Release notes for General Feature Release 10.6.12, including prerequisites, new features, enhancements, and fixes planned for this preview release."
---

# General Feature Release 10.6.12 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.12](xref:Cube_Feature_Release_10.6.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.12](xref:Web_apps_Feature_Release_10.6.12).
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

*No important changes have been selected yet.*

## Highlights

*No highlights have been selected yet.*

## New features

## Changes

### Enhancements

#### SLLogCollector now collects additional Elasticsearch and OpenSearch cluster information [ID 46618]

<!-- MR 10.7.0 - FR 10.6.12 -->

SLLogCollector now collects additional diagnostic information from configured Elasticsearch and OpenSearch clusters, including aliases, shard health and placement, disk allocation, cluster settings, ongoing recoveries, and pending cluster tasks.

The generated package now includes the following files in the `Elastic` folder for the configured database cluster:

- `_cat.aliases.txt`
- `_cat.shards.txt`
- `_cat.allocation.txt`
- `_cluster.settings.json`
- `_cat.recovery.txt`
- `_cat.pending_tasks.txt`

### Fixes

#### SNMP GET results could be matched to the wrong polling group [ID 46507]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When multiple polling groups were executed concurrently, results from SNMP GET requests could be matched to the wrong group, potentially causing runtime errors.

The group ID is now passed along with each SNMP GET request so that the result is matched to the correct group.

#### Problem when APIGateway when shut down [ID 46619]

<!-- MR 10.7.0 - FR 10.6.12 -->

Up to now, when the APIGateway module was shut down, it would stop working unexpectedly and throw an `ObjectDisposedException`.
