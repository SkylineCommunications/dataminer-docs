---
uid: General_Feature_Release_10.4.11
---

# General Feature Release 10.4.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.11](xref:Cube_Feature_Release_10.4.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.11](xref:Web_apps_Feature_Release_10.4.11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Failover: Virtual IP address check will now use arp commands if ping commands are not allowed [ID_40516]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

Up to now, on systems that do not allow ping commands to be executed, in some cases, the virtual IP address check would incorrectly conclude that the IP address was free and decide to claim it, causing the network interface card to malfunction due to IP addresses not being unique.

From now on, on systems that do not allow ping commands to be executed, the virtual IP address check will use arp commands instead.

### Fixes

*No fixes have been added yet.*
