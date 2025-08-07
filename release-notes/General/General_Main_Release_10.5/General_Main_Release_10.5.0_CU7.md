---
uid: General_Main_Release_10.5.0_CU7
---

# General Main Release 10.5.0 CU7 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU7](xref:Cube_Main_Release_10.5.0_CU7).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU7](xref:Web_apps_Main_Release_10.5.0_CU7).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### SLDataMiner issue after connection type of element changed [ID 43249]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a problem could occur in SLDataMiner when the connection type of an element changed. To prevent this, the validation of SNMPv3 usernames has now been improved.

#### GQI DxM: MessageBroker/SLNet not reconnected immediately after app settings change [ID 43386]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

When the app settings for the GQI DxM are modified, the MessageBroker and SLNet connection of the DxM will now be restored immediately. Previously, the reconnect only happened either after functionality attempted to access the connection or when the automatic reconnection was triggered, which happens once per minute. This will prevent the following possible issues that could previously occur:

- When GQI DxM functionality attempted to use the MessageBroker connection while it was disconnected, a deadlock situation could occur that blocked MessageBroker subscriptions.
- When you changed the GQI app settings while a reconnect was already progress, the connection could use a combination of old and new settings.

#### Failed upgrade action because of duplicate keys for SNMPv3 elements [ID 43477]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.9 -->

In some cases, it could occur that the SyncInfo file contained duplicate keys for SNMPv3 elements, which would cause upgrade actions to fail with the following error message: `UpgradeAction failed:System.ArgumentException: An item with the same key has already been added.`
