---
uid: General_Feature_Release_10.3.7
---

# General Feature Release 10.3.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.7](xref:Cube_Feature_Release_10.3.7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.3.7](xref:Web_apps_Feature_Release_10.3.7).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been added to this release yet.*

## Other features

#### DataMiner installation/upgrade: Automatic installation of DataMiner Extension Modules [ID_36085]

<!-- MR 10.4.0 - FR 10.3.7 -->

When you install or upgrade a DataMiner Agent, the following DataMiner Extension Modules (DxMs) will now automatically be installed (if not present yet):

- DataMiner ArtifactDeployer (version 1.4.5)
- DataMiner CoreGateway (version 2.12.2)
- DataMiner FieldControl (version 2.8.3)
- DataMiner Orchestrator (version 1.3.3)
- DataMiner SupportAssistant (version 1.3.2)

An upgrade action is also included that will check if the cloud endpoint hosted in CloudGateway will be reachable (TCP port 5100).

In addition, the DataMiner installer will now also add a firewall rule allowing inbound TCP port 5100 communication.

> [!NOTE]
> For detailed information on the changes included in the different versions of these DxMs, refer to the [dataminer.services change log](xref:DCP_change_log).

## Changes

### Enhancements

#### Enhanced performance when retrieving resources [ID_36129]

<!-- MR 10.3.0 [CU4] - FR 10.3.7 -->

Because of a number of enhancements, overall performance has increased when retrieving resources.

#### Failover: Obsolete CheckVIPs thread has been removed [ID_36253]

<!-- MR 10.2.0 [CU16]/10.3.0 [CU4] - FR 10.3.7 -->

In Failover setups using virtual IP addresses, once every minute the CheckVIPs thread would check whether the online Agent holds the correct IP addresses. However, due to the many locks it claimed to verify the current state of the IP addresses, it would delay other actions being executed in the system.

This obsolete thread has now been removed.

### Fixes

*No fixes yet*
