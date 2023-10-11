---
uid: General_Main_Release_10.2.0_CU21
---

# General Main Release 10.2.0 CU21 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_37267]

<!-- RN 37267: MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.11 -->

A number of security enhancements have been made.

#### DataMiner Cube: Caching enhancements [ID_37553]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

A number of general enhancements have been made with regard to cache management.

### Fixes

#### NATSCustodian could incorrectly pick an offline DMA as NAS candidate [ID_37312]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

Up to now, when NATSCustodian had to pick a NAS candidate, in some cases, it could pick a DataMiner Agent that was offline, causing an error to occur when trying to copy the credentials.

From now on, it will only be possible to trigger a NATS configuration reset when all DataMiner Agents in the cluster are online/running.

#### Updated dynamic IP address would incorrectly be applied to all connections of an element [ID_37445]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a parameter that was used to store the dynamic IP address of an element connection was updated, the dynamic IP address would incorrectly be applied to all connections of that element when the element was restarted.

#### DataMiner Cube - Alarm Console: Display issues when a correlation alarm was based on another correlation alarm [ID_37497]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When a correlation rule was based on another correlation rule, display issues could occur in the Alarm Console.

When the main correlation alarm got cleared, the base alarm would no longer be shown in the alarm tab, and when the base alarm got updated, it would be shown twice: once as the source of the other correlation alarm and once as a regular alarm.

#### PropertyChangeEvents would not be removed from the SLNet event cache when an element was deleted [ID_37576]

<!-- MR 10.2.0 [CU21]/10.3.0 [CU9] - FR 10.3.12 -->

When an element was deleted, `PropertyChangeEvent` instances for that element would incorrectly not get removed from the SLNet event cache.
