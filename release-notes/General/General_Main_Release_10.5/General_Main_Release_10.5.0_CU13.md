---
uid: General_Main_Release_10.5.0_CU13
---

# General Main Release 10.5.0 CU13 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU13](xref:Cube_Main_Release_10.5.0_CU13).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU13](xref:Web_apps_Main_Release_10.5.0_CU13).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID 44579]

<!-- 44579: MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

A number of security enhancements have been made.

#### SLDataGateway: StorageTypeNotFoundException will now always mention the StorageType that could not be found [ID 44603]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLDataGateway throws a `StorageTypeNotFoundException`, from now on, the message will always mention the StorageType that could not be found.

### Fixes

#### Problem with SLNet when receiving a subscription with a large filter that contained wildcards [ID 44512]

<!-- MR 10.5.0 [CU13] / 10.6.0 [CU1] - FR 10.6.4 -->

When SLNet received a dynamic table subscription with a very large filter that contained wildcards, up to now, it would throw a stack overflow exception and stop working.

From now on, SLNet subscriptions will now be blocked when they contain a filter that exceeds 140,000 characters.
