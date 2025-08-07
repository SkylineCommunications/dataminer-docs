---
uid: General_Feature_Release_10.5.10
---

# General Feature Release 10.5.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
>
> Before you upgrade to this DataMiner version, make sure **version 14.40.33816** or higher of the **Microsoft Visual C++ x86/x64 redistributables** is installed. Otherwise, the upgrade will trigger an **automatic reboot** of the DMA in order to complete the installation.
>
> The latest version of the redistributables can be downloaded from the [Microsoft website](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170#latest-microsoft-visual-c-redistributable-version):
>
> - [vc_redist.x86.exe](https://aka.ms/vs/17/release/vc_redist.x86.exe)
> - [vc_redist.x64.exe](https://aka.ms/vs/17/release/vc_redist.x64.exe)

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.10](xref:Cube_Feature_Release_10.5.10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.10](xref:Web_apps_Feature_Release_10.5.10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### 'Webpages\Public' folder now synced between DataMiner Agents [ID 43458]

<!-- MR 10.6.0 - FR 10.5.10 -->

The folder `C:\Skyline DataMiner\Webpages\Public\` will now be synced between DataMiner Agents in a cluster. As a consequence, files that are installed in this folder can now also be included in the companion files of a DataMiner app package.

### Fixes

#### SLDataMiner issue after connection type of element changed [ID 43249]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, a problem could occur in SLDataMiner when the connection type of an element changed. To prevent this, the validation of SNMPv3 usernames has now been improved.

#### GQI DxM: MessageBroker/SLNet not reconnected immediately after app settings change [ID 43386]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

When the app settings for the GQI DxM are modified, the MessageBroker and SLNet connection of the DxM will now be restored immediately. Previously, the reconnect only happened either after functionality attempted to access the connection or when the automatic reconnection was triggered, which happens once per minute. This will prevent the following possible issues that could previously occur:

- When GQI DxM functionality attempted to use the MessageBroker connection while it was disconnected, a deadlock situation could occur that blocked MessageBroker subscriptions.
- When you changed the GQI app settings while a reconnect was already progress, the connection could use a combination of old and new settings.

#### Slow handling of concurrent requests to retrieve or update bookings [ID 43450]

<!-- MR 10.6.0 - FR 10.5.10 -->

When a lot of concurrent requests had to be processed by the Repository API in the background, e.g. to retrieve or update bookings, this could cause thread starvation in SLDataGateway, causing these requests to be handled much more slowly than usual.

#### Failed upgrade action because of duplicate keys for SNMPv3 elements [ID 43477]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 -->

In some cases, it could occur that the SyncInfo file contained duplicate keys for SNMPv3 elements, which would cause upgrade actions to fail with the following error message: `UpgradeAction failed:System.ArgumentException: An item with the same key has already been added.`
